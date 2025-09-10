

using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;
namespace Bridgeline.Automation.Application.UseCases.Statuses
{
    public class GetStatusUseCase
    {
        private readonly IStatusRepository _statusRepository;
        public GetStatusUseCase(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public async Task<Status> ExecuteAsync (Guid id)
        {
            return await _statusRepository.GetStatus(id);
        }
    }
}
