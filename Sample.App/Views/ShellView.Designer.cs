namespace Sample.App.Views
{
    partial class ShellView
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
            this.FullName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FullName
            // 
            this.FullName.Location = new System.Drawing.Point(3, 3);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(199, 20);
            this.FullName.TabIndex = 0;
            // 
            // ShellView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FullName);
            this.Name = "ShellView";
            this.Size = new System.Drawing.Size(519, 385);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FullName;
    }
}
