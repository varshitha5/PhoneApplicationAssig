using PhoneApplicationAssig.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PhoneApplicationAssig.DAL
{
    public class ApplicationContext:DbContext
    {

        public ApplicationContext() : base("ApplicationContext")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Migrations.Configuration>());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Person>().Map(map =>
            {
                map.Properties(
                    p => new
                    {
                        p.ID,
                        p.FirstName,
                        p.LastName,
                        p.EmailId,
                        p.PhoneNumber,

                    });
                map.ToTable("Person");
            })
           .Map(map =>
           {
               map.Properties(
                   p => new
                   {
                       p.AddressOne,
                       p.AddressTwo,
                       p.CityId,
                       p.StateId,
                       p.CountryId,
                       p.PinCode,
                       p.IsActive,

                   });
               map.ToTable("Address");
           });

        }
        public override int SaveChanges()
        {
            var Changed = ChangeTracker.Entries();
            if (Changed != null)
            {
                foreach (var entry in Changed.Where(e => e.State == EntityState.Deleted))
                {
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsActive"] = false;
                }
            }
            return base.SaveChanges();
        }
    }
}