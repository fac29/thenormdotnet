using System;
using domain.interfaces;

namespace infrastructure.repositories;

public class UserRepository : IUser
{
    public Guid Id => throw new NotImplementedException();

    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string SummaryParagraph { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime Created { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
