namespace WinformStopwatch
{
    partial class FormStopwatch
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
            this.tbStartUrl = new System.Windows.Forms.TextBox();
            this.tbStopUrl = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblStop = new System.Windows.Forms.Label();
            this.lblStopwatch = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbStartUrl
            // 
            this.tbStartUrl.Location = new System.Drawing.Point(169, 63);
            this.tbStartUrl.Name = "tbStartUrl";
            this.tbStartUrl.Size = new System.Drawing.Size(510, 35);
            this.tbStartUrl.TabIndex = 0;
            // 
            // tbStopUrl
            // 
            this.tbStopUrl.Location = new System.Drawing.Point(169, 104);
            this.tbStopUrl.Name = "tbStopUrl";
            this.tbStopUrl.Size = new System.Drawing.Size(510, 35);
            this.tbStopUrl.TabIndex = 0;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(106, 66);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(57, 32);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Start";
            // 
            // lblStop
            // 
            this.lblStop.Location = new System.Drawing.Point(106, 107);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(57, 32);
            this.lblStop.TabIndex = 1;
            this.lblStop.Text = "Stop";
            // 
            // lblStopwatch
            // 
            this.lblStopwatch.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStopwatch.Location = new System.Drawing.Point(298, 173);
            this.lblStopwatch.Name = "lblStopwatch";
            this.lblStopwatch.Size = new System.Drawing.Size(188, 52);
            this.lblStopwatch.TabIndex = 1;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(12, 501);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(120, 50);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(138, 501);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 50);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(652, 499);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 50);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(526, 499);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 50);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormStopwatch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.lblStopwatch);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.tbStopUrl);
            this.Controls.Add(this.tbStartUrl);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "FormStopwatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStopwatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbStartUrl;
        private TextBox tbStopUrl;
        private Label lblStart;
        private Label lblStop;
        private Label lblStopwatch;
        private Button btnInstall;
        private Button btnRemove;
        private Button btnStop;
        private Button btnStart;
    }
}