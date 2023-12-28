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
    public partial class MN : DevExpress.XtraEditors.XtraForm
    {
        string[] path, files;
        HotKey hotKey;

        private string receiveData = "";
        Notice fs;
        public MN()
        {
            InitializeComponent();
            fs = new Notice();
            fs.Owner = this;
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
            if (simpleButton2.Text == "ループ")
            {
                axWindowsMediaPlayer1.settings.setMode("Loop", true);
                simpleButton2.Text = "解除";
            }
            else
            {
                axWindowsMediaPlayer1.settings.setMode("Loop", false);
                simpleButton2.Text = "ループ";
            }
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
            if (trackBarControl1.Value > 0)
            {
                label2.Text = trackBarControl2.Value.ToString();
                this.Opacity = trackBarControl2.Value * 0.1;
            }
            else
            {

                this.Opacity = 0.1;
            }
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBarControl1.Value.ToString();
            axWindowsMediaPlayer1.settings.volume = trackBarControl1.Value;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void MN_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBarControl1.Value;
            axWindowsMediaPlayer1.uiMode = "none";
            this.Focus();
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.Up);
            hotKey.HotKeyPush += new EventHandler(hotKey_HotKeyPush);
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.Right);
            hotKey.HotKeyPush += new EventHandler(hotKey_HotKeyPush_2);
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.Left);
            hotKey.HotKeyPush += new EventHandler(hotKey_HotKeyPush_3);
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.R);
            hotKey.HotKeyPush += new EventHandler(hotKey_HotKeyPush_4);
            hotKey = new HotKey(MOD_KEY.ALT | MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.R);
            hotKey.HotKeyPush += new EventHandler(hotKey_HotKeyPush_5);
        }
        void hotKey_HotKeyPush(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }
        void hotKey_HotKeyPush_2(object sender, EventArgs e)
        {
            int num = listBox1.SelectedIndex + 1;
            if (num > 0)
            {
                //listBoxControl1.SetSelected(num, true);
                listBox1.SelectedIndex = num;// 元
                axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
            }
            /*
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            if (text == "")
            {

            }
            else
            {
                fs.SendData = text;
                fs.Show();
            }
            */
        }

        

        void hotKey_HotKeyPush_3(object sender, EventArgs e)
        {
            int num = listBox1.SelectedIndex - 1;
            if (num > 0)
            {
                //listBoxControl1.SetSelected(num, true);
                listBox1.SelectedIndex = num;// 元
                axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
            }
            /*
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            if (text == "")
            {

            }
            else
            {
                fs.SendData = text;
                fs.Show();
            }
            */
        }
        void hotKey_HotKeyPush_4(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.setMode("Loop", true);
            simpleButton2.Text = "解除";
        }
        void hotKey_HotKeyPush_5(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.setMode("Loop", false);
            simpleButton2.Text = "ループ";
        }

        private void axWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {

        }
        [STAThread]
        private void MoveUp()
        {
            MoveItem(-1, listBox1);
        }

        [STAThread]
        private void MoveDown()
        {
            MoveItem(1, listBox1);
        }
        [STAThread]
        public void MoveItem(int direction, ListBox listBox)
        {
            // Checking selected item
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBox.SelectedItem;

            // Restore selection
            listBox.SetSelected(newIndex, true);
        }
        private int currentSongIndex = -1;

        [STAThread]
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1 && auto == "true")
            {
                if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
                {
                    BeginInvoke(new Action(() =>
                    {
                        listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                    }));
                }
            }
            /*
            // Test the current state of the player and display a message for each state.
            switch (e.newState)
            {
                case 0:    // Undefined
                           // currentStateLabel.Text = "Undefined";
                    break;

                case 1:    // Stopped
                    //currentStateLabel.Text = "Stopped";
                    if (auto == "true")
                    {
                        /*
                        int num = listBox1.SelectedIndex + 1;
                        if (num > 0)
                        {
                            //listBoxControl1.SetSelected(num, true);
                            listBox1.SelectedIndex = num;// 元
                            axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
                            listBox1.SetSelected(num, true);
                        }
                        */
            //MoveDown();
            /*
            int index = listBox1.SelectedIndex; // Get the index of the currently selected song
            index++;

            if (index == listBox1.Items.Count)
            {
                index = 0;
            }
            listBox1.SelectedIndex = index; // Re-assind the changed index to the index of my current item
            axWindowsMediaPlayer1.URL = path[index];
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        break;

    case 2:    // Paused
        //currentStateLabel.Text = "Paused";
        break;

    case 3:    // Playing
        //currentStateLabel.Text = "Playing";
        break;

    case 4:    // ScanForward
        //currentStateLabel.Text = "ScanForward";
        break;

    case 5:    // ScanReverse
        //currentStateLabel.Text = "ScanReverse";
        break;

    case 6:    // Buffering
        //currentStateLabel.Text = "Buffering";
        break;

    case 7:    // Waiting
        /*
        //currentStateLabel.Text = "Waiting";
        if (auto == "true")
        {
            int num = listBox1.SelectedIndex + 1;
            if (num > 0)
            {
                //listBoxControl1.SetSelected(num, true);
                listBox1.SelectedIndex = num;// 元
                axWindowsMediaPlayer1.URL = path[listBox1.SelectedIndex];
            }
        }
        */
            /*
        break;

    case 8:    // MediaEnded
        //currentStateLabel.Text = "MediaEnded";
        break;

    case 9:    // Transitioning
        //currentStateLabel.Text = "Transitioning";
        break;

    case 10:   // Ready
        //currentStateLabel.Text = "Ready";
        break;

    case 11:   // Reconnecting
        //currentStateLabel.Text = "Reconnecting";
        break;

    case 12:   // Last
        //currentStateLabel.Text = "Last";
        break;

    default:
        //currentStateLabel.Text = ("Unknown State: " + e.newState.ToString());
        break;
}
*/

        }
        string auto = "false";
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (simpleButton8.Text == "自動")
            {
                auto = "true";
                simpleButton8.Text = "解除";
            }
            else
            {
                auto = "false";
                simpleButton8.Text = "自動";
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (simpleButton10.Text == "表示:N")
            {
                axWindowsMediaPlayer1.uiMode = "full";
                simpleButton10.Text = "表示:F";
            }
            else
            {
                axWindowsMediaPlayer1.uiMode = "none";
                simpleButton10.Text = "表示:N";
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

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