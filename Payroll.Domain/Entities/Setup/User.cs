﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Entities.Setup
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // This should be encrypted in production
        public string Role { get; set; }       // Optional: Role-based authorization
        public string Email { get; set; }
        public bool IsActive { get; set; }// Optional: User email
    }
}
