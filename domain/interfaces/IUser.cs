using System;

namespace domain.interfaces;

public interface IUser
{
    Guid Id { get; }
    string Name { get; set; }
    string Email { get; set; }
    string SummaryParagraph { get; set; }
    DateTime Created { get; set; }
}