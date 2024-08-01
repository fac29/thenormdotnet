using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.interfaces;

public interface IWheelSegmentRepository
{
    Task<IWheelSegment?> GetByIdAsync(Guid id);

    Task<IEnumerable<IWheelSegment>> GetAllAsync();

    Task<IWheelSegment> CreateAsync(IWheelSegment wheelSegment);

    Task UpdateAsync(IWheelSegment wheelSegment);

    Task DeleteAsync(Guid id);

}


