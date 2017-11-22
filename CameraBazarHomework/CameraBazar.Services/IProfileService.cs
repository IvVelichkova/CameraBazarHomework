using System;
using System.Collections.Generic;
using System.Text;
using CameraBazar.Services.Models.Users;

namespace CameraBazar.Services
{
    public interface IProfileService
    {
       ProfileModel AllCameras(string userName);
    }
}
