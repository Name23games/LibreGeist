using YYTKInterop;

namespace LibreGeist.Core
{
    public class Sprite
    {
        private static readonly Dictionary<string, Sprite> loadedSprites = new();

        public static Sprite Icon => GetSpriteFromAsset("sSaveLoop");

        private readonly GameVariable index;
        private readonly int width = 0;
        private readonly int height = 0;
        private readonly int frames;
        private int currentFrame = -1;

        // TODO: Add support for sprite-offset

        public Sprite(string path, int frames = 1)
        {
            if (!path.StartsWith("mods/Geist/"))
            {
                path = "mods/Geist/" + path;
            }
            index = Game.Engine.CallFunction("sprite_add", path, 1, false, false, 0, 0);
            width = Game.Engine.CallFunction("sprite_get_width", index);
            height = Game.Engine.CallFunction("sprite_get_height", index);

            Game.Engine.CallFunction("sprite_set_offset", index, width / 2, height / 2);
            this.frames = frames;
        }

        public Sprite(GameVariable index)
        {
            this.index = index;
            width = Game.Engine.CallFunction("sprite_get_width", index);
            height = Game.Engine.CallFunction("sprite_get_height", index);

            this.frames = 1;
        }

        public static implicit operator GameVariable(Sprite sprite)
        {
            return sprite.index;
        }

        public static implicit operator Sprite(GameVariable index)
        {
            return new Sprite(index);
        }

        public int Width => width;

        public int Height => height;

        public int Frames => frames;

        //TODO: Provide animation functionality
        public int CurrentFrame
        {
            get => currentFrame;
            set => currentFrame = value;
        }

        /// <summary>
        /// <see href="https://manual.gamemaker.io/monthly/en/GameMaker_Language/GML_Reference/Drawing/Sprites_And_Tiles/draw_sprite_ext.htm"> GML doc</see>
        /// </summary>
        public void Draw(
            float x,
            float y,
            float scaleX = 1,
            float scaleY = 1,
            float angle = 0,
            int r = 255,
            int g = 255,
            int b = 255,
            int a = 255
        )
        {
            int colour = r + 256 * g + 256 * 256 * b;
            Game.Engine.CallFunction(
                "draw_sprite_ext",
                index,
                currentFrame,
                x,
                y,
                scaleX,
                scaleY,
                angle,
                colour,
                a / 255f
            );
        }

        /// <summary>
        /// <see href="https://manual.gamemaker.io/monthly/en/GameMaker_Language/GML_Reference/Drawing/Sprites_And_Tiles/draw_sprite_stretched.htm"> GML doc</see>
        /// </summary>
        public void DrawStretched(
            float x,
            float y,
            int width,
            int height,
            int r = 255,
            int g = 255,
            int b = 255,
            int a = 255
        )
        {
            int colour = r + 256 * g + 256 * 256 * b;
            Game.Engine.CallFunction(
                "draw_sprite_stretched",
                index,
                currentFrame,
                x,
                y,
                width,
                height,
                colour,
                a / 255f
            );
        }

        private static Sprite GetSpriteFromAsset(string assetName)
        {
            if (!loadedSprites.TryGetValue(assetName, out Sprite? value))
            {
                value = new Sprite(GML.GetAsset(assetName)!);
                loadedSprites.Add(assetName, value);
            }
            return value;
        }
    }
}
