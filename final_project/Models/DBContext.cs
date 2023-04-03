using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace final_project.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext2")
        {
        }

        public virtual DbSet<catalog> catalogs { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<catalog>()
                .HasMany(e => e.news)
                .WithOptional(e => e.catalog)
                .HasForeignKey(e => e.catid);
        }
    }
}
