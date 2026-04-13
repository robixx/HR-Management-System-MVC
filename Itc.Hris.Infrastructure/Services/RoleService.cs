using Itc.Hris.Application.Interfaces;
using Itc.Hris.Model.Entities;
using Itc.Hris.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Itc.Hris.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext _db;
        public RoleService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            _db.Roles.Add(role);
            await _db.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Roles.FindAsync(id);
            if (entity == null) return false;
            _db.Roles.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _db.Roles.AsNoTracking().ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _db.Roles.FindAsync(id);
        }

        public async Task<Role?> UpdateAsync(Role role)
        {
            var existing = await _db.Roles.FindAsync(role.Id);
            if (existing == null) return null;
            existing.Name = role.Name;
            existing.Description = role.Description;
            await _db.SaveChangesAsync();
            return existing;
        }
    }
}
