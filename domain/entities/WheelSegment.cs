using System;

using domain.interfaces;

namespace domain.entities;

public class WheelSegment : IWheelSegment
{
    public Guid Id { get; private set; }

    public string Title { get; set; } = string.Empty;

    public string SegmentResult { get; set; } = string.Empty;

    public string UserId { get; set; }

    public Guid UserResourceId { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }


}
