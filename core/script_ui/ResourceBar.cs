using PrismBox.core.script_ext;
using Terraria.GameContent;

namespace PrismBox.core.script_ui
{
    internal class ResourceBar : UIElement
    {
        private readonly Asset<Texture2D> frameTexture;

        /// <summary>
        /// The first color of the gradient of the bar.
        /// </summary>
        public Color gradientA;
        /// <summary>
        /// The second color of the gradient of the bar.
        /// </summary>
        public Color gradientB;

        /// <summary>
        /// The inner area that consists of the drawn bar. Set manually when instantiating the bar.
        /// </summary>
        public Rectangle innerDims;

        /// <summary>
        /// The current value of your resource. Update this value in your UIState's Update method.
        /// </summary>
        internal int currentValue;
        /// <summary>
        /// The maximum value of this resource. Set this when you set the defaults. 
        /// </summary>
        public int maximum;

        /// <summary>
        /// The UIImage pertaining to the resource bar's frame and texture. You can manually alter position after instantiation if needed.
        /// </summary>
        public UIImage frame;
        /// <summary>
        /// The UIText pertaining to the status text. You can manually alter this position after instantiation if needed.
        /// </summary>
        public UIText resourceText;

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            float quo = Utils.Clamp((float)currentValue / maximum, 0f, 1f);

            int steps = (int)((innerDims.Right - innerDims.Left) * quo);

            for (int i = 0; i < steps; i++)
                spriteBatch.Draw(TextureAssets.MagicPixel.Value, 
                    new Rectangle(innerDims.Left + i, innerDims.Y, 1, innerDims.Height), 
                    Color.Lerp(gradientA, gradientB, i / (innerDims.Right - innerDims.Left)));
        }

        public override void Update(GameTime gameTime)
        {
            resourceText.SetText($"{currentValue}/{maximum}");

            base.Update(gameTime);
        }
    }
}