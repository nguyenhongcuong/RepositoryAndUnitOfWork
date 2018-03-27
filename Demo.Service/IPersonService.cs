using Demo.Models;

namespace Demo.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(int? id);
    }
}
