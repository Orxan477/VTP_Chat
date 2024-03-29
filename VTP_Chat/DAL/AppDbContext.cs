﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VTP_Chat.Models;

namespace VTP_Chat.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
