namespace AudioSpectrumAdvance
{
    partial class Form_spector
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.pB_left = new System.Windows.Forms.ProgressBar();
            this.pB_right = new System.Windows.Forms.ProgressBar();
            this.cB_spectrum = new System.Windows.Forms.ComboBox();
            this.chart_spectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_spector = new System.Windows.Forms.Timer(this.components);
            this.lab_left = new System.Windows.Forms.Label();
            this.lab_right = new System.Windows.Forms.Label();
            this.elementHost_obj = new System.Windows.Forms.Integration.ElementHost();
            this.spectrum_elem = new AudioSpectrumAdvance.Spectrum();
            ((System.ComponentModel.ISupportInitialize)(this.chart_spectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // pB_left
            // 
            this.pB_left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pB_left.Location = new System.Drawing.Point(31, 233);
            this.pB_left.Name = "pB_left";
            this.pB_left.Size = new System.Drawing.Size(1269, 16);
            this.pB_left.TabIndex = 1;
            // 
            // pB_right
            // 
            this.pB_right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pB_right.Location = new System.Drawing.Point(31, 258);
            this.pB_right.Name = "pB_right";
            this.pB_right.Size = new System.Drawing.Size(1269, 16);
            this.pB_right.TabIndex = 2;
            // 
            // cB_spectrum
            // 
            this.cB_spectrum.FormattingEnabled = true;
            this.cB_spectrum.Location = new System.Drawing.Point(1179, 493);
            this.cB_spectrum.Name = "cB_spectrum";
            this.cB_spectrum.Size = new System.Drawing.Size(121, 21);
            this.cB_spectrum.TabIndex = 3;
            this.cB_spectrum.Visible = false;
            // 
            // chart_spectrum
            // 
            this.chart_spectrum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_spectrum.ChartAreas.Add(chartArea1);
            this.chart_spectrum.Location = new System.Drawing.Point(9, 280);
            this.chart_spectrum.Name = "chart_spectrum";
            this.chart_spectrum.Size = new System.Drawing.Size(1288, 219);
            this.chart_spectrum.TabIndex = 4;
            this.chart_spectrum.Text = "chart_spectrum";
            // 
            // timer_spector
            // 
            this.timer_spector.Interval = 25;
            // 
            // lab_left
            // 
            this.lab_left.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_left.AutoSize = true;
            this.lab_left.Location = new System.Drawing.Point(9, 236);
            this.lab_left.Name = "lab_left";
            this.lab_left.Size = new System.Drawing.Size(13, 13);
            this.lab_left.TabIndex = 5;
            this.lab_left.Text = "L";
            // 
            // lab_right
            // 
            this.lab_right.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_right.AutoSize = true;
            this.lab_right.Location = new System.Drawing.Point(9, 261);
            this.lab_right.Name = "lab_right";
            this.lab_right.Size = new System.Drawing.Size(15, 13);
            this.lab_right.TabIndex = 6;
            this.lab_right.Text = "R";
            // 
            // elementHost_obj
            // 
            this.elementHost_obj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost_obj.Location = new System.Drawing.Point(12, 12);
            this.elementHost_obj.Name = "elementHost_obj";
            this.elementHost_obj.Size = new System.Drawing.Size(1288, 215);
            this.elementHost_obj.TabIndex = 0;
            this.elementHost_obj.Child = this.spectrum_elem;
            // 
            // Form_spector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 534);
            this.Controls.Add(this.lab_right);
            this.Controls.Add(this.lab_left);
            this.Controls.Add(this.chart_spectrum);
            this.Controls.Add(this.cB_spectrum);
            this.Controls.Add(this.pB_right);
            this.Controls.Add(this.pB_left);
            this.Controls.Add(this.elementHost_obj);
            this.MinimumSize = new System.Drawing.Size(1325, 573);
            this.Name = "Form_spector";
            this.Text = "Spectrum";
            ((System.ComponentModel.ISupportInitialize)(this.chart_spectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost_obj;
        private Spectrum spectrum_elem;
        private System.Windows.Forms.ProgressBar pB_left;
        private System.Windows.Forms.ProgressBar pB_right;
        private System.Windows.Forms.ComboBox cB_spectrum;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_spectrum;
        private System.Windows.Forms.Timer timer_spector;
        private System.Windows.Forms.Label lab_left;
        private System.Windows.Forms.Label lab_right;
    }
}

