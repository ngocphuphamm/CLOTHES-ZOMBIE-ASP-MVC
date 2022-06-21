namespace ClothesWebNET.Models
{
    using System;
    using System.Collections.Generic;
    public class BillData
    {
        public string idBill { get; set; }
        public string idUser { get; set; }
        public string nameUser { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int address { get; set; }
        public int Ship { get; set; }
        public int Total { get; set; }
        public string PTTT { get; set; }
        public bool status { get; set; }
        public System.DateTime createdAt { get; set; }
        public int Qty { get; set;  }

    }

    public class ItemDetail
    {
        //thông tin trong b?ng Bill
        public string nameBook { get; set; }
        public string idBill { get; set; }
        public string phone { set; get; }
        public string address { get; set; }
        public int Total { get; set; }

        //thông tin trong b?ng DetailBill
        public string nameProduct { get; set; }
        public string idProduct { get; set; }
        public int qty { set; get; }
        public double price { get; set; }
        public int intoMoney { get; set; }
        public string idDetailBill { get; set; }


    }
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.DetailBIlls = new HashSet<DetailBIll>();
        }

        public string idBill { get; set; }
        public string idUser { get; set; }
        public int Shipping { get; set; }
        public int Total { get; set; }
        public string PTTT { get; set; }
        public bool status { get; set; }
        public System.DateTime createdAt { get; set; }
        public int totalQty { get; set; }
        public string nameBook { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBIll> DetailBIlls { get; set; }
    }
}