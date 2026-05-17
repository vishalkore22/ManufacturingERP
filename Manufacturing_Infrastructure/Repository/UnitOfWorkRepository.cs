using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufacturing_Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWorkRepository(ApplicationDBContext context)
        {
            _context = context;
        }        
    }
}
