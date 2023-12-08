using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SFDEnerji.Repository.Shared.Abstract;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    public class DashboardController : ControllerBase
    {
        public DashboardController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
