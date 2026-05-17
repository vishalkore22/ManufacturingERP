using Manufacturing_Core.Entity;
using Manufacturing_Infrastructure.Repository;
using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Manufacturing_Infrastructure
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<ILedgerRepository, LedgerRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITrPORequirementRepository, TrPORequirementRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<ITrInventoryTransectionRepository, TrInventoryTransectionRepository>();
            services.AddScoped<ITrRequirementCollectionsRepository, TrRequirementCollectionsRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IStockLedgerRepository, StockLedgerRepository>();
            services.AddScoped<ICurrentStockRepository, CurrentStockRepository>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ITrInventoryRepository, TrInventoryRepository>();
            services.AddScoped<ITrStockGoodsORScrapRepository, TrStockGoodsORScrapRepository>();
            return services;
        }
    }
}
