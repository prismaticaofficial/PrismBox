namespace PrismBox.core.script_ext
{
    internal static class UIExtensions
    {
        public static void SetDefaults(this UIElement ele, Vector2 size, Vector2 pos, bool center = false, Asset<Texture2D> uiTexture = null, UIElement par = null)
        {
            ele.Width.Set(size.X, 0f);
            ele.Height.Set(size.Y, 0f);
            ele.Left.Set(pos.X, 0f);
            ele.Top.Set(pos.Y, 0f);

            if (center)
                ele.HAlign = ele.VAlign = 0.5f;

            if (uiTexture is not null && ele is UIImage img)
                img.SetImage(uiTexture.Value);

            par?.Append(ele);
        }
    }
}