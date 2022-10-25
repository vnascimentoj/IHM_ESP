using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IHM_ESP
{
    public partial class Form1 : Form
    {
        ESPCom espCom;
        MainMenu mainMenu;

        ChartConfig speedConfig   = new ChartConfig() { multiplier = 1, x_max = 100, x_min = 0, y_max = 2200, y_min = 0 };
        ChartConfig voltageConfig = new ChartConfig() { multiplier = 1, x_max = 100, x_min = 0, y_max = 250, y_min = 0 };
        ChartConfig currentConfig = new ChartConfig() { multiplier = 1, x_max = 100, x_min = 0, y_max = 10, y_min = 0 };
        int roll_x = 100;
        public Form1()
        {
            InitializeComponent();
            InitializeCharts();
            InitializeMenu();
            InitializeTextBox();

            comboBox1.Click += ComboBox1_Click;

            btn_set_pwm.Enabled = false;
            btn_set_speed.Enabled = false;
        }

        private void ComboBox1_Click(object sender, EventArgs e)
        {
            update_com_list();
        }

        private void InitializeMenu()
        {
            mainMenu = new MainMenu();
            MenuItem File = mainMenu.MenuItems.Add("&Arquivo");
            //File.MenuItems.Add(new MenuItem("&Exportar gráficos"));
            MenuItem exportCsv = new MenuItem("&Exportar .csv");
            exportCsv.Click += ExportCsv_Click;
            File.MenuItems.Add(exportCsv);
            
            //this.Menu = mainMenu;

            MenuItem settings = mainMenu.MenuItems.Add("&Ajustes");
            settings.MenuItems.Add(new MenuItem("&Ajustes PID"));
            this.Menu = mainMenu;
            
        }

        public class Record
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        private void ExportCsv_Click(object sender, EventArgs e)
        {
            List<Record> records = new List<Record>();
            foreach (var data in chart_speed.Series["Velocidade"].Points)
                records.Add(new Record() { x = data.XValue, y = data.YValues[0] });
            

            string filename = DateTime.Now.ToString("hh-mm") + ".csv";
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture))
                csv.WriteRecords(records);
                    
        }

        private void InitializeTextBox()
        {
            textBox_speed.Mask = "9999";
            textBox_speed.PromptChar = ' ';
            textBox_speed.Text = trackBar_speed.Minimum.ToString();

            textBox_pwm.Mask = "999";
            textBox_pwm.PromptChar = ' ';
            textBox_pwm.Text = trackBar_pwm.Minimum.ToString();

            textBox_roll_x.Mask = "999";
            textBox_roll_x.PromptChar = ' ';
            textBox_roll_x.Text = roll_x.ToString();
        }

        private void InitializeCharts()
        {
            //Ajustes do gráfico de velocidade
            chart_speed.Titles.Add("Velocidade");
            chart_speed.ChartAreas[0].AxisX.Minimum = speedConfig.x_min;
            chart_speed.ChartAreas[0].AxisX.Maximum = speedConfig.x_max;
            chart_speed.ChartAreas[0].AxisY.Minimum = speedConfig.y_min;
            chart_speed.ChartAreas[0].AxisY.Maximum = speedConfig.y_max;
            chart_speed.ChartAreas[0].AxisY.Title = "RPM";
            chart_speed.Series.Clear();
            chart_speed.Series.Add("Velocidade");
            chart_speed.Series["Velocidade"].Points.AddY(new Random().Next(2100) + 100);
            chart_speed.Series["Velocidade"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //Ajustes do gráfico de tensão de armadura
            chart_voltage.Titles.Add("Tensão de armadura");
            chart_voltage.ChartAreas[0].AxisX.Minimum = voltageConfig.x_min;
            chart_voltage.ChartAreas[0].AxisX.Maximum = voltageConfig.x_max;
            chart_voltage.ChartAreas[0].AxisY.Minimum = voltageConfig.y_min;
            chart_voltage.ChartAreas[0].AxisY.Maximum = voltageConfig.y_max;
            chart_voltage.Series.Clear();
            chart_voltage.Series.Add("Tensão");
            chart_voltage.Series["Tensão"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            //Ajustes do gráfico de corrente de armadura
            chart_current.Titles.Add("Corrente de armadura");
            chart_current.ChartAreas[0].AxisX.Minimum = voltageConfig.x_min;
            chart_current.ChartAreas[0].AxisX.Maximum = voltageConfig.x_max;
            chart_current.ChartAreas[0].AxisY.Minimum = voltageConfig.y_min;
            chart_current.ChartAreas[0].AxisY.Maximum = voltageConfig.y_max;
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
            espCom.SetRPM(value);
        }

        private void btn_set_pwm_Click(object sender, EventArgs e)
        {
            // Velocidade == 0 => ajuste manual 
            // velocidade != 0 => ajuste automático 
            espCom.SetRPM(0);

            int value = Convert.ToInt16(textBox_pwm.Text);
            espCom.SetPWM(value);
        }

        // Função está adicionando em todos os gráficos para testes
        public void AddSpeedData(double[] data)
        {
            foreach(var value in data)
            {
                chart_speed.Series["Velocidade"].Points.AddXY(chart_speed.Series["Velocidade"].Points.Count, Math.Round(value * chart_speed.ChartAreas[0].AxisY.Maximum));
                chart_voltage.Series["Tensão"].Points.AddY(value * chart_voltage.ChartAreas[0].AxisY.Maximum); 
                chart_current.Series["Corrente"].Points.AddY(value * chart_current.ChartAreas[0].AxisY.Maximum);
            }

        } // End AddSpeedData

        private void update_com_list()
        {   
            comboBox1.Items.Clear();
            foreach (var port in SerialPort.GetPortNames())
                comboBox1.Items.Add(port);
        }

        private Random random = new Random();
        private void timer_update_Tick(object sender, EventArgs e)
        {
            //update_com_list();
            //AddSpeedData(new double[] { random.NextDouble() / 2 + 0.5 });

            chart_roll();
            UInt16[] valores = { 1000, 500, 500 };
            
            List<byte> lista = new List<byte>();
            for (int i = 0; i < valores.Length; i++)
            {
                lista.AddRange(BitConverter.GetBytes(valores[i]));
            }

            byte[] data = lista.ToArray();


            //int voltage = (int)(voltageConfig.multiplier * ((data[1] << 8) + data[0]));
            //int current = (int)(currentConfig.multiplier * ((data[3] << 8) + data[2]));
            //int rpm     = (int)(speedConfig.multiplier   * ((data[5] << 8) + data[4]));

            //chart_speed.Series["Velocidade"].Points.AddXY(chart_speed.Series["Velocidade"].Points.Count, rpm);
            //chart_voltage.Series["Tensão"].Points.AddXY(chart_voltage.Series["Tensão"].Points.Count, voltage);
            //chart_current.Series["Corrente"].Points.AddXY(chart_current.Series["Corrente"].Points.Count, current);
        }

        private void chart_roll()
        {
            if (cbox_roll_x.Checked)
            {
                if (chart_speed.Series["Velocidade"].Points.Count + 20 > chart_speed.ChartAreas[0].AxisX.Maximum)
                {
                    chart_speed.ChartAreas[0].AxisX.Minimum = chart_speed.Series["Velocidade"].Points.Count - (roll_x - 10);
                    chart_speed.ChartAreas[0].AxisX.Maximum = chart_speed.Series["Velocidade"].Points.Count + 10;

                    chart_voltage.ChartAreas[0].AxisX.Minimum = chart_voltage.Series["Tensão"].Points.Count - (roll_x - 10);
                    chart_voltage.ChartAreas[0].AxisX.Maximum = chart_voltage.Series["Tensão"].Points.Count + 10;

                    chart_current.ChartAreas[0].AxisX.Minimum = chart_current.Series["Corrente"].Points.Count - (roll_x - 10);
                    chart_current.ChartAreas[0].AxisX.Maximum = chart_current.Series["Corrente"].Points.Count + 10;
                }
            }
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

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (espCom == null)
            {
                esp_connect();
            }else
            {
                esp_disconnect();
                espCom = null;
            }

            update_com_list();
        }

        private void esp_disconnect()
        {
            if (espCom != null)
                espCom.Disconnect();

            btn_set_speed.Enabled = false;
            btn_set_pwm.Enabled = false;

            btn_connect.Text = "Conectar";
            comboBox1.ResetText();
        }

        private void esp_connect()
        {
            string comPort;
            try
            {
                comPort = comboBox1.SelectedItem.ToString();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Selecione uma porta válida.");
                return;
            }
                
            espCom = new ESPCom(comPort, 115200);

            btn_set_speed.Enabled = true;
            btn_set_pwm.Enabled = true;

            btn_connect.Text = "Desconectar";
        }

        bool start = false;
        private void btn_start_Click(object sender, EventArgs e)
        {
            start = !start;
            if(start)
            {
                btn_start.Text = "Iniciar";
                espCom.Start();
                timer_requestData.Enabled = true;
            }
            else
            {
                btn_start.Text = "Parar";
                espCom.Stop();
                timer_requestData.Enabled = false;
            }
            System.Threading.Thread.Sleep(1000);
        }

        private void chart_speed_Click(object sender, EventArgs e)
        {

        }

        private void chart_voltage_Click(object sender, EventArgs e)
        {

        }

        private void chart_current_Click(object sender, EventArgs e)
        {

        }

        private void chart_speed_DoubleClick(object sender, EventArgs e)
        {
            Form form = new View.FormChartConfig(speedConfig);
            form.ShowDialog();
            chart_update(chart_speed, speedConfig);
        }

        private void chart_voltage_DoubleClick(object sender, EventArgs e)
        {
            Form form = new View.FormChartConfig(voltageConfig);
            form.ShowDialog();
            chart_update(chart_voltage, voltageConfig);
        }

        private void chart_current_DoubleClick(object sender, EventArgs e)
        {
            Form form = new View.FormChartConfig(currentConfig);
            form.ShowDialog();
            chart_update(chart_current, currentConfig);
        }

        private void chart_update(System.Windows.Forms.DataVisualization.Charting.Chart chart, ChartConfig config)
        {   
            chart.ChartAreas[0].AxisY.Minimum = config.y_min;
            chart.ChartAreas[0].AxisY.Maximum = config.y_max;
        }

        private void textBox_roll_x_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btn_set_roll_Click(sender, e);
            }
        }

        private void btn_set_roll_Click(object sender, EventArgs e)
        {
            int temp = 0;
            try
            {
                temp = Convert.ToInt32(textBox_roll_x.Text);
            } catch(Exception ex)
            {                
                MessageBox.Show(ex.Message);
                return;
            }
            if (temp > 0)
                roll_x = temp;
            else
                MessageBox.Show("Valor deve ser maior que zero.");
            }

        private bool messageError = false;
        private void timer_requestData_Tick(object sender, EventArgs e)
        {
            byte[] data = espCom.RequestData();
            if (data != null)
            {   
                int voltage = (int)(voltageConfig.multiplier * ((data[1] << 8) + data[0]));
                int current = (int)(currentConfig.multiplier * ((data[3] << 8) + data[2]));
                int rpm     = (int)(speedConfig.multiplier * ((data[5] << 8) + data[4]));

                chart_speed.Series["Velocidade"].Points.AddXY(chart_speed.Series["Velocidade"].Points.Count, rpm);
                chart_voltage.Series["Tensão"].Points.AddXY(chart_voltage.Series["Tensão"].Points.Count, voltage);
                chart_current.Series["Corrente"].Points.AddXY(chart_current.Series["Corrente"].Points.Count, current);

                //messageError = false;
            }
            else if(!messageError)
            {
                MessageBox.Show("Mensagem de leitura nula");
                messageError = true;
            }
                
        }
    }
}
