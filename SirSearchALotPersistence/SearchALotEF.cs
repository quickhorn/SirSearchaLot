namespace SirSearchALotPersistence
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SearchALotEFContext : DbContext
    {
        public SearchALotEFContext()
            //: base("name=SearchALotEF") //uncomment this to see azure connection
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
