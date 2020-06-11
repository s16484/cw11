using APICodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICodeFirst.Services
{
    public class CodeFirstDbService : ICodeFirstDbService
    {
        private readonly CodeFirstDbContext _context;

        public CodeFirstDbService(CodeFirstDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetDoctor(int id)
        {
            var result = _context.Doctor
                .Where(n => n.IdDoctor == id);

            return result;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            var result = _context.Doctor
                .ToList();
            return result;
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Attach(doctor);
            _context.Add(doctor);
            _context.SaveChanges();

        }

        public void UpdateDoctor(int id, Doctor doc)
        {
            var doctor = new Doctor
            {
                IdDoctor = id,
                FirstName = doc.FirstName,
                LastName = doc.LastName,
                Email = doc.Email
            };
            _context.Attach(doctor);

            if (doc.FirstName != null)
            {
                _context.Entry(doctor).Property("FirstName").IsModified = true;
            }
            if (doc.LastName != null)
            {
                _context.Entry(doctor).Property("LastName").IsModified = true;
            }
            if (doc.Email != null)
            {
                _context.Entry(doctor).Property("Email").IsModified = true;
            }

            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = new Doctor
            {
                IdDoctor = id
            };
            _context.Attach(doctor);
            _context.Remove(doctor);
            _context.SaveChanges();
        }


    }
}
