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
        
        public async Task<HeroSlide?> FindHeroSlideById(int heroSlideId)
        {
            return await _db.Set<HeroSlide>().FindAsync(heroSlideId);
        }

        public async Task<bool> DeleteHeroSlide(int heroSlideId)
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
            
            matchingHeroSlide.Title = heroSlideUpdateRequest.Title;
            matchingHeroSlide.Link = heroSlideUpdateRequest.Link;
            matchingHeroSlide.Order = heroSlideUpdateRequest.Order;
            matchingHeroSlide.IsActive = heroSlideUpdateRequest.IsActive;
            matchingHeroSlide.ImageUrl = heroSlideUpdateRequest.ImageUrl;
            matchingHeroSlide.StartDate = heroSlideUpdateRequest.StartDate;
            matchingHeroSlide.EndDate = heroSlideUpdateRequest.EndDate;
            
            return matchingHeroSlide;
        }
    }
}