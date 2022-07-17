using Catalogue.Server.Infrastructure.Interfaces;
using Catalogue.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Server.Infrastructure.DataAccess
{
    public class CourseDataAccessLayer : ICourse
    {
        readonly CatalogueDBContext _dbContext;

        public CourseDataAccessLayer(IDbContextFactory<CatalogueDBContext> dbContext)
        {
            _dbContext = dbContext.CreateDbContext();
        }

        public async Task AddCourse(Course course)
        {
            try
            {
                _dbContext.Course.Add(course);
               await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> DeleteCourse(int courseId)
        {
            try
            {
                Course? course = await _dbContext.Course.FindAsync(courseId);

                if(course is not null)
                {
                    _dbContext.Course.Remove(course);
                    await _dbContext.SaveChangesAsync();

                    return course.Title;
                }

                return String.Empty;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Course>> GetAllCourse()
        {
            return await _dbContext.Course.AsNoTracking().ToListAsync();
        }

        public async Task UpdateCourse(Course course)
        {
            try
            {
                var result = await _dbContext.Course.FirstOrDefaultAsync(e => e.Id == course.Id);

                if (result is not null)
                {
                    result.Title = course.Title;
                    result.CreditHours = course.CreditHours;
                    result.Code = course.Code;
                }

                await _dbContext.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }
    }
}
