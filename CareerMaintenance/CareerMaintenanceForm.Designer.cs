namespace CareerMaintenance
{
    partial class CareerMaintenanceForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
      this.ExecuteMaintenanceButton = new System.Windows.Forms.Button();
      this.StatusTextBox = new System.Windows.Forms.TextBox();
      this.ScreenShotButton = new System.Windows.Forms.Button();
      this.StopButton = new System.Windows.Forms.Button();
      this.ResetButton = new System.Windows.Forms.Button();
      this.ProgressLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // ExecuteMaintenanceButton
      // 
      this.ExecuteMaintenanceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.ExecuteMaintenanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ExecuteMaintenanceButton.Location = new System.Drawing.Point(22, 21);
      this.ExecuteMaintenanceButton.Name = "ExecuteMaintenanceButton";
      this.ExecuteMaintenanceButton.Size = new System.Drawing.Size(519, 257);
      this.ExecuteMaintenanceButton.TabIndex = 0;
      this.ExecuteMaintenanceButton.Text = "Start";
      this.ExecuteMaintenanceButton.UseVisualStyleBackColor = false;
      this.ExecuteMaintenanceButton.Click += new System.EventHandler(this.ExecuteMaintenanceButton_Click);
      // 
      // StatusTextBox
      // 
      this.StatusTextBox.Location = new System.Drawing.Point(12, 400);
      this.StatusTextBox.Name = "StatusTextBox";
      this.StatusTextBox.Size = new System.Drawing.Size(776, 38);
      this.StatusTextBox.TabIndex = 1;
      // 
      // ScreenShotButton
      // 
      this.ScreenShotButton.Location = new System.Drawing.Point(547, 292);
      this.ScreenShotButton.Name = "ScreenShotButton";
      this.ScreenShotButton.Size = new System.Drawing.Size(229, 75);
      this.ScreenShotButton.TabIndex = 3;
      this.ScreenShotButton.Text = "ScreenShot";
      this.ScreenShotButton.UseVisualStyleBackColor = true;
      this.ScreenShotButton.Visible = false;
      this.ScreenShotButton.Click += new System.EventHandler(this.ScreenShotButton_Click);
      // 
      // StopButton
      // 
      this.StopButton.BackColor = System.Drawing.Color.Red;
      this.StopButton.Location = new System.Drawing.Point(547, 21);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(229, 123);
      this.StopButton.TabIndex = 4;
      this.StopButton.Text = "Stop";
      this.StopButton.UseVisualStyleBackColor = false;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // ResetButton
      // 
      this.ResetButton.BackColor = System.Drawing.Color.OrangeRed;
      this.ResetButton.Location = new System.Drawing.Point(547, 150);
      this.ResetButton.Name = "ResetButton";
      this.ResetButton.Size = new System.Drawing.Size(229, 128);
      this.ResetButton.TabIndex = 5;
      this.ResetButton.Text = "Reset";
      this.ResetButton.UseVisualStyleBackColor = false;
      this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
      // 
      // ProgressLabel
      // 
      this.ProgressLabel.AutoSize = true;
      this.ProgressLabel.BackColor = System.Drawing.Color.AntiqueWhite;
      this.ProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ProgressLabel.ForeColor = System.Drawing.Color.LightSeaGreen;
      this.ProgressLabel.Location = new System.Drawing.Point(28, 292);
      this.ProgressLabel.Name = "ProgressLabel";
      this.ProgressLabel.Size = new System.Drawing.Size(269, 91);
      this.ProgressLabel.TabIndex = 6;
      this.ProgressLabel.Text = "Ready";
      // 
      // CareerMaintenanceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.ProgressLabel);
      this.Controls.Add(this.ResetButton);
      this.Controls.Add(this.StopButton);
      this.Controls.Add(this.ScreenShotButton);
      this.Controls.Add(this.StatusTextBox);
      this.Controls.Add(this.ExecuteMaintenanceButton);
      this.Name = "CareerMaintenanceForm";
      this.Text = "Career Maintenance V1.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CareerMaintenanceForm_FormClosing);
      this.Shown += new System.EventHandler(this.CareerMaintenanceForm_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExecuteMaintenanceButton;
        private System.Windows.Forms.TextBox StatusTextBox;
        private System.Windows.Forms.Button ScreenShotButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label ProgressLabel;
    }
}

