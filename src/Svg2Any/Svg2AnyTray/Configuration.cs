using Newtonsoft.Json;
using Svg2Any;
using Svg2Any.Model;
using Svg2Any.Queue;

namespace Svg2AnyTray;

public partial class Configuration : Form
{
    private const string CONFIG_FILE = "config.json";
    private readonly Worker worker = new Worker();
    private readonly Watchers watchers = new Watchers();
    private Worker.WorkerStatusEnum currentStatus = Worker.WorkerStatusEnum.Stopped;

    public Configuration()
    {
        InitializeComponent();
        RegisterEvents();
        ReadSettings();
        worker.Start();
    }

    private void RegisterEvents()
    {
        worker.StatusChanged += (object? sender, Worker.WorkerStatusEnum e) => currentStatus = e;
        notSysTray.MouseClick += (object? sender, MouseEventArgs e) => ShowMe();
        Shown += (object? sender, EventArgs e) => HideMe(false);
        tmrStatus.Tick += (object? sender, EventArgs e) => RefreshStatus();
        btnPlay.Click += (object? sender, EventArgs e) => worker.Start();
        btnStop.Click += (object? sender, EventArgs e) => worker.Stop();
    }

    private void RefreshStatus()
    {
        switch (currentStatus)
        {
            case Worker.WorkerStatusEnum.Starting:
                pnlStatus.BackColor = Color.Orange;
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = "STARTING";
                btnPlay.Visible = btnStop.Visible = false;
                break;
            case Worker.WorkerStatusEnum.Running:
                pnlStatus.BackColor = Color.Green;
                lblStatus.ForeColor = Color.White;
                lblStatus.Text = "RUNNING";
                btnPlay.Visible = false;
                btnStop.Visible = true;
                break;
            case Worker.WorkerStatusEnum.Stopping:
                pnlStatus.BackColor = Color.Orange;
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = "STOPPING";
                btnPlay.Visible = btnStop.Visible = false;
                break;
            case Worker.WorkerStatusEnum.Stopped:
                pnlStatus.BackColor = Color.Red;
                lblStatus.ForeColor = Color.White;
                lblStatus.Text = "STOPPED";
                btnPlay.Visible = true;
                btnStop.Visible = false;
                break;
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            watchers.Add(folderBrowserDialog.SelectedPath);
            lstFolders.DataSource = watchers.GetFolders();
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (lstFolders.SelectedItem != null)
        {
            watchers.Remove(lstFolders.SelectedItem.ToString() ?? string.Empty);
            lstFolders.DataSource = watchers.GetFolders();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ReadSettings();
        HideMe(false);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        WriteSettings();
        HideMe(false);
    }

    private void ReadSettings()
    {
        if (File.Exists(CONFIG_FILE))
        {
            var settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(CONFIG_FILE));
            if (settings != null)
            {
                foreach (var folder in settings.MonitoredFolders)
                    watchers.Add(folder);
                if (settings.Png != null)
                    szePng.ApplySettings(settings.Png);
                if (settings.Ico != null)
                    szeIco.ApplySettings(settings.Ico);
                lstFolders.DataSource = watchers.GetFolders();
                watchers.PngSettings = szePng.GetSettings();
                watchers.IcoSettings = szeIco.GetSettings();
            }
        }
    }

    private void ShowMe()
    {
        Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        notSysTray.Visible = false;
        Show();
    }

    private void HideMe(bool showBallon)
    {
        notSysTray.Visible = true;
        Hide();
        if (showBallon) notSysTray.ShowBalloonTip(2000);
    }

    private void WriteSettings()
    {
        var settings = new Settings();
        settings.MonitoredFolders = lstFolders.Items.Cast<string>().ToArray();
        settings.Png = szePng.GetSettings();
        settings.Ico = szeIco.GetSettings();
        File.WriteAllText(CONFIG_FILE, JsonConvert.SerializeObject(settings));
        ReadSettings();
    }
}