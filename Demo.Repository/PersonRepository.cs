using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Demo.Models;

namespace Demo.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Person> GetAll()
        {
            return _entities.Set<Person>().Include(x => x.Country).AsEnumerable();
        }

        public Person GetById(long? id)
        {
            return _dbSet.Include(x => x.Country).FirstOrDefault(x => x.Id == id);
        }
    }
}
