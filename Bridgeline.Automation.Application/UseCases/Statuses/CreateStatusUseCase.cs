using Bridgeline.Automation.Application.DTOs.Statuses;
using Bridgeline.Automation.Domain.entities;
using Bridgeline.Automation.Domain.Interfaces.Repositories;


namespace Bridgeline.Automation.Application.UseCases.Statuses
{
    public class CreateStatusUseCase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly FindByNameStatusUseCase _findByNameStatusUseCase;

        public CreateStatusUseCase(IStatusRepository statusRepository, FindByNameStatusUseCase findByNameStatusUseCase)
        {
            _statusRepository = statusRepository;
            _findByNameStatusUseCase = findByNameStatusUseCase;
        }

        public async Task<Status> ExecuteAsync(PostStatusDto status)

        {

            if (!string.IsNullOrEmpty(status.Name))
            {
                var existingName = await _findByNameStatusUseCase.ExecuteAsync(status.Name);

                if (existingName != null)
                {
                    throw new Exception("The name already exists");
                }
            }

            var data = await _statusRepository.PostStatus(
                new Status
                {
                    Name = status.Name,
                    CreatedAt = DateTime.UtcNow,
                });
            return data;
        }
    }
}
