using Bridgeline.Automation.Application.DTOs.Statuses;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

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

        public async Task<Status> ExecuteAsync(Guid id, PostStatusDto status)
        {
            var data = await _getStatusUseCase.ExecuteAsync(id);

            if (data == null)
            {
                throw new InvalidOperationException($"El estado con ID '{id}' no existe.");
            }

            if(!string.IsNullOrEmpty(status.Name))
            {
                var existingStatus = await _findByNameStatusUseCase.ExecuteAsync(status.Name);
                if (existingStatus != null && existingStatus.Id != id)
                {
                    throw new InvalidOperationException($"El estado con nombre '{status.Name}' ya existe.");
                }
            }

            data.Name = status.Name ?? data.Name;
            data.UpdatedAt = new DateTime();

            return await _statusRepository.PutStatus(data);
        }
    }
}
