using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotBusinessLogic.Models
{
    public class SearchPersonResponse : ResponseBase
    {
        public List<PersonDTO> MatchedPersons { get; set; }
    }
}
