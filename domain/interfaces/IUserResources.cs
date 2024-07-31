using System;

namespace domain.interfaces;

public interface IUserResources
{
    Guid Id { get; }

    string Title { get; set; }

    string Author { get; set; }

    string Type { get; set; }

    string Content { get; set; }

    string ExternalReference { get; set; }

    string ResourcePicture { get; set; }

    DateTime Created { get; }

}
