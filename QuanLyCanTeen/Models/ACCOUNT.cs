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

    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            this.MENUs = new HashSet<MENU>();
            this.ORDERs = new HashSet<ORDER>();
            this.NOTIFICATIONs = new HashSet<NOTIFICATION>();
        }

        [Required(ErrorMessage = "Account code is required")]
        [Display(Name = "Account code")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [Display(Name = "Full name")]
        [StringLength(50, MinimumLength = 3)]
        public string FULL_NAME { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public bool STATUS { get; set; }

        [Required(ErrorMessage = "Role code is required")]
        [Display(Name = "Role code")]
        public int ROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICATION> NOTIFICATIONs { get; set; }
    }
}
