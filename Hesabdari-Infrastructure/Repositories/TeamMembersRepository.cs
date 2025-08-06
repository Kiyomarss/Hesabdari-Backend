using Hesabdari_Core.Domain.Entities;
using Hesabdari_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class TeamMembersRepository : RepositoryBase, ITeamMembersRepository
    {
        private readonly IApplicationDbContext _db;

        public TeamMembersRepository(IApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<TeamMember> AddTeamMember(TeamMember teamMember)
        {
            await _db.Set<TeamMember>().AddAsync(teamMember);

            await _db.SaveChangesAsync();
            
            return teamMember;
        }

        public Task UpdateTeamMember()
        {
            return _db.SaveChangesAsync();
        }

        public async Task<List<TeamMember>> GetTeamMembers()
        {
            return await _db.Set<TeamMember>()
                            .OrderBy(x => x.Order).ToListAsync();
        }
        
        public async Task<List<TeamMember>> GetDashboardTeamMembers()
        {
            return await _db.Set<TeamMember>().Where(b => b.IsActive)
                            .OrderBy(x => x.Order).ToListAsync();
        }
        
        public async Task<TeamMember?> FindTeamMemberById(int teamMemberId)
        {
            return await _db.Set<TeamMember>().FindAsync(teamMemberId);
        }

        public async Task<bool> DeleteTeamMember(int teamMemberId)
        {
            var rowsDeleted = await _db.Set<TeamMember>()
                                       .Where(b => b.Id == teamMemberId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
        
        public async Task<bool> DeleteImageTeamMember(int teamMemberId)
        {
            var rowsDeleted = await _db.Set<TeamMember>()
                                       .Where(b => b.Id == teamMemberId)
                                       .ExecuteDeleteAsync();

            return rowsDeleted > 0;
        }
    }
}