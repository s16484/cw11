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

            modelBuilder.Entity<Doctor>((builder) =>
            {
                builder.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Andrzej", LastName = "Kowalski", Email = "adrzej@gmail.com" },
                    new Doctor { IdDoctor = 2, FirstName = "Katarzyna", LastName = "Nowak", Email = "katarzyna@gmail.com" }
                    );
            });

            modelBuilder.Entity<Medicament>((builder) =>
            {
                builder.HasData(
                    new Medicament { IdMedicament = 1, Name = "Med1", Description = "Description - med1", Type = "type1" },
                    new Medicament { IdMedicament = 2, Name = "Med2", Description = "Description - med2", Type = "type2" }
                    );
            });

            modelBuilder.Entity<Patient>((builder) =>
            {
                builder.HasData(
                    new Patient { IdPatient = 1, FirstName = "Paweł", LastName = "Piotrowski", Birthdate = DateTime.Parse("1993-03-30") },
                    new Patient { IdPatient = 2, FirstName = "Piotr", LastName = "Pawlak", Birthdate = DateTime.Parse("1990-03-30") }
                    );
            });
            modelBuilder.Entity<Prescription>((builder) =>
            {
                builder.HasData(
                    new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 1, IdDoctor = 1 },
                    new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30), IdPatient = 2, IdDoctor = 1 }
                    );
            });

            modelBuilder.Entity<Prescription_Medicament>((builder) =>
            {
                builder.HasKey(p => new
                {
                    p.IdMedicament,
                    p.IdPrescription
                });

                //builder.HasOne<Medicament>()
                //    .WithMany()
                //    .HasForeignKey(n => n.IdMedicament)
                //    .IsRequired();
                //builder.HasOne<Prescription>()
                //    .WithMany()
                //    .HasForeignKey(n => n.IdPrescription)
                //    .IsRequired();
                //builder.Property(n => n.Details)
                //.HasMaxLength(100)
                //.IsRequired();

                builder.HasData(
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 100, Details = "abc" },
                    new Prescription_Medicament { IdMedicament = 1, IdPrescription = 2, Dose = 154, Details = "cba" }
                );

            });


        }


    }
}
