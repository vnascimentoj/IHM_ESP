using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM_ESP.View
{
    public partial class FormSettings : Form
    {   
        ControllerSettings controllerSettings;
        public FormSettings(ControllerSettings settings)
        {
            InitializeComponent();
            controllerSettings = settings;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            listView_settings.Items.Clear();
            PropertyInfo[] properties = typeof(ControllerSettings).GetProperties();

            foreach(var prop in properties)
            {
                foreach(Devices.ESP32RegisterAttribute attr in prop.GetCustomAttributes(typeof(Devices.ESP32RegisterAttribute)))
                {
                    ListViewItem listViewItem = new ListViewItem(attr.Description);
                    listViewItem.SubItems.Add(prop.GetValue(controllerSettings).ToString());
                    listViewItem.Tag = prop;
                    listView_settings.Items.Add(listViewItem);
                }
            }
        }

        private void listView_settings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView_settings.SelectedItems.Count > 0)
            {
                PropertyInfo property = listView_settings.SelectedItems[0].Tag as PropertyInfo;
                tb_value.Text = property.GetValue(controllerSettings).ToString();
            }
        }

        private void tb_value_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            if (regex.IsMatch(tb_value.Text))
            {
                if (listView_settings.SelectedItems.Count > 0)
                {
                    PropertyInfo property = listView_settings.SelectedItems[0].Tag as PropertyInfo;
                    property.SetValue(controllerSettings, Convert.ToUInt16(tb_value.Text));
                    listView_settings.SelectedItems[0].SubItems[1].Text = tb_value.Text;
                }
            }
        }
    }
}
