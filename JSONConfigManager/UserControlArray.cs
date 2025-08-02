using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JSONConfigManager
{
    public partial class UserControlArray : UserControl
    {
        public UserControlArray()
        {
            InitializeComponent();
        }

        private void UserControlArray_Load(object sender, EventArgs e)
        {
            string[] items = { "string", "int", "decimal", "bool", "array", "object" };
            ddlType.Items.AddRange(items);
            ddlType.SelectedIndex = 0;
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InvokeLostFocus(textBox, null);
            }
        }
    }
}
