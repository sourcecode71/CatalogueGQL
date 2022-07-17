using Catalogue.Shared.Models;

namespace Catalogue.Server.Infrastructure.Interfaces
{
    public interface ICourse
    {

        Task AddCourse(Course course);

        Task<List<Course>> GetAllCourse();

        Task UpdateCourse(Course course);

        Task<string> DeleteCourse(int courseId);
    }
}
