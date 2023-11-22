//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Converse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProDetails = new HashSet<ProDetail>();
        }
    
        public int ProID { get; set; }
        public int CatID { get; set; }
        public string ProName { get; set; }
        public string NameDecription { get; set; }
        public string ProImage { get; set; }
        public string ProImageHover { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<int> RemainQuantity { get; set; }
        public Nullable<int> DISCOUNT { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProDetail> ProDetails { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImageHover { get; set; }
    }
}
