using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SirSearchALotPersistence.Repositories;

namespace SirSearchALotPersistence.UnitsOfWork
{
    /// <summary>
    /// Entity framework unit of work.
    /// </summary>
    /// 
    public class SearchALotAzureUnitOfWork : ISearchALotUnitOfWork
    {
        public SearchALotAzureUnitOfWork()
        {
            _context = new SearchALotEFContext();
        }

        private SearchALotEFContext _context;

        public IPersonRepository Persons
        {
            get
            {
                return new PersonRepository(_context);
            }
        }
    }
}
