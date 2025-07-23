using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_Project.Models;
using New_Project.Servies;

namespace New_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
         
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this._superHeroService = superHeroService; 
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            return Ok(await _superHeroService.GetSuperHerosAsync());

        }
        [HttpGet("{id}")]

        public  async Task<ActionResult<SuperHero>> GetSuperHeroById(int id)
        {
            SuperHero? superHero =await _superHeroService.GetSuperHeroByIdAsync(id);
            if (superHero == null)
                return NotFound("SuperHero not found for this id");
            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperhero(SuperHero hero)
        {
            return Ok(await _superHeroService.AddSuperheroAsync(hero));
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHeroes(int id, SuperHero newHero)
        {
            var heros = await _superHeroService.UpdateSuperHeroesAsync(id, newHero);

            if (heros == null)
                return NotFound("superHero not found for this id");
            return Ok(heros);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHeroes(int id)
        {
            var heros =await  _superHeroService.DeleteSuperHeroesAsync(id);

            if (heros == null)
                return NotFound("superHero not found for this id");
            return Ok(heros);
        }
    }
}
