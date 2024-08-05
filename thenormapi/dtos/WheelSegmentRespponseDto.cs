using System;

namespace thenormapi.dtos;

public class WheelSegmentRespponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string SegmentResult { get; set; } = string.Empty;
    public string UserId { get; set; }
    public Guid UserResourceId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}