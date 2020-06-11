using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICodeFirst.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly CodeFirstDbContext _context;

        public DoctorsController(CodeFirstDbContext context)
        {
            _context = context;
        }


    }
}
