using Admission.API.Repository;
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
using TekGain.DAL.ErrorHandler;
using DA = System.ComponentModel.DataAnnotations;
using RestClient = RestSharp.RestClient;

namespace Admission.API
{
    [TestFixture]
    public class FunctionalTest
    {
        // NOTE :
        // 1. SHOULD NOT CHANGE THE TESTCASE NAME
        // 2. iMPLEMENT THE TESTCASE AS PER THE REQUIREMENT MENTIONED THE EACH TESTCAESE

       
        [Test, Order(1)]
        public void Test1_TDD_Invoke_CalculateFees_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ADMISSION REPOSITORY 'CALCULATEFEES' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(2)]
        public void Test2_TDD_Invoke_CalculateFees_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE ADMISSION REPOSITORY 'CALCULATEFEES' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(3)]
        public void Test3_TDD_Invoke_HighestFee_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ADMISSION REPOSITORY 'HIGHESTFEE' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(4)]
        public void Test4_TDD_Invoke_HighestFee_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ADMISSION REPOSITORY 'HIGHESTFEE' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(5)]
        public void Test5_TDD_Invoke_ViewFeedbackByCourseId_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ADMISSION REPOSITORY 'VIEWFEEDBACKBYCOURSEID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(6)]
        public void Test6_TDD_Invoke_ViewFeedbackByCourseId_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE ADMISSION REPOSITORY 'VIEWFEEDBACKBYCOURSEID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(7)]
        public void Test7_TDD_Invoke_GetAllRegistration_Method()
        {
            // REQUIREMENT :
            // TEST THE ADMISSION REPOSITORY 'GETALLREGISTRATION' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }
    }
}
