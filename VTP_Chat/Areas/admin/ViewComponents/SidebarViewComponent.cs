using Microsoft.AspNetCore.Mvc;

namespace VTP_Chat_Admin.ViewComponents
{
    public class SidebarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
