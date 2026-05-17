using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class TrRequirementCollectionsRepository : ITrRequirementCollectionsRepository
    {

        private readonly ApplicationDBContext _context;

        public TrRequirementCollectionsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<TrRequirementCollection>> GetAllRequirementCollectionsAsync()
        {
            var requirementCollections = await (from c in _context.TrRequirementCollections
                                                select new TrRequirementCollection
                                                {
                                                    RequirementCollectionId = c.RequirementCollectionId,
                                                    DepartmentId = c.DepartmentId,
                                                    DepartmentName = c.DepartmentName,
                                                    JobId = c.JobId,
                                                    Designation = c.Designation,
                                                    
                                                }).ToListAsync();
       
            return requirementCollections;
        }
    }
}
