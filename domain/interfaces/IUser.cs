using System;

namespace domain.interfaces
{
    public interface IUser
    {
        string Id { get; set; }

        string Name { get; set; }

        string Email { get; set; }

        string PictureUrl { get; set; }

        string SummaryParagraph { get; set; }

        DateTime Created { get; set; }

        DateTime Updated { get; set; }
    }
}