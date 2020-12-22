using Microsoft.EntityFrameworkCore;
using movieFind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movieFind.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<DepartmentModel> tbl_department { get; set; }

        public DbSet<SubsidiaryModel> tbl_subsidiary { get; set; }

        public DbSet<RoomModel> tbl_room { get; set; }

        public DbSet<MovieTypeModel> tbl_movie_type { get; set; }

        public DbSet<MovieModel> tbl_movie { get; set; }

        public DbSet<FunctionModel> tbl_function { get; set; }

        public DbSet<UserTypeModel> tbl_user_type { get; set; }

        public DbSet<UserModel> tbl_user { get; set; }

        public DbSet<UserSubsidiaryModel> tbl_user_subsidiary { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSubsidiaryModel>()
                .HasNoKey();
        }
    }
}
