using Bridgeline.Automation.Application.DTOs.Statuses;
using Bridgeline.Automation.Application.Exceptions;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
using System.Data;

namespace Bridgeline.Automation.Application.UseCases.Statuses
{
    public class UpdateStatusUseCase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly FindByNameStatusUseCase _findByNameStatusUseCase;
        private readonly GetStatusUseCase _getStatusUseCase;
        public UpdateStatusUseCase(IStatusRepository statusRepository, FindByNameStatusUseCase findByNameStatusUseCase, GetStatusUseCase getStatusUseCase)
        {
            _statusRepository = statusRepository;
            _findByNameStatusUseCase = findByNameStatusUseCase;
            _getStatusUseCase = getStatusUseCase;
        }

        public async Task<Status> ExecuteAsync(Guid id, PutStatusDto status)
        {
     
            if(!string.IsNullOrEmpty(status.Name))
            {
                var existingStatus = await _findByNameStatusUseCase.ExecuteAsync(status.Name);
                if (existingStatus != null && existingStatus.Id != id)
                {
                    throw new ConflictException($"A status with name '{status.Name}' already exists");
                }
            }

            var data = new Status
            {
                Id = id,
                Name = status.Name,
                UpdatedAt = DateTime.UtcNow
            };

            return await _statusRepository.Update(data);
        }
    }
}
