﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCIS.WebApi.Models
{
    public class UserModel
    {
        public List<User> UserList { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}