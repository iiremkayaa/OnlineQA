using Microsoft.EntityFrameworkCore;
using Project.OnlineQA.DataAccess.Concrete.EfCore.Mapping;
using Project.OnlineQA.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.OnlineQA.DataAccess.Concrete.EfCore.Context
{
    public class OnlineQADbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;database=OnlineQA;integrated security=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new SelectionMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserSelectionMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserSelection> UserSelections { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Selection> Selections { get; set; }
        public DbSet<Comment> Comments { get; set; }




    }
}
