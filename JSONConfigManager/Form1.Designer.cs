
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
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNewModConfig = new System.Windows.Forms.ToolStripSplitButton();
            this.btnWeb = new System.Windows.Forms.ToolStripButton();
            this.ddlSelectedMod = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSplitButtonProfile = new System.Windows.Forms.ToolStripComboBox();
            this.btnSelectGameLocation = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveModConfig = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnBackup = new System.Windows.Forms.ToolStripSplitButton();
            this.btnBackupSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBackupAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenBackupDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.ddlRestoreBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.dummyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userControlContainer = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(751, 629);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "";
            this.tbLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewModConfig,
            this.btnWeb,
            this.ddlSelectedMod,
            this.toolStripSplitButtonProfile,
            this.btnSelectGameLocation,
            this.btnRemoveModConfig,
            this.btnSave,
            this.btnBackup});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1165, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNewModConfig
            // 
            this.btnAddNewModConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNewModConfig.Image = global::JSONConfigManager.Properties.Resources.AddFile;
            this.btnAddNewModConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewModConfig.Name = "btnAddNewModConfig";
            this.btnAddNewModConfig.Size = new System.Drawing.Size(36, 25);
            this.btnAddNewModConfig.Text = "Add New Mod Config";
            this.btnAddNewModConfig.ToolTipText = "Add New Mod Config";
            this.btnAddNewModConfig.DropDownOpening += new System.EventHandler(this.btnAddNewModConfig_DropDownOpening);
            this.btnAddNewModConfig.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btnAddNewModConfig_DropDownItemClicked);
            // 
            // btnWeb
            // 
            this.btnWeb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnWeb.Image = global::JSONConfigManager.Properties.Resources.Web;
            this.btnWeb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(24, 25);
            this.btnWeb.Text = "Open Nexus Mod Page";
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // ddlSelectedMod
            // 
            this.ddlSelectedMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSelectedMod.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ddlSelectedMod.MaxDropDownItems = 32;
            this.ddlSelectedMod.Name = "ddlSelectedMod";
            this.ddlSelectedMod.Size = new System.Drawing.Size(350, 28);
            this.ddlSelectedMod.ToolTipText = "Select Mod Config file to load";
            this.ddlSelectedMod.SelectedIndexChanged += new System.EventHandler(this.ddlSelectedMod_SelectedIndexChanged);
            // 
            // toolStripSplitButtonProfile
            // 
            this.toolStripSplitButtonProfile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButtonProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripSplitButtonProfile.Name = "toolStripSplitButtonProfile";
            this.toolStripSplitButtonProfile.Size = new System.Drawing.Size(150, 28);
            this.toolStripSplitButtonProfile.Visible = false;
            this.toolStripSplitButtonProfile.SelectedIndexChanged += new System.EventHandler(this.toolStripSplitButtonProfile_SelectedIndexChanged);
            // 
            // btnSelectGameLocation
            // 
            this.btnSelectGameLocation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSelectGameLocation.AutoToolTip = false;
            this.btnSelectGameLocation.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnSelectGameLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectGameLocation.Name = "btnSelectGameLocation";
            this.btnSelectGameLocation.Size = new System.Drawing.Size(177, 25);
            this.btnSelectGameLocation.Text = "Select Game Location";
            this.btnSelectGameLocation.ToolTipText = "Directory to your Fallout 76 game folder";
            this.btnSelectGameLocation.Click += new System.EventHandler(this.btnSelectGameLocation_Click);
            // 
            // btnRemoveModConfig
            // 
            this.btnRemoveModConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveModConfig.Image = global::JSONConfigManager.Properties.Resources.RemoveFile;
            this.btnRemoveModConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveModConfig.Name = "btnRemoveModConfig";
            this.btnRemoveModConfig.Size = new System.Drawing.Size(24, 25);
            this.btnRemoveModConfig.Text = "Remove Mod Config";
            this.btnRemoveModConfig.Click += new System.EventHandler(this.btnRemoveModConfig_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::JSONConfigManager.Properties.Resources.SaveFile;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 25);
            this.btnSave.Text = "Save";
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
            this.btnBackup.Size = new System.Drawing.Size(93, 25);
            this.btnBackup.Text = "Backup";
            this.btnBackup.ButtonClick += new System.EventHandler(this.btnBackup_ButtonClick);
            // 
            // btnBackupSingle
            // 
            this.btnBackupSingle.Name = "btnBackupSingle";
            this.btnBackupSingle.Size = new System.Drawing.Size(214, 26);
            this.btnBackupSingle.Text = "Backup";
            this.btnBackupSingle.Click += new System.EventHandler(this.btnBackup_ButtonClick);
            // 
            // btnBackupAll
            // 
            this.btnBackupAll.Name = "btnBackupAll";
            this.btnBackupAll.Size = new System.Drawing.Size(214, 26);
            this.btnBackupAll.Text = "Backup All";
            this.btnBackupAll.Click += new System.EventHandler(this.btnBackupAll_Click);
            // 
            // btnOpenBackupDirectory
            // 
            this.btnOpenBackupDirectory.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnOpenBackupDirectory.Name = "btnOpenBackupDirectory";
            this.btnOpenBackupDirectory.Size = new System.Drawing.Size(214, 26);
            this.btnOpenBackupDirectory.Text = "Open Directory";
            this.btnOpenBackupDirectory.Click += new System.EventHandler(this.btnOpenBackupDirectory_Click);
            // 
            // ddlRestoreBackup
            // 
            this.ddlRestoreBackup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyToolStripMenuItem});
            this.ddlRestoreBackup.Image = global::JSONConfigManager.Properties.Resources.Restore;
            this.ddlRestoreBackup.Name = "ddlRestoreBackup";
            this.ddlRestoreBackup.Size = new System.Drawing.Size(214, 26);
            this.ddlRestoreBackup.Text = "Restore Backup";
            this.ddlRestoreBackup.DropDownOpened += new System.EventHandler(this.ddlRestoreBackup_DropDownOpened);
            // 
            // dummyToolStripMenuItem
            // 
            this.dummyToolStripMenuItem.Name = "dummyToolStripMenuItem";
            this.dummyToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.dummyToolStripMenuItem.Text = "dummy";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*.*";
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 657);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1165, 25);
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
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.userControlContainer);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.splitContainer1.Panel1MinSize = 410;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbLog);
            this.splitContainer1.Size = new System.Drawing.Size(1165, 629);
            this.splitContainer1.SplitterDistance = 410;
            this.splitContainer1.TabIndex = 4;
            // 
            // userControlContainer
            // 
            this.userControlContainer.AutoScroll = true;
            this.userControlContainer.AutoSize = true;
            this.userControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlContainer.Location = new System.Drawing.Point(0, 0);
            this.userControlContainer.Name = "userControlContainer";
            this.userControlContainer.Size = new System.Drawing.Size(410, 629);
            this.userControlContainer.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 682);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "Form1";
            this.Text = "JSONConfigManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox ddlSelectedMod;
        private System.Windows.Forms.ToolStripButton btnSelectGameLocation;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripComboBox toolStripSplitButtonProfile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel userControlContainer;
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
    }
}

