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

        public UserControlProperty()
        {
            InitializeComponent();
        }

        private void UserControlProperty_Load(object sender, EventArgs e)
        {
            string[] items = { "string", "int", "decimal", "bool", "array", "object" };
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
            if(ddlType.SelectedItem.ToString() == "array")
            {
                textBoxValue.Text = "[]";
            }
            else if(ddlType.SelectedItem.ToString() == "object")
            {
                textBoxValue.Text = "{}";
            }
        }
    }
}
