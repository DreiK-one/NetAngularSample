using InspectionAPI.Core.Interfaces;
using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Domain.Services
{
    public class InspectionTypeService : IInspectionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InspectionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InspectionType> GetInspectionTypeById(int id)
        {
            try
            {
                return await _unitOfWork.InspectionTypes.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<InspectionType>> GetInspectionTypes()
        {
            try
            {
                return await _unitOfWork.InspectionTypes.GetAll().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateInspectionType(InspectionType inspectionType)
        {
            try
            {
                if (inspectionType != null)
                {
                    await _unitOfWork.InspectionTypes.Add(inspectionType);
                    return await _unitOfWork.Save();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateInspectionType(InspectionType inspectionType)
        {
            try
            {
                if (inspectionType != null)
                {
                    await _unitOfWork.InspectionTypes.Update(inspectionType);
                    return await _unitOfWork.Save();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteInspectionType(int id)
        {
            try
            {
                var status = await _unitOfWork.InspectionTypes.GetById(id);

                if (status != null)
                {
                    await _unitOfWork.InspectionTypes.Remove(status.Id);
                    return await _unitOfWork.Save();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }  
    }
}
