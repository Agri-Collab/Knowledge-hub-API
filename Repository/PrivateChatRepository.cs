using api.Data;
using api.Models;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class PrivateChatRepository : IPrivateChatRepository
    {
        private readonly DataContext _context;

        public PrivateChatRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PrivateChat> GetOrCreateChatAsync(int user1Id, int user2Id)
        {
            var chat = await _context.PrivateChats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c =>
                    (c.User1Id == user1Id && c.User2Id == user2Id) ||
                    (c.User1Id == user2Id && c.User2Id == user1Id));

            if (chat != null)
                return chat;

            var newChat = new PrivateChat
            {
                User1Id = user1Id,
                User2Id = user2Id
            };

            _context.PrivateChats.Add(newChat);
            await _context.SaveChangesAsync();

            return newChat;
        }

        public async Task<IEnumerable<PrivateChat>> GetChatsForUserAsync(int userId)
        {
            return await _context.PrivateChats
                .Where(c => c.User1Id == userId || c.User2Id == userId)
                .Include(c => c.Messages)
                .ToListAsync();
        }

        public async Task<PrivateChat> GetChatByIdAsync(int chatId)
        {
            return await _context.PrivateChats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == chatId);
        }
    }
}
