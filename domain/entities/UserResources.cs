using System;
namespace domain.entities;

public class UserResources
{
    public Guid Id { get; private set; }

    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string Externalreference { get; set; } = string.Empty;

    public string ResourcePicture { get; set; } = string.Empty;

    public DateTime Created { get; set; }

}
