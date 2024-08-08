using BulkyWeRazor_Temp.Data;
using BulkyWeRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeRazor_Temp.Pages.Categories
{
	[BindProperties]
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _db;

		public Category Category { get; set; }
		public DeleteModel(ApplicationDbContext db) { _db = db; }
		public void OnGet(int? id)
		{
			if (id != null && id != 0)
			{
				Category = _db.Categories.Find(id);
			}

		}
		public IActionResult OnPost()
		{
			
			Category? obj = _db.Categories.Find(Category.Category_Id);
			//Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Category_Id == id);
			//Category? categoryFromDb2 = _db.Categories.Where(u => u.Category_Id == id).FirstOrDefault();
			if (obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);	
			_db.SaveChanges();
            TempData["success"] = "Category Deleted uccessfully ";
            return RedirectToPage("Index");
		}
	}
}
