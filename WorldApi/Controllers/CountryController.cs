using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WorldApi.Data;
using WorldApi.DTO.Country;
using WorldApi.Models;
using WorldApi.Repository;
using WorldApi.Repository.IRepository;

namespace WorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryController> _logger;


        //Constructor
        public CountryController(ICountryRepository countryRepository, IMapper mapper, ILogger<CountryController> logger)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
           
            var countries = await _countryRepository.GetAll();

            var countriesDto = _mapper.Map<List<CountryDto>>(countries);

            if(countries ==null)
            {

                return NoContent();
            }

            return Ok(countriesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<CountryDto>> GetById(int id) 
        {
            var country = await _countryRepository.Get(id);

            
            if(country == null) 
            {

                _logger.LogError($"Error while trying to get the record is id:{id}");
                return NoContent();
            }

            var countryDto = _mapper.Map<CountryDto>(country);
            return Ok(countryDto);

        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]


        public async Task<ActionResult<CreateCountryDto>> Create([FromBody] CreateCountryDto countryDto)
        {

            var result =  _countryRepository.IsRecordExists(x=>x.Name == countryDto.Name);


            if(result)
            {
                return Conflict("Country name already exist");
            }

            //Country country = new Country();
            //country.Name = countryDto.Name;
            //country.ShortName = countryDto.ShortName;
            //country.CountryCode = countryDto.CountryCode;

            var country = _mapper.Map<Country>(countryDto);



             await _countryRepository.Create(country);
            return CreatedAtAction("GetById", new {id = country.Id}, country);

        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Country>> Update(int id,[FromBody] UpdateCountryDto countryDto)
        {
            if(countryDto == null || id != countryDto.Id)
            {
                return BadRequest();
            }

            var country = _mapper.Map<Country>(countryDto);

            //var countryFromDb = _dbContext.Countries.Find(id);
                
            
            //if(countryFromDb == null )
            //{

            //    return NotFound();
            //}

            //countryFromDb.Name = country.Name;
            //countryFromDb.ShortName = country.ShortName;
            //countryFromDb.CountryCode = country.CountryCode;



            await _countryRepository.Update(country);
            
            return NoContent();

        }

        [HttpDelete("{id:int}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<Country>> DeleteById(int id) 
        {

            if(id == 0)
            {
                return BadRequest();
            }



            var country = await _countryRepository.Get(id);
            if(country == null)
            {
                return NotFound();
            }


            await _countryRepository.Delete(country);
            return NotFound();
        
        }

    }
}
