using Manufacturing_Core.Entity;
using ManufacturingERP_Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP_Application.Services
{
    public class TypeService: ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<List<MType>> GetAllType()
        {
            var type = await _typeRepository.GetAllType();

            if (type != null)
            {
                return type;
            }
            return null;
        }

        public async Task<string> GetTypeCode()
        {
            var type = await _typeRepository.GetTypeCode();

            if (type != null)
            {
                return type;
            }
            return null;
        }

        public async Task<int> SaveMTypeAsync(MType mType)
        {
            var result = await _typeRepository.SaveMTypeAsync(mType);

            if (result > 0)
            {
                return result;
            }

            return 0;
        }

        public async Task<MType> GetTypeByIdAsync(int id)
        {
            var type = await _typeRepository.GetTypeByIdAsync(id);
            if (type != null)
            {
                return type;
            }
            return null;
        }

        public async Task<int> UpdateTypeDetailsAsync(MType Mtype)
        {
            var type = await _typeRepository.UpdateTypeDetailsAsync(Mtype);
            if (type != null)
            {
                return type;
            }
            return 0;
        }

        public async Task<int> DeleteTypeDetailsAsync(int id)
        {
            var type = await _typeRepository.DeleteTypeDetailsAsync(id);
            if (type != null)
            {
                return type;
            }
            return 0;
        }

        public async Task<int?> GetTypeIdAsync()
        {
            var typeId = await _typeRepository.GetTypeIdAsync();

            if (typeId > 0)
            {
                return typeId;
            }
            return 0;
        }

        public async Task<string> GetTypeNameById(int id)
        {
            var typeName = await _typeRepository.GetTypeNameById(id);
            if (typeName != null)
            {
                return typeName;
            }
            return null;
        }
    }
}
