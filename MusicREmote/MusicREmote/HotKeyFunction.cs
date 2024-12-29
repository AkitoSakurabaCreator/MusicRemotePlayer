using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicREmote
{
    class HotKeyFunction
    {
        MN MN = null;
        PlayerController PContol = null;
        public HotKeyFunction(MN MN, PlayerController PContol)
        {
            this.MN = MN;
        }
        public void panelVisible(object sender, EventArgs e)
        {
            if (MN.panel2.Visible == true)
            {
                MN.panel2.Visible = false;
            }
            else
            {
                MN.panel2.Visible = true;
            }
        }
        public void hotKey_HotKeyPush_2(object sender, EventArgs e)
        {
            int num = MN.listBox1.SelectedIndex + 1;
            if (num > 0)
            {
                MN.listBox1.SelectedIndex = num;
                PContol.changeUrl(PContol.getPath()[MN.listBox1.SelectedIndex]);
            }
        }
        public void hotKey_HotKeyPush_3(object sender, EventArgs e)
        {
            int num = MN.listBox1.SelectedIndex - 1;
            if (num > 0)
            {
                MN.listBox1.SelectedIndex = num;
                PContol.changeUrl(PContol.getPath()[MN.listBox1.SelectedIndex]);
            }
        }
        public void loopChangeKeyTrue(object sender, EventArgs e)
        {
            PContol.loop(true);
            MN.simpleButton2.Text = "解除";
        }
        public void loopChangeKeyFalse(object sender, EventArgs e)
        {
            PContol.loop(false);
            MN.simpleButton2.Text = "ループ";
        }

    }
}
