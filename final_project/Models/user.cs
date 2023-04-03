namespace final_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            news = new HashSet<news>();
        }

        public int id { get; set; }

        [StringLength(100)]
        [Display(Name ="User Name")]
        [Required(ErrorMessage = "Required")]
        public string username { get; set; }

        [StringLength(120)]
        [Display(Name = "User E-mail")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "invalid Email")]
        public string email { get; set; }

        [StringLength(80)]
        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Required")]
        public string userpassword { get; set; }
        [NotMapped]
        [Display(Name ="Confirm Password")]
        [Compare("userpassword",ErrorMessage ="Not Match")]
        public string confirmpassword { get; set; }

        [Range(20,60,ErrorMessage ="Out Of Range")]
        public int? age { get; set; }

        public string useraddress { get; set; }

        [StringLength(250)]
        public string photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news { get; set; }
    }
}
