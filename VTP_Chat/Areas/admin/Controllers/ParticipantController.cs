using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VTP_Chat.Areas.admin.ViewModels;
using VTP_Chat.Areas.admin.ViewModels.Participant;
using VTP_Chat.DAL;
using VTP_Chat.Models;

namespace VTP_Chat.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class ParticipantController : Controller
    {
        private AppDbContext _context;

        public ParticipantController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.TakeCount = 6;
            var products = _context.Users.Skip((page - 1) * 6)
                                .Take(6).OrderByDescending(x => x.Id).ToList();

            var productsVM = GetProductList(products);
            int pageCount = GetPageCount(6);
            Paginate<ParticipantVM> model = new Paginate<ParticipantVM>(productsVM, page, pageCount);
            return View(model);
        }
        private int GetPageCount(int take)
        {
            var prodCount = _context.Users.Count();
            return (int)Math.Ceiling((decimal)prodCount / take);
        }
        private List<ParticipantVM> GetProductList(List<AppUser> user)
        {
            List<ParticipantVM> model = new List<ParticipantVM>();
            foreach (var item in user)
            {
                ParticipantVM userList = new ParticipantVM()
                {
                    Id=item.Id,
                    UserName=item.UserName,
                    FullName=item.FullName,
                    Email=item.Email,
                    IsActivated=item.IsActivated,
                };
                model.Add(userList);
            }
            return model;
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            AppUser dbUser = _context.Users.Where(x => x.Id == id && !x.IsActivated).FirstOrDefault();
            if (dbUser is null) return NotFound();
            dbUser.IsActivated = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }   
    }
}
