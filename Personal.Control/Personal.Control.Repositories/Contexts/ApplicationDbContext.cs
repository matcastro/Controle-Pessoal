﻿using Microsoft.EntityFrameworkCore;
using Personal.Control.Repositories.Models;

namespace Personal.Control.Repositories.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
