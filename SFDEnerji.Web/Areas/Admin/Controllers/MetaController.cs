using Microsoft.AspNetCore.Mvc;
using SFDEnerji.Data;
using SFDEnerji.Models;
using SFDEnerji.Repository.Shared.Abstract;
using SFDEnerji.Repository.Shared.Concrete;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    public class MetaController : ControllerBase
    {

        public MetaController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public IActionResult Index()
        {

           
            return View();
        }
    }
}
