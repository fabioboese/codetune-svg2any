namespace Svg2AnyTray
{
    partial class Configuration
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            szeIco = new Sizes();
            szePng = new Sizes();
            lstFolders = new ListBox();
            btnAdd = new Button();
            btnRemove = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            notSysTray = new NotifyIcon(components);
            spcSizes = new SplitContainer();
            btnSelectFile = new Button();
            tmrStatus = new System.Windows.Forms.Timer(components);
            lblStatus = new Label();
            pnlStatus = new Panel();
            btnStop = new Button();
            btnPlay = new Button();
            tabControl1 = new TabControl();
            tbpConfiguration = new TabPage();
            tbpLog = new TabPage();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)spcSizes).BeginInit();
            spcSizes.Panel1.SuspendLayout();
            spcSizes.Panel2.SuspendLayout();
            spcSizes.SuspendLayout();
            pnlStatus.SuspendLayout();
            tabControl1.SuspendLayout();
            tbpConfiguration.SuspendLayout();
            tbpLog.SuspendLayout();
            SuspendLayout();
            // 
            // szeIco
            // 
            szeIco.BackColor = Color.FromArgb(192, 255, 192);
            szeIco.Dock = DockStyle.Fill;
            szeIco.Location = new Point(0, 0);
            szeIco.MinimumSize = new Size(144, 150);
            szeIco.Name = "szeIco";
            szeIco.Size = new Size(151, 177);
            szeIco.TabIndex = 7;
            szeIco.Title = "ICO";
            // 
            // szePng
            // 
            szePng.BackColor = Color.FromArgb(192, 255, 255);
            szePng.Dock = DockStyle.Fill;
            szePng.Location = new Point(0, 0);
            szePng.MinimumSize = new Size(144, 150);
            szePng.Name = "szePng";
            szePng.Size = new Size(150, 177);
            szePng.TabIndex = 7;
            szePng.Title = "PNG";
            // 
            // lstFolders
            // 
            lstFolders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstFolders.FormattingEnabled = true;
            lstFolders.ItemHeight = 15;
            lstFolders.Location = new Point(6, 6);
            lstFolders.Name = "lstFolders";
            lstFolders.Size = new Size(309, 109);
            lstFolders.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.Location = new Point(162, 121);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemove.Location = new Point(240, 121);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 10;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(159, 332);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(240, 332);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // notSysTray
            // 
            notSysTray.BalloonTipText = "Svg2Any";
            notSysTray.BalloonTipTitle = "No folders are being monitored.";
            notSysTray.Icon = (Icon)resources.GetObject("notSysTray.Icon");
            notSysTray.Text = "notifyIcon1";
            notSysTray.Visible = true;
            // 
            // spcSizes
            // 
            spcSizes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            spcSizes.Location = new Point(8, 149);
            spcSizes.Name = "spcSizes";
            // 
            // spcSizes.Panel1
            // 
            spcSizes.Panel1.Controls.Add(szePng);
            // 
            // spcSizes.Panel2
            // 
            spcSizes.Panel2.Controls.Add(szeIco);
            spcSizes.Size = new Size(305, 177);
            spcSizes.SplitterDistance = 150;
            spcSizes.TabIndex = 11;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelectFile.FlatAppearance.BorderSize = 0;
            btnSelectFile.FlatStyle = FlatStyle.Flat;
            btnSelectFile.Image = Properties.Resources.select_files1;
            btnSelectFile.Location = new Point(6, 121);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(23, 23);
            btnSelectFile.TabIndex = 10;
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Visible = false;
            btnSelectFile.Click += btnAdd_Click;
            // 
            // tmrStatus
            // 
            tmrStatus.Enabled = true;
            tmrStatus.Interval = 1000;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(46, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(97, 23);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "STARTING";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStatus
            // 
            pnlStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlStatus.BackColor = Color.Orange;
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Controls.Add(btnStop);
            pnlStatus.Controls.Add(btnPlay);
            pnlStatus.Location = new Point(6, 332);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(143, 23);
            pnlStatus.TabIndex = 15;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Transparent;
            btnStop.BackgroundImageLayout = ImageLayout.Zoom;
            btnStop.Dock = DockStyle.Left;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Image = Properties.Resources.control_stop;
            btnStop.Location = new Point(23, 0);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(23, 23);
            btnStop.TabIndex = 16;
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Visible = false;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Transparent;
            btnPlay.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlay.Dock = DockStyle.Left;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Image = Properties.Resources.control_play_blue;
            btnPlay.Location = new Point(0, 0);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(23, 23);
            btnPlay.TabIndex = 15;
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Visible = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbpConfiguration);
            tabControl1.Controls.Add(tbpLog);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(329, 391);
            tabControl1.TabIndex = 16;
            // 
            // tbpConfiguration
            // 
            tbpConfiguration.Controls.Add(btnCancel);
            tbpConfiguration.Controls.Add(btnSave);
            tbpConfiguration.Controls.Add(pnlStatus);
            tbpConfiguration.Controls.Add(lstFolders);
            tbpConfiguration.Controls.Add(spcSizes);
            tbpConfiguration.Controls.Add(btnRemove);
            tbpConfiguration.Controls.Add(btnAdd);
            tbpConfiguration.Controls.Add(btnSelectFile);
            tbpConfiguration.Location = new Point(4, 24);
            tbpConfiguration.Name = "tbpConfiguration";
            tbpConfiguration.Padding = new Padding(3);
            tbpConfiguration.Size = new Size(321, 363);
            tbpConfiguration.TabIndex = 0;
            tbpConfiguration.Text = "Configuration";
            tbpConfiguration.UseVisualStyleBackColor = true;
            // 
            // tbpLog
            // 
            tbpLog.Controls.Add(textBox1);
            tbpLog.Location = new Point(4, 24);
            tbpLog.Name = "tbpLog";
            tbpLog.Padding = new Padding(3);
            tbpLog.Size = new Size(321, 386);
            tbpLog.TabIndex = 1;
            tbpLog.Text = "Log";
            tbpLog.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(3, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(315, 380);
            textBox1.TabIndex = 0;
            textBox1.WordWrap = false;
            // 
            // Configuration
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(329, 391);
            ControlBox = false;
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(345, 430);
            Name = "Configuration";
            StartPosition = FormStartPosition.Manual;
            Text = "SVG 2 ANY";
            spcSizes.Panel1.ResumeLayout(false);
            spcSizes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcSizes).EndInit();
            spcSizes.ResumeLayout(false);
            pnlStatus.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tbpConfiguration.ResumeLayout(false);
            tbpLog.ResumeLayout(false);
            tbpLog.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Sizes szeIco;
        private Sizes szePng;
        private ListBox lstFolders;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnSave;
        private Button btnCancel;
        private NotifyIcon notSysTray;
        private SplitContainer spcSizes;
        private Button btnSelectFile;
        private System.Windows.Forms.Timer tmrStatus;
        private Label lblStatus;
        private Panel pnlStatus;
        private Button btnStop;
        private Button btnPlay;
        private TabControl tabControl1;
        private TabPage tbpConfiguration;
        private TabPage tbpLog;
        private TextBox textBox1;
    }
}