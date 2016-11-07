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
            var personDto = new PersonDTO() { FirstName = "Myname", LastName = "Friend" };


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
    }
}
