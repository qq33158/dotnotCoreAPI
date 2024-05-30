using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentIocController : ControllerBase
    {
        private readonly IStudentIoc _studentIoc;

        public StudentIocController(IStudentIoc studentIoc)
        {
            _studentIoc = studentIoc;
        }


        // GET: api/<StudentIocController>
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentIoc.GetStudents();
        }

    }
}
