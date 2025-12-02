using BleachAPI.Models.DTOs;
using BleachAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BleachAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BleachAPIController : ControllerBase
    {
        private readonly BleachAPIService _bleachApiService;

        public BleachAPIController(BleachAPIService bleachAPIService)
        {
            _bleachApiService = bleachAPIService;
        }

        [HttpGet("{race}/{name}")]
        public async Task<ActionResult<CharacterDTO>> GetCharByRaceAndName(string race, string name)
        {
            var character = await _bleachApiService.GetCharacterByRaceAndNameAsync(race, name);

            if (character is null) return NotFound();

            return Ok(character);
        }
    }
}
