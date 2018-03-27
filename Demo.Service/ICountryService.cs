using Demo.Models;

namespace Demo.Service
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int? id);
    }
}
