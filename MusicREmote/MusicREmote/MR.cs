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

namespace MusicREmote
{
    public partial class MR : DevExpress.XtraEditors.XtraForm
    {
        public string[] path{ get; set; }
        public string[] files { get; set; }
        public string text { get; set; }
        public MR()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.fullScreen = true;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void trackBarControl2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string list;
        //Form1オブジェクトを保持するためのフィールド
        private static Form1 _form1Instance;

        //Form1オブジェクトを取得、設定するためのプロパティ
        public static Form1 Form1Instance
        {
            get
            {
                return _form1Instance;
            }
            set
            {
                _form1Instance = value;
            }
        }
        private void MN_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 50;
            axWindowsMediaPlayer1.uiMode = "none";
            this.Focus();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}