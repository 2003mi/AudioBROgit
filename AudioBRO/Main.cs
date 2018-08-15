using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace AudioBRO
{
    public partial class Main : Form
    {

        int vol;
        string vlogs;

        public Main()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            divicelist.Items.AddRange(devices.ToArray());
            label1.Text = null;
            label2.Text = null;
            coun.Text = null;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                pictureBox1.Image = Image.FromFile(@".\AudioMEME\frame_00_delay-0.1s.gif");
                pictureBox1.Image = null;
                this.Size = new Size(816, 860);
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        private void tickq_Tick(object sender, EventArgs e)
        {
            if(divicelist.SelectedItem != null)
            {
                var device = (MMDevice)divicelist.SelectedItem;
                vol = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
                coun.Text = vol.ToString();

                string tabs = new String(' ', vol);
                label1.Text = tabs;


                
                int volg = vol / 2;
                if(volg < 10)
                {
                    vlogs = @".\AudioMEME\frame_0" + volg + "_delay-0.1s.gif";
                }
                else
                {
                    vlogs = @".\AudioMEME\frame_" + volg + "_delay-0.1s.gif";
                }
                try
                {
                    pictureBox1.Image = Image.FromFile(vlogs);
                    label2.Text = (vol / 2).ToString();
                }
                catch
                {
                    pictureBox1.Image = null;
                    label2.Text = null;
                }
            }
        }
    }
}
