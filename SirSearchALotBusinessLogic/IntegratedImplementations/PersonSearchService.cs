using SirSearchALotBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SirSearchALotBusinessLogic.Models;
using SirSearchALotPersistence.UnitsOfWork;
using AutoMapper;

namespace SirSearchALotBusinessLogic.IntegratedImplementations
{
    public class PersonSearchService : IPersonSearchService
    {
        public PersonSearchService(ISearchALotUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private ISearchALotUnitOfWork _unitOfWork;

        public List<PersonDTO> SearchPersons(string search)
        {
            var results = _unitOfWork.Persons.SearchPersons(search);
            var dtoResults = Mapper.Map<List<PersonDTO>>(results);
            return dtoResults;
        }
    }
}
