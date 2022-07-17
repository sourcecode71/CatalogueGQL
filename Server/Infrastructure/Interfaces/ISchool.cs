using Catalogue.Shared.Models;

namespace Catalogue.Server.Infrastructure.Interfaces
{
    public interface ISchool
    {
        Task<School> CreateSchool(School school);
        Task<School> UpdateSchool(School school);
        Task<School>GetSchool(int id);
        Task<int>DeleteSchool(int id);
        IQueryable<School>GetSchools();
    }
}
