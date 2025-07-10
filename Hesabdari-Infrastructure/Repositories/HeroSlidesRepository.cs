using Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Infrastructure.DbContext;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class HeroSlidesRepository : RepositoryBase, IHeroSlidesRepository
    {
        private readonly IApplicationDbContext _db;

        public HeroSlidesRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<HeroSlide> AddHeroSlide(HeroSlide heroSlide)
        {
            await _db.Set<HeroSlide>().AddAsync(heroSlide);

            return heroSlide;
        }

        public async Task<List<HeroSlide>> GetHeroSlides()
        {
            return await _db.Set<HeroSlide>().ToListAsync();
        }
        
        public async Task<HeroSlide?> FindHeroSlideById(Guid heroSlideId)
        {
            return await _db.Set<HeroSlide>().FindAsync(heroSlideId);
        }

        public async Task<bool> DeleteHeroSlide(Guid heroSlideId)
        {
            var rowsDeleted = await _db.Set<HeroSlide>()
                                       .Where(b => b.Id == heroSlideId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }

        public async Task<HeroSlide> UpdateHeroSlide(HeroSlideUpsertRequest heroSlideUpdateRequest)
        {
            var matchingHeroSlide = await _db.Set<HeroSlide>().FindAsync(heroSlideUpdateRequest.Id);
            if (matchingHeroSlide == null)
            {
                throw new InvalidOperationException("HeroSlide with the given ID does not exist.");
            }
            
            matchingHeroSlide.Name = heroSlideUpdateRequest.Name;
            matchingHeroSlide.MaxCapacity = heroSlideUpdateRequest.MaxCapacity;
            matchingHeroSlide.RegularPrice = heroSlideUpdateRequest.RegularPrice;
            matchingHeroSlide.Discount = heroSlideUpdateRequest.Discount;
            matchingHeroSlide.ImagePath = heroSlideUpdateRequest.ImagePath;
            matchingHeroSlide.Description = heroSlideUpdateRequest.Description;
            
            return matchingHeroSlide;
        }
    }
}