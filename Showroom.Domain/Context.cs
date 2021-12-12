using Microsoft.EntityFrameworkCore;
using Showroom.Domain.Entities;

namespace Showroom.Domain
{
    public partial class Context : DbContext
    {
        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<Body> Bodies { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Class> Classs { get; set; } = null!;
        public virtual DbSet<Engine> Engines { get; set; } = null!;
        public virtual DbSet<Gearbox> Gearboxes { get; set; } = null!;
        public virtual DbSet<Generation> Generes { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<ModelOption> ModelOptions { get; set; } = null!;
        public virtual DbSet<Option> Options { get; set; } = null!;
        public virtual DbSet<CarShowroom> Showrooms { get; set; } = null!;
        public virtual DbSet<State> State { get; set; } = null!;
        public virtual DbSet<StateElement> StateElements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Body>(entity =>
            {
                entity.HasKey(e => e.IdBody);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.VinNumber);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.HasKey(e => e.IdEngine);
            });

            modelBuilder.Entity<Gearbox>(entity =>
            {
                entity.HasKey(e => e.IdGearbox);
            });

            modelBuilder.Entity<Generation>(entity =>
            {
                entity.HasKey(e => e.IdGeneration);
            });

            modelBuilder.Entity<ModelOption>(entity =>
            {
                entity.HasKey(e => e.IdModel);
                entity.HasKey(e => e.IdOption);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.IdOption);
            });

            modelBuilder.Entity<CarShowroom>(entity =>
            {
                entity.HasKey(e => e.IdShowroom);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.IdState);
            });

            modelBuilder.Entity<StateElement>(entity =>
            {
                entity.HasKey(e => e.IdState);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
