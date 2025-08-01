
namespace JSONConfigManager
{
    partial class UserControlDecimal
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
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown
            // 
            this.numericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown.DecimalPlaces = 3;
            this.numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericUpDown.Location = new System.Drawing.Point(290, 0);
            this.numericUpDown.Maximum = new decimal(new int[] {
            int.MaxValue,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            int.MinValue,
            0,
            0,
            -2147483648});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown.Size = new System.Drawing.Size(80, 27);
            this.numericUpDown.TabIndex = 0;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label.Location = new System.Drawing.Point(20, 0);
            this.label.Name = "label";
            this.label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label.Size = new System.Drawing.Size(264, 24);
            this.label.TabIndex = 1;
            this.label.Text = "label1";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserControlDecimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Controls.Add(this.numericUpDown);
            this.Name = "UserControlDecimal";
            this.Size = new System.Drawing.Size(370, 30);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NumericUpDown numericUpDown;
        public System.Windows.Forms.Label label;
    }
}
