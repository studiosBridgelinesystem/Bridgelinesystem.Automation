using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Statuses
{
    public class GetStatusesUseCase
    {
        private readonly IStatusRepository _statusRepository;
        public GetStatusesUseCase(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public async Task<List<Status>> ExecuteAsync()
        {
            return await _statusRepository.GetAll();
        }
    }
}
