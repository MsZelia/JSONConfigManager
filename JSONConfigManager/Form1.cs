using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONConfigManager
{
    public partial class Form1 : Form
    {
        private const string SETTING_X = "x";
        private const string SETTING_Y = "y";
        private const string SETTING_W = "w";
        private const string SETTING_H = "h";
        private const string SETTING_MOD_LIST = "modList";
        private const string SETTING_GAME_DIR = "gameDir";

        public string initDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Fallout76\\Data\\";

        public string gameDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Fallout76\\Data\\";

        public string backupDir = ".\\Backups\\";

        public string nexusURL = "https://www.nexusmods.com/fallout76/mods/";

        public Dictionary<string, string> modList = new Dictionary<string, string>();

        public Dictionary<string, string> nexusLinks = new Dictionary<string, string>()
        {
            { "buffsmeter.json", "2821" },
            { "campswaplock.json", "3267" },
            { "customradios.json", "2901" },
            { "hudbarpercentwidgets.json", "3124" },
            { "hudchallenges.json", "2860" },
            { "hudcondition.json", "3114" },
            { "hudplayerlist.json", "2811" },
            { "improvedpipboystatsconfig.json", "3080" },
            { "improvedsocialmenuconfig.json", "2915" },
            { "improvedworkbenchconfig.json", "2576" },
            { "inventomaticpipboyconfig.json", "2324" },
            { "inventomaticstashconfig.json", "2335" },
            { "radialmenuloadoutconfig.json", "3166" },
            { "skipmessagesconfig.json", "3007" },
            { "vatspriorityconfig.json", "3297" }
        };

        private JToken settings = null;

        private JToken config = null;

        private bool configEdited = false;

        private TreeNode selectedNode;

        private JToken selectedNodeToken;

        private UserControl nodeEditUserControl;
        public Form1()
        {
            InitializeComponent();
            LoadSettings();
        }

        public string logStatus
        {
            get => lblStatus.Text;
            set
            {
                lblStatus.Text = value;
            }
        }

        private void LoadSettings()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".json";
            try
            {
                string fileContent = File.ReadAllText(file);
                settings = JContainer.Parse(fileContent);
                if (settings[SETTING_MOD_LIST] != null)
                {
                    foreach (var mod in settings[SETTING_MOD_LIST].ToArray())
                    {
                        modList.Add((string)mod, (string)mod);
                    }
                }
                if (settings[SETTING_GAME_DIR] != null)
                {
                    gameDir = (string)settings[SETTING_GAME_DIR];
                }
                logStatus = $"Settings loaded!";
            }
            catch (FileNotFoundException)
            {
                SaveSettings();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show($"ERROR loading settings:{Environment.NewLine}{ex}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}Do you want to restore default settings?", "Restore Default Settings?", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    SaveSettings();
                }
            }
        }

        private void SaveSettings()
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".json";
            try
            {
                if (settings == null)
                {
                    settings = JToken.Parse("{}");
                }

                settings[SETTING_GAME_DIR] = gameDir;
                var keys = modList.Keys.ToArray();
                Array.Sort(keys);
                settings[SETTING_MOD_LIST] = JToken.FromObject(keys);
                settings[SETTING_X] = this.Left;
                settings[SETTING_Y] = this.Top;
                settings[SETTING_W] = this.Width;
                settings[SETTING_H] = this.Height;

                File.WriteAllText(file, settings.ToString());
                logStatus = $"Settings saved!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings:{Environment.NewLine}{ex}", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Backup(bool backupAll = false)
        {
            string file = ddlSelectedMod.Text;
            string backupTimeStampDir = backupDir + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "\\";

            try
            {
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error making backup directory:{Environment.NewLine}{ex}", "Backup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (backupAll)
                {
                    foreach (var item in ddlSelectedMod.Items)
                    {
                        BackupFile(item.ToString(), backupTimeStampDir);
                    }
                    MessageBox.Show($"Backing up finished!{Environment.NewLine}{Directory.GetFiles(backupTimeStampDir).Length} config files backed up.", "Backup All", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (BackupFile(file, backupTimeStampDir))
                    {
                        MessageBox.Show($"{file} backed up!", "Backup File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error making backup:{Environment.NewLine}{ex}", "Backup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    if (Directory.GetFiles(backupTimeStampDir).Length == 0)
                    {
                        Directory.Delete(backupTimeStampDir);
                    }
                }
                catch (Exception) { }
            }
        }

        private bool BackupFile(string file, string directory)
        {
            try
            {
                if (File.Exists(gameDir + file))
                {
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    File.Copy(gameDir + file, directory + file, false);
                }
                return true;
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR backing up file {file}: {ex}";
                MessageBox.Show($"Error backing up file {file}:{Environment.NewLine}{ex}", "Backup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void ListBackups()
        {
            try
            {
                foreach (ToolStripMenuItem tsmi in ddlRestoreBackup.DropDownItems)
                {
                    tsmi.DropDownItemClicked -= restoreBackup_DropDownItemClicked;
                }
                ddlRestoreBackup.DropDownItems.Clear();
                if (Directory.Exists(backupDir))
                {
                    foreach (string directory in Directory.GetDirectories(backupDir))
                    {
                        ToolStripMenuItem tsmi = new ToolStripMenuItem(directory.Substring(directory.LastIndexOf("\\") + 1));
                        tsmi.DropDownItems.Add(new ToolStripMenuItem("RESTORE ALL") { Tag = (directory, true) });
                        foreach (var file in Directory.GetFiles(directory))
                        {
                            tsmi.DropDownItems.Add(new ToolStripMenuItem(file.Substring(file.LastIndexOf("\\") + 1)) { Tag = (file, false) });
                        }
                        tsmi.DropDownItemClicked += restoreBackup_DropDownItemClicked;
                        ddlRestoreBackup.DropDownItems.Add(tsmi);
                    }
                }
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR Loading backups: {ex}";
            }
        }

        private void restoreBackup_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ValueTuple<string, bool> fileToRestore = (ValueTuple<string, bool>)(e.ClickedItem as ToolStripMenuItem).Tag;
            Restore(fileToRestore.Item1, fileToRestore.Item2);
        }

        private void Restore(string dir, bool isDir)
        {
            try
            {
                btnBackup.DropDown.Close();
                if (isDir)
                {
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        RestoreFile(file);
                    }
                    logStatus = "Backup restoration finished!";
                    MessageBox.Show("Backup restoration finished!", "Restore All", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (RestoreFile(dir))
                    {
                        logStatus = $"{dir} restored!";
                        MessageBox.Show($"{dir} restored!", "Restore File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring files:{Environment.NewLine}{ex}", "Restore error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RestoreFile(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    File.Copy(file, gameDir + file.Substring(file.LastIndexOf('\\') + 1), true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR Restoring file {file}: {ex}";
                MessageBox.Show($"Error restoring file {file}:{Environment.NewLine}{ex}", "Restore error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void SaveFile()
        {
            try
            {
                if (ddlSelectedMod.SelectedIndex == -1)
                {
                    return;
                }
                string file = "TestEdit.json";
                string cnf = config.ToString();
                File.WriteAllText(gameDir + file, cnf);
                logStatus = $"Saved all changes to {file}";
                configEdited = false;
            }
            catch (Exception ex)
            {
                logStatus = $"Error Saving file {ex}";
                MessageBox.Show($"Error Saving file:{Environment.NewLine}{ex}", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenBackupDirectory()
        {
            try
            {
                if (Directory.Exists(backupDir))
                {
                    Process.Start("explorer.exe", backupDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening backup directory:{Environment.NewLine}{ex}", "Backup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenNexusUrl()
        {
            try
            {
                string file = ddlSelectedMod.Text.ToLower();
                if (nexusLinks.ContainsKey(file))
                {
                    Process.Start(nexusURL + nexusLinks[file]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening nexus url:{Environment.NewLine}{ex}", "Web error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddModConfigFile(string file)
        {
            try
            {
                FileInfo info = new FileInfo(gameDir + file);
                modList.Add(file, file);
                InitLoadedModConfigs();
                logStatus = $"Config file {file} added!";
                SaveSettings();
            }
            catch (Exception ex)
            {
                logStatus = $"Error adding config: {ex}";
                MessageBox.Show($"Error adding config file:{Environment.NewLine}{ex}", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveModConfigFile()
        {
            if (!modList.ContainsKey(ddlSelectedMod.Text))
            {
                return;
            }
            modList.Remove(ddlSelectedMod.Text);
            logStatus = $"Config file {ddlSelectedMod.Text} removed!";
            ddlSelectedMod_SelectedIndexChanged(null, null);
            InitLoadedModConfigs(true);
            SaveSettings();
        }

        private void LoadModConfigFiles()
        {
            try
            {
                btnAddNewModConfig.DropDownItems.Clear();
                logStatus = "Loading...";
                foreach (var file in Directory.GetFiles(gameDir, "*.json"))
                {
                    FileInfo info = new FileInfo(file);
                    if (!modList.ContainsKey(info.Name))
                    {
                        btnAddNewModConfig.DropDownItems.Add(info.Name);
                    }
                }
                logStatus = "Ready";
            }
            catch (Exception ex)
            {
                logStatus = $"Error loading files: {ex}";
            }
        }

        private void toolStripSplitButtonProfile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectGameLocation_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string selectedDir = fbd.SelectedPath;
                    if (selectedDir.ToLower().IndexOf("data") == -1)
                    {
                        selectedDir = selectedDir + "\\Data\\";
                    }

                    if (!selectedDir.EndsWith("\\") && !selectedDir.EndsWith("/"))
                    {
                        selectedDir = selectedDir + "\\";
                    }

                    if (Directory.Exists(selectedDir))
                    {
                        gameDir = selectedDir;
                        logStatus = $"Game dir set: {selectedDir}";
                        SaveSettings();
                    }
                    else
                    {
                        logStatus = $"ERROR Selected game dir invalid: {selectedDir}";
                        MessageBox.Show($"Invalid game directory, folder does not exist!{Environment.NewLine}{selectedDir}", "Game dir error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SetConfigValue(object value, JToken token)
        {
            if (token.Parent is JProperty || token.Parent is JArray && token is JValue)
            {
                var prop = token as JValue;
                var prevValue = prop.Value;
                if (value is int i) prop.Value = i;
                else if (value is decimal d) prop.Value = d;
                else if (value is bool b) prop.Value = b;
                else if (value is string s) prop.Value = s;

                txtLog.Text += $"{token.Path}: {prevValue} -> {prop.Value}{Environment.NewLine}";
                RefreshConfigTree();
            }
            else
            {
                txtLog.Text += $"Parent is {token.Parent.Type}: {token.Parent}{Environment.NewLine}";
            }
        }

        private void RefreshConfigTree(string json = null)
        {
            string selectedPath = "";
            if (selectedNodeToken != null)
            {
                selectedPath = selectedNodeToken.Path;
            }
            selectedNode = null;
            selectedNodeToken = null;
            if (json == null)
            {
                jsonTreeView.ShowJson(config.ToString());
            }
            else
            {
                jsonTreeView.ShowJson(json);
            }
            if (selectedPath != "")
            {
                selectedNode = GetNodeFromPath(jsonTreeView.TopNode, selectedPath);
                if (selectedNode != null)
                {
                    selectedNode.EnsureVisible();
                    selectedNodeToken = selectedNode.Tag as JToken;
                    jsonTreeView_NodeMouseClick(null, new TreeNodeMouseClickEventArgs(selectedNode, MouseButtons.Left, 1, 0, 0));
                }
            }
            config = jsonTreeView.JSON;
            txtJson.Text = config.ToString();
        }

        private TreeNode GetNodeFromPath(TreeNode node, string path)
        {
            TreeNode foundNode = null;
            foreach (TreeNode tn in node.Nodes)
            {
                var tnPath = (tn.Tag as JToken)?.Path ?? "";
                if (tnPath == path)
                {
                    return tn;
                }
                else if (tn.Nodes.Count > 0)
                {
                    foundNode = GetNodeFromPath(tn, path);
                }
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown numericUpDown = sender as NumericUpDown;
                JToken token = numericUpDown.Parent.Tag as JToken;
                SetConfigValue(numericUpDown.Value, token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                txtLog.Text += $"ERROR changing numeric value!{Environment.NewLine}{ex}{Environment.NewLine}";
            }
        }

        private void NumericUpDownInt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown numericUpDown = sender as NumericUpDown;
                JToken token = numericUpDown.Parent.Tag as JToken;
                SetConfigValue(int.Parse(numericUpDown.Value.ToString()), token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                txtLog.Text += $"ERROR changing numeric value!{Environment.NewLine}{ex}{Environment.NewLine}";
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = sender as CheckBox;
                JToken token = checkBox.Parent.Tag as JToken;
                SetConfigValue(checkBox.Checked, token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                txtLog.Text += $"ERROR changing bool value!{Environment.NewLine}{ex}{Environment.NewLine}";
            }

        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                JToken token = textBox.Parent.Tag as JToken;
                SetConfigValue(textBox.Text, token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                txtLog.Text += $"ERROR changing string value!{Environment.NewLine}{ex}{Environment.NewLine}";
            }
        }

        private void ArrayTextBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                JToken token = textBox.Parent.Tag as JToken;
                SetConfigValue(textBox.Text.Trim().Split(','), token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                txtLog.Text += $"ERROR changing array value!{Environment.NewLine}{ex}{Environment.NewLine}";
            }
        }

        private void InitLoadedModConfigs(bool clearSelection = false)
        {
            ddlSelectedMod.Items.Clear();
            foreach (var key in modList.Keys)
            {
                if (File.Exists(gameDir + key))
                {
                    ddlSelectedMod.Items.Add(key);
                }
            }
            if (clearSelection)
            {
                ddlSelectedMod.Text = ddlSelectedMod.ToolTipText;
            }
        }

        private void ResetSelectedConfigControls()
        {
            foreach (Control uc in userControlContainer.Controls)
            {
                if (uc is UserControlInteger)
                {
                    (uc as UserControlInteger).numericUpDown.ValueChanged -= NumericUpDownInt_ValueChanged;
                }
                else if (uc is UserControlDecimal)
                {
                    (uc as UserControlDecimal).numericUpDown.ValueChanged -= NumericUpDown_ValueChanged;
                }
                else if (uc is UserControlBoolean)
                {
                    (uc as UserControlBoolean).checkBox.CheckedChanged -= CheckBox_CheckedChanged;
                }
                else if (uc is UserControlString)
                {
                    (uc as UserControlString).textBox.LostFocus -= TextBox_LostFocus;
                }
                else if (uc is UserControlArray)
                {
                    (uc as UserControlArray).textBox.LostFocus -= ArrayTextBox_LostFocus;
                }
            }
            userControlContainer.Controls.Clear();
        }

        private void UpdateToolbarButtons()
        {
            bool isModSelected = ddlSelectedMod.SelectedIndex != -1;
            btnRemoveModConfig.Enabled = isModSelected;
            btnSave.Enabled = isModSelected;
            btnBackupSingle.Enabled = isModSelected;
            btnWeb.Enabled = isModSelected && nexusLinks.ContainsKey(ddlSelectedMod.SelectedItem.ToString().ToLower());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitLoadedModConfigs();
            if (settings[SETTING_X] != null) this.Left = (int)settings[SETTING_X];
            if (settings[SETTING_Y] != null) this.Top = (int)settings[SETTING_Y];
            if (settings[SETTING_W] != null) this.Width = (int)settings[SETTING_W];
            if (settings[SETTING_H] != null) this.Height = (int)settings[SETTING_H];
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            UpdateToolbarButtons();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            if (configEdited)
            {
                if (MessageBox.Show($"You have unsaved changes.{Environment.NewLine}Are you sure you want to discard changes and exit?", "Discard Changes and Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ddlSelectedMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configEdited)
            {
                if (MessageBox.Show($"You have unsaved changes.{Environment.NewLine}Are you sure you want to discard changes and switch to selected config?", "Discard Changes and Switch?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
            }
            UpdateToolbarButtons();
            //ResetSelectedConfigControls();
            if (sender == null)
            {
                return;
            }

            string file = "";
            try
            {
                configEdited = false;
                file = ddlSelectedMod.SelectedItem.ToString();
                string fileContent = File.ReadAllText(gameDir + file);
                RefreshConfigTree(fileContent);
                logStatus = $"Config file {file} loaded!";
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR loading config {file}: {ex}";
                MessageBox.Show($"Error loading config {file}:{Environment.NewLine}{ex}", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewModConfig_DropDownOpening(object sender, EventArgs e)
        {
            LoadModConfigFiles();
        }

        private void btnAddNewModConfig_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddModConfigFile(e.ClickedItem.Text);
        }

        private void btnRemoveModConfig_Click(object sender, EventArgs e)
        {
            RemoveModConfigFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void btnBackup_ButtonClick(object sender, EventArgs e)
        {
            if (ddlSelectedMod.SelectedIndex != -1)
            {
                Backup();
            }
        }

        private void btnBackupAll_Click(object sender, EventArgs e)
        {
            Backup(true);
        }

        private void btnOpenBackupDirectory_Click(object sender, EventArgs e)
        {
            OpenBackupDirectory();
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            OpenNexusUrl();
        }

        private void ddlRestoreBackup_DropDownOpened(object sender, EventArgs e)
        {
            ListBackups();
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void jsonTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (nodeEditUserControl != null)
            {
                ResetSelectedConfigControls();
            }

            selectedNode = e.Node;
            if (selectedNode.Tag == null)
            {
                selectedNodeToken = null;
                return;
            }
            selectedNodeToken = selectedNode.Tag as JToken;
            //tbLog.Text += $"Node: {selectedNode.Text}, {selectedNode.FullPath}, {selectedNode.Tag}{Environment.NewLine}";

            switch (selectedNodeToken.Type)
            {
                case JTokenType.Object:
                    break;
                case JTokenType.Array:
                    break;
                case JTokenType.Integer:
                    {
                        var uc = new UserControlInteger();
                        uc.Tag = selectedNodeToken;
                        uc.label.Text = $"int {selectedNodeToken.Path}";
                        uc.numericUpDown.Value = int.Parse(selectedNodeToken.ToString());
                        uc.numericUpDown.ValueChanged += NumericUpDownInt_ValueChanged;
                        userControlContainer.Controls.Add(uc);
                        nodeEditUserControl = uc;
                        break;
                    }
                case JTokenType.Float:
                    {
                        var uc = new UserControlDecimal();
                        uc.Tag = selectedNodeToken;
                        uc.label.Text = $"float {selectedNodeToken.Path}";
                        uc.numericUpDown.Value = decimal.Parse(selectedNodeToken.ToString());
                        uc.numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
                        userControlContainer.Controls.Add(uc);
                        nodeEditUserControl = uc;
                        break;
                    }
                case JTokenType.Boolean:
                    {
                        var uc = new UserControlBoolean();
                        uc.Tag = selectedNodeToken;
                        uc.checkBox.Text = selectedNodeToken.Path;
                        uc.checkBox.Checked = bool.Parse(selectedNodeToken.ToString());
                        uc.checkBox.CheckedChanged += CheckBox_CheckedChanged;
                        userControlContainer.Controls.Add(uc);
                        nodeEditUserControl = uc;
                        break;
                    }
                case JTokenType.String:
                    {
                        var uc = new UserControlString();
                        uc.Tag = selectedNodeToken;
                        uc.label.Text = selectedNodeToken.Path;
                        uc.textBox.Text = selectedNodeToken.ToString();
                        uc.textBox.LostFocus += TextBox_LostFocus;
                        userControlContainer.Controls.Add(uc);
                        nodeEditUserControl = uc;
                        break;
                    }
                default:
                    break;
            }

        }

        private void btnAddNewModConfig_ButtonClick(object sender, EventArgs e)
        {
            LoadModConfigFiles();
            btnAddNewModConfig.DropDown.Show(btnAddNewModConfig.DropDown.Left, btnAddNewModConfig.DropDown.Top);
        }
    }
}
