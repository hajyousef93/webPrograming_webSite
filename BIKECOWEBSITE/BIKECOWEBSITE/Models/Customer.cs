//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIKECOWEBSITE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Rates_Comments = new HashSet<Rates_Comments>();
        }
        [Required]
        public double ID { get; set; }
        [Required]
        public string Marital_Status { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Range(5000,500000)]
        public double Income { get; set; }
        [Required]
        public double Children { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public string Home_Owner { get; set; }
        [Required]
        public double Cars { get; set; }
        [Required]
        public string Commute_Distance { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        [Range(18, 80)]
        public double Age { get; set; }
        public string Buy { get; set; }
        public string OrderNumber { get; set; }
        [Required]
        public string F_Name { get; set; }
        [Required]
        public string L_Name { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    
        public virtual Order Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rates_Comments> Rates_Comments { get; set; }
    }
}
