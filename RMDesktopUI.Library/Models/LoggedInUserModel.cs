﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Models
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreateDate { get; set; }

        public void ResetUser()
        {
            Token = "";
            Id = "";
            FirstName = "";
            LastName = "";
            EmailAddress = "";
            CreateDate = DateTime.MinValue;
        }
    }
}
