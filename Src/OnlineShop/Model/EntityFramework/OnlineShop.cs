namespace Model.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base("name=OnlineShop")
        {
        }

        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<AdvertisementPage> AdvertisementPages { get; set; }
        public virtual DbSet<AdvertisementPosition> AdvertisementPositions { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributeValue> AttributeValues { get; set; }
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductLink> ProductLinks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Action>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Action>()
                .HasMany(e => e.Functions)
                .WithMany(e => e.Actions)
                .Map(m => m.ToTable("ActionInFunctions").MapLeftKey("ActionId").MapRightKey("FunctionId"));

            modelBuilder.Entity<AdvertisementPage>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AdvertisementPage>()
                .HasMany(e => e.AdvertisementPositions)
                .WithRequired(e => e.AdvertisementPage)
                .HasForeignKey(e => e.PageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdvertisementPage>()
                .HasMany(e => e.Advertisements)
                .WithRequired(e => e.AdvertisementPage)
                .HasForeignKey(e => e.PageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdvertisementPosition>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AdvertisementPosition>()
                .Property(e => e.PageId)
                .IsUnicode(false);

            modelBuilder.Entity<AdvertisementPosition>()
                .HasMany(e => e.Advertisements)
                .WithRequired(e => e.AdvertisementPosition)
                .HasForeignKey(e => e.PositionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Advertisement>()
                .Property(e => e.PositionId)
                .IsUnicode(false);

            modelBuilder.Entity<Advertisement>()
                .Property(e => e.PageId)
                .IsUnicode(false);

            modelBuilder.Entity<AttributeValue>()
                .HasMany(e => e.ProductAttributes)
                .WithRequired(e => e.AttributeValue)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalog>()
                .Property(e => e.SeoAlias)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.SeoAlias)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories1)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("PostInCategories").MapLeftKey("CategoryId").MapRightKey("PostId"));

            modelBuilder.Entity<Footer>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Function>()
                .HasMany(e => e.Functions1)
                .WithOptional(e => e.Function1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Function>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Function)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("PostInTags").MapLeftKey("PostId").MapRightKey("TagId"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductAttributes)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductLinks)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductLinks1)
                .WithOptional(e => e.Product1)
                .HasForeignKey(e => e.LinkedProductId);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<Setting>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
