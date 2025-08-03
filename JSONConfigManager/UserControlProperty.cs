using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONConfigManager
{
    public partial class UserControlProperty : UserControl
    {
        public event EventHandler TextFieldDataSubmit;

        private Dictionary<string, string> dict = new Dictionary<string, string> {
            { "string", "" },
            { "int", "0" },
            {"decimal", "0.0" },
            {"bool", "false"},
            {"array", "[]"},
            {"object", "{}"} };

        public UserControlProperty()
        {
            InitializeComponent();
        }

        private void UserControlProperty_Load(object sender, EventArgs e)
        {
            string[] items = dict.Keys.ToArray();
            ddlType.Items.AddRange(items);
            ddlType.SelectedIndex = 0;
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextFieldDataSubmit.Invoke(this, new EventArgs());
            }
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedItem != null)
            {
                textBoxValue.Text = dict[ddlType.SelectedItem.ToString()];
                textBoxValue.Multiline = ddlType.SelectedIndex > 3;
            }
        }
    }
}
