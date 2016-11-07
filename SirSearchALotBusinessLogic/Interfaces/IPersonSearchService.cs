﻿using SirSearchALotBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotBusinessLogic.Interfaces
{
    public interface IPersonSearchService
    {
        List<PersonDTO> SearchPersons(string search);
    }
}