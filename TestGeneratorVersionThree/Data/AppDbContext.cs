using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGeneratorVersionThree.MVVM.Model;

namespace TestGeneratorVersionThree.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }


        //string dbPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\Data\\TestGeneratorDB.db";
        string dbPath = @"C:/GIT/TestGeneratorDB.db";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionModel>()
                .HasOne(qm => qm.Category)
                .WithMany(c => c.Questions)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
