using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraBazar.Services.Models.Cameras;
using CameraBazar.Services.Models.Users;
using CameraBazar.Web.Models.AccountViewModels;
using CameraBazar.Web.Models.Cameras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraBazar.Web.Controllers
{
    public class UsersController : Controller
    {

        [Authorize]
        public IActionResult Profile(ProfileModel cameras)
        {
            return View();
        }
    }
}
