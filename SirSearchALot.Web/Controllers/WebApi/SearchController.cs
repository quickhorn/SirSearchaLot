using SirSearchALotBusinessLogic.Interfaces;
using SirSearchALotBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SirSearchALot.Web.Controllers.WebApi
{
    public class SearchController : ApiController
    {
        public SearchController(IPersonSearchService searchService)
        {
            _searchService = searchService;
        }

        private IPersonSearchService _searchService;

        [HttpGet]
        public SearchPersonResponse Search(string searchString)
        {
            Thread.Sleep(1500);
            return _searchService.SearchPersons(searchString);
        }
    }
}
