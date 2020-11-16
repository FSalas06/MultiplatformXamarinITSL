using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTestDemo.Models;

namespace UnitTestDemo.Contracts.Services
{
    public interface ICatalogDataService
    {
        Task<IEnumerable<Pie>> GetAllPiesAsync();
        Task<IEnumerable<Pie>> GetPiesOfTheWeekAsync();
    }
}
