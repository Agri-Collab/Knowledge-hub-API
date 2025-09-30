using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAdvertisementRepository
{
    Task<AdvertisementRequest> AddAsync(AdvertisementRequest request);
    Task<AdvertisementRequest?> GetByIdAsync(int id);
    Task<IEnumerable<AdvertisementRequest>> GetPendingAsync();
    Task UpdateAsync(AdvertisementRequest request);
}
