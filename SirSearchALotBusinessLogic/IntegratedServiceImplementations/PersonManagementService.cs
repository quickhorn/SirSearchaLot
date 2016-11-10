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
                //This validation could be better in the DTO and using ModelState.
                if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
                {
                    return new AddPersonResponse() { Message = "Missing Argument. First and last name must be included for a person. For single named persons, use that name twice (E.g. Cher Cher)", Success = false };
                }
                if (string.IsNullOrEmpty(person.City) || string.IsNullOrEmpty(person.StreetAddress) || string.IsNullOrEmpty(person.State) || person.State.Length != 2 || string.IsNullOrEmpty(person.ZipCode))
                {
                    return new AddPersonResponse() { Message = "Address is incorrect. Please include an address.", Success = false };
                }
                if (person.State.Length != 2)
                {
                    return new AddPersonResponse() { Message = "State can only be a length of 2", Success = false };
                }
                if (string.IsNullOrEmpty(person.ImageUrl))
                {
                    return new AddPersonResponse() { Message = "Please include an image url.", Success = false };
                }
                //add other validation here for state, zip, and address and imgurl.
                var entityPerson = Mapper.Map<Person>(person);
                _unitOfWork.Persons.AddPerson(entityPerson);
                return new AddPersonResponse() { Success = true, PersonId = entityPerson.PersonId };
            }
            catch (Exception e)
            {
                //Log here if we get the time
                return new AddPersonResponse() { Message = "Exceptional Failure adding person. " + e.Message, Success = false };
            }
        }
    }
}
