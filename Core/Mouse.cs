using YYTKInterop;

namespace LibreGeist.Core
{
    public class Mouse
    {
        public delegate void ClickHandler(int button, int x, int y);
        public static event ClickHandler? OnClick;

        public static int X { get; private set; }
        public static int Y { get; private set; }

        internal static void Update()
        {
            var global = Game.Engine.GetGlobalObject();

            X = Game.Engine.GetBuiltinVariable("mouse_x", global, 0);
            Y = Game.Engine.GetBuiltinVariable("mouse_y", global, 0);

            if (Game.Engine.CallFunction("mouse_check_button_pressed", 1))
                OnClick?.Invoke(0, X, Y);

            if (Game.Engine.CallFunction("mouse_check_button_pressed", 2))
                OnClick?.Invoke(1, X, Y);
        }
    }
}