//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentInfo()
        {
            this.OrderInfoes = new HashSet<OrderInfo>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public System.DateTime CreditCardExpiration { get; set; }
        public int CreditCardVerificationValue { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardAddress1 { get; set; }
        public string CreditCardAddress2 { get; set; }
        public string CreditCardCity { get; set; }
        public string CreditCardState { get; set; }
        public string CreditCardPostal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderInfo> OrderInfoes { get; set; }
        public virtual User User { get; set; }
    }
}