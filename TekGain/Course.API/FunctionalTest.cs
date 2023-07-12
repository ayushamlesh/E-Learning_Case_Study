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
         


        }

        [Test, Order(3)]
        public void Test3_TDD_Invoke_GetCourseById_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETCOURSEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
          




        }

        [Test, Order(4)]
        public void Test4_TDD_Invoke_GetRating_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE COURSE REPOSITORY 'GETRATING' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
            // Arrange
           
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