using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SFDEnerji.Models;
using SFDEnerji.Repository.Shared.Abstract;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    public class SettingController : ControllerBase
    {
        public SettingController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
    
        public IActionResult Edit(int id)
        {

            return View(unitOfWork.Settings.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Setting setting)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Settings.Update(setting);
                unitOfWork.Save();
                return RedirectToAction("Index", "Dashboard");
            }
            return View(setting);
        }
    }
}
