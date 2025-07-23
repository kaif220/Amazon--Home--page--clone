using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using New_Project.Data;
using New_Project.Models;

namespace New_Project.Servies
{
    public class SuperHeroService : ISuperHeroService
    {
       
        private readonly DataContext _dataContext;

        public SuperHeroService(DataContext dataContext)
        {
            _dataContext = dataContext;  
        }



        public async Task<List<SuperHero>> AddSuperheroAsync(SuperHero hero)
        {
            await _dataContext.SuperHeroes.AddAsync(hero);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteSuperHeroesAsync(int id)
        {
            SuperHero? superHero = await  _dataContext.SuperHeroes.FindAsync(id);
            if (superHero == null)
                return null;
            _dataContext.SuperHeroes.Remove(superHero);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetSuperHeroByIdAsync(int id)
        {
            SuperHero? superHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (superHero == null)
                return null;
            return superHero;
        }

        public async Task<List<SuperHero>> GetSuperHerosAsync()
        {
            return await _dataContext.SuperHeroes.ToListAsync();   

        }

        public async Task<List<SuperHero>?> UpdateSuperHeroesAsync(int id, SuperHero newHero)
        {
            SuperHero? superHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (superHero == null)
                return null;
            superHero.Name = newHero.Name;
            superHero.Firstname = newHero.Firstname;
            superHero.Lastname = newHero.Lastname;
            superHero.Place = newHero.Place;
            await _dataContext.SaveChangesAsync();
            return await _dataContext.SuperHeroes.ToListAsync();
        }
    }
}
