using Common.Utils;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.Repositories;
using Services.IServices;

namespace Services.Services
{
    public class RoutineService(ApplicationDbContext context, ILogger<RoutineService> logger) : IRoutineService
    {
        private readonly RoutineRepository _repository = new(context);
        public async Task<ResponseHelper> GetRoutinesAsync()
        {
            ResponseHelper response = new();
            try
            {
                List<Routine> routines = [];

                routines = await _repository.GetRoutinesAsync();

                if (routines.Any())
                {
                    response.IsSuccess = true;
                    response.Data = routines;
                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error: {ex.Message}", ex.Message);
            }

            return response;
        }
    }
}
