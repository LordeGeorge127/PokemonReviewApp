using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon_Review_App.Dto;
using Pokemon_Review_App.Interfaces;
using Pokemon_Review_App.Models;
using Pokemon_Review_App.Repository;

namespace Pokemon_Review_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(owners);
            }
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();
            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(owner);
            }
        }
        [HttpGet("{ownerId}/Pokemon")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }
            var owner = _mapper.Map<List<PokemonDto>>(
                _ownerRepository.GetPokemonByOwner(ownerId));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(owner);
        }
    }
}
