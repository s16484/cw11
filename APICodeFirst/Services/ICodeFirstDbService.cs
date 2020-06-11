using APICodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICodeFirst.Services
{
    public interface ICodeFirstDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public IEnumerable<Doctor> GetDoctor(int id);
        public void AddDoctor(Doctor doctor);
        public void UpdateDoctor(int id, Doctor doc);
        public void DeleteDoctor(int id);

    }
}
