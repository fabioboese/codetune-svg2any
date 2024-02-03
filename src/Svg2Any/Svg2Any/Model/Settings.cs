using Newtonsoft.Json;

namespace Svg2Any.Model;

public class Settings
{
    private const string CONFIG_FILE = "config.json";

    public string[] MonitoredFolders { get; set; } = new string[] { };
    public ImageSettings? Ico { get; set; }
    public ImageSettings? Png { get; set; }

    public static void ReadConfig()
    {
        JsonConvert.DeserializeObject<Settings>(File.ReadAllText(CONFIG_FILE));
    }

    public void WriteConfig()
    {
        File.WriteAllText(CONFIG_FILE, JsonConvert.SerializeObject(this));
    }
}
