using BleachAPI.Models;
using BleachAPI.Models.DTOs;
using BleachAPI.Repository;
using BleachAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BleachAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BleachAPIController : ControllerBase
    {
        private readonly BleachAPIRepository _repo;
        public BleachAPIController(BleachAPIRepository repo) => _repo = repo;

        [HttpGet("{race}/{name}")]
        public async Task<IActionResult> Save(string race, string name)
        {
            await _repo.SaveFromApiAsync(race, name);
            return Ok("Salvo!");
        }
    }
}
