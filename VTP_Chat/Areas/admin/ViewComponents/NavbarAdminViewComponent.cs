using Microsoft.AspNetCore.Mvc;

namespace VTP_Chat_Admin.ViewComponents
{
    public class NavbarAdminViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
