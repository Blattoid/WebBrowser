namespace WebBrowser
{
    partial class SettingsWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.defaultHomepageInput = new System.Windows.Forms.TextBox();
            this.homepageOptionLabel = new System.Windows.Forms.Label();
            this.rememberLastPage = new System.Windows.Forms.CheckBox();
            this.useHTTPS = new System.Windows.Forms.CheckBox();
            this.browserNameLabel = new System.Windows.Forms.Label();
            this.browserNameInput = new System.Windows.Forms.TextBox();
            this.iconSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.iconSelectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defaultHomepageInput
            // 
            this.defaultHomepageInput.Location = new System.Drawing.Point(12, 81);
            this.defaultHomepageInput.Name = "defaultHomepageInput";
            this.defaultHomepageInput.Size = new System.Drawing.Size(326, 26);
            this.defaultHomepageInput.TabIndex = 0;
            // 
            // homepageOptionLabel
            // 
            this.homepageOptionLabel.AutoSize = true;
            this.homepageOptionLabel.Location = new System.Drawing.Point(12, 58);
            this.homepageOptionLabel.Name = "homepageOptionLabel";
            this.homepageOptionLabel.Size = new System.Drawing.Size(88, 20);
            this.homepageOptionLabel.TabIndex = 2;
            this.homepageOptionLabel.Text = "Homepage";
            // 
            // rememberLastPage
            // 
            this.rememberLastPage.AutoSize = true;
            this.rememberLastPage.Location = new System.Drawing.Point(13, 115);
            this.rememberLastPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rememberLastPage.Name = "rememberLastPage";
            this.rememberLastPage.Size = new System.Drawing.Size(231, 24);
            this.rememberLastPage.TabIndex = 3;
            this.rememberLastPage.Text = "Remember last page visited";
            this.rememberLastPage.UseVisualStyleBackColor = true;
            // 
            // useHTTPS
            // 
            this.useHTTPS.AutoSize = true;
            this.useHTTPS.Checked = true;
            this.useHTTPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useHTTPS.Location = new System.Drawing.Point(12, 140);
            this.useHTTPS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.useHTTPS.Name = "useHTTPS";
            this.useHTTPS.Size = new System.Drawing.Size(293, 24);
            this.useHTTPS.TabIndex = 5;
            this.useHTTPS.Text = "Use https by default (recommended)";
            this.useHTTPS.UseVisualStyleBackColor = true;
            // 
            // browserNameLabel
            // 
            this.browserNameLabel.AutoSize = true;
            this.browserNameLabel.Location = new System.Drawing.Point(12, 9);
            this.browserNameLabel.Name = "browserNameLabel";
            this.browserNameLabel.Size = new System.Drawing.Size(100, 20);
            this.browserNameLabel.TabIndex = 6;
            this.browserNameLabel.Text = "Browser Title";
            // 
            // browserNameInput
            // 
            this.browserNameInput.Location = new System.Drawing.Point(12, 29);
            this.browserNameInput.Name = "browserNameInput";
            this.browserNameInput.Size = new System.Drawing.Size(326, 26);
            this.browserNameInput.TabIndex = 7;
            // 
            // iconSelectDialog
            // 
            this.iconSelectDialog.DefaultExt = "ico";
            this.iconSelectDialog.Filter = "Icon Files (*.ico)|*.ico";
            this.iconSelectDialog.Title = "Select Icon File";
            this.iconSelectDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.iconSelectDialog_FileOk);
            // 
            // iconSelectButton
            // 
            this.iconSelectButton.Location = new System.Drawing.Point(12, 172);
            this.iconSelectButton.Name = "iconSelectButton";
            this.iconSelectButton.Size = new System.Drawing.Size(100, 89);
            this.iconSelectButton.TabIndex = 8;
            this.iconSelectButton.Text = "Choose Icon";
            this.iconSelectButton.UseVisualStyleBackColor = true;
            this.iconSelectButton.Click += new System.EventHandler(this.iconSelectButton_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 562);
            this.Controls.Add(this.iconSelectButton);
            this.Controls.Add(this.browserNameInput);
            this.Controls.Add(this.browserNameLabel);
            this.Controls.Add(this.useHTTPS);
            this.Controls.Add(this.rememberLastPage);
            this.Controls.Add(this.homepageOptionLabel);
            this.Controls.Add(this.defaultHomepageInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(750, 100);
            this.MaximumSize = new System.Drawing.Size(374, 618);
            this.MinimumSize = new System.Drawing.Size(374, 618);
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox defaultHomepageInput;
        private System.Windows.Forms.Label homepageOptionLabel;
        private System.Windows.Forms.CheckBox rememberLastPage;
        private System.Windows.Forms.CheckBox useHTTPS;
        private System.Windows.Forms.Label browserNameLabel;
        private System.Windows.Forms.TextBox browserNameInput;
        private System.Windows.Forms.Button iconSelectButton;
        public System.Windows.Forms.OpenFileDialog iconSelectDialog;
    }
}