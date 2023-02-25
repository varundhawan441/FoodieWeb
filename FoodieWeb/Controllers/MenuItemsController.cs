using Foodie.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : Controller
    {
        private readonly IUnitOfWork dbContext;

        private IWebHostEnvironment hostEnvironment;
        public MenuItemsController(IUnitOfWork dbContext, IWebHostEnvironment hostEnvironment)
        {
            this.dbContext = dbContext;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var menuItemList = dbContext.MenuItems.GetAll(includeProperties: "Category,FoodType");
            return Json(new { data= menuItemList });
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var menu = dbContext.MenuItems.GetFirstOrDefault(x => x.Id == Id);
            if (menu != null)
            {
                string webFolderPath = hostEnvironment.WebRootPath;
                string oldFilePath = Path.Combine(webFolderPath, menu.Image.TrimStart('\\').ToString());
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
                dbContext.MenuItems.Remove(menu);
                dbContext.Save();
                return Json(new { success = true, message = "Delete successful." });
            }
            else { return Json(new { success = false, }); }
        }
    }
}
