using Common.Utils;

namespace Services.IServices
{
    public interface IRoutineService
    {
        Task<ResponseHelper> GetRoutinesAsync();
    }
}
