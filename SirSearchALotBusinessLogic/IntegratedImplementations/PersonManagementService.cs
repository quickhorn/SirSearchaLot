using SirSearchALotBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SirSearchALotBusinessLogic.Models;
using SirSearchALotPersistence.UnitsOfWork;
using AutoMapper;
using SirSearchALotPersistence;

namespace SirSearchALotBusinessLogic.IntegratedImplementations
{
    public class PersonManagementService : IPersonManagementService
    {
        public PersonManagementService(ISearchALotUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private ISearchALotUnitOfWork _unitOfWork;

        public AddPersonResponse AddPerson(PersonDTO person)
        {
            try
            {
                var entityPerson = Mapper.Map<Person>(person);
                _unitOfWork.Persons.AddPerson(entityPerson);
                return new AddPersonResponse() { Success = true, PersonId = entityPerson.PersonId };
            }
            catch (Exception e)
            {
                //Log here if we get the time
                return new AddPersonResponse() { Message = "Failure adding person. " + e.Message, Success = false };
            }
        }
    }
}
