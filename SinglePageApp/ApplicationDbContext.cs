using DharaProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DharaProject
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<UserModel> UserModel { get; set; } = default!;
        public DbSet<ProductCategoryModel> ProductModel { get; set; } = default!;
        public DbSet<OrderModel> OrderModel { get; set; } = default!;
        public DbSet<Cart> Cart { get; set; } = default!;
        public DbSet<CategoryModel> CategoryModel { get; set; } = default!;
        public DbSet<ProductModel> OrderDetails { get; set; } = default!;

        
    }

    
    }


