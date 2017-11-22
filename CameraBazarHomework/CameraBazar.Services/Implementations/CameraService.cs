namespace CameraBazar.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using CameraBazar.Data;
    using CameraBazar.Data.Models;

    public class CameraService : ICameraService
    {
        private readonly CameraBazarDbContext db;

        public CameraService(CameraBazarDbContext db)
        {
            this.db = db;
        }

        public void Create(CameraMakeType cameraMake,
            string model,
            decimal price,
            int quantity,
            int minShutterSpeed, 
            int maxShutterSpeed,
            MinISOType minISO, 
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMeteringType> lightMetering,
            string description, 
            string imageUrl,
            string userId)
        {
            var camera = new Camera
            {
                Make = cameraMake,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LightMetering = (LightMeteringType)lightMetering.Cast<int>().Sum(),
                Description = description,
                ImageURL = imageUrl,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }
    }
}
