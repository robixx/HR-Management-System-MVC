using Itc.Hris.Application.Interfaces;
using Itc.Hris.Application.ModelView;
using Itc.Hris.Infrastructure.Data;
using Itc.Hris.Model.Entities;
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

        public async Task<(string Message, bool Status)> CreateAsync(RoleDto role)
        {
            try
            {
                if (role == null)
                {
                    return ("Data Not Valid", false);
                }

                var roleName = role?.RoleName?.Trim().ToLower();               
                var isExists = await _db.AppRole
                    .AnyAsync(x =>
                        x.RoleName != null &&
                        x.RoleName.Trim().ToLower() == roleName &&
                        x.RoleId != role.RoleId
                    );

                if (isExists)
                {
                    return ("Role name already exists", false);
                }

             
                if (role.RoleId > 0)
                {
                    var existing = await _db.AppRole
                        .FirstOrDefaultAsync(x => x.RoleId == role.RoleId);

                    if (existing == null)
                    {
                        return ("Role not found", false);
                    }

                    existing.RoleName = role.RoleName ?? "";
                    existing.Description = role.Description;
                    existing.IsActive = role.IsActive ?? 1;

                    _db.AppRole.Update(existing);
                    await _db.SaveChangesAsync();

                    return ($"{role.RoleName} updated successfully", true);
                }

             
                var entity = new AppRole
                {
                    RoleName = role?.RoleName ?? "",
                    Description = role?.Description,
                    IsActive = role?.IsActive ?? 1
                };

                await _db.AppRole.AddAsync(entity);
                await _db.SaveChangesAsync();

                return ($"{role?.RoleName} created successfully", true);
            }
            catch (Exception ex)
            {
                return ($"Service-->{nameof(RoleService)} Method-->{nameof(CreateAsync)} Error:{ex.Message}", false);
            }

        }

        public async Task<(string Message, bool Status)> DeleteAsync(int id)
        {
            try
            {
                var entity = await _db.AppRole.FindAsync(id);
            if (entity == null) return ("Role not found", false);
            _db.AppRole.Remove(entity);
            await _db.SaveChangesAsync();
            return ($"{entity.RoleName} deleted successfully", true);
           }
            catch (Exception ex)    
            {
                return ($"Service-->:{nameof(RoleService)} and ActionMethod-->{nameof(DeleteAsync)} Error:{ex.Message}", false);
            }
        }

        public async Task<(string Message, bool Status,List<RoleDto> data_list)> GetAllAsync()
        {
            try
            {
                var list = await _db.AppRole.AsNoTracking()
               .Select(r => new RoleDto
               {
                   RoleId = r.RoleId,
                   RoleName = r.RoleName,
                   Description = r.Description,
                   IsActive = r.IsActive
               })
               .ToListAsync();

                return ($"Roles retrieved successfully", true, list);

            }
            catch (Exception ex)
            {
                return ($"Service-->:{nameof(RoleService)} and ActionMethod-->{nameof(GetAllAsync)} Error:{ex.Message}", false, new List<RoleDto>());
            }
              
        }

        public async Task<(string Message, bool Status, RoleDto? data)> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _db.AppRole.FindAsync(id);
                if (entity == null) return ("Role not found", false, null);
                var roleDto = new RoleDto
                {
                    RoleId = entity.RoleId,
                    RoleName = entity.RoleName,
                    Description = entity.Description,
                    IsActive = entity.IsActive
                };
                return ("RoleData retrieved successfully", true, roleDto);
            }
            catch (Exception ex)
            {
                return ($"Service-->:{nameof(RoleService)} and ActionMethod-->{nameof(GetByIdAsync)} Error:{ex.Message}", false, new RoleDto());
            }
            
        }

        public async Task<(string Message, bool Status)> UpdateAsync(RoleDto role)
        {

            try
            {
                var existing = await _db.AppRole.FindAsync(role.RoleId);
                if (existing == null) return ("Role not found", false);
                existing.RoleName = role.RoleName;
                existing.Description = role.Description;
                existing.IsActive = role.IsActive ?? existing.IsActive;
                await _db.SaveChangesAsync();
                return ("Update Successfully", true);
            }
            catch (Exception ex)
            {
                return ($"Service-->:{nameof(RoleService)} and ActionMethod-->{nameof(UpdateAsync)} Error:{ex.Message}", false);
            }
            
        }
    }
}
