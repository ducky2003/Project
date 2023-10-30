using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
namespace Project.Components
{
    [ViewComponent( Name = "AboutUs")]
    public class AboutUsComponent : ViewComponent
    {
        private DataContext _dataContext;
        public AboutUsComponent(DataContext dataContext) { 
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _dataContext.AboutUss
                         where i.IsActive == true
                         select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
