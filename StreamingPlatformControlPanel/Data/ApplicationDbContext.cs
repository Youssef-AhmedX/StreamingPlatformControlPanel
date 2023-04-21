using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StreamingPlatformControlPanel.Core.Models;

namespace StreamingPlatformControlPanel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContentCategory> ContentCategories { get; set; }
        public DbSet<ContentFilmMaker> ContentFilmMakers { get; set; }
        public DbSet<FilmMaker> FilmMakers { get; set; }
        public DbSet<FilmMakerRole> FilmMakerRoles { get; set; }
        public DbSet<FilmRole> FilmRoles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episod> Episods { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FilmMakerRole>().HasKey(e => new { e.FilmMakerId, e.FilmRoleId});
            builder.Entity<ContentCategory>().HasKey(e => new { e.CategoryId, e.ContentId });
            builder.Entity<ContentFilmMaker>().HasKey(e => new { e.FilmMakerId, e.Role, e.ContentId });


            base.OnModelCreating(builder);
        }

    }
}