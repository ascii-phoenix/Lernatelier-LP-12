using HidSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mario_Kart_G923
{
    using HidSharp;
    using System;
    using System.Linq;

    public class G923Wheel
    {
        private HidDevice device;
        private HidStream stream;
        private readonly G923Parser parser = new G923Parser();
        private byte[] buffer;

        public event Action<G923Report> OnInput;

        public bool Connect()
        {
            var devices = DeviceList.Local.GetHidDevices(0x046D);

            device = devices.FirstOrDefault(d =>
                d.ProductID == 0xC266 || d.ProductID == 0xC26E ||
                d.GetProductName().Contains("G923"));

            if (device == null) return false;

            stream = device.Open();
            buffer = new byte[device.GetMaxInputReportLength()];
            return true;
        }

        public void Start()
        {
            while (true)
            {
                int len = stream.Read(buffer, 0, buffer.Length);
                if (len > 0)
                {
                    var report = parser.Parse(buffer);
                    OnInput?.Invoke(report);
                }
            }
        }
    }


}
