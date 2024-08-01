using System;
using System.Collections.Generic;
using System.Linq;
using domain.interfaces;
using domain.entities;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repositories;

public class WheelSegmentRepository : IWheelSegmentRepository
{
    private readonly ApplicationDbContext _context;
    public WheelSegmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IWheelSegment?> GetByIdAsync(Guid id)
    {
        return await _context.WheelSegment.FindAsync(id);
    }

    public async Task<IEnumerable<IWheelSegment>> GetAllAsync()
    {
        return await _context.WheelSegment.ToListAsync();
    }

    public async Task<IWheelSegment> CreateAsync(IWheelSegment wheelSegment)
    {
        var newWheelSegment = new WheelSegment
        {
            Title = wheelSegment.Title,
            SegmentResult = wheelSegment.SegmentResult,
            UserId = wheelSegment.UserId,
            UserResourceId = wheelSegment.UserResourceId,
            Created = DateTime.UtcNow
        };
        _context.WheelSegment.Add(newWheelSegment);
        await _context.SaveChangesAsync();
        return newWheelSegment;
    }

    public async Task UpdateAsync(IWheelSegment wheelSegment)
    {
        var existingWheelSegment = await _context.WheelSegment.FindAsync(wheelSegment.Id);
        if (existingWheelSegment != null)
        {
            existingWheelSegment.Title = wheelSegment.Title;
            existingWheelSegment.SegmentResult = wheelSegment.SegmentResult;
            existingWheelSegment.UserId = wheelSegment.UserId;
            existingWheelSegment.UserResourceId = wheelSegment.UserResourceId;
            existingWheelSegment.Updated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }


    }

    public async Task DeleteAsync(Guid id)
    {
        var wheelSegment = await _context.WheelSegment.FindAsync(id);
        if (wheelSegment != null)
        {
            _context.WheelSegment.Remove(wheelSegment);
            await _context.SaveChangesAsync();
        }
    }

}
