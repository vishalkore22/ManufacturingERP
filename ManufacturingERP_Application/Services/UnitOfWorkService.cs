using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class UnitOfWorkService : IUnitOfWorkServices
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public UnitOfWorkService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this._unitOfWorkRepository = unitOfWorkRepository;
        }

        

    }
}
