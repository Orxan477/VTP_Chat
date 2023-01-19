using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTP_Chat.DAL;
using VTP_Chat.VM;

namespace VTP_Chat.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index(string? num)
        {
            //var group = _context.Groups.Where(x => x.Value == num).FirstOrDefaultAsync();
            //if (group is null) return NotFound();
            HomeVM home = new HomeVM()
            {
                Groups = _context.Groups.ToList(),
                Chats = _context.Chats.Where(x => !x.IsDeleted && x.Group.Id == 1).Include(x=>x.AppUser).ToList(),
            };
            return View(home);
        }
        public IActionResult Clear() { }
    }
}