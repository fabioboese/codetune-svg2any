using Svg2Any;
using Svg2Any.Model;
using System.ComponentModel;

namespace Svg2AnyTray
{
    public partial class Sizes : UserControl
    {
        private readonly int[] BuiltInSizes;
        private readonly CheckBox[] SizesCheckboxes;

        public Sizes()
        {
            InitializeComponent();
            BuiltInSizes = new int[] { 16, 24, 32, 48, 64, 96, 128, 256 };
            SizesCheckboxes = new CheckBox[] { chk16, chk24, chk32, chk48, chk64, chk96, chk128, chk256 };
        }

        [Browsable(true), DefaultValue("---")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Browsable(false)]
        public ImageSettings GetSettings()
        {
            List<int> sizes = new List<int>();
            for (int i = 0; i < BuiltInSizes.Length; i++)
                if (SizesCheckboxes[i].Checked)
                    sizes.Add(BuiltInSizes[i]);

            var settings = new ImageSettings();
            
            settings.Sizes = sizes.ToArray();

            if (settings.CustomSize != null)
                settings.CustomSize = new Size(Convert.ToInt32(nudWidth.Value), Convert.ToInt32(nudHeight.Value));

            settings.Resolutions = ResolutionsEnum.None;
            if (chkSquared.Checked) settings.Resolutions |= ResolutionsEnum.Squared;
            if (chkFixedWidth.Checked) settings.Resolutions |= ResolutionsEnum.KeepRatioWithDefinedWidth;
            if (chkFixedHeight.Checked) settings.Resolutions |= ResolutionsEnum.KeepRatioWithDefinedHeight;

            return settings;
        }

        [Browsable(false)]
        public void ApplySettings(ImageSettings settings)
        {
            for (int i = 0; i < BuiltInSizes.Length; i++)
                SizesCheckboxes[i].Checked = settings.Sizes.Contains(BuiltInSizes[i]);

            if (settings.CustomSize != null)
            {
                nudWidth.Value = settings.CustomSize.Value.Width;
                nudHeight.Value = settings.CustomSize.Value.Height;
            }

            chkSquared.Checked = settings.Resolutions.HasFlag(ResolutionsEnum.Squared);
            chkFixedWidth.Checked = settings.Resolutions.HasFlag(ResolutionsEnum.KeepRatioWithDefinedWidth);
            chkFixedHeight.Checked = settings.Resolutions.HasFlag(ResolutionsEnum.KeepRatioWithDefinedHeight);
        }
    }
}
