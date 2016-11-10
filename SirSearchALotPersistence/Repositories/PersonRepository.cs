using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (!string.IsNullOrEmpty(search))
            {
                var searchLower = search.ToLower();
                var people = _context.People.Include(p => p.Interests).Where(p => p.FirstName.ToLower().Contains(searchLower) || p.LastName.ToLower().Contains(searchLower));
                //Consider parsing search at spaces to better find people and refine search.
                //Consider becoming an expert on search algorithms to provide "relevant" search results here.
                return people.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();
            }
            else
            {
                //Given our small data set, this is okay. In general, though, this is not a horribly great idea.
                return _context.People.Include(p => p.Interests).ToList();
            }
        }
    }
}
