using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
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

            await _db.SaveChangesAsync();
            
            return heroSlide;
        }

        public Task UpdateHeroSlide()
        {
            return _db.SaveChangesAsync();
        }
        
        public async Task<List<ImagesDto>> GetHeroSlidesImageUrl()
        {
            var today = DateTime.Now.Date;

            return await _db.Set<HeroSlide>()
                            .Where(b =>
                                       b.IsActive &&
                                       (b.StartDate == null || b.StartDate.Value.Date <= today) &&
                                       (b.EndDate == null || b.EndDate.Value.Date >= today))
                            .OrderBy(x => x.Order)
                            .Select(x => new ImagesDto(x.ImageDesktopWebpUrl, x.ImageDesktopJpgUrl, x.ImageMobileWebpUrl, x.ImageMobileJpgUrl))
                            .ToListAsync();
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
    }
}