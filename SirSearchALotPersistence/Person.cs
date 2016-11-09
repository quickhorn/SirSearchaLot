namespace SirSearchALotPersistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string StreetAddress { get; set; }
        
        [Required]
        public string State { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The Zip Code must be 5 characters")]
        [MaxLength(5, ErrorMessage = "The Zip Code must be 5 characters")]
        public string ZipCode { get; set; }

        [ForeignKey("PersonId")]
        public List<Interest> Interests { get; set; }

        [Required]
        public string ImageUrl { get; set; } 
    }
}
