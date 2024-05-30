using Api.Models;

namespace Api.Interfaces
{
    public interface IStudentIoc
    {
        Task<IEnumerable<Student>> GetStudents();
    }
}
