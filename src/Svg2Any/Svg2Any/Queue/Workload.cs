using Svg;
using Svg2Any.Converters;
using Svg2Any.Model;
using System.Drawing.Printing;
using System.Net.NetworkInformation;

namespace Svg2Any.Queue
{
    public class Workload
    {
        public Workload(string filepath, ImageSettings imageSettings, ISvgConverter converter, DateTime runAfter)
        {
            FilePath = filepath;
            ImageSettings = imageSettings;
            Converter = converter;
            RunAfter = runAfter;
        }

        public string FilePath { get; }
        public ImageSettings ImageSettings { get; }
        public ISvgConverter Converter { get; }
        public DateTime RunAfter { get; private set; }

        public int Try { get; private set; } = 1;
        public int NextInterval { get; private set; } = 200;
        public decimal IntervalIncreaseFactor { get; private set; } = 1.2M;
        public int MaxTries { get; private set; } = 35;

        public enum ExecutionResultEnum
        {
            Success,
            Failure,
            Retry
        }
        
        public ExecutionResultEnum Run()
        {
            try
            {
                SvgDocument doc = SvgDocument.Open(FilePath);
                var outDir = Path.GetDirectoryName(FilePath);
                if (outDir is not null)
                    Converter.Convert(doc, outDir, Path.GetFileNameWithoutExtension(FilePath), ImageSettings);
                return ExecutionResultEnum.Success;
            }
            catch (Exception)
            {
                if (Try <= MaxTries)
                {
                    Try++;
                    NextInterval = (int)(NextInterval * IntervalIncreaseFactor);
                    RunAfter = DateTime.Now.AddMilliseconds(NextInterval);
                    return ExecutionResultEnum.Retry;
                }
                else
                    return ExecutionResultEnum.Failure;
            }
        }
    }
}
