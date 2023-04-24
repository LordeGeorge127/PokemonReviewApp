
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon_Review_App.Dto;
using Pokemon_Review_App.Interfaces;
using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController:Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type =typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(pokemons);
            }
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId) 
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));  
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(pokemon);
            }
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();
            var rating = _pokemonRepository.GetPokemonRating(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Ok(rating);
            }

        }


    }
}
