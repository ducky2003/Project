using Microsoft.AspNetCore.Mvc;
using Project.Models;
namespace Project.Components
{
    [ViewComponent(Name = "TravelTip")]
    public class TravelTipComponents : ViewComponent
    {
        private DataContext _dataContext;
        public TravelTipComponents(DataContext dataContext) { 
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = (from i in _dataContext.TravelTipss
                         where i.IsActive == true
                         select i).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", query));
        }
    }
}
