using System.Drawing.Imaging;

namespace Svg2Any.Converters
{
    public class PngConverter : AbstractConverter
    {
        protected override ImageFormat ImageFormat { get; set; } = ImageFormat.Png;
        protected override string Extension { get; set; } = "png";
    }
}
