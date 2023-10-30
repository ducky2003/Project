using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class TipController : Controller
    {
        private readonly DataContext _dataContext;
        public TipController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.TravelTipss.OrderBy(m => m.TipID).ToList();
            return View(query);
        }
        [HttpGet]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var m = await _dataContext.TravelTipss.FindAsync(id);
            if (m == null)
            {
                return NotFound();

            }
            return View(m);
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var delTip = _dataContext.TravelTipss.Find(id);
            if (delTip == null)
            {
                return
                    NotFound();
            }
            _dataContext.TravelTipss.Remove(delTip);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var query = (from i in _dataContext.TravelTipss
                         select new SelectListItem()
                         {
                             Text = i.TipTitle,
                             Value = i.TipID.ToString(),
                         }).ToList();
            query.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });
            ViewBag.query = query;
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(TravelTip tl)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.TravelTipss.AddAsync(tl);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tl);
        }
    }
}
