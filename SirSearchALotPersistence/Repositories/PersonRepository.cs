using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotPersistence.Repositories
{
    /// <summary>
    /// Entity framework repository
    /// </summary>
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
            //Consider moving the search where clause somewhere unit testable.
            var searchUpper = search.ToUpperInvariant();
            var people = _context.People.Where(p => p.FirstName.ToUpperInvariant().Contains(searchUpper) || p.LastName.ToUpperInvariant().Contains(searchUpper));
            //Consider parsing search at spaces to better find people and refine search.
            //Consider becoming an expert on search algorithms to provide "relevant" search results here.
            return people.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();
        }
    }
}
