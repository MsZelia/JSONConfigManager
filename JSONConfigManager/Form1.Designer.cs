
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
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ddlSelectedMod = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSplitButtonProfile = new System.Windows.Forms.ToolStripComboBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.userControlContainer = new System.Windows.Forms.Panel();
            this.txtJson = new System.Windows.Forms.RichTextBox();
            this.jsonTreeView = new Alex75.JsonViewer.WindowsForm.JsonTreeView();
            this.btnAddNewModConfig = new System.Windows.Forms.ToolStripSplitButton();
            this.btnWeb = new System.Windows.Forms.ToolStripButton();
            this.btnSelectGameLocation = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveModConfig = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnBackup = new System.Windows.Forms.ToolStripSplitButton();
            this.btnBackupSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBackupAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenBackupDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.ddlRestoreBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.dummyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
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
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(270, 396);
            this.txtLog.TabIndex = 0;
            this.txtLog.TabStop = false;
            this.txtLog.Text = "";
            this.txtLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
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
            this.toolStrip1.Size = new System.Drawing.Size(984, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ddlSelectedMod
            // 
            this.ddlSelectedMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSelectedMod.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ddlSelectedMod.MaxDropDownItems = 32;
            this.ddlSelectedMod.Name = "ddlSelectedMod";
            this.ddlSelectedMod.Size = new System.Drawing.Size(264, 27);
            this.ddlSelectedMod.ToolTipText = "Select Mod Config file to load";
            this.ddlSelectedMod.SelectedIndexChanged += new System.EventHandler(this.ddlSelectedMod_SelectedIndexChanged);
            // 
            // toolStripSplitButtonProfile
            // 
            this.toolStripSplitButtonProfile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButtonProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripSplitButtonProfile.Name = "toolStripSplitButtonProfile";
            this.toolStripSplitButtonProfile.Size = new System.Drawing.Size(114, 27);
            this.toolStripSplitButtonProfile.Visible = false;
            this.toolStripSplitButtonProfile.SelectedIndexChanged += new System.EventHandler(this.toolStripSplitButtonProfile_SelectedIndexChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 611);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(984, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.jsonTreeView);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 584);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(581, 584);
            this.splitContainer2.SplitterDistance = 270;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 2;
            this.splitContainer2.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.userControlContainer);
            this.splitContainer3.Panel1MinSize = 100;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtLog);
            this.splitContainer3.Size = new System.Drawing.Size(270, 584);
            this.splitContainer3.SplitterDistance = 185;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.TabStop = false;
            // 
            // userControlContainer
            // 
            this.userControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlContainer.Location = new System.Drawing.Point(0, 0);
            this.userControlContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userControlContainer.MinimumSize = new System.Drawing.Size(0, 81);
            this.userControlContainer.Name = "userControlContainer";
            this.userControlContainer.Size = new System.Drawing.Size(270, 185);
            this.userControlContainer.TabIndex = 1;
            // 
            // txtJson
            // 
            this.txtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtJson.Location = new System.Drawing.Point(0, 0);
            this.txtJson.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtJson.Name = "txtJson";
            this.txtJson.Size = new System.Drawing.Size(308, 584);
            this.txtJson.TabIndex = 0;
            this.txtJson.Text = "";
            this.txtJson.Leave += new System.EventHandler(this.txtJson_Leave);
            // 
            // jsonTreeView
            // 
            this.jsonTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.jsonTreeView.FullRowSelect = true;
            this.jsonTreeView.ImageIndex = 0;
            this.jsonTreeView.LabelEdit = true;
            this.jsonTreeView.Location = new System.Drawing.Point(0, 0);
            this.jsonTreeView.Margin = new System.Windows.Forms.Padding(2);
            this.jsonTreeView.MinimumSize = new System.Drawing.Size(264, 4);
            this.jsonTreeView.Name = "jsonTreeView1";
            this.jsonTreeView.SelectedImageIndex = 0;
            this.jsonTreeView.Size = new System.Drawing.Size(400, 584);
            this.jsonTreeView.TabIndex = 0;
            this.jsonTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.jsonTreeView_NodeMouseClick);
            // 
            // btnAddNewModConfig
            // 
            this.btnAddNewModConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNewModConfig.Image = global::JSONConfigManager.Properties.Resources.AddFile;
            this.btnAddNewModConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewModConfig.Name = "btnAddNewModConfig";
            this.btnAddNewModConfig.Size = new System.Drawing.Size(36, 24);
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
            this.btnWeb.Size = new System.Drawing.Size(24, 24);
            this.btnWeb.Text = "Open Nexus Mod Page";
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // btnSelectGameLocation
            // 
            this.btnSelectGameLocation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSelectGameLocation.AutoToolTip = false;
            this.btnSelectGameLocation.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnSelectGameLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelectGameLocation.Name = "btnSelectGameLocation";
            this.btnSelectGameLocation.Size = new System.Drawing.Size(145, 24);
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
            this.btnRemoveModConfig.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveModConfig.Text = "Remove Mod Config";
            this.btnRemoveModConfig.Click += new System.EventHandler(this.btnRemoveModConfig_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::JSONConfigManager.Properties.Resources.SaveFile;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 24);
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
            this.btnBackup.Size = new System.Drawing.Size(82, 24);
            this.btnBackup.Text = "Backup";
            this.btnBackup.ButtonClick += new System.EventHandler(this.btnBackup_ButtonClick);
            // 
            // btnBackupSingle
            // 
            this.btnBackupSingle.Name = "btnBackupSingle";
            this.btnBackupSingle.Size = new System.Drawing.Size(155, 22);
            this.btnBackupSingle.Text = "Backup";
            this.btnBackupSingle.Click += new System.EventHandler(this.btnBackup_ButtonClick);
            // 
            // btnBackupAll
            // 
            this.btnBackupAll.Name = "btnBackupAll";
            this.btnBackupAll.Size = new System.Drawing.Size(155, 22);
            this.btnBackupAll.Text = "Backup All";
            this.btnBackupAll.Click += new System.EventHandler(this.btnBackupAll_Click);
            // 
            // btnOpenBackupDirectory
            // 
            this.btnOpenBackupDirectory.Image = global::JSONConfigManager.Properties.Resources.Browse;
            this.btnOpenBackupDirectory.Name = "btnOpenBackupDirectory";
            this.btnOpenBackupDirectory.Size = new System.Drawing.Size(155, 22);
            this.btnOpenBackupDirectory.Text = "Open Directory";
            this.btnOpenBackupDirectory.Click += new System.EventHandler(this.btnOpenBackupDirectory_Click);
            // 
            // ddlRestoreBackup
            // 
            this.ddlRestoreBackup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummyToolStripMenuItem});
            this.ddlRestoreBackup.Image = global::JSONConfigManager.Properties.Resources.Restore;
            this.ddlRestoreBackup.Name = "ddlRestoreBackup";
            this.ddlRestoreBackup.Size = new System.Drawing.Size(155, 22);
            this.ddlRestoreBackup.Text = "Restore Backup";
            this.ddlRestoreBackup.DropDownOpened += new System.EventHandler(this.ddlRestoreBackup_DropDownOpened);
            // 
            // dummyToolStripMenuItem
            // 
            this.dummyToolStripMenuItem.Name = "dummyToolStripMenuItem";
            this.dummyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.dummyToolStripMenuItem.Text = "dummy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 633);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
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

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox ddlSelectedMod;
        private System.Windows.Forms.ToolStripButton btnSelectGameLocation;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
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
        private System.Windows.Forms.RichTextBox txtJson;
    }
}

