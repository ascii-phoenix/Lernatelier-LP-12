using System;
using System.Collections.Generic;
using System.Text;

public class G923Report
{
    // Achsen
    public double Wheel { get; set; }    // -1 = links, +1 = rechts
    public double Accel { get; set; }    // 0 = nicht gedrückt, 1 = voll gedrückt
    public double Brake { get; set; }    // 0–1
    public double Clutch { get; set; }   // 0–1

    // D-Pad
    public int DPad { get; set; }        // -1 = keine Richtung, 0–7 = Richtung

    // Buttons
    public bool ButtonA { get; set; }
    public bool ButtonB { get; set; }
    public bool ButtonX { get; set; }
    public bool ButtonY { get; set; }
    public bool LB { get; set; }
    public bool RB { get; set; }
    public bool View { get; set; }
    public bool Menu { get; set; }
    public bool PS { get; set; }
    public bool StickLeft { get; set; }
    public bool StickRight { get; set; }
    public bool[] ExtraButtons { get; set; } // 8 weitere Lenkrad-Buttons

    public G923Report()
    {
        ExtraButtons = new bool[8];
    }
}


