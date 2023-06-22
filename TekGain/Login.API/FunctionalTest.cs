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
using TekGain.DAL;
using TekGain.DAL.Entities;
using DA = System.ComponentModel.DataAnnotations;
using RestClient = RestSharp.RestClient;

namespace Login.API
{
    [TestFixture]
    public class FunctionalTest
    {
        // NOTE :
        // 1. SHOULD NOT CHANGE THE TESTCASE NAME
        // 2. iMPLEMENT THE TESTCASE AS PER THE REQUIREMENT MENTIONED THE EACH TESTCAESE

        [Test, Order(1)]
        public void Test1_TDD_Invoke_SignUp_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ACCOUNT REPOSITORY 'SIGNUP' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(2)]
        public void Test2_TDD_Invoke_SignUp_Method_ForExisting_Email()
        {
            // REQUIREMENT :
            // TEST THE ACCOUNT REPOSITORY 'SIGNUP' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(3)]
        public void Test3_TDD_Check_SignIn_Method_JWTToken()
        {
            // REQUIREMENT :
            // TEST THE ACCOUNT REPOSITORY 'SIGNIN' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(4)]
        public void Test4_TDD_Invoke_SignIn_Method_ForInvalid_Credentials()
        {
            // REQUIREMENT :
            // TEST THE ACCOUNT REPOSITORY 'SIGNIN' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }
    }
}