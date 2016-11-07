namespace SirSearchALotPersistence
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SearchALotEFContext : DbContext
    {
        public SearchALotEFContext()
            : base("name=SearchALotEF")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(true);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(true);
        }
    }
}
