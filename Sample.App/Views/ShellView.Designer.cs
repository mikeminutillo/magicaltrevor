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
            this.components = new System.ComponentModel.Container();
            this.FullName = new System.Windows.Forms.TextBox();
            this.Go = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Main = new Magical.Trevor.Controls.Placeholder(this.components);
            this.SuspendLayout();
            // 
            // FullName
            // 
            this.FullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FullName.Location = new System.Drawing.Point(3, 10);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(199, 20);
            this.FullName.TabIndex = 0;
            // 
            // Go
            // 
            this.Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Go.Location = new System.Drawing.Point(211, 7);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(75, 23);
            this.Go.TabIndex = 1;
            this.Go.Text = "Go";
            this.Go.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.Location = new System.Drawing.Point(211, 266);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main.BackColor = System.Drawing.Color.Transparent;
            this.Main.Location = new System.Drawing.Point(4, 37);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(282, 223);
            this.Main.TabIndex = 3;
            this.Main.ViewModel = null;
            // 
            // ShellView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.FullName);
            this.Name = "ShellView";
            this.Size = new System.Drawing.Size(289, 292);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FullName;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.Button Exit;
        private Magical.Trevor.Controls.Placeholder Main;
    }
}
