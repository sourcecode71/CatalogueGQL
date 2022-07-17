using Catalogue.Server.Infrastructure.Interfaces;
using Catalogue.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Server.Infrastructure.DataAccess
{
    public class SchoolDataAccessLayer : ISchool
    {
        private readonly CatalogueDBContext _dbContext;

        public SchoolDataAccessLayer(IDbContextFactory<CatalogueDBContext> dbContext)
        {
            _dbContext = dbContext.CreateDbContext();
        }
      
        public async Task<School> CreateSchool(School school)
        {
            _dbContext.School.Add(school);
            await _dbContext.SaveChangesAsync();
            return school;
        }
        public async Task<School> GetSchool(int id)
        {
            School ? school = await _dbContext.School.FindAsync(id);
            if(school is null)
            {
                return new School();
            }
            else
            {
                return school;
            }
        }

        public IQueryable<School> GetSchools()
        {
            return  _dbContext.School;
        }

        public async Task<int> DeleteSchool(int id)
        {
            School? vSchool = await _dbContext.School.FindAsync(id);

            if (vSchool is not null)
            {
                vSchool.IsDeleted=true;
                await _dbContext.SaveChangesAsync();

                return vSchool.Id;
            }

            return 0;
        }

        public async Task<School> UpdateSchool(School school)
        {
            try
            {
                School? vSchool = await _dbContext.School.FindAsync(school.Id);

                if(vSchool is not null)
                {
                    vSchool.Title=school.Title;
                    vSchool.Name=school.Name;
                    await  _dbContext.SaveChangesAsync();

                    return vSchool;
                }
                else
                {
                  return  new School();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
