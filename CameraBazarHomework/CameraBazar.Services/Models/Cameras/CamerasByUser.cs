using System;
using System.Collections.Generic;
using System.Text;
using CameraBazar.Data.Models;

namespace CameraBazar.Services.Models.Cameras
{
    public class CamerasByUser
    {
        public int Id { get; set; }
        public CameraMakeType Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }

    }
}
