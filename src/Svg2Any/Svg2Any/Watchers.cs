using Svg;
using Svg2Any.Converters;
using Svg2Any.Model;
using Svg2Any.Queue;
using System.ComponentModel;

namespace Svg2Any;

public class Watchers
{
    private readonly Dictionary<string, FileSystemWatcher> watchers = new();
    private readonly PngConverter pngConverter = new();
    private readonly IcoConverter icoConverter = new();

    public void Add(string path)
    {
        if (!watchers.ContainsKey(path))
        {
            watchers.Add(path, CreateWatcher(path));
        }
    }

    public void Remove(string path)
    {
        if (watchers.ContainsKey(path))
        {
            DestroyWatcher(watchers[path]);
            _ = watchers.Remove(path);
        }
    }

    [Browsable(false)]
    public ImageSettings? PngSettings { get; set; }
    public ImageSettings? IcoSettings { get; set; }

    [Browsable(false)]
    public string[] GetFolders() => watchers.Keys.ToArray();

    private void DestroyWatcher(FileSystemWatcher watcher)
    {
        watcher.Created -= OnCreated;
        watcher.EnableRaisingEvents = false;
        watcher.Dispose();
    }

    private FileSystemWatcher CreateWatcher(string path)
    {
        FileSystemWatcher watcher = new(path);
        watcher.Created += OnCreated;
        watcher.EnableRaisingEvents = true;
        watcher.Filter = "*.svg";
        //watcher.NotifyFilter = NotifyFilters.LastWrite;
        return watcher;
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        if (PngSettings != null)
            Worker.Enqueue(new Workload(e.FullPath, PngSettings, pngConverter, DateTime.Now));
        if (IcoSettings != null)
            Worker.Enqueue(new Workload(e.FullPath, IcoSettings, icoConverter, DateTime.Now));
    }
}