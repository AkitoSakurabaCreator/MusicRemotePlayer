using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicREmote
{
    class PlayerController
    {
        MusicRemotePlayer musicPlayer = null;
        AxWMPLib.AxWindowsMediaPlayer player = null;
        HotKey hotKey;
        HotKeyFunction HKF = null;
        private string[] path, files;
        private bool auto = false;


        public PlayerController(MusicRemotePlayer musicPlayer)
        {
            this.musicPlayer = musicPlayer;
            player = musicPlayer.axWindowsMediaPlayer1;
            HKF = new HotKeyFunction(musicPlayer, this);
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.Up);
            hotKey.HotKeyPush += new EventHandler(HKF.panelVisible);
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.Right);
            hotKey.HotKeyPush += new EventHandler(HKF.nextPlay);
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.Left);
            hotKey.HotKeyPush += new EventHandler(HKF.previewPlay);
            hotKey = new HotKey(MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.R);
            hotKey.HotKeyPush += new EventHandler(HKF.loopChangeKeyTrue);
            hotKey = new HotKey(MOD_KEY.ALT | MOD_KEY.CONTROL | MOD_KEY.SHIFT, Keys.R);
            hotKey.HotKeyPush += new EventHandler(HKF.loopChangeKeyFalse);
        }

        public void play()
        {
            player.Ctlcontrols.play();
        }

        public void pause()
        {
            player.Ctlcontrols.pause();
        }
        public void stop()
        {
            player.Ctlcontrols.stop();
        }
        public void volumeChange(int volume)
        {
            player.settings.volume = volume;
        }
        public string loop()
        {
            bool loop = false;
            string result = "";
            if (loop)
            {
                player.settings.setMode("Loop", false);
                result = "ループ";
            }
            else
            {
                player.settings.setMode("Loop", true);
                result = "解除";
            }
            _ = !loop;

            return result;
        }
        public void loop(bool Switch)
        {
            player.settings.setMode("Loop", Switch);
        }
        public void screenChange(int number)
        {
            switch (number)
            {
                case 0:
                    player.fullScreen = true;
                    break;
                case 1:
                    player.uiMode = "full";
                    break;
                case 2:
                    player.uiMode = "none";
                    break;
                default:
                    break;
            }
        }

        public double opacityChange(double opacity)
        {
            double result;
            if (opacity > 0)
            {
                result = opacity * 0.1;
            }
            else
            {

                result = 0.1;
            }

            return result;
        }


        public void changeUrl(string url)
        {
            player.URL = url;
        }

        public string[] getPath()
        {
            return this.path;
        }
        public string[] setPath()
        {
            return this.path;
        }
        public void setPath(string[] path)
        {
            this.path = path;
        }
        public void setFiles(string[] files)
        {
            this.files = files;
        }
        public bool getAuto()
        {
            return this.auto;
        }
        public void setAuto(bool auto)
        {
            this.auto = auto;
        }

        public void fileSelect()
        {
            musicPlayer.listBox1.SelectedIndex = -1;
            musicPlayer.listBox1.Items.Clear();
            musicPlayer.listBox1.Update();
            musicPlayer.openFileDialog1.Title = "曲を選択";
            musicPlayer.openFileDialog1.Filter = "全てのファイルに対応しています。 |*.*";

            try
            {
                if (musicPlayer.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    setPath(musicPlayer.openFileDialog1.FileNames);
                    setFiles(musicPlayer.openFileDialog1.SafeFileNames);

                    for (int i = 0; i < files.Length; i++)
                    {
                        musicPlayer.listBox1.Items.Add(files[i]);
                    }

                }
            }catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
