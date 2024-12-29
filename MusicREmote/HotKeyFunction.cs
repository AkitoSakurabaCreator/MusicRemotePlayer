using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicREmote
{
    class HotKeyFunction
    {
        MusicRemotePlayer musicPlayer = null;
        PlayerController PContol = null;
        public HotKeyFunction(MusicRemotePlayer musicPlayer, PlayerController PContol)
        {
            this.musicPlayer = musicPlayer;
        }
        public void panelVisible(object sender, EventArgs e)
        {
            if (musicPlayer.panel2.Visible == true)
            {
                musicPlayer.panel2.Visible = false;
            }
            else
            {
                musicPlayer.panel2.Visible = true;
            }
        }
        public void hotKey_HotKeyPush_2(object sender, EventArgs e)
        {
            int num = musicPlayer.listBox1.SelectedIndex + 1;
            if (num > 0)
            {
                musicPlayer.listBox1.SelectedIndex = num;
                PContol.changeUrl(PContol.getPath()[musicPlayer.listBox1.SelectedIndex]);
            }
        }
        public void hotKey_HotKeyPush_3(object sender, EventArgs e)
        {
            int num = musicPlayer.listBox1.SelectedIndex - 1;
            if (num > 0)
            {
                musicPlayer.listBox1.SelectedIndex = num;
                PContol.changeUrl(PContol.getPath()[musicPlayer.listBox1.SelectedIndex]);
            }
        }
        public void loopChangeKeyTrue(object sender, EventArgs e)
        {
            PContol.loop(true);
            musicPlayer.simpleButton2.Text = "解除";
        }
        public void loopChangeKeyFalse(object sender, EventArgs e)
        {
            PContol.loop(false);
            musicPlayer.simpleButton2.Text = "ループ";
        }

    }
}
