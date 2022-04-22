using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IHM_ESP
{
    public partial class Form1 : Form
    {
        IComm comm;
        MainMenu mainMenu;
        public Form1()
        {
            InitializeComponent();
            InitializeCharts();
            InitializeMenu();
            InitializeTextBox();

            comm = new ESPComm("COM13", 115200);
        }

        private void InitializeMenu()
        {
            mainMenu = new MainMenu();
            MenuItem File = mainMenu.MenuItems.Add("&Arquivo");
            File.MenuItems.Add(new MenuItem("&Exportar gráficos"));
            File.MenuItems.Add(new MenuItem("&Exportar .csv"));
            //File.MenuItems.Add(new MenuItem("&Exit"));
            this.Menu = mainMenu;
            MenuItem About = mainMenu.MenuItems.Add("&Ajustes");
            About.MenuItems.Add(new MenuItem("&Ajustes PID"));
            this.Menu = mainMenu;
            //mainMenu.GetForm().BackColor = Color.Indigo;
        }

        private void InitializeTextBox()
        {
            textBox_speed.Mask = "9999";
            textBox_speed.PromptChar = ' ';
            textBox_speed.Text = trackBar_speed.Minimum.ToString();

            textBox_pwm.Mask = "999";
            textBox_pwm.PromptChar = ' ';
            textBox_pwm.Text = trackBar_pwm.Minimum.ToString();
        }

        private void InitializeCharts()
        {
            //Ajustes do gráfico de velocidade
            chart_speed.Titles.Add("Velocidade");
            chart_speed.ChartAreas[0].AxisX.Minimum = 0;
            chart_speed.ChartAreas[0].AxisX.Maximum = 100;
            chart_speed.ChartAreas[0].AxisY.Minimum = 0;
            chart_speed.ChartAreas[0].AxisY.Maximum = 2200;
            chart_speed.ChartAreas[0].AxisY.Title = "RPM";
            chart_speed.Series.Clear();
            chart_speed.Series.Add("Velocidade");
            chart_speed.Series["Velocidade"].Points.AddY(new Random().Next(2100) + 100);
            chart_speed.Series["Velocidade"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //Ajustes do gráfico de tensão de armadura
            chart_voltage.Titles.Add("Tensão de armadura");
            chart_voltage.ChartAreas[0].AxisX.Minimum = 0;
            chart_voltage.ChartAreas[0].AxisX.Maximum = 100;
            chart_voltage.ChartAreas[0].AxisY.Minimum = 0;
            chart_voltage.ChartAreas[0].AxisY.Maximum = 250;
            chart_voltage.Series.Clear();
            chart_voltage.Series.Add("Tensão");
            chart_voltage.Series["Tensão"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            //Ajustes do gráfico de corrente de armadura
            chart_current.Titles.Add("Corrente de armadura");
            chart_current.ChartAreas[0].AxisX.Minimum = 0;
            chart_current.ChartAreas[0].AxisX.Maximum = 100;
            chart_current.ChartAreas[0].AxisY.Minimum = 0;
            chart_current.ChartAreas[0].AxisY.Maximum = 15;
            chart_current.Series.Clear();
            chart_current.Series.Add("Corrente");
            chart_current.Series["Corrente"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        private void trackBar_speed_Scroll(object sender, EventArgs e)
        {
            textBox_speed.Text = trackBar_speed.Value.ToString();
        }

        private void trackBar_pwm_Scroll(object sender, EventArgs e)
        {
            textBox_pwm.Text = trackBar_pwm.Value.ToString();
        }

        private void textBox_speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int value = Convert.ToInt32(textBox_speed.Text);
                value = Math.Min(value, trackBar_speed.Maximum);
                value = Math.Max(value, trackBar_speed.Minimum);

                btn_set_speed_Click(this, new EventArgs());
                trackBar_speed.Value = value;
                textBox_speed.Text = value.ToString();
            }
        }

        private void textBox_pwm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int value = Convert.ToInt32(textBox_pwm.Text);
                value = Math.Min(value, trackBar_pwm.Maximum);
                value = Math.Max(value, trackBar_pwm.Minimum);

                btn_set_pwm_Click(this, new EventArgs());
                trackBar_pwm.Value = value;
                textBox_pwm.Text = value.ToString();
            }
        }

        private void btn_set_speed_Click(object sender, EventArgs e)
        {
            //Envia dados pela serial
            int value = Convert.ToInt16(textBox_speed.Text);
            //comm.SetRPM(value);
        }

        private void btn_set_pwm_Click(object sender, EventArgs e)
        {
            //Envia dados pela serial
            int value = Convert.ToInt16(textBox_pwm.Text);
            //comm.SetPWM(value);
        }

        private void chart_speed_Click(object sender, EventArgs e)
        {
            
        }

        public void AddSpeedData(double[] data)
        {
            foreach(var value in data)
            {
                //chart_speed.Series["Velocidade"].Points.AddY(Math.Round(value * chart_speed.ChartAreas[0].AxisY.Maximum));
                chart_speed.Series["Velocidade"].Points.AddXY(chart_speed.Series["Velocidade"].Points.Count, Math.Round(value * chart_speed.ChartAreas[0].AxisY.Maximum));
                chart_voltage.Series["Tensão"].Points.AddY(value * chart_voltage.ChartAreas[0].AxisY.Maximum); 
                chart_current.Series["Corrente"].Points.AddY(value * chart_current.ChartAreas[0].AxisY.Maximum);
            }


            if (cbox_roll_x.Checked)
            {   
                if (chart_speed.Series["Velocidade"].Points.Count + 20 > chart_speed.ChartAreas[0].AxisX.Maximum)
                {
                    chart_speed.ChartAreas[0].AxisX.Minimum = chart_speed.Series["Velocidade"].Points.Count - 80;
                    chart_speed.ChartAreas[0].AxisX.Maximum = chart_speed.Series["Velocidade"].Points.Count + 20;
                }
            }


        }
        private Random random = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            AddSpeedData(new double[] { random.NextDouble() / 2 + 0.5 });
        }

        Point prevPosition = new Point();
        ToolTip tooltip = new ToolTip();
        private void chart_speed_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition == pos)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart_speed.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                        tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart_speed,
                                            pos.X, pos.Y - 15);
                        // check if the cursor is really close to the point (2 pixels around the point)
                        //if (Math.Abs(pos.X - pointXPixel) < 2 &&
                        //    Math.Abs(pos.Y - pointYPixel) < 2)
                        //{
                        //    tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart_speed,
                        //                    pos.X, pos.Y - 15);
                        //}
                    }
                }
            }
        }
    }
}
