using Svg;
using Svg2Any.Model;

namespace Svg2Any.Converters
{
    public interface ISvgConverter
    {
        void Convert(SvgDocument svg, string outputDir, string name, ImageSettings imageSettings);
    }
}