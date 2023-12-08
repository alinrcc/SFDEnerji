using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SFDEnerji.Repository.Shared.Abstract;

namespace SFDEnerji.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ControllerBase : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
