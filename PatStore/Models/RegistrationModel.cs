using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatStore.Models
{
    public class RegistrationModel
    {
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public DateTime CreditCardExpiration { get; set; }
        [Required]
        public int CreditCardVerificationValue { get; set; }
        [Required]
        public string CreditCardName { get; set; }
        [Required]
        public string CreditCardAddress1 { get; set; }
        [Required]
        public string CreditCardAddress2 { get; set; }
        [Required]
        public string CreditCardCity { get; set; }
        [Required]
        public string CreditCardState { get; set; }
        [Required]
        public string CreditCardPostal { get; set; }

    }
}