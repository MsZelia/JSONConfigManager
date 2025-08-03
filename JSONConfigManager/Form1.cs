using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
        private const string SETTING_SPLIT_1 = "split1";
        private const string SETTING_SPLIT_2 = "split2";
        private const string SETTING_SPLIT_3 = "split3";
        private const string SETTING_DARK_THEME = "useDarkTheme";
        private const string SETTING_GAME_DIR = "gameDir";
        private const string SETTING_MOD_LIST = "modList";
        private const string SETTING_CUSTOM_LINKS = "customLinks";

        public string settingsDir = AppDomain.CurrentDomain.BaseDirectory + System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".json";

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

        public Dictionary<string, string> customLinks = new Dictionary<string, string>();

        private JToken settings = null;

        private JToken config = null;

        private bool configEdited = false;

        private TreeNode selectedNode;

        private JToken selectedNodeToken;

        private UserControl nodeEditUserControl;

        private string lastJsonText = string.Empty;

        private bool isDarkMode = false;

        private Color[] DarkColors = { Color.FromArgb(30, 30, 30), Color.FromArgb(50, 50, 50), Color.White };
        private Color[] LightColors = { Color.FromArgb(230, 230, 230), Color.FromArgb(190, 190, 190), Color.Black };

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

        public bool IsDarkMode
        {
            get => isDarkMode;
            set
            {
                if (value != isDarkMode)
                {
                    isDarkMode = value;
                    ToggleDarkMode();
                }
            }
        }

        #region SETTINGS
        private void LoadSettings()
        {
            try
            {
                string fileContent = File.ReadAllText(settingsDir);
                settings = JObject.Parse(fileContent);
                if (settings[SETTING_GAME_DIR] != null)
                {
                    gameDir = (string)settings[SETTING_GAME_DIR];
                }
                if (settings[SETTING_MOD_LIST] != null)
                {
                    foreach (var mod in settings[SETTING_MOD_LIST].ToArray())
                    {
                        modList.Add((string)mod, (string)mod);
                    }
                }
                if (settings[SETTING_CUSTOM_LINKS] != null)
                {
                    foreach (JProperty customLink in settings[SETTING_CUSTOM_LINKS])
                    {
                        customLinks.Add(customLink.Name, customLink.Value.ToString());
                        txtLog.Text += "customLink: " + customLink.Name + ":" + customLink.Value + "\n";
                    }
                }
                logStatus = $"Settings loaded!";
            }
            catch (FileNotFoundException)
            {
                SaveSettings();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show($"Error loading settings:{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}Do you want to restore default settings?", "Restore Default Settings?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    SaveSettings();
                }
                else
                {
                    Close();
                }
            }
        }

        private void SaveSettings()
        {
            try
            {
                if (settings == null)
                {
                    settings = JToken.Parse("{}");
                }

                settings[SETTING_X] = this.Left == 0 ? 50 : this.Left;
                settings[SETTING_Y] = this.Top == 0 ? 50 : this.Top;
                settings[SETTING_W] = this.Width;
                settings[SETTING_H] = this.Height;
                settings[SETTING_SPLIT_1] = splitContainer1.SplitterDistance;
                settings[SETTING_SPLIT_2] = splitContainer2.SplitterDistance;
                settings[SETTING_SPLIT_3] = splitContainer3.SplitterDistance;
                settings[SETTING_DARK_THEME] = IsDarkMode;
                settings[SETTING_GAME_DIR] = gameDir;
                var keys = modList.Keys.ToArray();
                Array.Sort(keys);
                settings[SETTING_MOD_LIST] = JToken.FromObject(keys);
                settings[SETTING_CUSTOM_LINKS] = JToken.FromObject(customLinks);

                File.WriteAllText(settingsDir, settings.ToString());
                logStatus = $"Settings saved!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings:{Environment.NewLine}{ex/*.Message*/}", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DARK MODE
        private void InitializeDarkTheme(Control control)
        {
            toolStrip1.BackColor = DarkColors[1];
            toolStrip1.ForeColor = DarkColors[2];
            statusStrip.BackColor = DarkColors[1];
            statusStrip.ForeColor = DarkColors[2];
            userControlContainer.BackColor = DarkColors[1];
            userControlContainer.ForeColor = DarkColors[2];
            txtLog.BackColor = DarkColors[1];
            txtLog.ForeColor = DarkColors[2];
            txtJson.BackColor = DarkColors[0];
            txtJson.ForeColor = DarkColors[2];
            jsonTreeView.BackColor = DarkColors[0];
            jsonTreeView.ForeColor = DarkColors[2];
            splitContainer1.BackColor = DarkColors[0];
            splitContainer2.BackColor = DarkColors[0];
            splitContainer3.BackColor = DarkColors[0];
        }

        private void ResetDarkTheme(Control control)
        {
            toolStrip1.BackColor = LightColors[1];
            toolStrip1.ForeColor = LightColors[2];
            statusStrip.BackColor = LightColors[1];
            statusStrip.ForeColor = LightColors[2];
            userControlContainer.BackColor = LightColors[1];
            userControlContainer.ForeColor = LightColors[2];
            txtLog.BackColor = LightColors[1];
            txtLog.ForeColor = LightColors[2];
            txtJson.BackColor = LightColors[0];
            txtJson.ForeColor = LightColors[2];
            jsonTreeView.BackColor = LightColors[0];
            jsonTreeView.ForeColor = LightColors[2];
            splitContainer1.BackColor = LightColors[0];
            splitContainer2.BackColor = LightColors[0];
            splitContainer3.BackColor = LightColors[0];
        }

        private void ToggleDarkMode()
        {
            if (IsDarkMode)
            {
                InitializeDarkTheme(this);
            }
            else
            {
                ResetDarkTheme(this);
            }
        }
        #endregion

        #region GAME DIRECTORY
        private void SelectGameLocation()
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
                        UpdateToolbarButtons();
                        InitLoadedModConfigs();
                    }
                    else
                    {
                        MessageBox.Show($"Invalid game directory, folder does not exist!{Environment.NewLine}{selectedDir}", "Game dir error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region BACKUPS
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
                MessageBox.Show($"Error backing up file {file}:{Environment.NewLine}{ex}", "Backup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
                    MessageBox.Show("Backup restoration finished!", "Restore All", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (RestoreFile(dir))
                    {
                        MessageBox.Show($"{dir} restored!", "Restore File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring files:{Environment.NewLine}{ex/*.Message*/}", "Restore error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error restoring file {file}:{Environment.NewLine}{ex}", "Restore error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error loading backups:{Environment.NewLine}{ex/*.Message*/}", "Restore error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    Directory.CreateDirectory(backupDir);
                    OpenBackupDirectory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening backup directory:{Environment.NewLine}{ex}", "Backup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region URLS
        private void OpenNexusUrl()
        {
            try
            {
                string file = ddlSelectedMod.Text.ToLower();
                if (customLinks.ContainsKey(file))
                {
                    Process.Start(customLinks[file]);
                    return;
                }
                if (nexusLinks.ContainsKey(file))
                {
                    Process.Start(nexusURL + nexusLinks[file]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening URL:{Environment.NewLine}{ex/*.Message*/}", "Web error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDragDroppedURL(string unicode)
        {
            if (unicode == null)
            {
                return;
            }
            if (Uri.TryCreate(unicode, UriKind.Absolute, out Uri uri))
            {
                customLinks.Add(ddlSelectedMod.SelectedItem.ToString().ToLower(), uri.ToString());
                txtLog.Text += $"Added custom URL for {ddlSelectedMod.SelectedItem}: {uri}{Environment.NewLine}";
                UpdateToolbarButtons();
            }
            else
            {
                txtLog.Text += $"URL invalid, not adding custom URL {unicode}!{Environment.NewLine}";
            }
        }
        #endregion

        #region CONFIG FILE MANIPULATION
        private void SaveFile()
        {
            try
            {
                if (ddlSelectedMod.SelectedIndex == -1)
                {
                    return;
                }
                string file = ddlSelectedMod.SelectedItem.ToString();
                string cnf = config.ToString();
                File.WriteAllText(gameDir + file, cnf);
                logStatus = $"Saved all changes to {file}";
                configEdited = false;

                MessageBox.Show($"Saved all changes to {file}.", "Save file", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Saving file:{Environment.NewLine}{ex/*.Message*/}", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddModConfigFile(string file)
        {
            try
            {
                FileInfo info = new FileInfo(gameDir + file);
                modList.Add(file, file);
                InitLoadedModConfigs();
                ddlSelectedMod.SelectedIndex = ddlSelectedMod.Items.Count - 1;
                logStatus = $"Config file {file} added!";
                SaveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding config file:{Environment.NewLine}{ex/*.Message*/}", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            InitLoadedModConfigs(true);
            SaveSettings();
            UpdateToolbarButtons();
            jsonTreeView.Nodes.Clear();
            txtJson.Text = string.Empty;
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
                logStatus = "Config files loaded";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config files:{Environment.NewLine}{ex/*.Message*/}", "Restore error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AddDragDroppedFiles(string[] files)
        {
            foreach (string filePath in files)
            {
                string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                if (filePath.IndexOf(gameDir) == -1)
                {
                    txtLog.Text += $"Not adding config file {fileName}, not located in game directory!{Environment.NewLine}";
                    continue;
                }
                if (fileName.ToLower().IndexOf(".json") == -1)
                {
                    txtLog.Text += $"Not adding config file {fileName}, not Json extension!{Environment.NewLine}";
                    continue;
                }
                if (modList.ContainsKey(fileName))
                {
                    txtLog.Text += $"Not adding config file {fileName}, config file already exists with that name!{Environment.NewLine}";
                    continue;
                }
                txtLog.Text += $"Adding config file {fileName}{Environment.NewLine}";
                AddModConfigFile(fileName);
            }
        }
        #endregion

        #region CONFIG EDITING
        private void ApplyManualEditChanges()
        {
            try
            {
                if (txtJson.Text.Trim() == string.Empty)
                {
                    return;
                }
                if (lastJsonText != txtJson.Text)
                {
                    configEdited = true;
                    JObject.Parse(txtJson.Text);
                    RefreshConfigTree(txtJson.Text);
                    txtLog.Text += $"Changes from manual edit applied!{Environment.NewLine}";
                }
            }
            catch (Exception ex)
            {
                txtLog.Text += $"Invalid Json from manual changes!{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}";
            }
        }

        private void SetConfigValue(object value, JToken token)
        {
            if (token.Type == JTokenType.Array)
            {
                var prop = token as JArray;
                if (value is Array)
                {
                    foreach (var item in value as Array)
                    {
                        var newElement = JToken.FromObject(item);
                        prop.Add(newElement);
                        txtLog.Text += $"{token.Path}: added element {item.ToString().Replace(',', '.')} ({newElement.Type}){Environment.NewLine}";
                    }
                }
                else if (value is JToken)
                {
                    if (value is JToken newElement)
                    {
                        prop.Add(newElement);
                        txtLog.Text += $"{token.Path}: added element {newElement} ({newElement.Type}){Environment.NewLine}";
                    }
                }
                RefreshConfigTree();
            }
            else if (token.Type == JTokenType.Object && value is KeyValuePair<string, object> kvPair)
            {
                var obj = token as JObject;
                JToken newElement;
                if (kvPair.Value is JToken)
                {
                    newElement = kvPair.Value as JToken;
                }
                else
                {
                    newElement = JToken.FromObject(kvPair.Value);
                }
                obj.Add(kvPair.Key, newElement);
                txtLog.Text += $"{(token.Path.Length == 0 ? "root" : token.Path)}: added property {kvPair.Key}: {newElement} ({newElement.Type}){Environment.NewLine}";
                RefreshConfigTree();
            }
            else if (token.Parent is JProperty || token.Parent is JArray && token is JValue)
            {
                var prop = token as JValue;
                var prevValue = prop.Value;
                if (value is int i) prop.Value = i;
                else if (value is decimal d) prop.Value = d;
                else if (value is bool b) prop.Value = b;
                else if (value is string s && (string)prevValue != s) prop.Value = s;
                if (prevValue != prop.Value)
                {
                    txtLog.Text += $"{token.Path}: {prevValue} -> {prop.Value}{Environment.NewLine}";
                    RefreshConfigTree();
                }
            }
            else
            {
                txtLog.Text += $"Parent is {token.Parent.Type}: {token.Parent}{Environment.NewLine}";
            }
        }

        private void RefreshConfigTree(string json = null)
        {
            string selectedPath = string.Empty;
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
            if (selectedPath != string.Empty)
            {
                selectedNode = GetNodeFromPath(jsonTreeView.TopNode, selectedPath);
                if (selectedNode != null)
                {
                    selectedNode.EnsureVisible();
                    selectedNodeToken = selectedNode.Tag as JToken;
                    jsonTreeView_NodeMouseClick(null, new TreeNodeMouseClickEventArgs(selectedNode, MouseButtons.Left, 1, 0, 0));
                    if (selectedNodeToken != null)
                    {
                        if (selectedNodeToken.Type == JTokenType.Array || selectedNodeToken.Type == JTokenType.Object)
                        {
                            selectedNode.Expand();
                        }
                    }
                }
            }
            config = jsonTreeView.JSON;
            txtJson.Text = config.ToString();
            lastJsonText = txtJson.Text;
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
                txtLog.Text += $"Error changing numeric value:{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}";
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
                txtLog.Text += $"Error changing numeric value:{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}";
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
                txtLog.Text += $"Error changing bool value:{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}";
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
                txtLog.Text += $"Error changing string value:{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}";
            }
        }

        private void TextBoxArray_DataSubmit(object sender, EventArgs e)
        {
            try
            {
                var ucArray = sender as UserControlArray;
                TextBox textBox = ucArray.textBox;
                string type = ucArray.ddlType.SelectedItem as string;
                JToken token = ucArray.Tag as JToken;

                object value = null;
                var txtValue = textBox.Text.Trim();
                if (type == "array")
                {
                    //object[] arr = { };
                    //array = new object[] { arr };
                    value = MapArray(txtValue);
                    if (value == null)
                    {
                        txtLog.Text += $"Error adding array: Invalid Json string!{Environment.NewLine}";
                        return;
                    }
                }
                else if (type == "object")
                {
                    //object obj = new object();
                    //array = new object[] { obj };
                    value = MapObject(txtValue);
                    if (value == null)
                    {
                        txtLog.Text += $"Error adding object: Invalid Json string!{Environment.NewLine}";
                        return;
                    }
                }
                else if (textBox.Text.Length > 0)
                {
                    value = textBox.Text.Split(',').Select(x => RemapObject(type, x)).ToArray();
                }
                else
                {
                    return;
                }

                SetConfigValue(value, token);
                configEdited = true;
                textBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                txtLog.Text += $"Error changing array value:{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}";
            }
        }

        private void TextBoxProperty_DataSubmit(object sender, EventArgs e)
        {
            try
            {
                var ucProp = sender as UserControlProperty;
                TextBox textBoxKey = ucProp.textBoxKey;
                TextBox textBoxValue = ucProp.textBoxValue;
                string type = ucProp.ddlType.SelectedItem as string;
                JToken token = ucProp.Tag as JToken;

                string key;
                object value = null;
                if (textBoxKey.Text.Trim().Length == 0)
                {
                    return;
                }
                key = textBoxKey.Text.Trim();
                var txtValue = textBoxValue.Text.Trim();
                if (type == "array")
                {
                    //value = new object[] { };
                    value = MapArray(txtValue);
                    if (value == null)
                    {
                        txtLog.Text += $"Error adding array: Invalid Json string!{Environment.NewLine}";
                        return;
                    }
                }
                else if (type == "object")
                {
                    //value = new object();
                    value = MapObject(txtValue);
                    if (value == null)
                    {
                        txtLog.Text += $"Error adding object: Invalid Json string!{Environment.NewLine}";
                        return;
                    }
                }
                else if (txtValue.Length > 0)
                {
                    value = RemapObject(type, txtValue);
                }
                else
                {
                    return;
                }
                var prop = new KeyValuePair<string, object>(key, value);
                SetConfigValue(prop, token);
                configEdited = true;
                textBoxKey.Text = string.Empty;
                textBoxValue.Text = string.Empty;
            }
            catch (Exception ex)
            {
                txtLog.Text += $"Error adding property value:{Environment.NewLine}{ex/*.Message*/}{Environment.NewLine}";
            }
        }

        private void SelectModConfigFile()
        {
            if (configEdited)
            {
                if (MessageBox.Show($"You have unsaved changes.{Environment.NewLine}Are you sure you want to discard changes and switch to selected config?", "Discard Changes and Switch?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
            }
            configEdited = false;
            UpdateToolbarButtons();
            //ResetSelectedConfigControls();
            if (ddlSelectedMod.SelectedIndex == -1)
            {
                return;
            }

            string file = string.Empty;
            try
            {
                file = ddlSelectedMod.SelectedItem.ToString();
                string fileContent = File.ReadAllText(gameDir + file);
                RefreshConfigTree(fileContent);
                logStatus = $"Config file {file} loaded!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config {file}:{Environment.NewLine}{ex}", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSelectedConfigEditControls(TreeNodeMouseClickEventArgs e)
        {
            if (nodeEditUserControl != null)
            {
                ResetSelectedConfigControls();
            }

            selectedNode = e.Node;
            if (selectedNode.Tag == null)
            {
                selectedNodeToken = config;
            }
            else
            {
                selectedNodeToken = selectedNode.Tag as JToken;
            }
            //tbLog.Text += $"Node: {selectedNode.Text}, {selectedNode.FullPath}, {selectedNode.Tag}{Environment.NewLine}";

            switch (selectedNodeToken.Type)
            {
                case JTokenType.Object:
                    {
                        var uc = new UserControlProperty();
                        uc.Tag = selectedNodeToken;
                        uc.TextFieldDataSubmit += TextBoxProperty_DataSubmit;
                        userControlContainer.Controls.Add(uc);
                        nodeEditUserControl = uc;
                        break;
                    }
                case JTokenType.Array:
                    {
                        var uc = new UserControlArray();
                        uc.Tag = selectedNodeToken;
                        uc.TextFieldDataSubmit += TextBoxArray_DataSubmit;
                        userControlContainer.Controls.Add(uc);
                        nodeEditUserControl = uc;
                        break;
                    }
                case JTokenType.Integer:
                    {
                        var uc = new UserControlInteger();
                        uc.Tag = selectedNodeToken;
                        uc.label.Text = selectedNodeToken.Path;
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
                        uc.label.Text = selectedNodeToken.Path;
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
        #endregion

        #region UTILITIES
        private JToken MapArray(string value)
        {
            JToken token = null;
            try
            {
                token = JArray.Parse(value);
                return token;
            }
            catch (Exception) { }
            //token = JArray.Parse("[]");
            return token;
        }

        private JToken MapObject(string value)
        {
            JToken token = null;
            try
            {
                token = JObject.Parse(value);
                return token;
            }
            catch (Exception) { }
            //token = JObject.Parse("{}");
            return token;
        }

        private object RemapObject(string type, string value)
        {
            if (type == "string")
            {
                return value.Trim();
            }
            else if (type == "int")
            {
                if (int.TryParse(value, out int result))
                {
                    return result;
                }
                return 0;
            }
            else if (type == "decimal")
            {
                if (decimal.TryParse(value.Replace('.', ','), out decimal result))
                {
                    return result;
                }
                return decimal.Zero;
            }
            else if (type == "bool")
            {
                if (bool.TryParse(value, out bool result))
                {
                    return result;
                }
                return false;
            }
            return string.Empty;
        }

        private TreeNode GetNodeFromPath(TreeNode node, string path)
        {
            TreeNode foundNode = null;
            foreach (TreeNode tn in node.Nodes)
            {
                var tnPath = (tn.Tag as JToken)?.Path ?? string.Empty;
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

        private void UpdateToolbarButtons()
        {
            btnAddNewModConfig.Enabled = Directory.Exists(gameDir);
            ddlSelectedMod.Enabled = btnAddNewModConfig.Enabled;
            btnBackupAll.Enabled = btnAddNewModConfig.Enabled;
            ddlRestoreBackup.Enabled = btnAddNewModConfig.Enabled;
            bool isModSelected = ddlSelectedMod.SelectedIndex != -1;
            btnRemoveModConfig.Enabled = isModSelected;
            btnSave.Enabled = isModSelected;
            btnBackupSingle.Enabled = isModSelected;

            if (isModSelected)
            {
                var modName = ddlSelectedMod.SelectedItem.ToString().ToLower();
                var url = customLinks.ContainsKey(modName) ? customLinks[modName] : (nexusLinks.ContainsKey(modName) ? $"{nexusURL}{nexusLinks[modName]}" : string.Empty);
                if (url != string.Empty)
                {
                    btnWeb.Enabled = true;
                    btnWeb.ToolTipText = $"Open mod page:{Environment.NewLine}{url}{Environment.NewLine}{Environment.NewLine}{btnWeb.Tag}";
                }
                else
                {
                    btnWeb.Enabled = false;
                    btnWeb.ToolTipText = (string)btnWeb.Tag;
                }
            }
            else
            {
                btnWeb.Enabled = false;
                btnWeb.ToolTipText = (string)btnWeb.Tag;
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
                    (uc as UserControlArray).TextFieldDataSubmit -= TextBoxArray_DataSubmit;
                }
                else if (uc is UserControlProperty)
                {
                    (uc as UserControlProperty).TextFieldDataSubmit -= TextBoxProperty_DataSubmit;
                }
            }
            userControlContainer.Controls.Clear();
        }
        #endregion

        #region FORM EVENTS
        private void Form1_Load(object sender, EventArgs e)
        {
            InitLoadedModConfigs();
            if (settings[SETTING_X] != null) this.Left = (int)settings[SETTING_X];
            if (settings[SETTING_Y] != null) this.Top = (int)settings[SETTING_Y];
            if (settings[SETTING_W] != null) this.Width = Math.Max((int)settings[SETTING_W], this.MinimumSize.Width);
            if (settings[SETTING_H] != null) this.Height = Math.Max((int)settings[SETTING_H], this.MinimumSize.Height);

            if (settings[SETTING_SPLIT_1] != null) splitContainer1.SplitterDistance = (int)settings[SETTING_SPLIT_1];
            if (settings[SETTING_SPLIT_2] != null) splitContainer2.SplitterDistance = (int)settings[SETTING_SPLIT_2];
            if (settings[SETTING_SPLIT_3] != null) splitContainer3.SplitterDistance = (int)settings[SETTING_SPLIT_3];
            if (settings[SETTING_DARK_THEME] != null) IsDarkMode = (bool)settings[SETTING_DARK_THEME];
            else IsDarkMode = false;
            ToggleDarkMode();
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

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.UnicodeText))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                AddDragDroppedFiles(files);
            }
            else if (ddlSelectedMod.SelectedIndex != -1)
            {
                string unicode = (string)e.Data.GetData(DataFormats.UnicodeText);
                AddDragDroppedURL(unicode);
            }
        }
        #endregion

        #region UI EVENTS
        private void toolStripSplitButtonProfile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectGameLocation_Click(object sender, EventArgs e)
        {
            SelectGameLocation();
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            OpenNexusUrl();
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

        private void ddlRestoreBackup_DropDownOpened(object sender, EventArgs e)
        {
            ListBackups();
        }

        private void restoreBackup_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ValueTuple<string, bool> fileToRestore = (ValueTuple<string, bool>)(e.ClickedItem as ToolStripMenuItem).Tag;
            Restore(fileToRestore.Item1, fileToRestore.Item2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void ddlSelectedMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectModConfigFile();
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

        private void btnAddNewModConfig_ButtonClick(object sender, EventArgs e)
        {
            LoadModConfigFiles();
            btnAddNewModConfig.DropDown.Show(btnAddNewModConfig.DropDown.Left, btnAddNewModConfig.DropDown.Top);
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void jsonTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            InitializeSelectedConfigEditControls(e);
        }

        private void txtJson_Leave(object sender, EventArgs e)
        {
            ApplyManualEditChanges();
        }
        #endregion

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            IsDarkMode = !IsDarkMode;
        }
    }
}
