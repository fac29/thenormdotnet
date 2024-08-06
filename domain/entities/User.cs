using System;

using domain.interfaces;

namespace domain.entities
{
    public class User : IUser
    {
        public required string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public string SummaryParagraph { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}