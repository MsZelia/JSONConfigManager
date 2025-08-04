
namespace JSONConfigManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNewModConfig = new System.Windows.Forms.ToolStripSplitButton();
            this.btnWeb = new System.Windows.Forms.ToolStripButton();
            this.ddlSelectedMod = new System.Windows.Forms.ToolStripComboBox();
            this.ddlAbout = new System.Windows.Forms.ToolStripSplitButton();
            this.btnGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNexusMods = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNexusUserPage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKofi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDarkMode = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveModConfig = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnBackup = new System.Windows.Forms.ToolStripSplitButton();
            this.btnBackupSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBackupAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenBackupDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.ddlRestoreBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.dummyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectGameLocation = new System.Windows.Forms.ToolStripButton();
            this.ddlBrowse = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnBrowseBackupDir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrowseIniDir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrowseGameDir = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrowseProgramDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButtonProfile = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.userControlContainer = new System.Windows.Forms.Panel();
            this.jsonTreeView = new Alex75.JsonViewer.WindowsForm.JsonTreeView();
            this.txtLog = new JSONConfigManager.QuickScrollRichTextBox();
            this.txtJson = new JSONConfigManager.QuickScrollRichTextBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewModConfig,
            this.btnWeb,
            this.ddlSelectedMod,
            this.ddlAbout,
            this.btnDarkMode,
            this.btnRemoveModConfig,
            this.btnSave,
            this.btnBackup,
            this.ddlBrowse,
            this.btnSelectGameLocation,
            this.toolStripSplitButtonProfile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1312, 32);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNewModConfig
            // 
            this.btnAddNewModConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNewModConfig.Image = global::JSONConfigManager.Properties.Resources.AddFile;
            this.btnAddNewModConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewModConfig.Name = "btnAddNewModConfig";
            this.btnAddNewModConfig.Size = new System.Drawing.Size(39, 28);
            this.btnAddNewModConfig.Text = "Add New Mod Config";
            this.btnAddNewModConfig.ToolTipText = "Add New Mod Config";
            this.btnAddNewModConfig.ButtonClick += new System.EventHandler(this.btnAddNewModConfig_ButtonClick);
            this.btnAddNewModConfig.DropDownOpening += new System.EventHandler(this.btnAddNewModConfig_DropDownOpening);
            this.btnAddNewModConfig.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btnAddNewModConfig_DropDownItemClicked);
            // 
            // btnWeb
            // 
            this.btnWeb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWeb.Image = global::JSONConfigManager.Properties.Resources.Web;
            this.btnWeb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(29, 28);
            this.btnWeb.Tag = "To add custom URL for selected mod, drag and drop link in program bounds.";
            this.btnWeb.Text = "Open Nexus Mod Page";
            this.btnWeb.ToolTipText = "Open Nexus Mod Page or Custom URL\r\n\r\nTo add custom URL for selected mod, drag and" +
    " drop it in program bounds.";
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // ddlSelectedMod
            // 
            this.ddlSelectedMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSelectedMod.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ddlSelectedMod.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ddlSelectedMod.MaxDropDownItems = 32;
            this.ddlSelectedMod.Name = "ddlSelectedMod";
            this.ddlSelectedMod.Size = new System.Drawing.Size(351, 31);
            this.ddlSelectedMod.SelectedIndexChanged += new System.EventHandler(this.ddlSelectedMod_SelectedIndexChanged);
            // 
            // ddlAbout
            // 
            this.ddlAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ddlAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddlAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGithub,
            this.btnNexusMods,
            this.toolStripSeparator3,
            this.btnNexusUserPage,
            this.btnKofi,
            this.toolStripSeparator2,
            this.btnAbout});
            this.ddlAbout.Image = global::JSONConfigManager.Properties.Resources.Info;
            this.ddlAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddlAbout.Name = "ddlAbout";
            this.ddlAbout.Size = new System.Drawing.Size(39, 28);
            this.ddlAbout.Text = "About";
            this.ddlAbout.ButtonClick += new System.EventHandler(this.ddlAbout_ButtonClick);
            // 
            // btnGithub
            // 
            this.btnGithub.Image = global::JSONConfigManager.Properties.Resources.Github;
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(316, 28);
            this.btnGithub.Text = "Open on GitHub";
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // btnNexusMods
            // 
            this.btnNexusMods.Image = global::JSONConfigManager.Properties.Resources.Nexus;
            this.btnNexusMods.Name = "btnNexusMods";
            this.btnNexusMods.Size = new System.Drawing.Size(316, 28);
            this.btnNexusMods.Text = "Open on NexusMods";
            this.btnNexusMods.Click += new System.EventHandler(this.btnNexusMods_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(313, 6);
            // 
            // btnNexusUserPage
            // 
            this.btnNexusUserPage.Image = global::JSONConfigManager.Properties.Resources.Nexus;
            this.btnNexusUserPage.Name = "btnNexusUserPage";
            this.btnNexusUserPage.Size = new System.Drawing.Size(316, 28);
            this.btnNexusUserPage.Text = "My other mods";
            this.btnNexusUserPage.Click += new System.EventHandler(this.btnNexusUserPage_Click);
            // 
            // btnKofi
            // 
            this.btnKofi.Image = global::JSONConfigManager.Properties.Resources.Kofi;
            this.btnKofi.Name = "btnKofi";
            this.btnKofi.Size = new System.Drawing.Size(316, 28);
            this.btnKofi.Text = "Donate/Support me on Ko-Fi";
            this.btnKofi.Click += new System.EventHandler(this.btnKofi_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(313, 6);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = global::JSONConfigManager.Properties.Resources.Info;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(316, 28);
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnDarkMode
            // 
            this.btnDarkMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDarkMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDarkMode.Image = global::JSONConfigManager.Properties.Resources.DarkMode;
            this.btnDarkMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDarkMode.Name = "btnDarkMode";
            this.btnDarkMode.Size = new System.Drawing.Size(29, 28);
            this.btnDarkMode.Text = "DarkMode";
            this.btnDarkMode.ToolTipText = "Toggle between Light and Dark mode";
            this.btnDarkMode.Click += new System.EventHandler(this.btnDarkMode_Click);
            // 
            // btnRemoveModConfig
            // 
            this.btnRemoveModConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveModConfig.Image = global::JSONConfigManager.Properties.Resources.RemoveFile;
            this.btnRemoveModConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveModConfig.Name = "btnRemoveModConfig";
            this.btnRemoveModConfig.Size = new System.Drawing.Size(29, 28);
            this.btnRemoveModConfig.Text = "Remove Selected Mod Config";
            this.btnRemoveModConfig.Click += new System.EventHandler(this.btnRemoveModConfig_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::JSONConfigManager.Properties.Resources.SaveFile;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 28);
            this.btnSave.Text = "Save";
            this.btnSave.ToolTipText = "Save Config Changes (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnBackup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBackupSingle,
            this.btnBackupAll,
            this.btnOpenBackupDirectory,
            this.ddlRestoreBackup});
            this.btnBackup.Image = global::JSONConfigManager.Properties.Resources.Backup;
            this.btnBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(104, 28);
            this.btnBackup.Text = "Backup";
            this.btnBackup.ToolTipText = "Backup config files or Restore from backup points";
            this.btnBackup.ButtonClick += new System.EventHandler(this.btnBackup_ButtonClick);
            // 
            // btnBackupSingle
            // 
            this.btnBackupSingle.Image = global::JSONConfigManager.Properties.Resources.Backup;
            this.btnBackupSingle.Name = "btnBackupSingle";
            this.btnBackupSingle.ShortcutKeyDisplayString = "";
            this.btnBackupSingle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.btnBackupSingle.Size = new System.Drawing.Size(272, 28);
            this.btnBackupSingle.Text = "Backup";
            this.btnBackupSingle.Click += new System.EventHandler(this.btnBackupSingle_Click);
            // 
            // btnBackupAll
            // 
            this.btnBackupAll.Image = global::JSONConfigManager.Properties.Resources.Backup;
            this.btnBackupAll.Name = "btnBackupAll";
            this.btnBackupAll.ShortcutKeyDisplayString = "";
            this.btnBackupAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.btnBackupAll.Size = new System.Drawing.Size(272, 28);
            this.btnBackupAll.Text = "Backup All";
            this.btnBackupAll.Click += new System.EventHandler(this.btnBackupAll_Click);
            // 
            // btnOpenBackupDirectory
            // 
            this.btnOpenBackupDirectory.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnOpenBackupDirectory.Name = "btnOpenBackupDirectory";
            this.btnOpenBackupDirectory.ShortcutKeyDisplayString = "";
            this.btnOpenBackupDirectory.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.btnOpenBackupDirectory.Size = new System.Drawing.Size(272, 28);
            this.btnOpenBackupDirectory.Text = "Open Directory";
            this.btnOpenBackupDirectory.Click += new System.EventHandler(this.btnOpenBackupDirectory_Click);
            // 
            // ddlRestoreBackup
            // 
            this.ddlRestoreBackup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyToolStripMenuItem});
            this.ddlRestoreBackup.Image = global::JSONConfigManager.Properties.Resources.Restore;
            this.ddlRestoreBackup.Name = "ddlRestoreBackup";
            this.ddlRestoreBackup.ShortcutKeyDisplayString = "";
            this.ddlRestoreBackup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.ddlRestoreBackup.Size = new System.Drawing.Size(272, 28);
            this.ddlRestoreBackup.Text = "Restore Backup";
            this.ddlRestoreBackup.DropDownOpened += new System.EventHandler(this.ddlRestoreBackup_DropDownOpened);
            this.ddlRestoreBackup.Click += new System.EventHandler(this.ddlRestoreBackup_Click);
            // 
            // dummyToolStripMenuItem
            // 
            this.dummyToolStripMenuItem.Name = "dummyToolStripMenuItem";
            this.dummyToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.dummyToolStripMenuItem.Text = "dummy";
            // 
            // btnSelectGameLocation
            // 
            this.btnSelectGameLocation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSelectGameLocation.AutoToolTip = false;
            this.btnSelectGameLocation.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnSelectGameLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectGameLocation.Name = "btnSelectGameLocation";
            this.btnSelectGameLocation.Size = new System.Drawing.Size(156, 28);
            this.btnSelectGameLocation.Text = "Select Game Dir";
            this.btnSelectGameLocation.ToolTipText = "Select your Fallout 76 game folder or data directory";
            this.btnSelectGameLocation.Click += new System.EventHandler(this.btnSelectGameLocation_Click);
            // 
            // ddlBrowse
            // 
            this.ddlBrowse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ddlBrowse.AutoToolTip = false;
            this.ddlBrowse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBrowseBackupDir,
            this.btnBrowseIniDir,
            this.btnBrowseGameDir,
            this.btnBrowseProgramDir});
            this.ddlBrowse.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.ddlBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddlBrowse.Name = "ddlBrowse";
            this.ddlBrowse.Size = new System.Drawing.Size(98, 28);
            this.ddlBrowse.Text = "Browse";
            this.ddlBrowse.Click += new System.EventHandler(this.ddlBrowse_Click);
            // 
            // btnBrowseBackupDir
            // 
            this.btnBrowseBackupDir.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnBrowseBackupDir.Name = "btnBrowseBackupDir";
            this.btnBrowseBackupDir.ShortcutKeyDisplayString = "";
            this.btnBrowseBackupDir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.btnBrowseBackupDir.Size = new System.Drawing.Size(242, 28);
            this.btnBrowseBackupDir.Text = "Backups";
            this.btnBrowseBackupDir.Click += new System.EventHandler(this.btnBrowseBackupDir_Click);
            // 
            // btnBrowseIniDir
            // 
            this.btnBrowseIniDir.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnBrowseIniDir.Name = "btnBrowseIniDir";
            this.btnBrowseIniDir.ShortcutKeyDisplayString = "";
            this.btnBrowseIniDir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.btnBrowseIniDir.Size = new System.Drawing.Size(242, 28);
            this.btnBrowseIniDir.Text = "Game INIs";
            this.btnBrowseIniDir.Click += new System.EventHandler(this.btnBrowseIniDir_Click);
            // 
            // btnBrowseGameDir
            // 
            this.btnBrowseGameDir.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnBrowseGameDir.Name = "btnBrowseGameDir";
            this.btnBrowseGameDir.ShortcutKeyDisplayString = "";
            this.btnBrowseGameDir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.btnBrowseGameDir.Size = new System.Drawing.Size(242, 28);
            this.btnBrowseGameDir.Text = "Game Data";
            this.btnBrowseGameDir.Click += new System.EventHandler(this.btnBrowseGameDir_Click);
            // 
            // btnBrowseProgramDir
            // 
            this.btnBrowseProgramDir.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnBrowseProgramDir.Name = "btnBrowseProgramDir";
            this.btnBrowseProgramDir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.btnBrowseProgramDir.Size = new System.Drawing.Size(242, 28);
            this.btnBrowseProgramDir.Text = "Program Dir";
            this.btnBrowseProgramDir.Click += new System.EventHandler(this.btnBrowseProgramDir_Click);
            // 
            // toolStripSplitButtonProfile
            // 
            this.toolStripSplitButtonProfile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButtonProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripSplitButtonProfile.Name = "toolStripSplitButtonProfile";
            this.toolStripSplitButtonProfile.Size = new System.Drawing.Size(151, 31);
            this.toolStripSplitButtonProfile.Visible = false;
            this.toolStripSplitButtonProfile.SelectedIndexChanged += new System.EventHandler(this.toolStripSplitButtonProfile_SelectedIndexChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 753);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip.Size = new System.Drawing.Size(1312, 26);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.lblStatus.Size = new System.Drawing.Size(49, 20);
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AllowDrop = true;
            this.splitContainer1.Panel1.Controls.Add(this.jsonTreeView);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1312, 721);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1MinSize = 270;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtJson);
            this.splitContainer2.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.splitContainer2.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(908, 721);
            this.splitContainer2.SplitterDistance = 270;
            this.splitContainer2.TabIndex = 2;
            this.splitContainer2.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.userControlContainer);
            this.splitContainer3.Panel1MinSize = 180;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtLog);
            this.splitContainer3.Size = new System.Drawing.Size(270, 721);
            this.splitContainer3.SplitterDistance = 227;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.TabStop = false;
            // 
            // userControlContainer
            // 
            this.userControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlContainer.Location = new System.Drawing.Point(0, 0);
            this.userControlContainer.Margin = new System.Windows.Forms.Padding(0);
            this.userControlContainer.MinimumSize = new System.Drawing.Size(0, 100);
            this.userControlContainer.Name = "userControlContainer";
            this.userControlContainer.Size = new System.Drawing.Size(270, 227);
            this.userControlContainer.TabIndex = 1;
            // 
            // jsonTreeView
            // 
            this.jsonTreeView.AllowDrop = true;
            this.jsonTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jsonTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jsonTreeView.FullRowSelect = true;
            this.jsonTreeView.HideSelection = false;
            this.jsonTreeView.ImageIndex = 0;
            this.jsonTreeView.Location = new System.Drawing.Point(0, 0);
            this.jsonTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jsonTreeView.MinimumSize = new System.Drawing.Size(352, 5);
            this.jsonTreeView.Name = "jsonTreeView1";
            this.jsonTreeView.SelectedImageIndex = 0;
            this.jsonTreeView.Size = new System.Drawing.Size(400, 721);
            this.jsonTreeView.TabIndex = 0;
            this.jsonTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.jsonTreeView_AfterSelect);
            this.jsonTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.jsonTreeView_NodeMouseClick);
            this.jsonTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.jsonTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Margin = new System.Windows.Forms.Padding(0);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(270, 490);
            this.txtLog.TabIndex = 0;
            this.txtLog.TabStop = false;
            this.txtLog.Text = "";
            this.txtLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // txtJson
            // 
            this.txtJson.BackColor = System.Drawing.SystemColors.Window;
            this.txtJson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtJson.Location = new System.Drawing.Point(0, 0);
            this.txtJson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(634, 721);
            this.txtJson.TabIndex = 0;
            this.txtJson.Text = "";
            this.txtJson.Leave += new System.EventHandler(this.txtJson_Leave);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 779);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1327, 728);
            this.Name = "Form1";
            this.Text = "JSONConfigManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QuickScrollRichTextBox txtLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox ddlSelectedMod;
        private System.Windows.Forms.ToolStripButton btnSelectGameLocation;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripComboBox toolStripSplitButtonProfile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSplitButton btnAddNewModConfig;
        private System.Windows.Forms.ToolStripButton btnRemoveModConfig;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSplitButton btnBackup;
        private System.Windows.Forms.ToolStripMenuItem btnBackupSingle;
        private System.Windows.Forms.ToolStripMenuItem btnBackupAll;
        private System.Windows.Forms.ToolStripMenuItem btnOpenBackupDirectory;
        private System.Windows.Forms.ToolStripButton btnWeb;
        private System.Windows.Forms.ToolStripMenuItem ddlRestoreBackup;
        private System.Windows.Forms.ToolStripMenuItem dummyToolStripMenuItem;
        private Alex75.JsonViewer.WindowsForm.JsonTreeView jsonTreeView;
        private System.Windows.Forms.Panel userControlContainer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private QuickScrollRichTextBox txtJson;
        private System.Windows.Forms.ToolStripButton btnDarkMode;
        private System.Windows.Forms.ToolStripSplitButton ddlAbout;
        private System.Windows.Forms.ToolStripMenuItem btnNexusMods;
        private System.Windows.Forms.ToolStripMenuItem btnGithub;
        private System.Windows.Forms.ToolStripMenuItem btnKofi;
        private System.Windows.Forms.ToolStripMenuItem btnNexusUserPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton ddlBrowse;
        private System.Windows.Forms.ToolStripMenuItem btnBrowseGameDir;
        private System.Windows.Forms.ToolStripMenuItem btnBrowseIniDir;
        private System.Windows.Forms.ToolStripMenuItem btnBrowseBackupDir;
        private System.Windows.Forms.ToolStripMenuItem btnBrowseProgramDir;
    }
}

