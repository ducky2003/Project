using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private DataContext _dataContext;
        public AdminMenuComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _dataContext.AdminMenus
                         where i.IsActive == true select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
