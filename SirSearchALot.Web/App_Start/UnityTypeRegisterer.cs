using Microsoft.Practices.Unity;
using SirSearchALotBusinessLogic.IntegratedImplementations;
using SirSearchALotBusinessLogic.Interfaces;
using SirSearchALotPersistence.Repositories;
using SirSearchALotPersistence.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SirSearchALot.Web
{
    public static class UnityTypeRegisterer
    {
        public static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IPersonSearchService, PersonSearchService>();
            container.RegisterType<IPersonManagementService, PersonManagementService>();
            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<ISearchALotUnitOfWork, SearchALotUnitOfWork>();
        }
    }
}