using PrismBox.core.script_ui;

namespace PrismBox.core.script_ext
{
    internal static class UIExtensions
    {
        public static void SetDefaults(this UIElement ele, int height, int width, int x, int y, bool center = false, UIElement par = null)
        {
            ele.Width.Set(width, 0f);
            ele.Height.Set(height, 0f);
            ele.Left.Set(x, 0f);
            ele.Top.Set(y, 0f);

            if (center)
                ele.HAlign = ele.VAlign = 0.5f;

            par?.Append(ele);
        }

        public static void SetDefaults(this UIElement ele, Vector2 size, Vector2 pos, bool center = false, UIElement par = null)
        {
            ele.Width.Set(size.X, 0f);
            ele.Height.Set(size.Y, 0f);
            ele.Left.Set(pos.X, 0f);
            ele.Top.Set(pos.Y, 0f);

            if (center)
                ele.HAlign = ele.VAlign = 0.5f;

            par?.Append(ele);
        }

        public static void SetDefaults(this ResourceBar bar, int height, int width, int x, int y, Asset<Texture2D> frame, int max, Color gradA, Color gradB, bool center = false, UIElement par = null)
        {
            bar.SetDefaults(height, width, x, y, center, par);
            bar.frame.SetDefaults(frame.Size(), Vector2.Zero, center, par, frame);
            bar.resourceText.SetDefaults(frame.Size(), new Vector2(0, 40), center, par, "0/0");

            bar.maximum = max;
            bar.gradientA = gradA;
            bar.gradientB = gradB;
        }

        public static void SetDefaults(this ResourceBar bar, Vector2 size, Vector2 pos, Asset<Texture2D> frame, int max, Color gradA, Color gradB, bool center = false, UIElement par = null)
        {
            bar.SetDefaults(size, pos, center, par);
            bar.frame.SetDefaults(frame.Size(), Vector2.Zero, false, par, frame);
            bar.resourceText.SetDefaults(frame.Size(), new Vector2(0, 40), false, par, "0/0");

            bar.maximum = max;
            bar.gradientA = gradA;
            bar.gradientB = gradB;
        }

        public static void SetDefaults(this UIImage img, int height, int width, int x, int y, bool center = false, UIElement par = null, Asset<Texture2D> uiTexture = null)
        {
            img.SetDefaults(height, width, x, y, center, par);

            if (uiTexture is not null)
                img.SetImage(uiTexture.Value);
        }

        public static void SetDefaults(this UIText txt, int height, int width, int x, int y, bool center = false, UIElement par = null, string text = null)
        {
            txt.SetDefaults(height, width, x, y, center, par);

            if (text is not null)
                txt.SetText(text);
        }

        public static void SetDefaults(this UIImage img, Vector2 size, Vector2 pos, bool center = false, UIElement par = null, Asset<Texture2D> uiTexture = null)
        {
            img.SetDefaults(size, pos, center, par);

            if (uiTexture is not null)
                img.SetImage(uiTexture.Value);
        }

        public static void SetDefaults(this UIText txt, Vector2 size, Vector2 pos, bool center = false, UIElement par = null, string text = null)
        {
            txt.SetDefaults(size, pos, center, par);

            if (text is not null)
                txt.SetText(text);
        }
    }
}