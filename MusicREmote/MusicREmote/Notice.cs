using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicREmote
{
    public partial class Notice : Form
    {
        public string text { get; set; }
        public string sendData = "";
        public Notice()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.FormBorderStyle = FormBorderStyle.None;

            // ウィンドウを画面右下に表示させる
            /*
            int left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            DesktopBounds = new Rectangle(left, top, this.Width, this.Height);
            */
            this.DesktopLocation = new Point(1200, 20);
        }
        //Form1オブジェクトを保持するためのフィールド
        private static MN _form1Instance;

        //Form1オブジェクトを取得、設定するためのプロパティ
        public static MN Form1Instance
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

        public string SendData
        {
            set
            {
                sendData = value;
                label1.Text = sendData;
            }
            get
            {
                return sendData;
            }
        }
        private string _strParam;

        public string strParam
        {
            get
            {
                return _strParam;
            }
            set
            {
                _strParam = value;
            }
        }

        private void Notice_Load(object sender, EventArgs e)
        {
            /*
            string str = Form1Instance.Text;
            label1.Text = str;
            */
            label1.Text = sendData;
            timer1.Start();

        }

        int time = 4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if (time == 0)
            {
                timer1.Stop();
                base.Close();
            }
        }
    }
}
