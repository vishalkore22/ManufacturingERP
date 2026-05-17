using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class SupplierRepository :ISupplierRepository
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public SupplierRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<int?> GetSupplierId()
        {
            var supplierId = await _applicationDBContext.MSuppliers.MaxAsync(x => (int?)x.PkSupId) == null ? 0 : await _applicationDBContext.MSuppliers.MaxAsync(x => (int)x.PkSupId);
            if (supplierId != null)
            {
                return supplierId+1;
            }
            return 0;
        }

        public async Task<string> GetSupplierCodeById()
        {
            var supplierId = await _applicationDBContext.MSuppliers.MaxAsync(x => (int?)x.PkSupId) == null ? 0 : await _applicationDBContext.MSuppliers.MaxAsync(x => (int)x.PkSupId);
            string suppCode = "";
            if (supplierId == null || supplierId==0)
            {
                suppCode = "SC001"; 
                return suppCode;
            }
            else
            {
                supplierId = supplierId + 1;
                suppCode = "SC00" + supplierId;
                return suppCode;
            }
            return "";
        }

        public async Task<List<MSupplier>> GetAllSuppliersAsync()
        {
            return await _applicationDBContext.MSuppliers.ToListAsync();
        }

        public async Task<int> SaveSupplierAsync(MSupplierViewModel model)
        {
            await _applicationDBContext.MSuppliers.AddAsync(model.MSupplier);
            await _applicationDBContext.SaveChangesAsync();
            return model.MSupplier.PkSupId;
        }

        //public async Task<List<MSupplier>> GetSupplierInfo()
        //{
        //    var supplierList = await _applicationDBContext.MSuppliers.ToListAsync();
        //    return supplierList;
        //}

        public async Task<List<MSupplier>> GetSupplierInfo()
        {
            //var supplierList = new List<MSupplierViewModel>();
            var supplierList =await (from c in _applicationDBContext.MSuppliers                              
                               select new MSupplier
                                {
                                  PkSupId=c.PkSupId,
                                  SupplierCode=c.SupplierCode,
                                  SupplierName=c.SupplierName                                  
                                }).ToListAsync();
            if (supplierList != null)
            {
                return supplierList;
            }
            return null;
        }

        public async Task<int?> GetAddressMaxIdAsync()
        {
            var fkAddressId = await _applicationDBContext.MAddresses.MaxAsync(x => (int?)x.PkAddressId) == null ? 0 : await _applicationDBContext.MAddresses.MaxAsync(x => (int?)x.PkAddressId);
            fkAddressId = fkAddressId + 1;

            return fkAddressId;
        }

        public async Task<int> SaveSupplierAddressInformationAsync(MSupplierViewModel model)
        {
            await _applicationDBContext.MAddresses.AddAsync(model.mAddress);
            var pksupplierId=await _applicationDBContext.SaveChangesAsync();
            return pksupplierId;
        }

        public async Task<MSupplier> GetSupplierInfoById(int id)
        {
            //var supplierInfo= await _applicationDBContext.MSuppliers.Where(x=>x.PkSupId==id).FirstOrDefaultAsync();
            var supplierInfo= await(from c in _applicationDBContext.MSuppliers
                              where c.PkSupId == id
                              select new MSupplier
                              {
                                  PkSupId = c.PkSupId,
                                  SupplierCode = c.SupplierCode,
                                  SupplierName = c.SupplierName,
                                  ShortName = c.ShortName,
                                  LicenceId = c.LicenceId,
                                  VATNo = c.VATNo,
                                  CSTNo = c.CSTNo,
                                  TINno = c.TINno,
                                  GSTIn= c.GSTIn
                              }).FirstOrDefaultAsync();


            if (supplierInfo != null)
            {
                return supplierInfo;
            }
            return null;
        }

        public async Task<MAddress> GetSupplierAddressById(int id)
        {
            var supplierAddress = await _applicationDBContext.MAddresses.FirstOrDefaultAsync(x=>x.FkSupId==id);
            if (supplierAddress != null)
            {
                return supplierAddress;
            }
            return null;
        }

        public async Task<int> UpdateSupplierdetailsAsync(MSupplierViewModel model)
        {
            _applicationDBContext.MSuppliers.Update(model.MSupplier);
            var UpdateSupp = await _applicationDBContext.SaveChangesAsync();
            return UpdateSupp;
        }

        public async Task<int> UpdateSupplierAddressByIdAsync(MSupplierViewModel ModelAdd)
        {
            _applicationDBContext.MAddresses.Update(ModelAdd.mAddress);
            var result = await _applicationDBContext.SaveChangesAsync();

            if (result > 0)
            {
                return result;
            }
            return 0;
        }

        public async Task<int> DeleteSupplierInformationByIdAsync(int id)
        {
            var model = new MSupplier()
            {
                PkSupId = id
            };
            _applicationDBContext.MSuppliers.Remove(model);
            var result= await _applicationDBContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteSuppAddressByIdAsync(int id)
        {
            var model= (from a in _applicationDBContext.MAddresses
                       where a.FkSupId==id
                       select a).FirstOrDefault();
            _applicationDBContext.MAddresses.Remove(model);
            var result= await _applicationDBContext.SaveChangesAsync();

            return result;
        }
    }
}
