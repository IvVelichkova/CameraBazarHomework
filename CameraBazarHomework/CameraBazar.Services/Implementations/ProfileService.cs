namespace CameraBazar.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CameraBazar.Data;
    using CameraBazar.Services.Models.Users;
    using System.Linq;

    public class ProfileService : IProfileService
    {
        private readonly CameraBazarDbContext db;

        public ProfileService(CameraBazarDbContext db)
        {
            this.db = db;
        }

        public ProfileModel AllCameras(string userName)
        {
           return this.db.Users.Where(u => u.UserName == userName)
                .Select(c => new ProfileModel
                {
                    UserName = c.UserName,
                    Phone = c.PhoneNumber,
                    Email = c.Email,
                    Cameras = c.Cameras.Select(cm => new Models.Cameras.CamerasByUser
                    {
                        Id = cm.Id,
                        Make = cm.Make,
                        Model = cm.Model,
                        Price = cm.Price,
                        Quantity = cm.Quantity,
                        ImageUrl = cm.ImageURL,
                        UserName = cm.User.UserName
                    })
                }).FirstOrDefault();
        }
    }
}
