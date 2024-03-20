using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldApi.DTO.Country;
using WorldApi.DTO.States;
using WorldApi.Models;
using WorldApi.Repository;
using WorldApi.Repository.IRepository;

namespace WorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StatesController(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StateDto>>> GetAll()
        {

            var states = await _stateRepository.GetAll();

            var statesDto = _mapper.Map<List<CountryDto>>(states);

            if (states == null)
            {

                return NoContent();
            }

            return Ok(statesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<StateDto>> GetById(int id)
        {
            var state = await _stateRepository.Get(id);

            var stateDto = _mapper.Map<StateDto>(state);
            if (state == null)
            {
                return NoContent();
            }
            return Ok(stateDto);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]


        public async Task<ActionResult<CreateStateDto>> Create([FromBody] CreateStateDto stateDto)
        {

            var result = _stateRepository.IsRecordExists(x => x.Name == stateDto.Name);


            if (result)
            {
                return Conflict("State name already exist");
            }

            
            var state = _mapper.Map<States>(stateDto);



            await _stateRepository.Create(state);
            return CreatedAtAction("GetById", new { id = state.Id }, state);

        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<States>> Update(int id, [FromBody] UpdateStateDto stateDto)
        {
            if (stateDto == null || id != stateDto.Id)
            {
                return BadRequest();
            }

            var state = _mapper.Map<States>(stateDto);

           



            await _stateRepository.Update(state);

            return NoContent();

        }

        [HttpDelete("{id:int}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<States>> DeleteById(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }



            var state = await _stateRepository.Get(id);
            if (state == null)
            {
                return NotFound();
            }


            await _stateRepository.Delete(state);
            return NotFound();

        }


    }
}
