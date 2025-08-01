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

        private int yOffset = 0;


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
                if (settings["modList"] != null)
                {
                    foreach (var mod in settings["modList"].ToArray())
                    {
                        modList.Add((string)mod, (string)mod);
                    }
                }
                if (settings["gameDir"] != null)
                {
                    gameDir = (string)settings["gameDir"];
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

                settings["gameDir"] = gameDir;
                var keys = modList.Keys.ToArray();
                Array.Sort(keys);
                settings["modList"] = JToken.FromObject(keys);

                File.WriteAllText(file, settings.ToString());
                logStatus = $"Settings loaded!";
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

        private void ListChildren(JToken token)
        {
            foreach (var child in token.Children())
            {
                if (child.Type == JTokenType.Property)
                {
                    ListChildren(child);
                }
                else if (child.Type == JTokenType.Object)
                {
                    yOffset += 20;
                    ListChildren(child);
                }
                /*else if (child.Type == JTokenType.Array)
                {
                    var uc = new UserControlString();
                    uc.Tag = token;
                    uc.label.Text = token.Path + ":";
                    uc.textBox.Text = child.ToString();
                    uc.textBox.Enabled = false;
                    uc.Top = yOffset;
                    yOffset += uc.Height;
                    userControlContainer.Controls.Add(uc);

                    for (int subChildId = 0; subChildId < child.Children().Count(); subChildId++)
                    {
                        var subChild = child.Children().ElementAt(subChildId);
                        string key = subChild.Parent.Path + "[" + subChild + "]";
                        var ucChild = new UserControlString();
                        ucChild.Tag = subChild;
                        if (subChild.Type == JTokenType.String)
                        {

                        ucChild.label.Text = $"{key} {subChildId}:";
                        }
                        else
                        {
                        ucChild.label.Text = $"NOT_STRING ({subChild.Type})";
                            ucChild.label.ForeColor = Color.Red;
                        }
                        ucChild.textBox.Text = subChild.ToString();
                        ucChild.textBox.LostFocus += TextBox_LostFocus;
                        ucChild.Top = yOffset;
                        yOffset += ucChild.Height;
                        userControlContainer.Controls.Add(ucChild);
                    }

                }*/
                else
                {
                    switch (child.Type)
                    {
                        case JTokenType.Integer:
                            {
                                var uc = new UserControlInteger();
                                uc.Tag = token;
                                uc.label.Text = token.Path;//.Substring(token.Parent.Path.Length);
                                uc.numericUpDown.Value = int.Parse(child.ToString());
                                uc.numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
                                uc.Top = yOffset;
                                yOffset += uc.Height;
                                userControlContainer.Controls.Add(uc);
                                break;
                            }
                        case JTokenType.Float:
                            {
                                var uc = new UserControlDecimal();
                                uc.Tag = token;
                                uc.label.Text = token.Path;//.Substring(token.Parent.Path.Length);
                                uc.numericUpDown.Value = decimal.Parse(child.ToString());
                                uc.numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
                                uc.Top = yOffset;
                                yOffset += uc.Height;
                                userControlContainer.Controls.Add(uc);
                                break;
                            }
                        case JTokenType.Boolean:
                            {
                                var uc = new UserControlBoolean();
                                uc.Tag = token;
                                uc.checkBox.Text = token.Path;//.Substring(token.Parent.Path.Length);
                                uc.checkBox.Checked = bool.Parse(child.ToString());
                                uc.checkBox.CheckedChanged += CheckBox_CheckedChanged;
                                uc.Top = yOffset;
                                yOffset += uc.Height;
                                userControlContainer.Controls.Add(uc);
                                break;
                            }
                        case JTokenType.String:
                            {
                                var uc = new UserControlString();
                                uc.Tag = token;
                                uc.label.Text = token.Path + ":"; //.Substring(token.Parent.Path.Length);
                                uc.textBox.Text = child.ToString();
                                uc.textBox.LostFocus += TextBox_LostFocus;
                                uc.Top = yOffset;
                                yOffset += uc.Height;
                                userControlContainer.Controls.Add(uc);
                                break;
                            }
                        case JTokenType.Array:
                            {
                                var uc = new UserControlArray();
                                uc.Tag = token;
                                uc.label.Text = token.Path + ":";
                                uc.textBox.Text = string.Join(",", child.Children());
                                uc.textBox.LostFocus += ArrayTextBox_LostFocus;
                                uc.Top = yOffset;
                                yOffset += uc.Height;
                                userControlContainer.Controls.Add(uc);
                                break;
                            }
                        default:
                            {
                                tbLog.Text += $"Control not made for: {token.Path} ({child.Type}){Environment.NewLine}";
                                break;
                            }
                    }

                }
            }
        }

        private void SetConfigValue(object value, JToken token)
        {
            string key = token.Path.Substring(token.Parent.Path.Length).TrimStart('.');
            string parentKey = token.Parent.Path;

            JToken parent;
            if (parentKey == "")
            {
                parent = config;
            }
            else
            {
                parent = config[parentKey];
            }

            var previousValue = parent[key];
            if (value is int i) parent[key] = i;
            else if (value is decimal d) parent[key] = d;
            else if (value is bool b) parent[key] = b;
            else if (value is string s) parent[key] = s;
            else if (value is Array arr) parent[key] = JToken.FromObject(arr);
            tbLog.Text += $"{token.Path}: {previousValue} -> {parent[key]}{Environment.NewLine}";
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown numericUpDown = sender as NumericUpDown;
                JToken token = numericUpDown.Parent.Tag as JToken;
                bool isDecimal = numericUpDown.Parent is UserControlDecimal;
                SetConfigValue(isDecimal ? numericUpDown.Value : (int)numericUpDown.Value, token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                tbLog.Text += $"ERROR changing numeric value! {ex}{Environment.NewLine}";
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
                tbLog.Text += $"ERROR changing bool value! {ex}{Environment.NewLine}";
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
                tbLog.Text += $"ERROR changing string value! {ex}{Environment.NewLine}";
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
                tbLog.Text += $"ERROR changing string value! {ex}{Environment.NewLine}";
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
            yOffset = 0;
            tbLog.Text = "";
            foreach (Control uc in userControlContainer.Controls)
            {
                if (uc is UserControlInteger)
                {
                    (uc as UserControlInteger).numericUpDown.ValueChanged -= NumericUpDown_ValueChanged;
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
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            UpdateToolbarButtons();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            ResetSelectedConfigControls();
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

                this.config = JContainer.Parse(fileContent);
                ListChildren(config);
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
            tbLog.SelectionStart = tbLog.Text.Length;
            tbLog.ScrollToCaret();
        }
    }
}
