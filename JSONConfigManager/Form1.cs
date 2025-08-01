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

namespace JSONConfigValidator
{
    public partial class Form1 : Form
    {
        public string initDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Fallout76\\Data\\";

        public string backupDir = ".\\Backups\\";

        public string gameDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Fallout76\\Data\\";

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

        private int yOffset = 0;

        private JToken config = null;
        private bool configEdited = false;


        private JToken settings = null;


        public Form1()
        {
            InitializeComponent();
            loadConfig();
        }

        public string logStatus
        {
            get => lblStatus.Text;
            set
            {
                lblStatus.Text = value;
            }
        }

        private void loadConfig()
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
            catch (FileNotFoundException ex)
            {
                saveSettings();
            }
            catch (JsonReaderException ex)
            {
                saveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR loading settings: {ex.ToString()}");
            }
        }

        private void saveSettings()
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
                MessageBox.Show($"ERROR saving settings: {ex.ToString()}");
            }
        }

        private void backup(bool backupAll = false)
        {
            string file = ddlSelectedMod.Text;
            string backupTimeStampDir = backupDir + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss").Replace(':', '-') + "\\";

            try
            {
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR Making Backup Directory: {ex.ToString()}";
                return;
            }

            try
            {
                if (backupAll)
                {
                    foreach (var item in ddlSelectedMod.Items)
                    {
                        backupFile(item.ToString(), backupTimeStampDir);
                    }
                }
                else
                {
                    backupFile(file, backupTimeStampDir);
                }
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR Making Backup: {ex.ToString()}";
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

        private void backupFile(string file, string directory)
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
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR Backing Up File: {ex.ToString()}";
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
                        richTextBox1.Text += $"Game dir set: {selectedDir}{Environment.NewLine}";
                        saveSettings();
                    }
                    else
                    {
                        logStatus = $"ERROR Selected game dir invalid: {selectedDir}";
                        richTextBox1.Text += $"ERROR Selected game dir invalid: {selectedDir}{Environment.NewLine}";
                    }
                }
            }
        }

        private void listChildren(JToken token)
        {
            foreach (var child in token.Children())
            {
                if (child.Type == JTokenType.Property)
                {
                    listChildren(child);
                }
                else if (child.Type == JTokenType.Object)
                {
                    yOffset += 20;
                    listChildren(child);
                }
                else if (child.Type == JTokenType.Array)
                {
                    var uc = new UserControlString();
                    uc.Tag = token;
                    uc.label.Text = token.Path /*.Substring(token.Parent.Path.Length)*/ + ":";
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

                            ucChild.label.Text = $"{key} {subChildId}:" /*.Substring(token.Parent.Path.Length)*/;
                        }
                        else
                        {
                            ucChild.label.Text = $"NOT_STRING ({subChild.Type})"/*.Substring(token.Parent.Path.Length)*/ + ":";
                            ucChild.label.ForeColor = Color.Red;
                        }
                        ucChild.textBox.Text = subChild.ToString();
                        ucChild.textBox.LostFocus += TextBox_LostFocus;
                        ucChild.Top = yOffset;
                        yOffset += ucChild.Height;
                        userControlContainer.Controls.Add(ucChild);
                    }

                }
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
                                uc.label.Text = token.Path /*.Substring(token.Parent.Path.Length)*/ + ":";
                                uc.textBox.Text = child.ToString();
                                uc.textBox.LostFocus += TextBox_LostFocus;
                                uc.Top = yOffset;
                                yOffset += uc.Height;
                                userControlContainer.Controls.Add(uc);
                                break;
                            }
                        default:
                            {
                                richTextBox1.Text += $"Control not made for: {token.Path} ({child.Type}){Environment.NewLine}";
                                break;
                            }
                    }

                }
            }
        }

        private void setConfigValue(object value, JToken token)
        {
            string key = token.Path.Substring(token.Parent.Path.Length).TrimStart('.');
            string parentKey = token.Parent.Path;
            if (parentKey == "")
            {
                var previousValue = config[key];
                if (value is int) config[key] = (int)value;
                else if (value is decimal) config[key] = (decimal)value;
                else if (value is bool) config[key] = (bool)value;
                else if (value is string) config[key] = (string)value;
                richTextBox1.Text += $"{token.Path}: {previousValue} -> {config[key]}{Environment.NewLine}";
            }
            else
            {
                var previousValue = config[parentKey][key];
                if (value is int) config[parentKey][key] = (int)value;
                else if (value is decimal) config[parentKey][key] = (decimal)value;
                else if (value is bool) config[parentKey][key] = (bool)value;
                else if (value is string) config[parentKey][key] = (string)value;
                richTextBox1.Text += $"{token.Path}: {previousValue} -> {config[parentKey][key]}{Environment.NewLine}";
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NumericUpDown numericUpDown = sender as NumericUpDown;
                JToken token = numericUpDown.Parent.Tag as JToken;
                bool isDecimal = numericUpDown.Parent is UserControlDecimal;
                setConfigValue(isDecimal ? numericUpDown.Value : (int)numericUpDown.Value, token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"ERROR changing numeric value! {ex.ToString()}{Environment.NewLine}";
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = sender as CheckBox;
                JToken token = checkBox.Parent.Tag as JToken;
                setConfigValue(checkBox.Checked, token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"ERROR changing bool value! {ex.ToString()}{Environment.NewLine}";
            }

        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                JToken token = textBox.Parent.Tag as JToken;
                setConfigValue(textBox.Text.Trim(), token);
                configEdited = true;
            }
            catch (Exception ex)
            {
                richTextBox1.Text += $"ERROR changing string value! {ex.ToString()}{Environment.NewLine}";
            }
        }

        private void initLoadedModConfigs(bool clearSelection = false)
        {
            ddlSelectedMod.Items.Clear();
            foreach (var key in modList.Keys)
            {
                try
                {
                    if (File.Exists(gameDir + key))
                    {
                        ddlSelectedMod.Items.Add(key);
                    }
                }
                catch (Exception ex) { }
            }
            if (clearSelection)
            {
                ddlSelectedMod.Text = ddlSelectedMod.ToolTipText;
            }
        }

        private void resetSelectedConfigControls()
        {
            yOffset = 0;
            richTextBox1.Text = "";
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
            }
            userControlContainer.Controls.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initLoadedModConfigs();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (configEdited)
            {
                if (MessageBox.Show($"You have unsaved changes.{Environment.NewLine}Are you sure you want to discard changes and exit?", "Discard Changes and Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ddlSelectedMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configEdited)
            {
                if (MessageBox.Show($"You have unsaved changes.{Environment.NewLine}Are you sure you want to discard changes and switch to selected config?", "Discard Changes and Switch?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            resetSelectedConfigControls();
            if (sender == null)
            {
                return;
            }

            string file = "";
            try
            {
                configEdited = false;
                file = ddlSelectedMod.SelectedItem.ToString();
                btnWeb.Visible = nexusLinks.ContainsKey(file.ToLower());
                string fileContent = File.ReadAllText(gameDir + file);

                this.config = JContainer.Parse(fileContent);
                listChildren(config);
                logStatus = $"Config file {file} loaded!";
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR loading config {file}: {ex.ToString()}";
            }
        }

        private void btnAddNewModConfig_DropDownOpening(object sender, EventArgs e)
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
                logStatus = $"Error loading files: {ex.ToString()}";
            }
        }

        private void toolStripButtonAddNewModConfig_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                string file = e.ClickedItem.Text;
                FileInfo info = new FileInfo(gameDir + file);
                modList.Add(file, file);
                initLoadedModConfigs();
                logStatus = $"Config file {file} added!";
                saveSettings();
            }
            catch (Exception ex)
            {
                logStatus = $"Error adding config: {ex.ToString()}";
            }
        }

        private void btnRemoveModConfig_Click(object sender, EventArgs e)
        {
            if (modList.ContainsKey(ddlSelectedMod.Text))
            {
                modList.Remove(ddlSelectedMod.Text);
                logStatus = $"Config file {ddlSelectedMod.Text} removed!";
                ddlSelectedMod_SelectedIndexChanged(null, null);
                initLoadedModConfigs(true);
                saveSettings();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string file = "TestEdit.json";
                string cnf = config.ToString();
                File.WriteAllText(gameDir + file, cnf);
                logStatus = $"Saved all changes to {file}";
                configEdited = false;
            }
            catch (Exception ex)
            {
                logStatus = $"ERROR Saving file {ex.ToString()}";
            }
        }

        private void btnBackup_ButtonClick(object sender, EventArgs e)
        {
            backup();
        }

        private void btnBackupAll_Click(object sender, EventArgs e)
        {
            backup(true);
        }

        private void btnOpenBackupDirectory_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(backupDir))
            {
                Process.Start("explorer.exe", backupDir);
            }
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            string file = ddlSelectedMod.Text.ToLower();
            if (nexusLinks.ContainsKey(file))
            {
                Process.Start(nexusURL + nexusLinks[file]);
            }
        }
    }
}
