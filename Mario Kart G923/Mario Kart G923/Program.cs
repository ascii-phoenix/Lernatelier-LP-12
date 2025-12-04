namespace Mario_Kart_G923
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wheel = new G923Wheel();

            if (!wheel.Connect())
            {
                Console.WriteLine("G923 nicht gefunden!");
                return;
            }

            wheel.OnInput += r =>
            {
                Console.WriteLine($"Wheel: {r.Wheel}, Gas: {r.Accel}, Bremse: {r.Brake}, Kupplung: {r.Clutch}");
                Console.WriteLine($"DPad: {r.DPad}");

                if (r.ButtonA) Console.WriteLine("A gedrückt");
                if (r.ButtonB) Console.WriteLine("B gedrückt");
                if (r.ButtonX) Console.WriteLine("X gedrückt");
                if (r.ButtonY) Console.WriteLine("Y gedrückt");

                for (int i = 0; i < r.ExtraButtons.Length; i++)
                    if (r.ExtraButtons[i])
                        Console.WriteLine($"Extra Button {i + 1} gedrückt");
            };

            wheel.Start();

        }
    }
}
