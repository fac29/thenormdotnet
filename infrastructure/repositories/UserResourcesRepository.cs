using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.interfaces;
using domain.entities;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class UserResourcesRepository : IUserResourcesRepository
{
    private readonly ApplicationDbContext _context;

    public UserResourcesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IUserResources> GetByIdAsync(Guid id)
    {
        return await _context.UserResources.FindAsync(id);
    }

    public async Task<IEnumerable<IUserResources>> GetAllAsync()
    {
        return await _context.UserResources.ToListAsync();
    }

    public async Task<IUserResources> CreateAsync(IUserResources userResource)
    {
        var entity = new UserResources
        {
            Id = Guid.NewGuid(),
            Title = userResource.Title,
            Author = userResource.Author,
            Type = userResource.Type,
            Content = userResource.Content,
            ExternalReference = userResource.ExternalReference,
            ResourcePicture = userResource.ResourcePicture,
            Created = DateTime.UtcNow
        };

        _context.UserResources.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IUserResources> UpdateAsync(IUserResources userResource)
    {
        var entity = await _context.UserResources.FindAsync(userResource.Id);
        if (entity == null)
        {
            return null;
        }

        entity.Title = userResource.Title;
        entity.Author = userResource.Author;
        entity.Type = userResource.Type;
        entity.Content = userResource.Content;
        entity.ExternalReference = userResource.ExternalReference;
        entity.ResourcePicture = userResource.ResourcePicture;

        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.UserResources.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.UserResources.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}