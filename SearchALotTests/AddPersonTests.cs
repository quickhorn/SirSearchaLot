using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SirSearchALotPersistence.UnitsOfWork;
using SirSearchALotPersistence;
using SirSearchALotBusinessLogic.IntegratedImplementations;
using SirSearchALotBusinessLogic.Models;
using SirSearchALotBusinessLogic;

namespace SearchALotTests
{
    [TestClass]
    public class AddPersonTests
    {
        public AddPersonTests()
        {
            AutoMapperInitializer.Initialize();
        }

        [TestMethod]
        public void TestAddSuccessful()
        {
            //setup
            var mUnitOfWork = new Mock<ISearchALotUnitOfWork>();
            mUnitOfWork.Setup(f => f.Persons.AddPerson(It.IsAny<Person>()));

            var personManagementService = new PersonManagementService(mUnitOfWork.Object);
            var personDto = new PersonDTO() { FirstName = "Myname", LastName = "Friend", City = "Cityssss", ImageUrl = "image.gif", State = "UT", StreetAddress = "MyAddress", ZipCode = "84444" };


            //action
            var response = personManagementService.AddPerson(personDto);

            //assert
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public void TestMissingFirstName()
        {
            //setup
            var mUnitOfWork = new Mock<ISearchALotUnitOfWork>();
            mUnitOfWork.Setup(f => f.Persons.AddPerson(It.IsAny<Person>()));

            var personManagementService = new PersonManagementService(mUnitOfWork.Object);
            var personDto = new PersonDTO() { LastName = "Friend" };


            //action
            var response = personManagementService.AddPerson(personDto);

            //assert
            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public void TestMissingLastName()
        {
            //setup
            var mUnitOfWork = new Mock<ISearchALotUnitOfWork>();
            mUnitOfWork.Setup(f => f.Persons.AddPerson(It.IsAny<Person>()));

            var personManagementService = new PersonManagementService(mUnitOfWork.Object);
            var personDto = new PersonDTO() { FirstName = "MyName" };


            //action
            var response = personManagementService.AddPerson(personDto);

            //assert
            Assert.IsFalse(response.Success);
        }


        [TestMethod]
        public void TestMissingAddress()
        {
            var mUnitOfWork = new Mock<ISearchALotUnitOfWork>();
            mUnitOfWork.Setup(f => f.Persons.AddPerson(It.IsAny<Person>()));

            var personManagementService = new PersonManagementService(mUnitOfWork.Object);

            var personDtoMissingCity = new PersonDTO() { FirstName = "MyName", LastName = "LastName", State = "UT", StreetAddress = "45", ZipCode = "45345", ImageUrl = "image.gif" };
            var response = personManagementService.AddPerson(personDtoMissingCity);
            Assert.IsFalse(response.Success);

            var personDtoMissingState = new PersonDTO() { FirstName = "MyName", LastName = "LastName", StreetAddress = "45", City = "Cityzz", ZipCode = "45345", ImageUrl = "image.gif" };
            response = personManagementService.AddPerson(personDtoMissingState);
            Assert.IsFalse(response.Success);

            var personDtoMissingStreetAddress = new PersonDTO() { FirstName = "MyName", LastName = "LastName", State = "UT", City = "Cityzz", ZipCode = "45345", ImageUrl = "image.gif" };
            response = personManagementService.AddPerson(personDtoMissingStreetAddress);
            Assert.IsFalse(response.Success);

            var personDtoMissingZip = new PersonDTO() { FirstName = "Myname", LastName = "Friend", City = "Cityssss", ImageUrl = "image.gif", State = "UT", StreetAddress = "MyAddress" };
            response = personManagementService.AddPerson(personDtoMissingZip);
            Assert.IsFalse(response.Success);
        }


        [TestMethod]
        public void TestMissingImageUrl()
        {
            var mUnitOfWork = new Mock<ISearchALotUnitOfWork>();
            mUnitOfWork.Setup(f => f.Persons.AddPerson(It.IsAny<Person>()));

            var personManagementService = new PersonManagementService(mUnitOfWork.Object);

            var personDto = new PersonDTO() { FirstName = "Myname", LastName = "Friend", City = "Cityssss", State = "UT", StreetAddress = "MyAddress", ZipCode = "84444" };
            var response = personManagementService.AddPerson(personDto);
            Assert.IsFalse(response.Success);
        }
    }
}
