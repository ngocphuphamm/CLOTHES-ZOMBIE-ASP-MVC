//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
/// <summary>
/// 
/// </summary>
namespace ClothesWebNET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailBIll
    {
        public string idDetailBill { get; set; }
        public string idProduct { get; set; }
        public string idBill { get; set; }
        public int qty { get; set; }
        public double intoMoney { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
