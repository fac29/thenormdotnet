using System;
using System.Collections.Generic;
using System.Linq;
using domain.interfaces;
using domain.entities;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IUser?> GetByIdAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task<IEnumerable<IUser>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<IUser> CreateAsync(IUser user)
    {
        var newUser = new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PictureUrl = user.PictureUrl,
            SummaryParagraph = user.SummaryParagraph,
            Created = DateTime.UtcNow

        };
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return newUser;
    }

    public async Task UpdateAsync(IUser user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.PictureUrl = user.PictureUrl;
            existingUser.SummaryParagraph = user.SummaryParagraph;
            existingUser.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}