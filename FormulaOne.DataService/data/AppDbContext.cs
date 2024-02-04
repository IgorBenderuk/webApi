using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achivment> Achivments { get; set;}

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Achivment>()
                    .HasOne(d=>d.Driver)
                    .WithMany(a=>a.Achivments)
                    .HasForeignKey(a=>a.DriverId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("Fk_Achivments_Driver");

            }
    }
}
