//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCanTeen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            this.NOTIFICATIONs = new HashSet<NOTIFICATION>();
            this.ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }

        [Required(ErrorMessage = "Order code is required")]
        [Display(Name = "Order code")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Order code is required")]
        [Display(Name = "Order code")]
        public string ORDER_CODE { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DATE { get; set; }

        [Required(ErrorMessage = "Account code is required")]
        [Display(Name = "Account code")]
        public Nullable<int> ACCOUNT_ID { get; set; }

        [Display(Name = "Customer code")]
        [Required(ErrorMessage = "Customer code is required")]
        public int CUSTOMER_ID { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        public int STATUS { get; set; }

        [Display(Name = "FeedBack")]
        [Required(ErrorMessage = "FeedBack is required")]
        public string FEEDBACK { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}
