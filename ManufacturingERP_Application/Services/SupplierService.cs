using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<int?> GetSupplierId()
        {
            var supplierId = await _supplierRepository.GetSupplierId();

            if (supplierId != null)
            {
                return supplierId;
            }
            return 0;
        }

        public async Task<string> GetSupplierCodeById()
        {
            var suppCode = await _supplierRepository.GetSupplierCodeById();
            return suppCode;
        }

        public async Task<int> SaveSupplierAsync(MSupplierViewModel model)
        {
            var suppId = await _supplierRepository.SaveSupplierAsync(model);
            return suppId;
        }

        public async Task<List<MSupplier>> GetSupplierInfo()
        {
            var supplierList = await _supplierRepository.GetSupplierInfo();
            return supplierList;
        }

        public async Task<int?> GetAddressMaxIdAsync()
        {
            var fkaddressId = await _supplierRepository.GetAddressMaxIdAsync();

            if (fkaddressId > 0)
            {
                return fkaddressId;
            }
            return 0;
        }

        public async Task<int> SaveSupplierAddressInformationAsync(MSupplierViewModel model)
        {
            var addressId = await _supplierRepository.SaveSupplierAddressInformationAsync(model);
            return addressId;
        }

        public async Task<MSupplier> GetSupplierInfoById(int id)
        {
            var supplierInfo = await _supplierRepository.GetSupplierInfoById(id);
            return supplierInfo;
        }

        public async Task<MAddress> GetSupplierAddressById(int id)
        {
            var address = await _supplierRepository.GetSupplierAddressById(id);
            return address;
        }

        public async Task<int> UpdateSupplierdetailsAsync(MSupplierViewModel model)
        {
            var updtsupp = await _supplierRepository.UpdateSupplierdetailsAsync(model);
            return updtsupp;
        }

        public async Task<int> UpdateSupplierAddressByIdAsync(MSupplierViewModel ModelAdd)
        {
            var updateAddress= await _supplierRepository.UpdateSupplierAddressByIdAsync(ModelAdd);
            return updateAddress;
        }

        public async Task<int> DeleteSupplierInformationByIdAsync(int id)
        {
            var supplierInfo = await _supplierRepository.DeleteSupplierInformationByIdAsync(id);
            return supplierInfo;
        }

        public async Task<int> DeleteSuppAddressByIdAsync(int id)
        {
            var supplierAddress = await _supplierRepository.DeleteSuppAddressByIdAsync(id);
            return supplierAddress;
        }
    }
}
