using InspectionAPI.Core.Interfaces;
using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Domain.Services
{
    public class InspectionService : IInspectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InspectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Inspection> GetInspectionById(int id)
        {
            try
            {
                return await _unitOfWork.Inspections.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Inspection>> GetInspections()
        {
            try
            {
                return await _unitOfWork.Inspections.GetAll().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateInspection(Inspection inspection)
        {
            try
            {
                if (inspection != null)
                {
                    await _unitOfWork.Inspections.Add(inspection);
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

        public async Task<int> UpdateInspection(Inspection inspection)
        {
            try
            {
                if (inspection != null)
                {
                    await _unitOfWork.Inspections.Update(inspection);
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

        public async Task<int> DeleteInspection(int id)
        {
            try
            {
                var status = await _unitOfWork.Inspections.GetById(id);

                if (status != null)
                {
                    await _unitOfWork.Inspections.Remove(status.Id);
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
