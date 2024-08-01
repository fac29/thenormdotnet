using System;

namespace thenormapi.dtos;

public class UserResourceDto
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string ExternalReference { get; set; } = string.Empty;
    public string ResourcePicture { get; set; } = string.Empty;
}
