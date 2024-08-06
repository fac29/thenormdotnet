using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.interfaces;

namespace infrastructure.repositories;

public interface IUserResourcesRepository
{
    Task<IUserResources?> GetByIdAsync(Guid id);
    Task<IUserResources?> UpdateAsync(IUserResources userResource);
    Task<IEnumerable<IUserResources>> GetAllAsync();
    Task<IUserResources> CreateAsync(IUserResources userResource);
    Task<bool> DeleteAsync(Guid id);
}