using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotPersistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository(SearchALotEFContext context)
        {
            _context = context;
        }

        private SearchALotEFContext _context;

        public void AddPerson(Person p)
        {
            _context.People.Add(p);
            _context.SaveChanges();
        }

        public List<Person> SearchPersons(string search)
        {
            var searchUpper = search.ToUpperInvariant();
            var people = _context.People.Where(p => p.FirstName.ToUpperInvariant().Equals(search) || p.LastName.ToUpperInvariant().Equals(searchUpper));
            return people.ToList();
        }
    }
}
