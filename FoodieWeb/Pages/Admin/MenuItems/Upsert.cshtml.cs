using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodieWeb.Pages.Admin.MenuItems
{
	[BindProperties]
	public class UpsertModel : PageModel
	{

		public MenuItem MenuItem { get; set; }
		public IEnumerable<SelectListItem> CategoryListItem { get; set; }
		public IEnumerable<SelectListItem> FoodTypeListItem { get; set; }
		private readonly IUnitOfWork dbContext;
		private IWebHostEnvironment hostEnvironment;
		public UpsertModel(IUnitOfWork context, IWebHostEnvironment _hostEnvironment)
		{
			dbContext = context;
			MenuItem = new();
			hostEnvironment = _hostEnvironment;

		}
		public void OnGet(int? id)
		{
            if (id != null)
            {
                //Edit
                MenuItem = dbContext.MenuItems.GetFirstOrDefault(u => u.Id == id);
            }
            CategoryListItem = dbContext.Category.GetAll().Select(s => new SelectListItem()
			{
				Text = s.Name,
				Value = s.Id.ToString()
			});
			FoodTypeListItem = dbContext.FoodTypes.GetAll().Select(s => new SelectListItem()
			{
				Text = s.Name,
				Value = s.Id.ToString()
			});
		}

		public async Task<IActionResult> OnPost(int id)
		{
			string webFolderPath = hostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;
			if (MenuItem.Id == 0)
			{
				// Create if ID is zero
				string fullPath = Path.Combine(webFolderPath, @"Images\menuItems");
				string filename = Guid.NewGuid().ToString();
				string extension = Path.GetExtension(files[0].FileName);
				using (var fileStream = new FileStream(Path.Combine(fullPath, filename + extension), FileMode.Create))
				{
					files[0].CopyTo(fileStream);
				}
				MenuItem.Image = Path.Combine(@"Images\menuItems", filename + extension);
				dbContext.MenuItems.Add(MenuItem);
				dbContext.Save();
			}
			else
			{
				// Update if id greater than zero
				var oldMenuItem = dbContext.MenuItems.GetFirstOrDefault(x => x.Id == MenuItem.Id);
				if(files.Count> 0) 
				{
					string fullPath = Path.Combine(webFolderPath, @"Images\menuItems");
					string filename = Guid.NewGuid().ToString();
					string extension = Path.GetExtension(files[0].FileName);

					using (var fileStream = new FileStream(Path.Combine(fullPath, filename+extension),FileMode.Create))
					{
						files[0].CopyTo(fileStream);
					}

					string oldFilePath = Path.Combine(webFolderPath, oldMenuItem.Image.TrimStart('\\').ToString());
					if(System.IO.File.Exists(oldFilePath))
					{
						System.IO.File.Delete(oldFilePath);
					}
					MenuItem.Image = Path.Combine(@"Images\menuItems", filename + extension);
				}
				else
				{
					MenuItem.Image = oldMenuItem.Image;
				}
				dbContext.MenuItems.Update(MenuItem);
				dbContext.Save();
			}
			return RedirectToPage("./Index");
		}
	}
}
