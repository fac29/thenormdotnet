﻿using System;

namespace thenormapi.dtos;

public class UserDto
{
    public required string Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PictureUrl { get; set; } = string.Empty;

    public string SummaryParagraph { get; set; } = string.Empty;

}
