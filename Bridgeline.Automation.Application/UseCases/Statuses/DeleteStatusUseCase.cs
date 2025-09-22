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

            if (status !=null && status.IsActive == false)
            {
                throw new Exception("Status is already inactive and cannot be deleted.");
            }

            return await _statusRepository.Delete(statusId);
        }
    }
}
