using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VTP_Chat.DAL;
using VTP_Chat.Models;

namespace VTP_Chat.Hubs
{
    public class ChatHub : Hub
    {
        private AppDbContext _context;
        private UserManager<AppUser> _userManager;

        public ChatHub(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task SendMessage(string user, string group, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
            var dbGroup = await _context.Groups.Where(x => x.Value == group).FirstOrDefaultAsync();
            if (dbGroup is null) throw new BadHttpRequestException("error");
            var dbUser = await _userManager.FindByNameAsync(user);
            if (dbUser is null) throw new BadHttpRequestException("error");
            Chat chat = new Chat()
            {
                GroupId = dbGroup.Id,
                Date = DateTime.Now,
                AppUserId = dbUser.Id,
                IsDeleted = false,
                Message = message,
            };
            await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();
        }
        public async Task AddGroupAsync(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }
        public async Task RemoveGroupAsync(string group)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }
    }
}
