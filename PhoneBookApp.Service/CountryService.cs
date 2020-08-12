using PhoneBookApp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Service
{
    public class CountryService
    {
        ApplicationContext applicationContext;
        public CountryService()
        {
            applicationContext = new ApplicationContext();

        }
        public IEnumerable<Country> GetCountries()
        {

            return applicationContext.Countries.Where(c => c.IsActive.Equals(true));
        }
        public IEnumerable<Country> AddCountries(Country country)
        {
            applicationContext.Countries.Add(country);
            applicationContext.SaveChanges();
            return applicationContext.Countries;
        }
        public Country UpdateCountries(Country country)
        {
            var existingCountry = applicationContext.Countries.FirstOrDefault(x => x.ContryId == country.ContryId);
            if (existingCountry == null)
            {
                throw new InvalidOperationException("Country Id NotFound");
            }
            existingCountry.CountryName = country.CountryName;
            applicationContext.SaveChanges();
            return country;
        }

        public void DeleteCountries(int id)
        {

            var existingCountry = applicationContext.Countries.FirstOrDefault(x => x.ContryId == id && x.IsActive);
            if (existingCountry == null)
            {
                throw new InvalidOperationException("Country Id NotFound");
            }
            applicationContext.Entry(existingCountry).State = EntityState.Deleted;
            //applicationContext.Countries.Remove(existingCountry);
            applicationContext.SaveChanges();

        }
    }
}