using PhoneWeb.DAL;
using PhoneWeb.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneApplicationWebApi.Controllers
{
    public class CountriesController : ApiController
    {
        CountryService countryService;
        public CountriesController()
        {
            countryService = new CountryService();
        }
        public IEnumerable<Country> Get()
        {
           
            return countryService.GetCountries();
        }
        public IEnumerable<Country> AddCountries(Country country)
        {
            return countryService.AddCountries(country);
        }
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] Country country)
        {
            try
            {
                if (id == default(int))
                {
                    return NotFound();
                }
                country.ContryId = id;
                Country result = countryService.UpdateCountries(country);

                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id == default(int))
                {
                    return NotFound();
                }
                countryService.DeleteCountries(id);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


    }
}
