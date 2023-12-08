using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFDEnerji.Models;
using SFDEnerji.Repository.Shared.Abstract;
using SFDEnerji.Utility;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    public class PictureController : ControllerBase
    {
        public PictureController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var picture = unitOfWork.Pictures.GetById(id);
            picture.IsDeleted = true;
            unitOfWork.Save();
            return Ok();
        }
        [HttpPost]
        public IActionResult GetAll(int id, string type)
        {
            if(type=="page")
            {
                return Json( unitOfWork.Pages.GetAll(p=>p.Id==id).Select(p=>new
                {
                    p.Pictures
                }).FirstOrDefault() );
            }
            else if(type=="service")
            {
                return Json(unitOfWork.Services.GetAll(p => p.Id == id).Select(p => new
                {
                    p.Pictures
                }).FirstOrDefault());
            }
            else if(type=="project")
            {
                return Json(unitOfWork.Projects.GetAll(p => p.Id == id).Select(p => new
                {
                    p.Pictures
                }).FirstOrDefault());
            }
            else
            {
                return Json(new { data = unitOfWork.Pictures.GetAll() });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SavePictures(List<IFormFile> postedFiles, int entityId,string type)
        {
            Page page=null;
            Service service = null;
            Project project=null;
            
            if(type=="page")
                page = unitOfWork.Pages.GetById(entityId);
            else if(type=="service")
                service = unitOfWork.Services.GetById(entityId);
            else if(type=="project")
                project = unitOfWork.Projects.GetById(entityId);
          
            

            foreach (var file in postedFiles)
            {
                var filename = "";
              

                if (page != null)
                {
                    filename = page.Name.TextClean() + "-" + Helper.RandomStringGenerator(10) + "-" + file.FileName.TextClean();
                }
                else if (service != null)
                {
                    filename = service.Name.TextClean() + "-" + Helper.RandomStringGenerator(10) + "-" + file.FileName.TextClean();
                }
                else if (project != null)
                {
                    filename = project.Name.TextClean() + "-" + Helper.RandomStringGenerator(10) + "-" + file.FileName.TextClean();
                }


                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", type+"s", "Gallery");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //dosyayi diske kaydetme kısmı
                var stream = new FileStream(Path.Combine(path, filename), FileMode.Create);
                await file.CopyToAsync(stream);
                stream.Close();
                Picture picture = new Picture();
                picture.Path = filename;
                picture.Description = "";
                picture.Name = "";

                if (page != null)
                    page.Pictures.Add(picture);
                else if (service != null)
                    service.Pictures.Add(picture);
                else if (project != null)
                    project.Pictures.Add(picture);

              


            }

            if(page!=null)
                                unitOfWork.Pages.Update(page);
            else if(service!=null)
                unitOfWork.Services.Update(service);
            else if(project!=null)
                unitOfWork.Projects.Update(project);

           
            unitOfWork.Save();


            if (page != null)
                return RedirectToAction("Pictures", "Page", new { pageId = entityId });
            else if (service != null)
                return RedirectToAction("Pictures", "Service", new { serviceId = entityId });
            else if (project != null)
                return RedirectToAction("Pictures", "Project", new { projectId = entityId });
            else 
                return RedirectToAction("Index");
            



        }

    }
}
