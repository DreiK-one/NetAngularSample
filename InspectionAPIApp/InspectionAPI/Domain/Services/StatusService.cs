using InspectionAPI.Core.Interfaces;
using InspectionAPI.Core.Interfaces.Data;
using InspectionAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Domain.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Status> GetStatusById(int id)
        {
            try
            {
                return await _unitOfWork.Statuses.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Status>> GetStatuses()
        {
            try
            {
                return await _unitOfWork.Statuses.GetAll().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateStatus(Status status)
        {
            try
            {
                if (status != null)
                {
                    await _unitOfWork.Statuses.Add(status);
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

        public async Task<int> UpdateStatus(Status status)
        {
            try
            {
                if (status != null)
                {
                    await _unitOfWork.Statuses.Update(status);
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

        public async Task<int> DeleteStatus(int id)
        {
            try
            {
                var status = await _unitOfWork.Statuses.GetById(id);

                if (status != null)
                {
                    await _unitOfWork.Statuses.Remove(status.Id);
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
