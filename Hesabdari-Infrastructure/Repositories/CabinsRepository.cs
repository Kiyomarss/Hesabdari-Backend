using Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Infrastructure.DbContext;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class CabinsRepository : RepositoryBase, ICabinsRepository
    {
        private readonly IApplicationDbContext _db;

        public CabinsRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Cabin> AddCabin(Cabin cabin)
        {
            await _db.Set<Cabin>().AddAsync(cabin);

            return cabin;
        }

        public async Task<List<Cabin>> GetCabins()
        {
            return await _db.Set<Cabin>().ToListAsync();
        }
        
        public async Task<Cabin?> FindCabinById(Guid cabinId)
        {
            return await _db.Set<Cabin>().FindAsync(cabinId);
        }

        public async Task<bool> DeleteCabin(Guid cabinId)
        {
            var rowsDeleted = await _db.Set<Cabin>()
                                       .Where(b => b.Id == cabinId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }

        public async Task<Cabin> UpdateCabin(CabinUpsertRequest cabinUpdateRequest)
        {
            var matchingCabin = await _db.Set<Cabin>().FindAsync(cabinUpdateRequest.Id);
            if (matchingCabin == null)
            {
                throw new InvalidOperationException("Cabin with the given ID does not exist.");
            }
            
            matchingCabin.Name = cabinUpdateRequest.Name;
            matchingCabin.MaxCapacity = cabinUpdateRequest.MaxCapacity;
            matchingCabin.RegularPrice = cabinUpdateRequest.RegularPrice;
            matchingCabin.Discount = cabinUpdateRequest.Discount;
            matchingCabin.ImagePath = cabinUpdateRequest.ImagePath;
            matchingCabin.Description = cabinUpdateRequest.Description;
            
            return matchingCabin;
        }
    }
}