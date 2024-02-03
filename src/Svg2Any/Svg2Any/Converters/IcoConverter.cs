using System.Drawing.Imaging;

namespace Svg2Any.Converters
{
    public class IcoConverter : AbstractConverter
    {
        protected override ImageFormat ImageFormat { get; set; } = ImageFormat.Icon;
        protected override string Extension { get; set; } = "ico";
    }
}
