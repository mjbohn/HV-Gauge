using Mich3l.Controls.Gauges;
namespace GaugeTestapp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.rndtimer = new System.Windows.Forms.Timer(this.components);
            this.hvGauge14 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge15 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge13 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge12 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge11 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge10 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge9 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge8 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge7 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge6 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge5 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge4 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge3 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge2 = new Mich3l.Controls.Gauges.HVGauge();
            this.hvGauge1 = new Mich3l.Controls.Gauges.HVGauge();
            this.SuspendLayout();
            // 
            // rndtimer
            // 
            this.rndtimer.Enabled = true;
            this.rndtimer.Interval = 1000;
            this.rndtimer.Tick += new System.EventHandler(this.rndtimer_Tick);
            // 
            // hvGauge14
            // 
            this.hvGauge14.BackColor = System.Drawing.Color.Red;
            this.hvGauge14.ForeColor = System.Drawing.Color.Black;
            this.hvGauge14.GaugeBackColor = System.Drawing.Color.Red;
            this.hvGauge14.GaugeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.hvGauge14.GaugeType = Mich3l.Controls.Gauges.HVGauge.GaugeTypes.Line;
            this.hvGauge14.Location = new System.Drawing.Point(243, 357);
            this.hvGauge14.MiddleRangeposition = Mich3l.Controls.Gauges.HVGauge.MidRangePositions.Position1;
            this.hvGauge14.Name = "hvGauge14";
            this.hvGauge14.ShowPercentSign = false;
            this.hvGauge14.Size = new System.Drawing.Size(450, 45);
            this.hvGauge14.SmoothGradientTransition = true;
            this.hvGauge14.TabIndex = 16;
            this.hvGauge14.Text = "hvGauge14";
            // 
            // hvGauge15
            // 
            this.hvGauge15.BackColor = System.Drawing.Color.Red;
            this.hvGauge15.ForeColor = System.Drawing.Color.Black;
            this.hvGauge15.GaugeBackColor = System.Drawing.Color.Red;
            this.hvGauge15.GaugeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hvGauge15.GaugeType = Mich3l.Controls.Gauges.HVGauge.GaugeTypes.Line;
            this.hvGauge15.Location = new System.Drawing.Point(243, 302);
            this.hvGauge15.MiddleRangeposition = Mich3l.Controls.Gauges.HVGauge.MidRangePositions.Position2;
            this.hvGauge15.Name = "hvGauge15";
            this.hvGauge15.ShowPercentSign = false;
            this.hvGauge15.Size = new System.Drawing.Size(450, 45);
            this.hvGauge15.SmoothGradientTransition = true;
            this.hvGauge15.TabIndex = 15;
            this.hvGauge15.Text = "hvGauge15";
            // 
            // hvGauge13
            // 
            this.hvGauge13.BackColor = System.Drawing.Color.White;
            this.hvGauge13.ForeColor = System.Drawing.Color.Black;
            this.hvGauge13.GaugeBackColor = System.Drawing.Color.White;
            this.hvGauge13.GaugeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.hvGauge13.GaugeType = Mich3l.Controls.Gauges.HVGauge.GaugeTypes.Line;
            this.hvGauge13.Location = new System.Drawing.Point(243, 408);
            this.hvGauge13.Name = "hvGauge13";
            this.hvGauge13.ShowPercentSign = false;
            this.hvGauge13.ShowRanges = false;
            this.hvGauge13.ShowValue = false;
            this.hvGauge13.Size = new System.Drawing.Size(450, 14);
            this.hvGauge13.SmoothGradientTransition = true;
            this.hvGauge13.TabIndex = 13;
            this.hvGauge13.Text = "hvGauge13";
            // 
            // hvGauge12
            // 
            this.hvGauge12.BackColor = System.Drawing.Color.Red;
            this.hvGauge12.ForeColor = System.Drawing.Color.Black;
            this.hvGauge12.GaugeBackColor = System.Drawing.Color.Red;
            this.hvGauge12.GaugeType = Mich3l.Controls.Gauges.HVGauge.GaugeTypes.Line;
            this.hvGauge12.Location = new System.Drawing.Point(243, 251);
            this.hvGauge12.Name = "hvGauge12";
            this.hvGauge12.ShowPercentSign = false;
            this.hvGauge12.Size = new System.Drawing.Size(450, 45);
            this.hvGauge12.SmoothGradientTransition = true;
            this.hvGauge12.TabIndex = 12;
            this.hvGauge12.Text = "hvGauge12";
            // 
            // hvGauge11
            // 
            this.hvGauge11.BackColor = System.Drawing.SystemColors.Control;
            this.hvGauge11.ForeColor = System.Drawing.Color.Black;
            this.hvGauge11.Location = new System.Drawing.Point(243, 200);
            this.hvGauge11.Name = "hvGauge11";
            this.hvGauge11.Size = new System.Drawing.Size(450, 45);
            this.hvGauge11.SmoothGradientTransition = true;
            this.hvGauge11.TabIndex = 11;
            this.hvGauge11.Text = "hvGauge11";
            // 
            // hvGauge10
            // 
            this.hvGauge10.BackColor = System.Drawing.SystemColors.Control;
            this.hvGauge10.ForeColor = System.Drawing.Color.Black;
            this.hvGauge10.Location = new System.Drawing.Point(243, 149);
            this.hvGauge10.Name = "hvGauge10";
            this.hvGauge10.Size = new System.Drawing.Size(450, 45);
            this.hvGauge10.StackedBar = false;
            this.hvGauge10.TabIndex = 10;
            this.hvGauge10.Text = "hvGauge10";
            // 
            // hvGauge9
            // 
            this.hvGauge9.BackColor = System.Drawing.SystemColors.Control;
            this.hvGauge9.ForeColor = System.Drawing.Color.Black;
            this.hvGauge9.Location = new System.Drawing.Point(243, 98);
            this.hvGauge9.Name = "hvGauge9";
            this.hvGauge9.Size = new System.Drawing.Size(450, 45);
            this.hvGauge9.TabIndex = 9;
            this.hvGauge9.Text = "hvGauge9";
            // 
            // hvGauge8
            // 
            this.hvGauge8.BackColor = System.Drawing.SystemColors.Control;
            this.hvGauge8.ForeColor = System.Drawing.Color.Black;
            this.hvGauge8.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge8.IndicatorColor = System.Drawing.Color.Black;
            this.hvGauge8.IndicatorDisplayTime = 1500;
            this.hvGauge8.Location = new System.Drawing.Point(65, 17);
            this.hvGauge8.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge8.Name = "hvGauge8";
            this.hvGauge8.ShowBorder = false;
            this.hvGauge8.ShowIndicator = true;
            this.hvGauge8.ShowPercentSign = false;
            this.hvGauge8.ShowValue = false;
            this.hvGauge8.Size = new System.Drawing.Size(39, 450);
            this.hvGauge8.SmoothGradientTransition = true;
            this.hvGauge8.TabIndex = 8;
            this.hvGauge8.Text = "hvGauge8";
            // 
            // hvGauge7
            // 
            this.hvGauge7.BackColor = System.Drawing.SystemColors.Control;
            this.hvGauge7.ForeColor = System.Drawing.Color.Black;
            this.hvGauge7.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge7.IndicatorColor = System.Drawing.Color.Black;
            this.hvGauge7.IndicatorDisplayTime = 1500;
            this.hvGauge7.Location = new System.Drawing.Point(104, 17);
            this.hvGauge7.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge7.Name = "hvGauge7";
            this.hvGauge7.ShowBorder = false;
            this.hvGauge7.ShowIndicator = true;
            this.hvGauge7.ShowPercentSign = false;
            this.hvGauge7.ShowValue = false;
            this.hvGauge7.Size = new System.Drawing.Size(39, 450);
            this.hvGauge7.SmoothGradientTransition = true;
            this.hvGauge7.TabIndex = 7;
            this.hvGauge7.Text = "hvGauge7";
            // 
            // hvGauge6
            // 
            this.hvGauge6.BackColor = System.Drawing.SystemColors.Control;
            this.hvGauge6.ForeColor = System.Drawing.Color.Black;
            this.hvGauge6.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge6.IndicatorColor = System.Drawing.Color.Black;
            this.hvGauge6.IndicatorDisplayTime = 1500;
            this.hvGauge6.Location = new System.Drawing.Point(143, 17);
            this.hvGauge6.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge6.Name = "hvGauge6";
            this.hvGauge6.ShowBorder = false;
            this.hvGauge6.ShowIndicator = true;
            this.hvGauge6.ShowPercentSign = false;
            this.hvGauge6.ShowValue = false;
            this.hvGauge6.Size = new System.Drawing.Size(39, 450);
            this.hvGauge6.SmoothGradientTransition = true;
            this.hvGauge6.TabIndex = 6;
            this.hvGauge6.Text = "hvGauge6";
            // 
            // hvGauge5
            // 
            this.hvGauge5.BackColor = System.Drawing.SystemColors.Control;
            this.hvGauge5.ForeColor = System.Drawing.Color.Black;
            this.hvGauge5.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge5.IndicatorColor = System.Drawing.Color.Black;
            this.hvGauge5.IndicatorDisplayTime = 1500;
            this.hvGauge5.Location = new System.Drawing.Point(182, 17);
            this.hvGauge5.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge5.Name = "hvGauge5";
            this.hvGauge5.ShowBorder = false;
            this.hvGauge5.ShowIndicator = true;
            this.hvGauge5.ShowPercentSign = false;
            this.hvGauge5.ShowValue = false;
            this.hvGauge5.Size = new System.Drawing.Size(39, 450);
            this.hvGauge5.SmoothGradientTransition = true;
            this.hvGauge5.TabIndex = 5;
            this.hvGauge5.Text = "hvGauge5";
            // 
            // hvGauge4
            // 
            this.hvGauge4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge4.ForeColor = System.Drawing.Color.Black;
            this.hvGauge4.GaugeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge4.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge4.Location = new System.Drawing.Point(47, 17);
            this.hvGauge4.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge4.Name = "hvGauge4";
            this.hvGauge4.ShowIndicator = true;
            this.hvGauge4.ShowPercentSign = false;
            this.hvGauge4.ShowValue = false;
            this.hvGauge4.Size = new System.Drawing.Size(10, 450);
            this.hvGauge4.TabIndex = 4;
            this.hvGauge4.Text = "hvGauge4";
            // 
            // hvGauge3
            // 
            this.hvGauge3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge3.ForeColor = System.Drawing.Color.Black;
            this.hvGauge3.GaugeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge3.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge3.Location = new System.Drawing.Point(37, 17);
            this.hvGauge3.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge3.Name = "hvGauge3";
            this.hvGauge3.ShowIndicator = true;
            this.hvGauge3.ShowPercentSign = false;
            this.hvGauge3.ShowValue = false;
            this.hvGauge3.Size = new System.Drawing.Size(10, 450);
            this.hvGauge3.TabIndex = 3;
            this.hvGauge3.Text = "hvGauge3";
            // 
            // hvGauge2
            // 
            this.hvGauge2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge2.ForeColor = System.Drawing.Color.Black;
            this.hvGauge2.GaugeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge2.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge2.Location = new System.Drawing.Point(27, 17);
            this.hvGauge2.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge2.Name = "hvGauge2";
            this.hvGauge2.ShowIndicator = true;
            this.hvGauge2.ShowPercentSign = false;
            this.hvGauge2.ShowValue = false;
            this.hvGauge2.Size = new System.Drawing.Size(10, 450);
            this.hvGauge2.TabIndex = 2;
            this.hvGauge2.Text = "hvGauge2";
            // 
            // hvGauge1
            // 
            this.hvGauge1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge1.ForeColor = System.Drawing.Color.Black;
            this.hvGauge1.GaugeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hvGauge1.GaugeOrientation = Mich3l.Controls.Gauges.HVGauge.GaugeOrientations.Vertical;
            this.hvGauge1.Location = new System.Drawing.Point(17, 17);
            this.hvGauge1.Margin = new System.Windows.Forms.Padding(0);
            this.hvGauge1.Name = "hvGauge1";
            this.hvGauge1.ShowIndicator = true;
            this.hvGauge1.ShowPercentSign = false;
            this.hvGauge1.ShowValue = false;
            this.hvGauge1.Size = new System.Drawing.Size(10, 450);
            this.hvGauge1.TabIndex = 0;
            this.hvGauge1.Text = "hvGauge1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 492);
            this.Controls.Add(this.hvGauge14);
            this.Controls.Add(this.hvGauge15);
            this.Controls.Add(this.hvGauge13);
            this.Controls.Add(this.hvGauge12);
            this.Controls.Add(this.hvGauge11);
            this.Controls.Add(this.hvGauge10);
            this.Controls.Add(this.hvGauge9);
            this.Controls.Add(this.hvGauge8);
            this.Controls.Add(this.hvGauge7);
            this.Controls.Add(this.hvGauge6);
            this.Controls.Add(this.hvGauge5);
            this.Controls.Add(this.hvGauge4);
            this.Controls.Add(this.hvGauge3);
            this.Controls.Add(this.hvGauge2);
            this.Controls.Add(this.hvGauge1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private HVGauge hvGauge1;
        private HVGauge hvGauge2;
        private HVGauge hvGauge3;
        private HVGauge hvGauge4;
        private System.Windows.Forms.Timer rndtimer;
        private HVGauge hvGauge5;
        private HVGauge hvGauge6;
        private HVGauge hvGauge7;
        private HVGauge hvGauge8;
        private HVGauge hvGauge9;
        private HVGauge hvGauge10;
        private HVGauge hvGauge11;
        private HVGauge hvGauge12;
        private HVGauge hvGauge13;
        private HVGauge hvGauge15;
        private HVGauge hvGauge14;






    }
}

