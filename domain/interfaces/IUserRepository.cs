using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.interfaces;

public interface IUserRepository
{
    Task<IUser?> GetByIdAsync(string id);
    Task<IEnumerable<IUser>> GetAllAsync();
    Task<IUser> CreateAsync(IUser user);
    Task UpdateAsync(IUser user);
    Task DeleteAsync(string id);
}