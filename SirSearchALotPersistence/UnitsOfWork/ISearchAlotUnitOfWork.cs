using SirSearchALotPersistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotPersistence.UnitsOfWork
{
    public interface ISearchALotUnitOfWork
    {
        public IPersonRepository Persons { get; }
    }
}
