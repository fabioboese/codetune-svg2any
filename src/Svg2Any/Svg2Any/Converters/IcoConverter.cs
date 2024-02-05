using Svg;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace Svg2Any.Converters
{

    public class IcoConverter : AbstractConverter
    {
        protected override ImageFormat ImageFormat { get; set; } = ImageFormat.Icon;
        protected override string Extension { get; set; } = "ico";

        protected override void OnSaveImage(SvgDocument svg, Size size, string filePath)
        {
            var img = svg.Draw(size.Width, size.Height);
            using (MemoryStream imageData = new MemoryStream())
            {
                img.Save(imageData, ImageFormat.Png);
                using (BinaryWriter iconWriter = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
                {
                    // Icon Header
                    iconWriter.Write((short)0); // 0: Reserved
                    iconWriter.Write((short)1); // 2: 1=Icon, 2=Cursor
                    iconWriter.Write((short)1); // 4: Number of images
                
                    // Image Entry
                    iconWriter.Write((byte)size.Width); // 6: Width
                    iconWriter.Write((byte)size.Height); // 7: Height
                    iconWriter.Write((byte)0); // 8: Number of colors
                    iconWriter.Write((byte)0); // 9: Reserved
                    iconWriter.Write((short)0); // 10: Color planes
                    iconWriter.Write((short)0); // 12: Bits per pixel
                    iconWriter.Write((int)imageData.Length); // 14: Size of image data
                    iconWriter.Write((int)22); // 18: Offset of image data

                    // Image Data
                    iconWriter.Write(imageData.ToArray()); // 22: Image data
                    iconWriter.Flush();
                    iconWriter.Close();
                    imageData.Close();
                }
            }
        }
    }
}
