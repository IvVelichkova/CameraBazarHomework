namespace CameraBazar.Web.Infrastructure.Extensions
{
    using Data.Models;
    public  static class EnumExtentions
    {
        public static string ToDisplayName(this LightMeteringType lightMeteringType)
        {
            if (lightMeteringType==LightMeteringType.CenterWeight)
            {
                return "Center - Weight";
            }

            return lightMeteringType.ToString();
        }
    }
}
