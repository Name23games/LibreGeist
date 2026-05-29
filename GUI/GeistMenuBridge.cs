using LibreGeist.Core;

namespace LibreGeist.GUI
{
    public class GeistMenuBridge : IMenuBridge
    {
        public int MouseX => Mouse.X;
        public int MouseY => Mouse.Y;

        public void PlaySelectSound()
        {
            // Add TetherGeist sound later
        }

        public void PlayConfirmSound()
        {
            // Add TetherGeist sound later
        }
    }
}