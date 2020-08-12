namespace PhoneBookWeb.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.States)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Address)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.StateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.StateId)
                .WillCascadeOnDelete(false);
        }
    }
}
