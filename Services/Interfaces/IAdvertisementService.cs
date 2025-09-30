using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAdvertisementService
{
    Task<AdvertisementRequest> CreateRequestAsync(AdvertisementRequestForCreateDto dto, string userId);
    Task<IEnumerable<AdvertisementRequest>> GetPendingRequestsAsync();
    Task<AdvertisementRequest?> GetByIdAsync(int id);
    Task ReviewRequestAsync(int id, bool approve);
}
