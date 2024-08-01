using System;

namespace thenormapi.dtos
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SummaryParagraph { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}