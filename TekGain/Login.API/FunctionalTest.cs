using Login.API.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using TekGain.DAL;
using TekGain.DAL.Entities;
using DA = System.ComponentModel.DataAnnotations;
using RestClient = RestSharp.RestClient;



namespace Login.API
{
    [TestFixture]
    public class FunctionalTest
    {
        private AccountRepository _accountRepository;
        private Mock<UserManager<User>> _userManagerMock;
        private Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private Mock<IConfiguration> _configurationMock;
        private Mock<ILogger<AccountRepository>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _userManagerMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
            _configurationMock = new Mock<IConfiguration>();
            _loggerMock = new Mock<ILogger<AccountRepository>>();

            _accountRepository = new AccountRepository(
                _userManagerMock.Object,
                _roleManagerMock.Object,
                _configurationMock.Object,
                _loggerMock.Object);
        }

        [Test, Order(1)]
        public async Task Test1_TDD_Invoke_SignUp_Method_ForValid()
        {
            // Arrange
            var signUpObj = new SignUp
            {
                FirstName = "a",
                LastName = "K",
                Email = "ak@example.com",
                Password = "Ayush@11",
                ConfirmPassword = "Ayush@11"

            };

            _userManagerMock.Setup(m => m.FindByEmailAsync(signUpObj.Email)).ReturnsAsync((User)null);
            _userManagerMock.Setup(m => m.CreateAsync(It.IsAny<User>(), signUpObj.Password)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _accountRepository.SignUp(signUpObj);

            // Assert
            Assert.AreEqual(IdentityResult.Success, result);
        }

        [Test, Order(2)]
        public async Task Test2_TDD_Invoke_SignUp_Method_ForExisting_Email()
         {
            // Arrange
            var signUpObj = new SignUp
            {
                FirstName = "a",
                LastName = "K",
                Email = "ak@example.com",
                Password = "Ayush@11",
                ConfirmPassword = "Ayush@11"
            };
            var existingUser = new User { Email = signUpObj.Email };
            _userManagerMock.Setup(u => u.FindByEmailAsync(signUpObj.Email))
                .ReturnsAsync(existingUser);

            // Act
            var result = await _accountRepository.SignUp(signUpObj);

            // Assert
            Assert.IsFalse(result.Succeeded);
        }

        [Test, Order(3)]
        public async Task Test3_TDD_Check_SignIn_Method_JWTToken()
        {
            // Arrange
            var signInObj = new SignIn
            {

                Email = "ak@example.com",
                Password = "Ayush@11"
            };

            var user = new User { Email = signInObj.Email };
            var userRoles = new List<string> { "User" };
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            userRoles.ForEach(role => authClaims.Add(new Claim(ClaimTypes.Role, role)));

            _userManagerMock.Setup(m => m.FindByEmailAsync(signInObj.Email)).ReturnsAsync(user);
            _userManagerMock.Setup(m => m.CheckPasswordAsync(user, signInObj.Password)).ReturnsAsync(true);
            _userManagerMock.Setup(m => m.GetRolesAsync(user)).ReturnsAsync(userRoles);

            _configurationMock.Setup(c => c["JWT:Secret"]).Returns("sample-jwt-secret");
            _configurationMock.Setup(c => c["JWT:ValidIssuer"]).Returns("sample-issuer");
            _configurationMock.Setup(c => c["JWT:ValidAudience"]).Returns("sample-audience");

            // Act
            var result = await _accountRepository.SignIn(signInObj);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual("Incorrect Email/Password", result);
        }

        [Test, Order(4)]
        public async Task Test4_TDD_Invoke_SignIn_Method_ForInvalid_Credentials()
        {
            // Arrange
            var signInObj = new SignIn
            {
                Email = "ak@example.com",
                Password = "Ayush@11"
            };

            _userManagerMock.Setup(m => m.FindByEmailAsync(signInObj.Email)).ReturnsAsync((User)null);

            // Act
            var result = await _accountRepository.SignIn(signInObj);

            // Assert
            Assert.AreEqual("Incorrect Email/Password", result);
        }
    }
}
