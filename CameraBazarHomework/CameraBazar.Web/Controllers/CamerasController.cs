namespace CameraBazar.Web.Controllers
{
    using System.Linq;
    using CameraBazar.Data.Models;
    using CameraBazar.Services;
    using CameraBazar.Web.Models.Cameras;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CamerasController : Controller
    {
        private readonly ICameraService cameras;
        private readonly UserManager<User> userManager;

        public CamerasController(UserManager<User> userManager,
            ICameraService cameras)
        {
            this.userManager = userManager;
            this.cameras = cameras;
        }

        [Authorize]
        //[Route("cameras/add")]
        public IActionResult Add() => View(new AddViewModel());

        [Authorize]
        [HttpPost]
        public IActionResult Add(
            AddViewModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }
            if (!cameraModel.LightMetering.Any())
            {
                ModelState.AddModelError(nameof(cameraModel.LightMetering), "Light Metering must have a value!");
                return View(cameraModel);
            }
            this.cameras.Create(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMetering,
                cameraModel.ImageURL,
                cameraModel.Description,
                this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
