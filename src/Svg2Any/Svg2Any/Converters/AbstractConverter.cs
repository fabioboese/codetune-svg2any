using Svg;
using Svg2Any.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svg2Any.Converters
{
    public class AbstractConverter : ISvgConverter
    {
        protected virtual ImageFormat ImageFormat { get; set; } = ImageFormat.Bmp;
        protected virtual string Extension { get; set; } = "bmp";
        protected virtual int NumberOfTries { get; set; } = 20;
        protected virtual int MilisecondsAddedOnEachRetry { get; set; } = 200;

        public virtual void Convert(SvgDocument svg, string outputDir, string name, ImageSettings imageSettings)
        {
            foreach (var size in imageSettings.GetAllSizes(imageSettings.Resolutions))
            {
                string filename;
                if (size.Width == 0)
                    filename = $"{name}-h{size.Height}.{Extension}";
                else if (size.Height == 0)
                    filename = $"{name}-w{size.Width}.{Extension}";
                else
                    filename = $"{name}-r{size.Width}x{size.Height}.{Extension}";

                var filePath = Path.Combine(outputDir, filename);
                OnSaveImage(svg, size, filePath);
            }
        }

        protected virtual void OnSaveImage(SvgDocument svg, Size size, string filePath)
        {
            svg.Draw(size.Width, size.Height).Save(filePath, ImageFormat);
        }
    }
}
