using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Statuses
{
    public class DeleteStatusUseCase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly GetStatusUseCase _getStatusUseCase;
        public DeleteStatusUseCase(IStatusRepository statusRepository, GetStatusUseCase getStatusUseCase)
        {
            _statusRepository = statusRepository;
            _getStatusUseCase = getStatusUseCase;
        }
        public async Task<bool> ExecuteAsync(Guid statusId)
        {
            var status = await _getStatusUseCase.ExecuteAsync(statusId);
            if (status == null)
            {
                throw new KeyNotFoundException("Status not found.");
            }
            await _statusRepository.DeleteStatus(statusId);
            return true;
        }
    }
}
