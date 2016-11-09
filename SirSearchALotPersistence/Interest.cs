using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirSearchALotPersistence
{
    [Table("Interest")]
    public partial class Interest
    {
        [Required]
        [Key]
        public int InterestId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
