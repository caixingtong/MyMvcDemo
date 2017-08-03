namespace MyMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbFirstModel : DbContext
    {
        public DbFirstModel()
            : base("name=DbFirstModel")
        {
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .Property(e => e.Row)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Col)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
               .Property(e => e.Grain)
               .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Areas)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Quality)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Price)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.ChartMan)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Style)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}
