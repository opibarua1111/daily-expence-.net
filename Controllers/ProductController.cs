using DailyExpenses.Data;
using DailyExpenses.Models;
using Microsoft.AspNetCore.Mvc;

namespace DailyExpenses.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ProductController(ApplicationDBContext db)
        {
            _db = db;
        }

        //public IActionResult Index()
        //{
        //    IEnumerable<Products> objProductList = _db.products;
        //    return View(objProductList);
        //}
        public IEnumerable<Products> result { get; set; }
        public IActionResult Index(DateTime startDate, DateTime endDate)
        {
            result = (from x in _db.products where (x.CreatedDateTime >= startDate) && (x.CreatedDateTime <= endDate) select x).ToList();
            return View(result);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Your Expense recorded successfully";
                return RedirectToAction("Index");
            }
           return View(obj);
        } 
        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.products.Find(id);
            if(productFromDb==null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Your Expense Edit successfully";
                return RedirectToAction("Index");
            }
           return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _db.products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.products.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.products.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Your Expense deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
