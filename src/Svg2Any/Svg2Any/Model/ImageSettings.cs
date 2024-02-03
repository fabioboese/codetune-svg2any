using System.Drawing;

namespace Svg2Any.Model
{
    public class ImageSettings
    {
        public int[] Sizes { get; set; } = Array.Empty<int>();
        public Size? CustomSize { get; set; } = null;
        public ResolutionsEnum Resolutions { get; set; } = ResolutionsEnum.None;
        public List<Size> GetAllSizes(ResolutionsEnum resolution)
        {
            List<Size> sizeList = new List<Size>();

            if ((resolution & ResolutionsEnum.Squared) != 0)
                sizeList.AddRange(Sizes.Select(x => new Size(x, x)));

            if ((resolution & ResolutionsEnum.KeepRatioWithDefinedWidth) != 0)
                sizeList.AddRange(Sizes.Select(x => new Size(x, 0)));

            if ((resolution & ResolutionsEnum.KeepRatioWithDefinedHeight) != 0)
                sizeList.AddRange(Sizes.Select(x => new Size(0, x)));

            if (CustomSize.HasValue)
                sizeList.Add(CustomSize.Value);

            return sizeList;
        }
    }
}
