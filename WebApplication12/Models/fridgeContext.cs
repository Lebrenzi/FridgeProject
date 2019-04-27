using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication12.Models
{
    public partial class fridgeContext : DbContext
    {
        public fridgeContext()
        {
        }

        public fridgeContext(DbContextOptions<fridgeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accesstype> Accesstype { get; set; }
        public virtual DbSet<Categoryitempattern> Categoryitempattern { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Itempattern> Itempattern { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<Shelf> Shelf { get; set; }
        public virtual DbSet<Shelftype> Shelftype { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Apollo11;database=fridge");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Accesstype>(entity =>
            {
                entity.ToTable("accesstype", "fridge");

                entity.HasIndex(e => e.Type)
                    .HasName("type")
                    .IsUnique();

                entity.Property(e => e.AccessTypeId)
                    .HasColumnName("accessTypeId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categoryitempattern>(entity =>
            {
                entity.ToTable("categoryitempattern", "fridge");

                entity.HasIndex(e => e.StorageId)
                    .HasName("storageId");

                entity.Property(e => e.CategoryItemPatternId)
                    .HasColumnName("categoryItemPatternId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CurrentQuantity)
                    .HasColumnName("currentQuantity")
                    .HasColumnType("decimal(3,0)");

                entity.Property(e => e.ExpectedQuantity)
                    .HasColumnName("expectedQuantity")
                    .HasColumnType("decimal(3,0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShopingFrequency)
                    .HasColumnName("shopingFrequency")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.StorageId)
                    .HasColumnName("storageId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Categoryitempattern)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("categoryitempattern_ibfk_1");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item", "fridge");

                entity.HasIndex(e => e.ItemPatterId)
                    .HasName("itemPatterId");

                entity.HasIndex(e => e.ShelfId)
                    .HasName("shelfId");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expirationDate")
                    .HasColumnType("date");

                entity.Property(e => e.IsOpen)
                    .HasColumnName("isOpen")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.ItemPatterId)
                    .HasColumnName("itemPatterId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ShelfId)
                    .HasColumnName("shelfId")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.ItemPatter)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ItemPatterId)
                    .HasConstraintName("item_ibfk_2");

                entity.HasOne(d => d.Shelf)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ShelfId)
                    .HasConstraintName("item_ibfk_1");
            });

            modelBuilder.Entity<Itempattern>(entity =>
            {
                entity.ToTable("itempattern", "fridge");

                entity.HasIndex(e => e.CategoryItemPatternId)
                    .HasName("categoryItemPatternId");

                entity.Property(e => e.ItemPatternId)
                    .HasColumnName("itemPatternId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.BarCode)
                    .HasColumnName("barCode")
                    .HasColumnType("decimal(13,0)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasColumnType("decimal(3,0)");

                entity.Property(e => e.CategoryItemPatternId)
                    .HasColumnName("categoryItemPatternId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.LongLife)
                    .HasColumnName("longLife")
                    .HasColumnType("decimal(3,0)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("decimal(5,0)");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryItemPattern)
                    .WithMany(p => p.Itempattern)
                    .HasForeignKey(d => d.CategoryItemPatternId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("itempattern_ibfk_1");
            });

            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.ToTable("privilege", "fridge");

                entity.HasIndex(e => e.AccessTypeId)
                    .HasName("accessTypeId");

                entity.HasIndex(e => e.StorageId)
                    .HasName("storageId");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.PrivilegeId)
                    .HasColumnName("privilegeId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.AccessTypeId)
                    .HasColumnName("accessTypeId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.StorageId)
                    .HasColumnName("storageId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.Privilege)
                    .HasForeignKey(d => d.AccessTypeId)
                    .HasConstraintName("privilege_ibfk_3");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Privilege)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("privilege_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Privilege)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("privilege_ibfk_1");
            });

            modelBuilder.Entity<Shelf>(entity =>
            {
                entity.ToTable("shelf", "fridge");

                entity.HasIndex(e => e.ShelfTypeId)
                    .HasName("shelfTypeId");

                entity.HasIndex(e => e.StorageId)
                    .HasName("storageId");

                entity.Property(e => e.ShelfId)
                    .HasColumnName("shelfId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasColumnType("decimal(3,0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfTypeId)
                    .HasColumnName("shelfTypeId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.StorageId)
                    .HasColumnName("storageId")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.ShelfType)
                    .WithMany(p => p.Shelf)
                    .HasForeignKey(d => d.ShelfTypeId)
                    .HasConstraintName("shelf_ibfk_2");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Shelf)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("shelf_ibfk_1");
            });

            modelBuilder.Entity<Shelftype>(entity =>
            {
                entity.ToTable("shelftype", "fridge");

                entity.HasIndex(e => e.Type)
                    .HasName("type")
                    .IsUnique();

                entity.Property(e => e.ShelfTypeId)
                    .HasColumnName("shelfTypeId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("storage", "fridge");

                entity.Property(e => e.StorageId)
                    .HasColumnName("storageId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "fridge");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.Login)
                    .HasName("login")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });
        }
    }
}
