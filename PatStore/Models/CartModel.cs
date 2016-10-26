using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatStore.Models
{
    public class CartModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        //[CreditCard]
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

        public int ProdId { get; set; }
        public int PayId { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }

        public string Location { get; set; }
    }
}