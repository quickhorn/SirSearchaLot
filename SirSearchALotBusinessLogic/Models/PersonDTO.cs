using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotBusinessLogic.Models
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }
        
        public string State { get; set; }

        public string ZipCode { get; set; }

        public List<InterestDTO> Interests { get; set; }

        public string ImageUrl { get; set; }
    }
}
