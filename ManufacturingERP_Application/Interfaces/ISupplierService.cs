using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ISupplierService
    {
        Task<int?> GetSupplierId();
        Task<string> GetSupplierCodeById();
        Task<List<MSupplier>> GetSupplierInfo();
        Task<int?> GetAddressMaxIdAsync();
        Task<int> SaveSupplierAsync(MSupplierViewModel model);

        Task<int> SaveSupplierAddressInformationAsync(MSupplierViewModel model);

        Task<MSupplier> GetSupplierInfoById(int id);

        Task<MAddress> GetSupplierAddressById(int id);

        Task<int> UpdateSupplierdetailsAsync(MSupplierViewModel model);

        Task<int> UpdateSupplierAddressByIdAsync(MSupplierViewModel ModelAdd);

        Task<int> DeleteSupplierInformationByIdAsync(int id);

        Task<int> DeleteSuppAddressByIdAsync(int id);
    }
}
