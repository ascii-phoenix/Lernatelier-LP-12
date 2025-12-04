using System;
using System.Collections.Generic;
using System.Text;

namespace Mario_Kart_G923
{
    public class G923Parser
    {
        public G923Report Parse(byte[] raw)
        {
            var r = new G923Report();

            // 16-Bit Lenkrad (Little-Endian)
            int wheelRaw = raw[1] | (raw[2] << 8);
            r.Wheel = (wheelRaw / 65535.0) * 2 - 1; // -1 bis +1

            // Pedale normalisiert 0–1
            r.Accel = raw[3] / 255.0;
            r.Brake = raw[4] / 255.0;
            r.Clutch = raw[5] / 255.0;

            // D-Pad (HAT)
            int hat = raw[6] & 0x0F;
            r.DPad = hat == 0x0F ? -1 : hat;

            // Buttons Byte 6/7/8
            r.ButtonA = (raw[6] & 0x10) != 0;
            r.ButtonB = (raw[6] & 0x20) != 0;
            r.ButtonX = (raw[6] & 0x40) != 0;
            r.ButtonY = (raw[6] & 0x80) != 0;

            r.LB = (raw[7] & 0x01) != 0;
            r.RB = (raw[7] & 0x02) != 0;
            r.View = (raw[7] & 0x04) != 0;
            r.Menu = (raw[7] & 0x08) != 0;
            r.PS = (raw[7] & 0x10) != 0;
            r.StickLeft = (raw[7] & 0x20) != 0;
            r.StickRight = (raw[7] & 0x40) != 0;

            // Extra Lenkrad Buttons (Byte 8)
            for (int i = 0; i < 8; i++)
            {
                r.ExtraButtons[i] = (raw[8] & (1 << i)) != 0;
            }

            return r;
        }
    }


}
