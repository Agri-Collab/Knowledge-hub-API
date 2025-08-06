using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class PrivateMessageRepository : IPrivateMessageRepository
    {
        private readonly DataContext _context;

        public PrivateMessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task SendMessageAsync(PrivateMessage message)
        {
            _context.PrivateMessages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrivateMessage>> GetMessagesForChatAsync(int chatId)
        {
            return await _context.PrivateMessages
                .Include(m => m.Sender)
                .Where(m => m.ChatId == chatId)
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }
    }
}
