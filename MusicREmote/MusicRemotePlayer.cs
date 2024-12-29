using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace MusicREmote
{
    public partial class MusicRemotePlayer : DevExpress.XtraEditors.XtraForm
    {
        PlayerController PContol = null;
        public MusicRemotePlayer()
        {
            InitializeComponent();
            PContol = new PlayerController(this);
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PContol.play();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            PContol.pause();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            PContol.stop();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            simpleButton2.Text=PContol.loop();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PContol.screenChange(0);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void trackBarControl2_EditValueChanged(object sender, EventArgs e)
        {
            this.Opacity = PContol.opacityChange(trackBarControl1.Value);
            label2.Text = trackBarControl1.Value.ToString();
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBarControl1.Value.ToString();
            PContol.volumeChange(trackBarControl1.Value);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] path = PContol.getPath();
            axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void MusicRemotePlayer_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBarControl1.Value;
            axWindowsMediaPlayer1.uiMode = "none";
            this.Focus();
          
        }

        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {

        }


        [STAThread]
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1 && PContol.getAuto())
            {
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    BeginInvoke(new Action(() =>
                    {
                        listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                    }));
                }
            }
        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (simpleButton8.Text == "自動")
            {
                PContol.setAuto(true);
                simpleButton8.Text = "解除";
            }
            else
            {
                PContol.setAuto(true);
                simpleButton8.Text = "自動";
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (simpleButton10.Text == "表示:N")
            {
                PContol.screenChange(1);
                simpleButton10.Text = "表示:F";
            }
            else
            {
                PContol.screenChange(2);
                simpleButton10.Text = "表示:N";
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            PContol.fileSelect();
        }
    }
}