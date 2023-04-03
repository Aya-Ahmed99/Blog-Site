namespace final_project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        public int id { get; set; }

        [StringLength(550)]
        [Display(Name ="New Title")]
        public string title { get; set; }

        [StringLength(550)]
        [Display(Name = "New Summary")]
        public string bref { get; set; }
        [Display(Name = "New Description")]
        public string newdesc { get; set; }

        [StringLength(550)]
        public string photo { get; set; }
        public DateTime? newdate { get; set; }

        public int? catid { get; set; }

        public int? userid { get; set; }

        public virtual catalog catalog { get; set; }

        public virtual user user { get; set; }
    }
}
