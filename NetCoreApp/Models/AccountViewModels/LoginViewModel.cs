﻿using System.ComponentModel.DataAnnotations;

namespace NetCoreApp.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]       
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]        
        public bool RememberMe { get; set; }
    }
}