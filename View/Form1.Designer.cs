
namespace IHM_ESP
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_start = new System.Windows.Forms.Button();
            this.lb_axisX = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbox_roll_x = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_speed = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_speed = new System.Windows.Forms.MaskedTextBox();
            this.btn_set_speed = new System.Windows.Forms.Button();
            this.trackBar_speed = new System.Windows.Forms.TrackBar();
            this.lb_pwm = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_pwm = new System.Windows.Forms.MaskedTextBox();
            this.btn_set_pwm = new System.Windows.Forms.Button();
            this.trackBar_pwm = new System.Windows.Forms.TrackBar();
            this.chart_speed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_voltage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_current = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_pwm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_voltage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_current)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart_speed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart_voltage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart_current, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel9, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.lb_axisX, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.cbox_roll_x, 0, 2);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 377);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 6;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(240, 181);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel9.Controls.Add(this.btn_start, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 151);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(234, 27);
            this.tableLayoutPanel9.TabIndex = 7;
            // 
            // btn_start
            // 
            this.btn_start.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_start.Location = new System.Drawing.Point(143, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(88, 21);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Iniciar";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lb_axisX
            // 
            this.lb_axisX.AutoSize = true;
            this.lb_axisX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_axisX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_axisX.Location = new System.Drawing.Point(3, 0);
            this.lb_axisX.Name = "lb_axisX";
            this.lb_axisX.Size = new System.Drawing.Size(234, 23);
            this.lb_axisX.TabIndex = 0;
            this.lb_axisX.Text = "Intervalo X";
            this.lb_axisX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel7.Controls.Add(this.maskedTextBox1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(234, 30);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maskedTextBox1.Location = new System.Drawing.Point(3, 3);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(134, 20);
            this.maskedTextBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(143, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aplicar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ajuste de PWM";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel8.Controls.Add(this.maskedTextBox2, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 115);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(234, 30);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maskedTextBox2.Location = new System.Drawing.Point(3, 3);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(134, 20);
            this.maskedTextBox2.TabIndex = 0;
            this.maskedTextBox2.Visible = false;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(143, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Aplicar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // cbox_roll_x
            // 
            this.cbox_roll_x.AutoSize = true;
            this.cbox_roll_x.Location = new System.Drawing.Point(3, 62);
            this.cbox_roll_x.Name = "cbox_roll_x";
            this.cbox_roll_x.Size = new System.Drawing.Size(129, 17);
            this.cbox_roll_x.TabIndex = 6;
            this.cbox_roll_x.Text = "Habilitar rolagem de X";
            this.cbox_roll_x.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lb_speed, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.trackBar_speed, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lb_pwm, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.trackBar_pwm, 0, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 190);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(240, 181);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // lb_speed
            // 
            this.lb_speed.AutoSize = true;
            this.lb_speed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_speed.Location = new System.Drawing.Point(3, 0);
            this.lb_speed.Name = "lb_speed";
            this.lb_speed.Size = new System.Drawing.Size(234, 23);
            this.lb_speed.TabIndex = 0;
            this.lb_speed.Text = "Ajuste de velocidade";
            this.lb_speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.Controls.Add(this.textBox_speed, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_set_speed, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(234, 30);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // textBox_speed
            // 
            this.textBox_speed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_speed.Location = new System.Drawing.Point(3, 3);
            this.textBox_speed.Name = "textBox_speed";
            this.textBox_speed.Size = new System.Drawing.Size(134, 20);
            this.textBox_speed.TabIndex = 0;
            this.textBox_speed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_speed_KeyDown);
            // 
            // btn_set_speed
            // 
            this.btn_set_speed.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_set_speed.Location = new System.Drawing.Point(143, 3);
            this.btn_set_speed.Name = "btn_set_speed";
            this.btn_set_speed.Size = new System.Drawing.Size(88, 23);
            this.btn_set_speed.TabIndex = 1;
            this.btn_set_speed.Text = "Aplicar";
            this.btn_set_speed.UseVisualStyleBackColor = true;
            this.btn_set_speed.Click += new System.EventHandler(this.btn_set_speed_Click);
            // 
            // trackBar_speed
            // 
            this.trackBar_speed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_speed.Location = new System.Drawing.Point(3, 62);
            this.trackBar_speed.Maximum = 2000;
            this.trackBar_speed.Minimum = 200;
            this.trackBar_speed.Name = "trackBar_speed";
            this.trackBar_speed.Size = new System.Drawing.Size(234, 24);
            this.trackBar_speed.TabIndex = 2;
            this.trackBar_speed.TickFrequency = 100;
            this.trackBar_speed.Value = 200;
            this.trackBar_speed.Scroll += new System.EventHandler(this.trackBar_speed_Scroll);
            // 
            // lb_pwm
            // 
            this.lb_pwm.AutoSize = true;
            this.lb_pwm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_pwm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pwm.Location = new System.Drawing.Point(3, 89);
            this.lb_pwm.Name = "lb_pwm";
            this.lb_pwm.Size = new System.Drawing.Size(234, 23);
            this.lb_pwm.TabIndex = 3;
            this.lb_pwm.Text = "Ajuste de PWM";
            this.lb_pwm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Controls.Add(this.textBox_pwm, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_set_pwm, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 115);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(234, 30);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // textBox_pwm
            // 
            this.textBox_pwm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pwm.Location = new System.Drawing.Point(3, 3);
            this.textBox_pwm.Name = "textBox_pwm";
            this.textBox_pwm.Size = new System.Drawing.Size(134, 20);
            this.textBox_pwm.TabIndex = 0;
            this.textBox_pwm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_pwm_KeyDown);
            // 
            // btn_set_pwm
            // 
            this.btn_set_pwm.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_set_pwm.Location = new System.Drawing.Point(143, 3);
            this.btn_set_pwm.Name = "btn_set_pwm";
            this.btn_set_pwm.Size = new System.Drawing.Size(88, 23);
            this.btn_set_pwm.TabIndex = 1;
            this.btn_set_pwm.Text = "Aplicar";
            this.btn_set_pwm.UseVisualStyleBackColor = true;
            this.btn_set_pwm.Click += new System.EventHandler(this.btn_set_pwm_Click);
            // 
            // trackBar_pwm
            // 
            this.trackBar_pwm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_pwm.Location = new System.Drawing.Point(3, 151);
            this.trackBar_pwm.Maximum = 100;
            this.trackBar_pwm.Minimum = 10;
            this.trackBar_pwm.Name = "trackBar_pwm";
            this.trackBar_pwm.Size = new System.Drawing.Size(234, 27);
            this.trackBar_pwm.TabIndex = 5;
            this.trackBar_pwm.TickFrequency = 10;
            this.trackBar_pwm.Value = 10;
            this.trackBar_pwm.Scroll += new System.EventHandler(this.trackBar_pwm_Scroll);
            // 
            // chart_speed
            // 
            chartArea7.Name = "ChartArea1";
            this.chart_speed.ChartAreas.Add(chartArea7);
            this.chart_speed.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chart_speed.Legends.Add(legend7);
            this.chart_speed.Location = new System.Drawing.Point(249, 3);
            this.chart_speed.Name = "chart_speed";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart_speed.Series.Add(series7);
            this.chart_speed.Size = new System.Drawing.Size(732, 181);
            this.chart_speed.TabIndex = 0;
            this.chart_speed.Text = "chart1";
            this.chart_speed.Click += new System.EventHandler(this.chart_speed_Click);
            this.chart_speed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_speed_MouseMove);
            // 
            // chart_voltage
            // 
            chartArea8.Name = "ChartArea1";
            this.chart_voltage.ChartAreas.Add(chartArea8);
            this.chart_voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chart_voltage.Legends.Add(legend8);
            this.chart_voltage.Location = new System.Drawing.Point(249, 190);
            this.chart_voltage.Name = "chart_voltage";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart_voltage.Series.Add(series8);
            this.chart_voltage.Size = new System.Drawing.Size(732, 181);
            this.chart_voltage.TabIndex = 1;
            this.chart_voltage.Text = "chart2";
            // 
            // chart_current
            // 
            chartArea9.Name = "ChartArea1";
            this.chart_current.ChartAreas.Add(chartArea9);
            this.chart_current.Dock = System.Windows.Forms.DockStyle.Fill;
            legend9.Name = "Legend1";
            this.chart_current.Legends.Add(legend9);
            this.chart_current.Location = new System.Drawing.Point(249, 377);
            this.chart_current.Name = "chart_current";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chart_current.Series.Add(series9);
            this.chart_current.Size = new System.Drawing.Size(732, 181);
            this.chart_current.TabIndex = 2;
            this.chart_current.Text = "chart3";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_connect, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 181);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // btn_connect
            // 
            this.btn_connect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_connect.Location = new System.Drawing.Point(147, 3);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(90, 23);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Conectar";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_speed)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_pwm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_voltage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_current)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_speed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_voltage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_current;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lb_speed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.MaskedTextBox textBox_speed;
        private System.Windows.Forms.Button btn_set_speed;
        private System.Windows.Forms.TrackBar trackBar_speed;
        private System.Windows.Forms.Label lb_pwm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.MaskedTextBox textBox_pwm;
        private System.Windows.Forms.Button btn_set_pwm;
        private System.Windows.Forms.TrackBar trackBar_pwm;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lb_axisX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.CheckBox cbox_roll_x;
    }
}

