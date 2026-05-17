using Manufacturing_Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Interfaces
{
    public interface ITrRequirementCollectionsService
    {
        Task<List<TrRequirementCollection>> GetAllRequirementCollectionsAsync();
    }
}
