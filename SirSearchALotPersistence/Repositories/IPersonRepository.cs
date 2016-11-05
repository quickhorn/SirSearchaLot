using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotPersistence.Repositories
{ 
    public interface IPersonRepository
    {
        List<Person> SearchPersons(string search);

        /// <summary>
        /// Adds a person. Note that more than one person can exist with the same name.
        /// </summary>
        /// <param name="p"></param>
        void AddPerson(Person p);
    }
}
