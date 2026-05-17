using Manufacturing_Core.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Manufacturing_Core.Entity
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        //{ }

        //First Migration
        public DbSet<MAccountType> MAccountTypes { get; set; }
        public DbSet<MBank> MBanks { get; set; }        
        public DbSet<MLedger> MLedgers { get; set; }
        public DbSet<MAddress> MAddresses { get; set; }

        //Second Migration
        public DbSet<MType> MTypes { get; set; }

        //Third Migration
        public DbSet<MCategory> MCategory { get; set; }

        //Fourth Migration
        public DbSet<MSubcategory> MSubcategory { get; set; }

        //sixt th Migeation
        public DbSet<MBooks> MBooks { get; set; }

        public DbSet<MAuthors> Authors { get; set; }

        //seventh Migration
        public DbSet<MItem> MItems { get; set; }

        //eight Migration
        public DbSet<MProduct> MProducts { get; set; }

        public DbSet<MMetarial> MMetarials { get; set; }

        //nineth Migration
        public DbSet<MSupplier> MSuppliers { get; set; }
        
        //public DbSet<MSupplierViewModel> mSupplierViewModels { get; set; }

        //Eleventh Migration
        public DbSet<TrPORequirementCollection> TrPORequirementCollections { get; set; }
        public DbSet<MPurchaseOrder> MPurchaseOrders { get; set; }
        public DbSet<MPurchaseOrderDetails> MPurchaseOrderDetails { get; set; }
        public DbSet<TrInventoryTransaction> TrInventoryTransaction { get; set; }
        public DbSet<TrRequirementCollection> TrRequirementCollections { get; set; }
        public DbSet<MWarehouses> MWarehouses { get; set; }
        public DbSet<MLocation> MLocations { get; set; }
        public DbSet<TrInventory> TrInventories { get; set; }
        public DbSet<TrStockLedger> TrStockLedgers { get; set; }
        public DbSet<TrCurrentStock> TrCurrentStocks { get; set; }
        public DbSet<TrInventoryTransaction> TrInventoryTransactions { get; set; }
        public DbSet<TrInventoryViewModel> TrInventoryViewModels { get; set; }
        public DbSet<TrStockGoodsORScrap> TrStockGoodsORScrap { get; set; }
        public DbSet<TrStockGoodsAsPerSupplier> TrStockGoodsAsPerSuppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=VISHAL\\SQLEXPRESS;Initial Catalog=ManufacturingERP111;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(x => x.UserName)
                .HasMaxLength(100);

            builder.Ignore<SelectListItem>();  // 🔥 Fix
        
            foreach (var fk in builder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.NoAction;
            }            

            builder.Entity<MBank>()
                .HasOne(b => b.MAccountTypes)
                .WithMany(a => a.MBanks)
                .HasForeignKey(b => b.FkAccountTypeId);

             builder.Entity<MSubcategory>()
                .HasOne(x => x.MType)
                .WithMany(y => y.Subcategories)
                .HasForeignKey(x => x.FkTypeId)
                .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<MSubcategory>()
                .HasOne(x => x.MCategory)
                .WithMany(y => y.Subcategories)
                .HasForeignKey(x => x.FkCatId)
                .OnDelete(DeleteBehavior.Cascade); // only this one cascades

            builder.Entity<TrCurrentStock>()
                .HasKey(x => new { x.MaterialId, x.WarehouseId });

            builder.Entity<TrInventory>()
                .HasKey(x => new { x.MaterialId, x.WarehouseId, x.TransactionDate });

            builder.Entity<TrStockLedger>()
                .HasKey(x => new { x.MaterialId, x.WarehouseId, x.TransactionDate });

            builder.Entity<TrCurrentStock>()
                .HasOne<MWarehouses>()
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction); // 🔥 FIX

            builder.Entity<TrCurrentStock>()
                .HasOne<MMetarial>() // if exists
                .WithMany()
                .HasForeignKey(x => x.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TrCurrentStock>()
                .HasOne<MWarehouses>()
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction); // 🔥 Important

            builder.Entity<TrInventory>()
                .HasOne<MWarehouses>()
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TrStockLedger>()
                .HasOne<MWarehouses>()
                .WithMany()
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<TrInventory>()
                .HasOne<MWarehouses>()
                .WithMany()
                .HasForeignKey(x => x.WarehouseId);

        }
    }
}
