using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Umer_Soft
{
    public partial class About : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public About()
        {
            InitializeComponent();
            player.URL = "umer.mp3";
            player.controls.play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            Form2 op = new Form2();
            op.Show();
        }
    }
}
