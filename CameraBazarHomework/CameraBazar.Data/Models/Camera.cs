using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CameraBazar.Data.Models
{
    public class Camera
    {
        public int Id { get; set; }

        public CameraMakeType Make { get; set; }

        [Required]
        [MinLength(100)]
        public string Model { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }
        [Required]
        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }
        [Required]
        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        public MinISOType MinISO { get; set; }
        [Range(200, 409600)]
        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }
        [Required]
        [MaxLength(15)]
        public string VideoResolution { get; set; }

        public LightMeteringType LightMetering { get; set; }
        [Required]
        [MaxLength(6000)]
        public string Description { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageURL { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
