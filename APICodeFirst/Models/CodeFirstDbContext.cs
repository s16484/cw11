using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace APICodeFirst.Models
{
    public class CodeFirstDbContext : DbContext
    {
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public DbSet<Medicament> Medicament { get; set; }

        public CodeFirstDbContext() { }

        public CodeFirstDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(p => new
                {
                    p.IdMedicament,
                    p.IdPrescription
                });
        }


    }
}
