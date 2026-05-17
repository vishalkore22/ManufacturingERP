using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class TrRequirementCollectionsService : ITrRequirementCollectionsService
    {
        private readonly ITrRequirementCollectionsRepository _trRequirementCollectionsRepository;

        public TrRequirementCollectionsService(ITrRequirementCollectionsRepository trRequirementCollectionsRepository)
        {
            _trRequirementCollectionsRepository = trRequirementCollectionsRepository;
        }

        public async Task<List<TrRequirementCollection>> GetAllRequirementCollectionsAsync()
        {
            var requirementCollections =await _trRequirementCollectionsRepository.GetAllRequirementCollectionsAsync();
            return requirementCollections;
        }
    }
}
