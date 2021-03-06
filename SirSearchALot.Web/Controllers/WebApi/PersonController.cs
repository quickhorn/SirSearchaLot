﻿using SirSearchALotBusinessLogic.Interfaces;
using SirSearchALotBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace SirSearchALot.Web.Controllers.WebApi
{
    public class PersonController : ApiController
    {
        public PersonController(IPersonManagementService service)
        {
            _service = service;
        }

        private IPersonManagementService _service;

        [HttpPost]
        public AddPersonResponse AddPerson(PersonDTO person)
        {
            Thread.Sleep(1500);
            return _service.AddPerson(person);
            //return new AddPersonResponse();
        }
    }
}
