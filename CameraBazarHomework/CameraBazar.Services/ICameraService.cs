using System;
using System.Collections.Generic;
using System.Text;
using CameraBazar.Data.Models;

namespace CameraBazar.Services
{
    public interface ICameraService
    {
        void Create(CameraMakeType cameraMake,
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
            string userId);
    }
}
