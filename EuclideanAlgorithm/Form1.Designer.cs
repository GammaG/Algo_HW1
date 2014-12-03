namespace EuclideanAlgorithm
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBox_Results = new System.Windows.Forms.TextBox();
            this.button_loops = new System.Windows.Forms.Button();
            this.numericUpDown_loops = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Method = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clearD = new System.Windows.Forms.Button();
            this.XNLabel = new System.Windows.Forms.Label();
            this.numericUpDown_x = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_n = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.setXNBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_loops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_n)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Results
            // 
            this.textBox_Results.Location = new System.Drawing.Point(12, 129);
            this.textBox_Results.Multiline = true;
            this.textBox_Results.Name = "textBox_Results";
            this.textBox_Results.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Results.Size = new System.Drawing.Size(338, 450);
            this.textBox_Results.TabIndex = 6;
            // 
            // button_loops
            // 
            this.button_loops.Location = new System.Drawing.Point(31, 100);
            this.button_loops.Name = "button_loops";
            this.button_loops.Size = new System.Drawing.Size(135, 23);
            this.button_loops.TabIndex = 7;
            this.button_loops.Text = "Generate Histogram";
            this.button_loops.UseVisualStyleBackColor = true;
            this.button_loops.Click += new System.EventHandler(this.button_getHistogram_Click);
            // 
            // numericUpDown_loops
            // 
            this.numericUpDown_loops.Location = new System.Drawing.Point(175, 45);
            this.numericUpDown_loops.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_loops.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_loops.Name = "numericUpDown_loops";
            this.numericUpDown_loops.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown_loops.TabIndex = 8;
            this.numericUpDown_loops.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "loops=";
            // 
            // comboBox_Method
            // 
            this.comboBox_Method.FormattingEnabled = true;
            this.comboBox_Method.Items.AddRange(new object[] {
            "iterative exponentiation",
            "recursive exponentiation",
            "faster recursive exponentiation"});
            this.comboBox_Method.Location = new System.Drawing.Point(65, 12);
            this.comboBox_Method.Name = "comboBox_Method";
            this.comboBox_Method.Size = new System.Drawing.Size(261, 21);
            this.comboBox_Method.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Method:";
            // 
            // chart1
            // 
            chartArea1.Name = "Default";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(369, 15);
            this.chart1.Name = "chart1";
            series1.ChartArea = "Default";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(757, 593);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // clearD
            // 
            this.clearD.Location = new System.Drawing.Point(175, 100);
            this.clearD.Name = "clearD";
            this.clearD.Size = new System.Drawing.Size(136, 23);
            this.clearD.TabIndex = 15;
            this.clearD.Text = "Clear Diagram";
            this.clearD.UseVisualStyleBackColor = true;
            this.clearD.Click += new System.EventHandler(this.clearD_Click);
            // 
            // XNLabel
            // 
            this.XNLabel.AutoSize = true;
            this.XNLabel.Location = new System.Drawing.Point(172, 129);
            this.XNLabel.Name = "XNLabel";
            this.XNLabel.Size = new System.Drawing.Size(0, 13);
            this.XNLabel.TabIndex = 17;
            // 
            // numericUpDown_x
            // 
            this.numericUpDown_x.Location = new System.Drawing.Point(48, 42);
            this.numericUpDown_x.Name = "numericUpDown_x";
            this.numericUpDown_x.Size = new System.Drawing.Size(69, 20);
            this.numericUpDown_x.TabIndex = 18;
            this.numericUpDown_x.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_n
            // 
            this.numericUpDown_n.Location = new System.Drawing.Point(49, 68);
            this.numericUpDown_n.Name = "numericUpDown_n";
            this.numericUpDown_n.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown_n.TabIndex = 19;
            this.numericUpDown_n.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "x= ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "n=";
            // 
            // setXNBtn
            // 
            this.setXNBtn.Location = new System.Drawing.Point(175, 71);
            this.setXNBtn.Name = "setXNBtn";
            this.setXNBtn.Size = new System.Drawing.Size(101, 23);
            this.setXNBtn.TabIndex = 22;
            this.setXNBtn.Text = "set values";
            this.setXNBtn.UseVisualStyleBackColor = true;
            this.setXNBtn.Click += new System.EventHandler(this.setXN);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(12, 585);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 23;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 645);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.setXNBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown_n);
            this.Controls.Add(this.numericUpDown_x);
            this.Controls.Add(this.XNLabel);
            this.Controls.Add(this.clearD);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Method);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_loops);
            this.Controls.Add(this.button_loops);
            this.Controls.Add(this.textBox_Results);
            this.Name = "Form1";
            this.Text = "HW1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_loops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_n)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Results;
        private System.Windows.Forms.Button button_loops;
        private System.Windows.Forms.NumericUpDown numericUpDown_loops;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Method;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button clearD;
        private System.Windows.Forms.Label XNLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown_x;
        private System.Windows.Forms.NumericUpDown numericUpDown_n;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button setXNBtn;
        private System.Windows.Forms.Button clearBtn;
    }
}

