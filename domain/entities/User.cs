﻿using System;
using System.Collections.Generic;
using domain.interfaces;

namespace domain.entities
{
    public class User : IUser
    {
        public Guid Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SummaryParagraph { get; set; } = string.Empty;
        public List<Guid> UserResourceIds { get; set; } = new List<Guid>();
        public DateTime Created { get; set; }
    }
}