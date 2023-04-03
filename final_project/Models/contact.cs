namespace final_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contact")]
    public partial class contact
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string message { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Required")]
        public string email { get; set; }

        [StringLength(50)]
        public string fullname { get; set; }
        

    }
}
