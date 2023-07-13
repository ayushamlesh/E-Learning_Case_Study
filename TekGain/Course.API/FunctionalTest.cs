using Course.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TekGain.DAL;
using TekGain.DAL.Entities;
using TekGain.DAL.ErrorHandler;


namespace Course.API
{

    [TestFixture]
    public class FunctionalTest
    {
        // NOTE :
        // 1. SHOULD NOT CHANGE THE TESTCASE NAME
         private Mock<ICourseRepository> _courseRepositoryMock;
        private ILogger<CourseRepository> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _loggerMock = Mock.Of<ILogger<CourseRepository>>();
        }
        // 2. iMPLEMENT THE TESTCASE AS PER THE REQUIREMENT MENTIONED THE EACH TESTCAESE



        [Test, Order(1)]
        public void Test1_TDD_Invoke_AddCourse_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'ADDCOURSE' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
          

        }

        [Test, Order(2)]
        public void Test2_TDD_Invoke_GetCourseById_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETCOURSEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            var course = new TekGain.DAL.Entities.Course { Id = 1 };

            _courseRepositoryMock.Setup(repo => repo.GetCourseById(1)).Returns(course);
            var courseController = new CourseController(_courseRepositoryMock.Object);

            // Act
            var result = courseController.GetCourseById(1);

            // Assert
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(course, ((OkObjectResult)result).Value);
         


        }

        [Test, Order(3)]
        public void Test3_TDD_Invoke_GetCourseById_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETCOURSEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
           _courseRepositoryMock.Setup(repo => repo.GetCourseById(111)).Throws(new ServiceException("Invalid Course Id"));
            var courseController = new CourseController(_courseRepositoryMock.Object);

            // Act
            var result = courseController.GetCourseById(111);

            // Assert
            Assert.IsTrue(result is BadRequestObjectResult);





        }

        [Test, Order(4)]
        public void Test4_TDD_Invoke_GetRating_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETRATING' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            int courseId = 1;
            var rating = 4.5;
            _courseRepositoryMock.Setup(repo => repo.GetRating(courseId)).Returns(rating);
            var courseController = new CourseController(_courseRepositoryMock.Object);

            // Act
            var result = courseController.GetRating(courseId);

            // Assert
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(rating, ((OkObjectResult)result).Value);
           
        }

        [Test, Order(5)]
        public void Test5_TDD_Invoke_GetRating_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETRATING' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
           

        }

        [Test, Order(6)]
        public void Test6_TDD_Invoke_CalculateAverageRating_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'CALCULATEAVERAGERATING' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
          
        }
    }
}	 	  	  		    	 	     	      	 	