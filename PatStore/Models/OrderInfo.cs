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
    
    public partial class OrderInfo
    {
        public int Id { get; set; }
        public int ProdId { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal Total { get; set; }
    
        public virtual PaymentInfo PaymentInfo { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
