namespace LibreGeist.Core
{
    public class Color
    {
        public static readonly Color Aqua = new Color(16776960);
        public static readonly Color Black = new Color(0);
        public static readonly Color Blue = new Color(16711680);
        public static readonly Color Dkgray = new Color(4210752);
        public static readonly Color Fuchsia = new Color(16711935);
        public static readonly Color Gray = new Color(8421504);
        public static readonly Color Green = new Color(32768);
        public static readonly Color Lime = new Color(65280);
        public static readonly Color Ltgray = new Color(12632256);
        public static readonly Color Maroon = new Color(128);
        public static readonly Color Navy = new Color(8388608);
        public static readonly Color Olive = new Color(32896);
        public static readonly Color Orange = new Color(4235519);
        public static readonly Color Purple = new Color(8388736);
        public static readonly Color Red = new Color(255);
        public static readonly Color Silver = new Color(12632256);
        public static readonly Color Teal = new Color(8421376);
        public static readonly Color White = new Color(16777215);
        public static readonly Color Yellow = new Color(65535);

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public int Value
        {
            get { return (B << 16) | (G << 8) | R; }
            set
            {
                R = value & 255;
                G = (value >> 8) & 255;
                B = (value >> 16) & 255;
            }
        }

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(int value)
        {
            Value = value;
        }

        public static implicit operator int(Color color)
        {
            return color.Value;
        }

        public static implicit operator Color(int color)
        {
            return new Color(color);
        }
    }
}
