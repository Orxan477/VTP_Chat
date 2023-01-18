using Microsoft.AspNetCore.Mvc;

namespace VTP_Chat.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
