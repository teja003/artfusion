﻿using Artfusion.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtFusion.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FollowsModel>().HasKey(table => new
            {
                table.FollowingUserId,
                table.FollowedUserId
            });

            modelBuilder.Entity<LikesModel>().HasKey(table => new
            {
                table.ProductId,
                table.UserId
            });

        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<FollowsModel> Follows { get; set; }
        public DbSet<LikesModel> Likes { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        public DbSet<PaymentsModel> Payments { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<UserAddressModel> UserAddress { get; set; }
        public DbSet<UserModel> Users { get; set; }

    }
}