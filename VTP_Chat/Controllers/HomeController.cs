using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VTP_Chat.DAL;
using VTP_Chat.Hubs;
using VTP_Chat.Models;
using VTP_Chat.VM;

namespace VTP_Chat.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AppDbContext _context;
        private IHubContext<ChatHub> _hub;

        public HomeController(AppDbContext context,IHubContext<ChatHub> hub)
        {
            _context = context;
            _hub = hub;

        }
        
        public async Task<IActionResult> Index(string num)
        {
            //Group dbGroup = await _context.Groups.Where(x => x.Value == num).FirstOrDefaultAsync();
            //List<Chat> dbChat = await _context.Chats.Include(x => x.Group).Where(x => x.GroupId == 1).ToListAsync();
            //return Json(dbGroup);
            //var group = _context.Groups.Where(x => x.Value == num).FirstOrDefaultAsync();
            //if (group is null) return NotFound();
            HomeVM home = new HomeVM()
            {
                Groups = await _context.Groups.ToListAsync(),
                //Chats = await _context.Chats.Where(x => !x.IsDeleted && x.Group.Id == 1).Include(x => x.AppUser).ToListAsync(),
            };
            return View(home);
        }
        //public IActionResult CurrentMessages(string gr) 
        //{
        //    return Json(gr);
        //}
    }
}