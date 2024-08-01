using System;
using System.Collections.Generic;

namespace domain.interfaces
{
    public interface IUser
    {
        Guid Id { get; }
        string Name { get; set; }
        string Email { get; set; }
        string SummaryParagraph { get; set; }
        List<Guid> UserResourceIds { get; set; }
        DateTime Created { get; set; }
    }
}