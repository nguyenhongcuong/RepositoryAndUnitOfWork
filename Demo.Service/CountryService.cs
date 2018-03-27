using Demo.Models;
using Demo.Repository;

namespace Demo.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        private IUnitOfWork _unitOfWork;
        private ICountryRepository _countryRepository;

        public CountryService(IUnitOfWork unitOfWork, ICountryRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = repository;
        }

        public Country GetById(int? id)
        {
            return _countryRepository.GetById(id);
        }
    }
}
