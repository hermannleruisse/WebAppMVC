﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMVC.Models;

namespace WebAppMVC.DTO
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }

        public AuthenticateResponse(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Role = user.Role;
        }
    }
}