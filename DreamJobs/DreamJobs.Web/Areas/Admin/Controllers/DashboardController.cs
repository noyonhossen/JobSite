using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamJobs.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DreamJobs.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy = "InternalUser")]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new AdminDashboardModel();
            await model.LoadModelData();
            return View(model);
        }
    }
}
