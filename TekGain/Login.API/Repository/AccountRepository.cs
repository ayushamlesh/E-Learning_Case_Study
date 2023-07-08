using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TekGain.DAL.Entities;

namespace Login.API.Repository
{

    public class AccountRepository : IAccountRepository
    {
        // Implement the code here
        private readonly UserManager<User> _um;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly ILogger<AccountRepository> _logger;
        private readonly IConfiguration _configuration;
        public AccountRepository(UserManager<User> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration, ILogger<AccountRepository> logger)
        {
            _um = usermanager;
            _rm = rolemanager;
            _logger = logger;
            _configuration = configuration;
        }
        public static class UserRole
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
        public async Task<IdentityResult> SignUp(SignUp signUpObj)
        {
            var userExists = await _um.FindByEmailAsync(signUpObj.Email);
            if (userExists != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email already exists" });
            }

            User user = new()
            {
                Email = signUpObj.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUpObj.Email,
                FirstName = signUpObj.FirstName,
                LastName = signUpObj.LastName,
            };

            var CreateUserResult = await _um.CreateAsync(user, signUpObj.Password);
            if (!CreateUserResult.Succeeded)
            {
                return IdentityResult.Failed();
            }
           
            /*if (!await _rm.RoleExistsAsync(UserRole.User))
            {
                await _rm.CreateAsync(new IdentityRole(UserRole.User));
            }

            if (await _rm.RoleExistsAsync(UserRole.User))
            {
                await _um.AddToRoleAsync(user, UserRole.User);
            }
            */

            //for admin
            if (!await _rm.RoleExistsAsync(UserRole.Admin))
            {
                await _rm.CreateAsync(new IdentityRole(UserRole.Admin));
            }

            if (await _rm.RoleExistsAsync(UserRole.Admin))
            {
                await _um.AddToRoleAsync(user, UserRole.Admin);
            }
            //end admin

            _logger.LogInformation($"{DateTime.Now} INFO: Registration completed for {signUpObj.Email}");

            return IdentityResult.Success;

        }

        public async Task<string> SignIn(SignIn signInObj)
        {
            var user = await _um.FindByEmailAsync(signInObj.Email);
            if (user == null)
            {
                _logger.LogWarning($"{DateTime.Now} WAR: Sign failed : {signInObj.Email}");
                return "Incorrect Email/Password";
            }
            if (!await _um.CheckPasswordAsync(user, signInObj.Password))
            {
                _logger.LogWarning($"{DateTime.Now} WAR: Sign failed : {signInObj.Email}");
                return "Incorrect Email/Password";
            }

            var userRoles = await _um.GetRolesAsync(user);
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            _logger.LogInformation($"{DateTime.Now} INFO: Sign success {signInObj.Email}");
            return token;
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}