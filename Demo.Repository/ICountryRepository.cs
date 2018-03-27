using Demo.Models;

namespace Demo.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int? id);
    }
}
