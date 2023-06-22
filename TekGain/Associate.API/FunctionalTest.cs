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

namespace Associate.API
{
    [TestFixture]
    public class FunctionalTest
    {
        // NOTE :
        // 1. SHOULD NOT CHANGE THE TESTCASE NAME
        // 2. iMPLEMENT THE TESTCASE AS PER THE REQUIREMENT MENTIONED THE EACH TESTCAESE
        
        [Test, Order(1)]
        public void Test1_TDD_Invoke_AddAssociate_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'ADDASSOCIATE' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(2)]
        public void Test2_TDD_Invoke_GetAssociateById_Method_ForValid()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'GETASSOCIATEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
        }

        [Test, Order(3)]
        public void Test3_TDD_Invoke_GetAssociateById_Method_ForInvalid()
        {
            // REQUIREMENT :
            // TEST THE ASSOCIATE REPOSITORY 'GETASSOCIATEBYID' PROCESS TO SEE WHETHER IT SUCCEEDS OR FAILS
            // IMPLEMENTATION IS ACCURATE OR NOT FOR VALID CASES
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
        }
    }
}