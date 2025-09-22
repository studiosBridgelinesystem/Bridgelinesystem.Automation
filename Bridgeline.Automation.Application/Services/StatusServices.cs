
using Bridgeline.Automation.Application.DTOs.Statuses;
using Bridgeline.Automation.Application.Interfaces.Services;
using Bridgeline.Automation.Application.UseCases.Statuses;

namespace Bridgeline.Automation.Application.Services
{
    public  class StatusServices : IStatusServices
    {
        private readonly CreateStatusUseCase _createStatusUseCase;
        private readonly UpdateStatusUseCase _updateStatusUseCase;
        private readonly FindByNameStatusUseCase _findByNameStatusUseCase;
        private readonly GetStatusUseCase _getStatusUseCase;
        private readonly GetStatusesUseCase _getStatusesUseCase;
        private readonly DeleteStatusUseCase _deleteStatusUseCase;

        public StatusServices(
            CreateStatusUseCase createStatusUseCase,
            UpdateStatusUseCase updateStatusUseCase,
            FindByNameStatusUseCase findByNameStatusUseCase,
            GetStatusUseCase getStatusUseCase,
            GetStatusesUseCase getStatusesUseCase,
            DeleteStatusUseCase deleteStatusUseCase
            )
        {
            _createStatusUseCase = createStatusUseCase;
            _updateStatusUseCase = updateStatusUseCase;
            _findByNameStatusUseCase = findByNameStatusUseCase;
            _getStatusUseCase = getStatusUseCase;
            _getStatusesUseCase = getStatusesUseCase;
            _deleteStatusUseCase = deleteStatusUseCase;
        }   

        public async Task<ResponseStatusDto>CreateStatusService(PostStatusDto status)
        {
            var result = await _createStatusUseCase.ExecuteAsync(status);
            return new ResponseStatusDto
            {
                Id = result.Id,
                Name = result.Name
            };
        }
        public async Task<ResponseStatusDto> UpdateStatusService(Guid id, PutStatusDto status)
        {
            var result = await _updateStatusUseCase.ExecuteAsync(id, status);
            return new ResponseStatusDto
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public async Task<ResponseStatusDto> FindByNameStatusService(string name)
        {
            var result = await _findByNameStatusUseCase.ExecuteAsync(name);
            if (result == null) return null;
            return new ResponseStatusDto
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public async Task<ResponseStatusDto> GetStatusService(Guid id)
        {
            var result = await _getStatusUseCase.ExecuteAsync(id);
            if (result == null) return null;
            return new ResponseStatusDto
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public async Task<List<ResponseStatusDto>> GetStatusesService()
        {
            var results = await _getStatusesUseCase.ExecuteAsync();
            return results.Select(result => ResponseStatusDto.FromEntity(result)).ToList();
        }

        public async Task<bool> DeleteStatusService(Guid statusId)
        {
            return await _deleteStatusUseCase.ExecuteAsync(statusId);
        }
    }
}
