﻿using Microsoft.EntityFrameworkCore;

namespace ShoesECommerceApp.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options) :base (options)
        {
           
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Shoes> shoe { get; set; }
    }
}
