using System;

namespace domain.entities;

public class User
{

    public Guid Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string SummaryParagraph { get; set; } = string.Empty;

    public DateTime Created { get; set; }

}
