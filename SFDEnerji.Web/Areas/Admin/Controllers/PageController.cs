using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFDEnerji.Models;
using SFDEnerji.Repository.Shared.Abstract;
using SFDEnerji.Utility;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    public class PageController : ControllerBase
    {
        public PageController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new {data=unitOfWork.Pages.GetAll().Select(p=> new
            {
                p.Id,
                p.Name,
                p.Slug,
                PictureCount=p.Pictures.Count,
                p.ViewCount
            })});
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Page page)
        {
            unitOfWork.Pages.Add(page);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Pictures(int pageId)
        {

            return View(unitOfWork.Pages.GetAll(x => x.Id == pageId).Include(s => s.Pictures).FirstOrDefault().Pictures.Where(p => p.IsDeleted == false).ToList());
        }

     

    }
}
