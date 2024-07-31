using System;
using domain.entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<UserResources> UserResources { get; set; }
}