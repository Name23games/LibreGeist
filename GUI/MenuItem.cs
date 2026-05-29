using LibreGeist.Core;
using YYTKInterop;

namespace LibreGeist.GUI
{
    public class MenuItem
    {
        public string Text { get; set; }

        public bool Selected { get; set; }

        public int Order { get; set; }

        public int Width { get; set; } = 120;

        public int Height { get; set; } = 16;

        public Action? Action { get; set; }

        public MenuItem(string text, Action? action = null, int order = 0)
        {
            Text = text;
            Action = action;
            Order = order;
        }

        public void Update(float dt)
        {
            // Animation goes here later
        }

        public void Draw(int x, int y)
        {
            Game.Engine.CallFunction("draw_set_color", 16777215);

            Game.Engine.CallFunction(
                "draw_text",
                x,
                y,
                Text
            );
        }
        public bool IsInside(int mouseX, int mouseY, int x, int y)
        {
            return mouseX >= x
                && mouseY >= y
                && mouseX < x + Width
                && mouseY < y + Height;
        }
    }
}
