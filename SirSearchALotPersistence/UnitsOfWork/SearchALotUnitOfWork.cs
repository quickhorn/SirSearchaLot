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
    //We could throw this into a factory to keep that pesky "new" out of this class, but I think that's too many layers.
    //If we wanted a different persistence implementation, a good place to start replacing 
    //implementations is here. Write a new UnitOfWork and related repositories.    
    public class SearchALotUnitOfWork : ISearchALotUnitOfWork
    {
        public SearchALotUnitOfWork()
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
