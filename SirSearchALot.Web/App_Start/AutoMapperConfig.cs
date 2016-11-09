using SirSearchALotBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SirSearchALot.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper()
        {
            //The automapper is in the BL layer so it can be shared and tested with the testing project.
            AutoMapperInitializer.Initialize();
        }
    }
}