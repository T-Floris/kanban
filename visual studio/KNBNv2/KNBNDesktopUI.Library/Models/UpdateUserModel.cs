﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Models
{
    public class UpdateUserModel
    {
        [Required]
        [DisplayName("Id")]
        public string Id 
        { 
            get; set; 
        }

        [Required]
        [DisplayName("First Name")]
        public string FirstName
        {
            get; set;
        }

        [Required]
        [DisplayName("Last Name")]
        public string LastName
        {
            get; set;
        }

        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress
        {
            get; set;
        }

        [Required]
        [DisplayName("User name")]
        public string UserName
        {
            get; set;
        }


        [Required]
        [DisplayName("Password")]
        public string Password
        {
            get; set;
        }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword
        {
            get; set;
        }
    }
}
