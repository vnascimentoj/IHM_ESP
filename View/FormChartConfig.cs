using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM_ESP.View
{
    public partial class FormChartConfig : Form
    {
        ChartConfig config;
        public FormChartConfig(ChartConfig chartConfig)
        {
            InitializeComponent();
            config = chartConfig;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            config.y_max = Convert.ToDouble(tb_ymax.Text);
            config.y_min = Convert.ToDouble(tb_ymin.Text);
            config.multiplier = Convert.ToDouble(tb_mult.Text);

            this.Close();
        }
    }
}
