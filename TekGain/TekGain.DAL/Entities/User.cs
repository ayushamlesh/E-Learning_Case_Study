﻿using Microsoft.AspNetCore.Identity;
using System;
namespace TekGain.DAL.Entities
{
    public class User : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
