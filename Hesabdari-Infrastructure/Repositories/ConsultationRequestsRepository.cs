using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO.ConsultationRequest;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class ConsultationRequestsRepository : RepositoryBase, IConsultationRequestsRepository
    {
        private readonly IApplicationDbContext _db;

        public ConsultationRequestsRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task AddConsultationRequest(ConsultationRequest consultationRequest)
        {
            await _db.Set<ConsultationRequest>().AddAsync(consultationRequest);

            await _db.SaveChangesAsync();
        }

        public Task UpdateConsultationRequest()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<List<ConsultationRequest>> GetConsultationRequests(PaginationRequestDto dto)
        {
            IQueryable<ConsultationRequest> query = _db.Set<ConsultationRequest>();

            if (!string.IsNullOrWhiteSpace(dto.Status))
            {
                query = dto.Status switch
                {
                    "isStarred" => query.Where(r => r.IsStarred),
                    "new"       => query.Where(r => !r.IsRead),
                    _           => query
                };
            }

            return await query
                         .OrderByDescending(r => r.CreateAt)
                         .Skip((dto.Page - 1) * dto.PageSize)
                         .Take(dto.PageSize)
                         .ToListAsync();
        }

        public async Task<int> GetConsultationRequestsCount(PaginationRequestDto dto)
        {
            IQueryable<ConsultationRequest> query = _db.Set<ConsultationRequest>();

            if (!string.IsNullOrWhiteSpace(dto.Status))
            {
                query = dto.Status switch
                {
                    "isStarred" => query.Where(r => r.IsStarred),
                    "new"       => query.Where(r => !r.IsRead),
                    _           => query
                };
            }

            return await query.CountAsync();
        }
        
        public async Task<List<ConsultationRequest>> GetStarredConsultationRequests()
        {
            return await _db.Set<ConsultationRequest>()
                            .Where(x => x.IsStarred == true)
                            .OrderByDescending(x => x.CreateAt).ToListAsync();
        }

        public async Task<List<ConsultationRequest>> GetUnreadConsultationRequests()
        {
            return await _db.Set<ConsultationRequest>()
                            .Where(x => x.IsRead == false)
                            .OrderByDescending(x => x.CreateAt).ToListAsync();
        }
        
        public async Task<int> GetUnreadCount()
        {
            return await _db.Set<ConsultationRequest>()
                            .Where(x => x.IsRead == false)
                            .CountAsync();
        }
        
        public async Task<ConsultationRequest?> FindConsultationRequestById(long id)
        {
            return await _db.Set<ConsultationRequest>().FindAsync(id);
        }

        public async Task<bool> DeleteConsultationRequests(List<long> list)
        {
            var rowsDeleted = await _db.Set<ConsultationRequest>()
                                       .Where(b => list.Contains(b.Id))
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
    }
}