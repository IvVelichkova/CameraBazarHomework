using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CameraBazar.Data.Models;

namespace CameraBazar.Web.Models.Cameras
{
    public class AddViewModel
    {

        public CameraMakeType Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Min Shutter Speed")]
        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Max Shutter Speed")]
        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Min ISO")]
        public MinISOType MinISO { get; set; }

        [Display(Name = "Max ISO")]
        [Range(200, 409600)]
        public int MaxISO { get; set; }

        [Display(Name = "Is Full Frame")]
        public bool IsFullFrame { get; set; }

        [Required]
        [Display(Name = "Video Resoliution")]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metring")]
        public IEnumerable<LightMeteringType> LightMetering { get; set; } = new List<LightMeteringType>();

        public string Description { get; set; }

        public string ImageURL { get; set; }

    }
}
