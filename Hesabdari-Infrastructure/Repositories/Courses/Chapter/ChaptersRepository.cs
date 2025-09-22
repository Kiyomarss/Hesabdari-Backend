using Hesabdari_Core.Domain.Entities;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class ChaptersRepository : RepositoryBase, IChaptersRepository
    {
        private readonly IApplicationDbContext _db;

        public ChaptersRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Chapter> AddChapter(Chapter chapter)
        {
            await _db.Set<Chapter>().AddAsync(chapter);

            await _db.SaveChangesAsync();
            
            return chapter;
        }

        public Task UpdateChapter()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteChapter(int chapterId)
        {
            var rowsDeleted = await _db.Set<Chapter>()
                                       .Where(b => b.Id == chapterId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
    }
}