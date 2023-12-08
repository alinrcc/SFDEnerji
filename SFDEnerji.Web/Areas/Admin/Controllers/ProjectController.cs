using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFDEnerji.Models;
using SFDEnerji.Repository.Shared.Abstract;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    public class ProjectController : ControllerBase
    {
        public ProjectController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json( new { data = unitOfWork.Projects.GetAll().Select(p=>new
            {
                p.Id,
                p.Name,
                p.Slug,
                p.Thumbnail,
                p.ViewCount,
                PictureCount=p.Pictures.Count,
                ServiceName=p.Service.Name

            }).ToList() });
        }
        public IActionResult Add()
        {
            ViewBag.Services = unitOfWork.Services.GetAll().ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Add(Project project)
        {
           
            unitOfWork.Projects.Add(project);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Pictures(int projectId)
        {
            return View(unitOfWork.Projects.GetAll(x => x.Id == projectId).Include(s => s.Pictures).FirstOrDefault().Pictures.Where(p => p.IsDeleted == false).ToList());
        }



    }
}
