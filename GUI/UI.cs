using LibreGeist.Core;
using YYTKInterop;

namespace LibreGeist.GUI
{
    public static class UI
    {
        // Main UI font
        public static string Font => "fLoosey17";

        // Main UI colors
        public static Color NormalColor => Color.White;
        public static Color DisabledColor => Color.Silver;
        public static Color ShadowColor => Color.Black;

        // Draw outlined text using the game's outline script
        public static void DrawText(
            float x,
            float y,
            string text,
            Color color,
            float scaleX = 1f,
            float scaleY = 1f
        )
        {
            var global = Game.Engine.GetGlobalObject();

            // Set font first
            Game.Engine.CallFunction(
                "draw_set_font",
                GML.GetAsset(Font)
            );

            // Call game's outlined text script
            Game.Engine.CallFunction(
                "script_execute",
                global["draw_text_outline"],

                x,
                y,

                text,

                scaleX,
                scaleY,

                color.Value
            );
        }

        // Measure text width
        public static int MeasureTextWidth(
            string text,
            float scale = 1f
        )
        {
            Game.Engine.CallFunction(
                "draw_set_font",
                GML.GetAsset(Font)
            );

            return (int)(
                Game.Engine.CallFunction(
                    "string_width",
                    text
                ).ToFloat() * scale
            );
        }

        // Rectangle hover helper
        public static bool PointInRect(
            int px,
            int py,
            int x,
            int y,
            int width,
            int height
        )
        {
            return px >= x
                && py >= y
                && px < x + width
                && py < y + height;
        }
    }
}