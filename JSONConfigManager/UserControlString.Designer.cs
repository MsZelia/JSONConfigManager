
namespace JSONConfigManager
{
    partial class UserControlString
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label.Location = new System.Drawing.Point(-10, 1);
            this.label.Name = "label";
            this.label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label.Size = new System.Drawing.Size(350, 24);
            this.label.TabIndex = 2;
            this.label.Text = "label1";
            this.label.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.textBox.Location = new System.Drawing.Point(5, 27);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(345, 27);
            this.textBox.TabIndex = 3;
            // 
            // UserControlString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label);
            this.Name = "UserControlString";
            this.Size = new System.Drawing.Size(355, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label;
        public System.Windows.Forms.TextBox textBox;
    }
}
