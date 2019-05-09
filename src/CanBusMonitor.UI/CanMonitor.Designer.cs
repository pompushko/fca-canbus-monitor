namespace CanBusMonitor.UI
{
    partial class CanMonitor
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
            this.canMonitorTabControl = new CanBusMonitor.UI.Controls.CanMonitorTabControl();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.canMonitorTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // canMonitorTabControl
            // 
            this.canMonitorTabControl.Location = new System.Drawing.Point(6, 38);
            this.canMonitorTabControl.Name = "canMonitorTabControl";
            this.canMonitorTabControl.SelectedIndex = 0;
            this.canMonitorTabControl.Size = new System.Drawing.Size(782, 400);
            this.canMonitorTabControl.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 9);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(87, 9);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // CanMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.canMonitorTabControl);
            this.Name = "CanMonitor";
            this.Text = "CanMonitor";
            this.canMonitorTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CanBusMonitor.UI.Controls.CanMonitorTabControl canMonitorTabControl;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
    }
}

