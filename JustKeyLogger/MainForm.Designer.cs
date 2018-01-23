namespace JustKeyLogger
{
    partial class MainForm
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
            this.LogFileDirectoryLabel = new System.Windows.Forms.Label();
            this.LogFileBrowseButton = new System.Windows.Forms.Button();
            this.LogFileInExplorerButton = new System.Windows.Forms.Button();
            this.LogFileDirectoryLocationTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.SendEmailButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogFileDirectoryLabel
            // 
            this.LogFileDirectoryLabel.AutoSize = true;
            this.LogFileDirectoryLabel.Location = new System.Drawing.Point(37, 85);
            this.LogFileDirectoryLabel.Name = "LogFileDirectoryLabel";
            this.LogFileDirectoryLabel.Size = new System.Drawing.Size(92, 13);
            this.LogFileDirectoryLabel.TabIndex = 0;
            this.LogFileDirectoryLabel.Text = "Log File Directory:";
            // 
            // LogFileBrowseButton
            // 
            this.LogFileBrowseButton.Location = new System.Drawing.Point(447, 85);
            this.LogFileBrowseButton.Name = "LogFileBrowseButton";
            this.LogFileBrowseButton.Size = new System.Drawing.Size(90, 23);
            this.LogFileBrowseButton.TabIndex = 2;
            this.LogFileBrowseButton.Text = "Browse";
            this.LogFileBrowseButton.UseVisualStyleBackColor = true;
            this.LogFileBrowseButton.Click += new System.EventHandler(this.LogFileBrowseButton_Click);
            // 
            // LogFileInExplorerButton
            // 
            this.LogFileInExplorerButton.Location = new System.Drawing.Point(543, 85);
            this.LogFileInExplorerButton.Name = "LogFileInExplorerButton";
            this.LogFileInExplorerButton.Size = new System.Drawing.Size(115, 23);
            this.LogFileInExplorerButton.TabIndex = 3;
            this.LogFileInExplorerButton.Text = "Show in Explorer";
            this.LogFileInExplorerButton.UseVisualStyleBackColor = true;
            this.LogFileInExplorerButton.Click += new System.EventHandler(this.LogFileInExplorerButton_Click);
            // 
            // LogFileDirectoryLocationTextBox
            // 
            this.LogFileDirectoryLocationTextBox.Location = new System.Drawing.Point(135, 85);
            this.LogFileDirectoryLocationTextBox.Name = "LogFileDirectoryLocationTextBox";
            this.LogFileDirectoryLocationTextBox.Size = new System.Drawing.Size(306, 20);
            this.LogFileDirectoryLocationTextBox.TabIndex = 4;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(50, 169);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 5;
            this.EmailLabel.Text = "Email:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(135, 169);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(306, 20);
            this.EmailTextBox.TabIndex = 6;
            // 
            // SendEmailButton
            // 
            this.SendEmailButton.Location = new System.Drawing.Point(447, 169);
            this.SendEmailButton.Name = "SendEmailButton";
            this.SendEmailButton.Size = new System.Drawing.Size(211, 23);
            this.SendEmailButton.TabIndex = 7;
            this.SendEmailButton.Text = "Send Email";
            this.SendEmailButton.UseVisualStyleBackColor = true;
            this.SendEmailButton.Click += new System.EventHandler(this.SendEmailButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(243, 307);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(198, 45);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(447, 307);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(211, 45);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(37, 323);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(63, 13);
            this.StatusLabel.TabIndex = 10;
            this.StatusLabel.Text = "Status: OFF";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 397);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SendEmailButton);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.LogFileDirectoryLocationTextBox);
            this.Controls.Add(this.LogFileInExplorerButton);
            this.Controls.Add(this.LogFileBrowseButton);
            this.Controls.Add(this.LogFileDirectoryLabel);
            this.Name = "MainForm";
            this.Text = "Just Key Logger";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogFileDirectoryLabel;
        private System.Windows.Forms.Button LogFileBrowseButton;
        private System.Windows.Forms.Button LogFileInExplorerButton;
        private System.Windows.Forms.TextBox LogFileDirectoryLocationTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button SendEmailButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label StatusLabel;
    }
}

