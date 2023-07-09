using Course.API.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
using TekGain.DAL.ErrorHandler;
using DA = System.ComponentModel.DataAnnotations;
using RestClient = RestSharp.RestClient;
using Course.API.Repository;

namespace Course.API
{
    [TestFixture]
    public class FunctionalTest
    {
        // NOTE :
        // 1. SHOULD NOT CHANGE THE TESTCASE NAME
        // 2. iMPLEMENT THE TESTCASE AS PER THE REQUIREMENT MENTIONED THE EACH TESTCAESE

        [Test, Order(1)]
        public void Test1_TDD_Invoke_AddCourse_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'ADDCOURSE' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            var course = new Course
            {
                Id = 1,
                Name = "Cour1",
                Fee = 100,
                Rating = 4.5,
                Duration = 30,
                Type = "Typ1"
            };

            // Act
            bool result = _courseRepository.AddCourse(course);

            // Assert
            Assert.IsTrue(result);
        }

        [Test, Order(2)]
        public void Test2_TDD_Invoke_GetCourseById_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETCOURSEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            int courseId = 1;

            // Act
            Course result = _courseRepository.GetCourseById(courseId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(courseId, result.Id);
        }

        [Test, Order(3)]
        public void Test3_TDD_Invoke_GetCourseById_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETCOURSEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            int courseId = 99;

            // Act & Assert
            Assert.Throws<ServiceException>(() => _courseRepository.GetCourseById(courseId));

        }

        [Test, Order(4)]
        public void Test4_TDD_Invoke_GetRating_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETRATING' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            int courseId = 1;

            // Act
            double result = _courseRepository.GetRating(courseId);

            // Assert
            Assert.AreEqual(4.5, result);
        }

        [Test, Order(5)]
        public void Test5_TDD_Invoke_GetRating_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETRATING' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            int courseId = 99;

            // Act
            double result = _courseRepository.GetRating(courseId);

            // Assert
            Assert.AreEqual(0, result);

        }

        [Test, Order(6)]
        public void Test6_TDD_Invoke_CalculateAverageRating_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'CALCULATEAVERAGERATING' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
            int courseId = 1;
            double newRating = 3.5;

            // Act
            bool result = _courseRepository.CalculateAverageRating(courseId, newRating);

            // Assert
            Assert.IsTrue(result);
        }
    }
}	 	  	  		    	 	     	      	 	