using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;

namespace Bridgeline.Automation.Application.UseCases.Statuses
{
    public class FindByNameStatusUseCase
    {
        private readonly IStatusRepository _statusRepository;
        public FindByNameStatusUseCase(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public async Task<Status> ExecuteAsync(string name)
        {
            return await _statusRepository.FindByName(name);
        }
    }
}
