using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
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
    }
}
