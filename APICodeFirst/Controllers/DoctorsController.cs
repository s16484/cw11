using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICodeFirst.Models;
using APICodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICodeFirst.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly ICodeFirstDbService _dbservice;

        public DoctorsController(ICodeFirstDbService dbservice)
        {
            _dbservice = dbservice;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var result = _dbservice.GetDoctors();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var result = _dbservice.GetDoctor(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doc)
        {
            _dbservice.AddDoctor(doc);
            return Ok("Dodano doktora");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor([FromRoute] int id, [FromBody] Doctor doc)
        {
            _dbservice.UpdateDoctor(id, doc);
            return Ok("Aktualizacja zakończona powodzeniem");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            _dbservice.DeleteDoctor(id);
            return Ok("Usunięto doktora: " + id);
        }
    }
}
