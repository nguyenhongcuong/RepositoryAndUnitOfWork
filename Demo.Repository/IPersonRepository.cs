using Demo.Models;

namespace Demo.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(long? id);
    }
}
