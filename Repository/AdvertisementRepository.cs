using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AdvertisementRepository : IAdvertisementRepository
{
    private readonly DataContext _context;

    public AdvertisementRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<AdvertisementRequest> AddAsync(AdvertisementRequest request)
    {
        _context.AdvertisementRequests.Add(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public async Task<AdvertisementRequest?> GetByIdAsync(int id)
    {
        return await _context.AdvertisementRequests
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<AdvertisementRequest>> GetPendingAsync()
    {
        return await _context.AdvertisementRequests
            .Include(a => a.User)
            .Where(a => a.IsApproved == null)
            .ToListAsync();
    }

    public async Task UpdateAsync(AdvertisementRequest request)
    {
        _context.AdvertisementRequests.Update(request);
        await _context.SaveChangesAsync();
    }
}
