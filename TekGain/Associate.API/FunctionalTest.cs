using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using TekGain.DAL;
using TekGain.DAL.Entities;
using DA = System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using RestClient = RestSharp.RestClient;
using Associate.API.Repository;
using NUnit.Framework.Internal;
using TekGain.DAL.ErrorHandler;
using System.Linq;
using Associate.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Associate.API
{
    [TestFixture]
    public class FunctionalTest
    {
        // NOTE :
        // 1. SHOULD NOT CHANGE THE TESTCASE NAME
        private Mock<IAssociateRepository> _associateRepositoryMock;
        private ILogger<AssociateRepository> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _associateRepositoryMock = new Mock<IAssociateRepository>();
            _loggerMock = Mock.Of<ILogger<AssociateRepository>>();
        }

        // 2. iMPLEMENT THE TESTCASE AS PER THE REQUIREMENT MENTIONED THE EACH TESTCAESE

        [Test, Order(1)]
        public void Test1_TDD_Invoke_AddAssociate_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'ADDASSOCIATE' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
 



        }

        [Test, Order(2)]
        public void Test2_TDD_Invoke_GetAssociateById_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'GETASSOCIATEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            var associate = new TekGain.DAL.Entities.Associate { Id = 1 };

            _associateRepositoryMock.Setup(repo => repo.GetAssociateById(1)).Returns(associate);
            var associateController = new AssociateController(_associateRepositoryMock.Object);

            // Act
            var result = associateController.GetAssociateById(1);

            // Assert
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(associate, ((OkObjectResult)result).Value);



        }

        [Test, Order(3)]
        public void Test3_TDD_Invoke_GetAssociateById_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'GETASSOCIATEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            _associateRepositoryMock.Setup(repo => repo.GetAssociateById(1)).Throws(new ServiceException("Invalid Associate Id"));
            var associateController = new AssociateController(_associateRepositoryMock.Object);

            // Act
            var result = associateController.GetAssociateById(1);

            // Assert
            Assert.IsTrue(result is BadRequestObjectResult);


        }
    

        [Test, Order(4)]
        public void Test4_TDD_Invoke_UpdateAssociateAddress_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'UPDATEASSOCIATEADDRESS' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            

        }

        [Test, Order(5)]
        public void Test5_TDD_Invoke_GetAllAssociate_Method()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'GETALLASSOCIATE' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            var associates = new List<TekGain.DAL.Entities.Associate> { new TekGain.DAL.Entities.Associate(), new TekGain.DAL.Entities.Associate() };

            _associateRepositoryMock.Setup(repo => repo.GetAllAssociate()).Returns(associates);
            var associateController = new AssociateController(_associateRepositoryMock.Object);

            // Act
            var result = associateController.GetAllAssociate();

            // Assert
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(associates, ((OkObjectResult)result).Value);
        }
    }
}




