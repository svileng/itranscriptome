namespace ExperimentsManager.Views
{
    partial class ExperimentDetailsForm
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
            this.txtExperimentDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtExperimentDetails
            // 
            this.txtExperimentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExperimentDetails.Location = new System.Drawing.Point(12, 12);
            this.txtExperimentDetails.Multiline = true;
            this.txtExperimentDetails.Name = "txtExperimentDetails";
            this.txtExperimentDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExperimentDetails.ShortcutsEnabled = false;
            this.txtExperimentDetails.Size = new System.Drawing.Size(515, 297);
            this.txtExperimentDetails.TabIndex = 1;
            this.txtExperimentDetails.TabStop = false;
            // 
            // ExperimentDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 321);
            this.Controls.Add(this.txtExperimentDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExperimentDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Experiment Full Details";
            this.Load += new System.EventHandler(this.ExperimentDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExperimentDetails;
    }
}