

using System.Windows.Forms.DataVisualization.Charting;

namespace Genetic_Algorithm
{
   
    public partial class Form1 : Form
    {
        private class ZoomFrame
        {
            public double XStart { get; set; }
            public double XFinish { get; set; }
            public double YStart { get; set; }
            public double YFinish { get; set; }
        }


        bool isAdded = false;
        int populationSize;
        int chromosomeLenght;
        double crossOverRate;
        double mutationRate;
        double elitismRate;
        int generationAmount;
        
        
        
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
        }

        private void start_Click(object sender, EventArgs e)
        {
            chart1.Series["Convergence"].Points.Clear();
            GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(populationSize: populationSize,
                chromosomeLenght: chromosomeLenght, crossOverRate: crossOverRate, mutationRate: mutationRate, elitismRate: elitismRate,
                generationAmount: generationAmount);

            try
            {
                List<double> bestSolutionParams = geneticAlgorithm.OptimizeSelectedFunctionAndReturnBestSolution().ToList<double>();
                bestSolutionParams.Add(geneticAlgorithm.FitnessFunction(bestSolutionParams.ToArray<double>()));



                dataGridView1.ColumnCount = bestSolutionParams.Count;

                if (!isAdded)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows.Add();
                }

                isAdded = true; 
               

                for (int i = 0; i < bestSolutionParams.Count; i++)
                {
                    if (i != bestSolutionParams.Count - 1)
                    {
                        dataGridView1.Rows[0].Cells[i].Value = String.Format("x{0}", i + 1);
                    }
                    else
                    {
                        dataGridView1.Rows[0].Cells[i].Value = "y";
                    }

                }

                for (int i = 0; i < bestSolutionParams.Count; i++)
                {
                    dataGridView1.Rows[1].Cells[i].Value = bestSolutionParams[i];

                }


                for (int i = 0; i < geneticAlgorithm.bestSolutionsForIndividualGenerations.Count; i++)
                {
                    chart1.Series["Convergence"].Points.AddXY(i+1, geneticAlgorithm.bestSolutionsForIndividualGenerations[i]);
                }

                

                /*foreach (var item in geneticAlgorithm.bestSolutionsForIndividualGenerations)
                {
                    MessageBox.Show(item.ToString());
                }*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        populationSize = Convert.ToInt32(textBox1.Text);
                        textBox1.Enabled = false;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message.ToString() + " " + "Try Again.");
                    }

                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        chromosomeLenght = Convert.ToInt32(textBox2.Text);
                        textBox2.Enabled = false;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message.ToString() + " " + "Try Again.");
                    }

                }

            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        if (0 < double.Parse(textBox3.Text) && 1 > double.Parse(textBox3.Text))
                        {
                            crossOverRate = double.Parse(textBox3.Text);
                            textBox3.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Enter a value between 0 and 1.");
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message.ToString() + " " + "Try Again.");
                    }

                }

            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (0 < double.Parse(textBox5.Text) && 1 > double.Parse(textBox5.Text))
                    {
                        mutationRate = double.Parse(textBox5.Text);
                        textBox5.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Enter a value between 0 and 1.");
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message.ToString() + " " + "Try Again.");
                }

            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        if (0 < double.Parse(textBox6.Text) && 1 > double.Parse(textBox6.Text))
                        {
                            elitismRate = Convert.ToDouble(textBox6.Text);
                            textBox6.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Enter a value between 0 and 1.");
                        }

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message.ToString() + " " + "Try Again.");
                    }

                }

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    generationAmount = Convert.ToInt32(textBox4.Text);
                    textBox4.Enabled = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message.ToString() + " " + "Try Again.");
                }

            }
        }

        private readonly Stack<ZoomFrame> _zoomFrames = new Stack<ZoomFrame>();
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0)
                {
                    if (0 < _zoomFrames.Count)
                    {
                        var frame = _zoomFrames.Pop();
                        if (_zoomFrames.Count == 0)
                        {
                            xAxis.ScaleView.ZoomReset();
                            yAxis.ScaleView.ZoomReset();
                        }
                        else
                        {
                            xAxis.ScaleView.Zoom(frame.XStart, frame.XFinish);
                            yAxis.ScaleView.Zoom(frame.YStart, frame.YFinish);
                        }
                    }
                }
                else if (e.Delta > 0)
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    _zoomFrames.Push(new ZoomFrame { XStart = xMin, XFinish = xMax, YStart = yMin, YFinish = yMax });

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }

    }
}