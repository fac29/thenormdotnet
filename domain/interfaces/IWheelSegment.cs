using System;

namespace domain.interfaces;

public interface IWheelSegment
{
    Guid Id { get; }

    string Title { get; set; }

    string SegmentResult { get; set; }

    Guid UserId { get; set; }

    Guid UserResourceId { get; set; }

    DateTime Created { get; set; }

    DateTime Updated { get; set; }

}