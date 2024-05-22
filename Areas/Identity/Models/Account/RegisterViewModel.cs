// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FptLongChauApp.Areas.Identity.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Must enter {0}")]
        [EmailAddress(ErrorMessage = "Wrong Email Format")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Must enter {0}")]
        [StringLength(100, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repeat password")]
        [Compare("Password", ErrorMessage = "Incorrectly repeated password.")]
        public string ConfirmPassword { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Account name")]
        [Required(ErrorMessage = "Must enter {0}")]
        [StringLength(100, ErrorMessage = "{0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string UserName { get; set; }

    }
}