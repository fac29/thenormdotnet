using System;
using domain.interfaces;

namespace domain.entities;

public class UserResources : IUserResources
{
    public Guid Id { get; private set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string Externalreference { get; set; } = string.Empty;

    public string ResourcePicture { get; set; } = string.Empty;

    public DateTime Created { get; set; }

    Guid IUserResources.Id => throw new NotImplementedException();

    string IUserResources.Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string IUserResources.Author { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string IUserResources.Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string IUserResources.Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string IUserResources.ExternalReference { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    string IUserResources.ResourcePicture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    DateTime IUserResources.Created => throw new NotImplementedException();
}
