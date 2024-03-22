namespace Genetic_Algorithm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(658, 145);
            dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(97, 226);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(86, 27);
            textBox1.TabIndex = 1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(97, 289);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(86, 27);
            textBox2.TabIndex = 2;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(97, 356);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(86, 27);
            textBox3.TabIndex = 3;
            textBox3.KeyDown += textBox3_KeyDown;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(95, 499);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(86, 27);
            textBox4.TabIndex = 4;
            textBox4.KeyDown += textBox4_KeyDown;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(95, 426);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(86, 27);
            textBox5.TabIndex = 4;
            textBox5.KeyDown += textBox5_KeyDown;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(95, 573);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(86, 27);
            textBox6.TabIndex = 5;
            textBox6.KeyDown += textBox6_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 203);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 6;
            label1.Text = "Population Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 266);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 7;
            label2.Text = "Chromosom Lenght";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(89, 333);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 8;
            label3.Text = "Crossover Rate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 403);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 9;
            label4.Text = "Mutation Rate";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(95, 550);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 10;
            label5.Text = "Elitism Rate";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(75, 476);
            label6.Name = "label6";
            label6.Size = new Size(139, 20);
            label6.TabIndex = 11;
            label6.Text = "Generation Amount";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(504, 556);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = false;
            button1.Click += start_Click;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(297, 221);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Convergence";
            chart1.Series.Add(series2);
            chart1.Size = new Size(375, 305);
            chart1.TabIndex = 14;
            chart1.Text = "chart1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(358, 603);
            label7.Name = "label7";
            label7.Size = new Size(329, 20);
            label7.TabIndex = 15;
            label7.Text = "Press enter after every input of given parameters";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(717, 632);
            Controls.Add(label7);
            Controls.Add(chart1);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label label7;
    }
}