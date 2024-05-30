using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Service
{
    public class StudentIocService:IStudentIoc
    {
        private readonly AppDbContext _context;
        public StudentIocService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _context.Students.AsNoTracking().ToListAsync();
            return students;
        }
    }
}
