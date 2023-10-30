using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Areas.Admin.Models;
using Project.Models;
namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class MenuController : Controller
    {
        private readonly DataContext _dataContext;
        public MenuController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.Menus.OrderBy(m => m.MenuID).ToList();
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
            var m = await _dataContext.Menus.FindAsync(id);
            if (m == null)
            {
                return NotFound();

            }
            return View(m);
        }
        [HttpPost]
        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var delMenu = _dataContext.Menus.Find(id);
            if (delMenu == null)
            {
                return
                    NotFound();
            }
            _dataContext.Menus.Remove(delMenu);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var query = (from i in _dataContext.Menus
                         select new SelectListItem()
                         {
                             Text = i.MenuName,
                             Value = i.MenuID.ToString(),
                         }).ToList();
            query.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = "0"
            });
            ViewBag.query = query;
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Menu mn)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.Menus.AddAsync(mn);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        [HttpGet]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var sm = _dataContext.Menus.Find(id);
            if (sm == null)
                return NotFound();
            var query = (from i in _dataContext.Menus
                         select new SelectListItem()
                         {
                             Text = i.MenuName,
                             Value = i.MenuID.ToString(),
                         }).ToList();
            query.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = string.Empty
            });
            ViewBag.query = query;
            return View(sm);
        }
        [HttpPost]
        [Route("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Menus.Update(mn);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
