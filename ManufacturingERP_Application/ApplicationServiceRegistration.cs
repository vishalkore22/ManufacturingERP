using ManufacturingERP_Application.Interfaces;
using ManufacturingERP_Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ManufacturingERP_Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {            
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ILedgerService, LedgerService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ITrPORequirementService, TrPORequirementService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<ITrInventoryTransectionService, TrInventoryTransectionService>();
            services.AddScoped<ITrRequirementCollectionsService, TrRequirementCollectionsService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IStockLedgerService, StockLedgerService>();
            services.AddScoped<ICurrentStockService, CurrentStockService>();
            services.AddScoped<IUnitOfWorkServices, UnitOfWorkService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ITrInventoryServices, TrInventoryServices>();
            services.AddScoped<ITrStockGoodsORScrapServices, TrStockGoodsORScrapServices>();
            return services;
        }
    }
}
