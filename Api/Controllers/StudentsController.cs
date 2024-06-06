using Api.Common;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController:ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents(){
            var students = await _context.Students.AsNoTracking().ToListAsync();
            return students;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var existStudent = await _context.Students.FindAsync(student.Id);

            if (existStudent == null){
                await _context.AddAsync(student);
                var result = await _context.SaveChangesAsync();
                if (result > 0){
                    return Ok();
                }
            }else{
                return BadRequest("ID already exists");
            }
            return BadRequest();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id){
            var student = await _context.Students.FindAsync(id);
            if(student is null){
                return NotFound();
            }
            return Ok(student);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id){
            var student = await _context.Students.FindAsync(id);
            if(student is null){
                return NotFound();
            }
            _context.Remove(student);
            var result = await _context.SaveChangesAsync();
            if(result > 0){
                return Ok("Student deleted");
            }
            return BadRequest("Unable to delete student");
        }   
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditStudent(int id, Student student){
            var studentFromDb = await _context.Students.FindAsync(id);
            if(studentFromDb is null){
                return BadRequest("Student Not found");
            }
            studentFromDb.Name = student.Name;
            studentFromDb.Address = student.Address;
            studentFromDb.Email = student.Email;
            studentFromDb.PhoneNumber = student.PhoneNumber;

            var result = await _context.SaveChangesAsync();
            if(result > 0){
                return Ok("Student Sucessfully updated");
            }
            return BadRequest("Unable to updated student");
        }

        // FromForm無法直接解析Json字串(value)至對應的類別物件，可以透過JsonSerializer.Deserialize解析
        // 為了不每個程式都寫JsonSerializer.Deserialize，將解析方法寫在FormDataJsonBinder裡面
        // FormBody可以直接解析Json字串(value)至對應的類別物件
        [HttpPost("FormDataJsonBinder")]
        public void PostFormDataJsonBinder([FromForm][ModelBinder(BinderType =typeof(FormDataJsonBinder))] Student value) { 
        
            

        }
    }
}