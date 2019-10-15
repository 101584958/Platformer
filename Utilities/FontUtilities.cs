using SwinGameSDK;

namespace Template.Utilities
{
    class FontUtilities
    {
        public static readonly Font Arial12 = SwinGame.LoadFont("Arial", 12);
        public static readonly Font Arial24 = SwinGame.LoadFont("Arial", 24);

        public static void DrawString(Font font, string text, float x, float y, Color color)
        {
            SwinGame.DrawText(text, color, font, x, y);
        }

        public static void DrawCenteredString(Font font, string text, float x, float y, Color color)
        {
            x -= SwinGame.TextWidth(font, text) / 2.0f;
            y -= SwinGame.TextHeight(font, text) / 2.0f;

            DrawString(font, text, x, y, color);
        }
    }
}
