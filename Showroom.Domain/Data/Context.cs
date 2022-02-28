using Microsoft.EntityFrameworkCore;
using Showroom.Domain.Entities;
using Showroom.Domain.Entitis.UserEntities;

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
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wishlist> Wishlist { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Body>(entity =>
            {
                entity.HasKey(e => e.idBody);

                entity.ToTable("Body");

                entity.Property(e => e.idBody).HasColumnName("idbody");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
                entity.Property(e => e.Volume).HasColumnName("Volume");
                entity.Property(e => e.Door).HasColumnName("Door");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand);

                entity.ToTable("Brand");

                entity.Property(e => e.IdBrand).HasColumnName("idBrand");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.VinNumber);

                entity.ToTable("Car");

                entity.Property(e => e.VinNumber).HasColumnName("vin-number").HasMaxLength(20);
                entity.Property(e => e.Colour).HasColumnName("Colour").HasMaxLength(45);
                entity.Property(e => e.Price).HasColumnName("Price");
                entity.Property(e => e.IdModel).HasColumnName("IdModel");
                entity.Property(e => e.IdShowroom).HasColumnName("IdShowroom");

                entity.HasOne(d => d.IdModelNavigation)
                .WithMany(p => p.Cars)
                .HasForeignKey(d => d.IdModel);

                entity.HasOne(d => d.IdShowroomNavigation)
                .WithMany(p => p.Cars)
                .HasForeignKey(d => d.IdShowroom);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass);

                entity.ToTable("Class");

                entity.Property(e => e.IdClass).HasColumnName("idClass");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.HasKey(e => e.IdEngine);

                entity.ToTable("Engine");

                entity.Property(e => e.IdEngine).HasColumnName("idEngine");
                entity.Property(e => e.Type).HasColumnName("Type").HasMaxLength(45);
                entity.Property(e => e.Volume).HasColumnName("Volume");
                entity.Property(e => e.HP).HasColumnName("HP");
                entity.Property(e => e.Consumption).HasColumnName("Consumption");
            });

            modelBuilder.Entity<Gearbox>(entity =>
            {
                entity.HasKey(e => e.IdGearbox);

                entity.ToTable("Gearbox");

                entity.Property(e => e.IdGearbox).HasColumnName("idGearbox");
                entity.Property(e => e.Type).HasColumnName("Type");
                entity.Property(e => e.Number).HasColumnName("Number");
            });

            modelBuilder.Entity<Generation>(entity =>
            {
                entity.HasKey(e => e.IdGeneration);

                entity.ToTable("Generation");

                entity.Property(e => e.IdGeneration).HasColumnName("idGeneration");
                entity.Property(e => e.Year).HasColumnName("Year");
                entity.Property(e => e.Produced).HasColumnName("Produced");
            });

            modelBuilder.Entity<ModelOption>(entity =>
            {
                entity.HasKey(e => e.IdModel);
                entity.HasKey(e => e.IdOption);

                entity.ToTable("ModelOption");

                entity.Property(e => e.IdModel).HasColumnName("idModel");
                entity.Property(e => e.IdOption).HasColumnName("IdOption");

                entity.HasOne(d => d.IdModelNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdModel);
                entity.HasOne(d => d.IdOptionNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdOption);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.IdOption);

                entity.ToTable("Option");

                entity.Property(e => e.IdOption).HasColumnName("idOption");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
            });

            modelBuilder.Entity<CarShowroom>(entity =>
            {
                entity.HasKey(e => e.IdShowroom);

                entity.ToTable("Showroom");

                entity.Property(e => e.IdShowroom).HasColumnName("idShowroom");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
                entity.Property(e => e.Address).HasColumnName("Address").HasMaxLength(45);
                entity.Property(e => e.Phone).HasColumnName("Phone").HasMaxLength(20);
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(45);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.IdState);

                entity.ToTable("State");

                entity.Property(e => e.IdState).HasColumnName("idState");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
            });

            modelBuilder.Entity<StateElement>(entity =>
            {
                entity.HasKey(e => e.IdStateElement);

                entity.ToTable("StateElement");

                entity.Property(e => e.IdStateElement).HasColumnName("idStateElement");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
                entity.Property(e => e.VinNumber).HasColumnName("vin-number").HasMaxLength(20);
                entity.Property(e => e.IdState).HasColumnName("IdState");

                entity.HasOne(d => d.IdCarNavigation)
                .WithMany()
                .HasForeignKey(d => d.VinNumber);
                entity.HasOne(d => d.IdStateNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdState);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.IdModel);

                entity.ToTable("Model");

                entity.Property(e => e.IdModel).HasColumnName("idModel");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(45);
                entity.Property(e => e.IdBody).HasColumnName("IdBody");
                entity.Property(e => e.IdBrand).HasColumnName("IdBrand");
                entity.Property(e => e.IdClass).HasColumnName("IdClass");
                entity.Property(e => e.IdEngine).HasColumnName("IdEngine");
                entity.Property(e => e.IdGearbox).HasColumnName("IdGearbox");
                entity.Property(e => e.IdGeneration).HasColumnName("IdGeneration");

                entity.HasOne(d => d.IdBodyNavigation)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.IdBody);
                entity.HasOne(d => d.IdBrandNavigation)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.IdBrand);
                entity.HasOne(d => d.IdClassNavigation)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.IdClass);
                entity.HasOne(d => d.IdEngineNavigation)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.IdEngine);
                entity.HasOne(d => d.IdGearboxNavigation)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.IdGearbox);
                entity.HasOne(d => d.IdGenerationNavigation)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.IdGeneration);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("IdUser");
                entity.Property(e => e.UserName).HasColumnName("UserName").HasMaxLength(45);
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(45);
                entity.Property(e => e.Phone).HasColumnName("Phone").HasMaxLength(16);
                entity.Property(e => e.Password).HasColumnName("Password").HasMaxLength(100);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasKey(e => e.IdWishlist);

                entity.ToTable("Wishlist");

                entity.Property(e => e.IdWishlist).HasColumnName("IsWishlist");
                entity.Property(e => e.Date).HasColumnName("Date");
                entity.Property(e => e.IdUser).HasColumnName("IdUser");
                entity.Property(e => e.IdCar).HasColumnName("vin-number").HasMaxLength(20);

                entity.HasOne(d => d.IdUserNavigation)
                .WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.IdUser);
                entity.HasOne(d => d.IdCarNavigation)
                .WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.IdCar);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
