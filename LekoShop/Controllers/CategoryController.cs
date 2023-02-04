using LekoShop.Data;
using LekoShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LekoShop.Controllers
{
	public class CategoryController : Controller
	{
		private readonly LekoContext _context;

		public CategoryController(LekoContext context)
		{
			_context=context;
		}

		public IActionResult SearchCategory(string name)
		{
			var searched=_context.Categorys.Where(s=>s.Name==name).ToList();
			if (searched==null)
			{
				return NotFound();
			}
			else return View(searched);

        }
	
		public IActionResult CategoryList()
		{
			var categoryList = _context.Categorys.ToList();
			return View(categoryList);
		}
		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateCategory(Category obj)
		{
			if (ModelState.IsValid) { 
				_context.Categorys.Add(obj);
				_context.SaveChanges();
                return RedirectToAction("CategoryList");
            }
			return View(obj);
        }
		[HttpGet]
		public IActionResult DeleteCategory(int id)
		{
			if (id!=0)
			{
                var obj = _context.Categorys.Find(id);
                return View(obj);
            }
			return BadRequest("id is 0");
            
		}
		[HttpPost]
		public IActionResult DeleteCategory(Category objForDelete)
		{
			if (objForDelete!=null)
			{
				_context.Categorys.Remove(objForDelete);
				_context.SaveChanges();
			}
			return RedirectToAction("CategoryList");
		}
		[HttpGet]
		public IActionResult EditCategory(int id)
		{
			if (id!=0)
			{
				var obj = _context.Categorys.Find(id);
				if (obj!=null)
				{
					return View(obj);
				}
			}
			return BadRequest("Id is 0 or isn't available ");
		}
		[HttpPost]
        public IActionResult EditCategory(Category objForUpdate)
		{
			if (objForUpdate!=null)
			{
				_context.Categorys.Update(objForUpdate);
				_context.SaveChanges() ;
                return RedirectToAction("CategoryList");
            }
			return NotFound("Object is Null");
		}

		

    }
}
