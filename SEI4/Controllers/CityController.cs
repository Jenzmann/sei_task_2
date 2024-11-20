using Microsoft.AspNetCore.Mvc;

namespace SEI4.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CityController : Controller
    {
        public CityController()
        {
            
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(Program.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCities([FromRoute] string id)
        {
            var city = Program.Cities.FirstOrDefault(c => c.Id.Equals(id));
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public IActionResult PostCity(City city) 
        {
            if (!IsCityValid(city))
            {
                return BadRequest("City invalid!");
            }
            
            city.Id = Guid.NewGuid().ToString();
            Program.Cities.Add(city);
            return Ok(city);
        }

        [HttpPut("{id}")]
        public IActionResult PutCity([FromRoute] string id, [FromBody] City city)
        {
            if (!IsCityValid(city))
            {
                return BadRequest("City invalid!");
            }
            var tempCity = Program.Cities.FirstOrDefault(c => c.Id.Equals(id));
            if(tempCity == null)
            {
                return NotFound();
            }
            tempCity.Latitude = city.Latitude;
            tempCity.Longtitude = city.Longtitude;
            tempCity.Country = city.Country;
            tempCity.PostalCode = city.PostalCode;
            tempCity.Name = city.Name;
            return Ok(tempCity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity([FromRoute] string id) 
        {
            if(Program.Cities.FirstOrDefault(c=>c.Id.Equals(id)) == null)
            {
                return NotFound();
            }
            Program.Cities.Remove(Program.Cities.FirstOrDefault(c=>c.Id.Equals(id)));
            return Ok();
        }

        private bool IsCityValid(City city)
        {

            if (city.Country == null || city.Country.Length != 2)
            {
                return false;
            }
            city.Country = city.Country.ToUpper();
            if (city.Country == "DE")
            {
                if (!Int64.TryParse(city.PostalCode, out _))
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class City()
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public string Country { get; set; }
    }
}
