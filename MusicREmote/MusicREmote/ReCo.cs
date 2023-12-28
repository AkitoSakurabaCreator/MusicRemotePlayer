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
    public partial class ReCo : DevExpress.XtraEditors.XtraForm
    {
        string[] path, files;
        public ReCo()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            MR.axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
            MR.axWindowsMediaPlayer1.Ctlcontrols.play();
            */
            //string str = Form1.Form1Instance.TextBoxText;

            //Form1のTextBox1.Textの値を設定
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            listBox1.Items.Clear();
            listBox1.Update();
            openFileDialog1.Title = "曲を選択";
            openFileDialog1.Filter = "全てのファイルに対応しています。 |*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileNames;
                files = openFileDialog1.SafeFileNames;

                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }

            }
            else
            {

            }
        }
    }
}