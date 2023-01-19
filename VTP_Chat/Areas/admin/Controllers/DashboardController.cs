using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VTP_Chat.DAL;
using VTP_Chat_Admin.ViewModels.Home;

namespace VTP_Chat_Admin.Controllers
{
        [Authorize(Roles = "Admin")]
    [Area("Admin")] 
    public class DashboardController : Controller
    {
        private AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM home = new HomeVM()
            {
                User = _context.Users.Count()
            };
            return View(home);
        }
    }
}