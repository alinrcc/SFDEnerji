using Microsoft.AspNetCore.Mvc;
using SFDEnerji.Models.ViewModels;
using SFDEnerji.Repository.Shared.Abstract;
using System.Diagnostics;

namespace SFDEnerji.Web.Controllers
{
    public class HomeController : Controller
    {
   private readonly IUnitOfWork unitOfWork;

        public HomeController( IUnitOfWork unitOfWork)
        {
          
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm();
            homeVm.Services = unitOfWork.Services.GetAll().ToList();
            homeVm.Projects = unitOfWork.Projects.GetAll().ToList();
            homeVm.Settings = unitOfWork.Settings.GetById(1);
            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}