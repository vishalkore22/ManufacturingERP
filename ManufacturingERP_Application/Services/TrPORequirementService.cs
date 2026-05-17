using Manufacturing_Core.Entity;
using Manufacturing_Core.ViewModels;
using ManufacturingERP_Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class TrPORequirementService : ITrPORequirementService
    {
        private readonly ITrPORequirementRepository _repository;

        public TrPORequirementService(ITrPORequirementRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TrPORequirementCollection>> GetRequirementCollectionAsync()
        {
            var ReqColl = await _repository.GetRequirementCollectionAsync();
            if (ReqColl != null)
            {
                return ReqColl;
            }
            return null;
        }

        public async Task<int> GetRequirementIdAsync()
        {
            var reqid = await _repository.GetRequirementIdAsync();
            return reqid;
        }

        public async Task<string> GetWorkOrderNumber()
        {
            var wonum = await _repository.GetWorkOrderNumber();
            return wonum.ToString();
        }

        public async Task<string> GetBOMNumber()
        {
            var bomnum = await _repository.GetBOMNumber();
            return bomnum.ToString();
        }

        public async Task<List<SelectListItem>> BindMaterialDropDown()
        {
            var material = await _repository.BindMaterialDropDown();
            if (material != null)
            {
                return material;
            }

            return null;
        }

        public async Task<MMetarial> GetMatIdCodeNameAsync(int MaterialID)
        {
            var material = await _repository.GetMatIdCodeNameAsync(MaterialID);
            return material;
        }

        public async Task<int> SaveRequirementCollection(TrPORequirementCollection model)
        {
            var material = await _repository.SaveRequirementCollection(model);

            return material;
        }

        public async Task<int> UpdateTrRequirementCollectionAsync(TrPORequirementCollection model)
        {
            var updateTrReqColl = await _repository.UpdateTrRequirementCollectionAsync(model);
            return updateTrReqColl;
        }

        public async Task<TrPORequirementCollection> GetTrPORequirementCollectionById(int id)
        {
            var TrPoRequirementColl = await _repository.GetTrPORequirementCollectionById(id);
            return TrPoRequirementColl;
        }

        public async Task<int> DeleteTrPORequirementCollectionByIdAsync(int id)
        {
            var del = await _repository.DeleteTrPORequirementCollectionByIdAsync(id);
            return del;
        }

        public async Task<int> UpdateInventoryAsync(TrInventoryViewModel dto)
        {
            var updateInventory = await _repository.UpdateInventoryAsync(dto);
            return updateInventory;
        }
    }
}
