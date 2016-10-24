using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatStore.Models
{
    public class LoginModel
    {
        [Required]     
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(32)]
        public string Password { get; set; }          
    }
}