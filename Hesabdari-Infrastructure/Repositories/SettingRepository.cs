using Hesabdari_Core.Domain.Entities;
using Hesabdari_Infrastructure.DbContext;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class SettingRepository : RepositoryBase, ISettingRepository
    {
        private readonly IApplicationDbContext _db;

        public SettingRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Setting> GetSetting()
        {
            return await _db.Set<Setting>().SingleAsync();
        }

        public Task UpdateSetting()
        {
            return _db.SaveChangesAsync();
        }
    }
}