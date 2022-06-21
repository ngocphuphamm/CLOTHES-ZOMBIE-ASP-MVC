namespace ClothesWebNET.Models
{
    using System;
    using System.Collections.Generic;
    public class ProductDTODetail
    {
        public string idProduct { get; set; }
        public string type { get; set; }
        public string nameProduct { get; set; }
        public double price { get; set; }
        public string URLImage { get; set; }
        public int sizeM { get; set; }
        public int sizeL { get; set; }
        public int sizeXL { get; set;  }

    }

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.DetailBIlls = new HashSet<DetailBIll>();
            this.ImageProducts = new HashSet<ImageProduct>();
        }

        public string nameProduct { get; set; }
        public string idProduct { get; set; }
        public int sizeM { get; set; }
        public int sizeL { get; set; }
        public int sizeXL { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string idType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailBIll> DetailBIlls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }
        public virtual Type Type { get; set; }
    }
}