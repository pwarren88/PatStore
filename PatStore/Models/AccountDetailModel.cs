using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatStore.Models
{
    public class AccountDetailModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(7)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}