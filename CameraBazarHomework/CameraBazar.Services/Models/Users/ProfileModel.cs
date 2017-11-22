using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraBazar.Services.Models.Cameras;

namespace CameraBazar.Services.Models.Users

{
    public class ProfileModel
    {
        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<CamerasByUser> Cameras { get; set; } = new List<CamerasByUser>();
       
    }
}
