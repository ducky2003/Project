using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Components
{
    [ViewComponent (Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private DataContext _dataContext;
        public MenuViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _dataContext.Menus
                         where i.IsActive == true && i.Position == 1
                         select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default",query));
        }
    }
}
