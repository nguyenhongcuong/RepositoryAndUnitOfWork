using Demo.Models;
using Demo.Repository;

namespace Demo.Service
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        private IUnitOfWork _unitOfWork;
        private IPersonRepository _personRepository;
        public PersonService(IUnitOfWork unitOfWork, IPersonRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = repository;
        }

        public Person GetById(int? id)
        {
            return _personRepository.GetById(id);
        }
    }
}
