using System;

namespace thenormapi.dtos;

public class WheelSegmentDto
{
    public string Title { get; set; } = string.Empty;
    public string SegmentResult { get; set; } = string.Empty;
    public string UserId { get; set; }
    public Guid UserResourceId { get; set; }
}