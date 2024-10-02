namespace PrismBox.core.script_it.prism_it_comps
{
    /// <summary>
    /// An Item Component that automatically draws the glowmask in both the world and the inventory. <br></br>
    /// Component usage example is provided in the PrismBox GitHub Wiki.
    /// </summary>
    internal class GlowmaskComponent : ItemComponent
    {
        /// <summary>
        /// The texture used for the STATIC glowmask. <br></br>
        /// Animated glowmask support coming soon.
        /// </summary>
        public static Asset<Texture2D> glowmaskTexture;

        /// <summary>
        /// Whether or not to draw the glowmask while in the inventory. <br></br> Defaults to true.
        /// </summary>
        public bool drawInInv = true;
        /// <summary>
        /// Whether or not to draw the glowmask while in the world. <br></br> Defaults to true.
        /// </summary>
        public bool drawInWorld = true;

        public override void C_PostDrawInInv(Item it, SpriteBatch sB, Vector2 pos, Rectangle fr, Color dC, Color iC, Vector2 orig, float sc)
        {
            if (drawInInv)
                sB.Draw(glowmaskTexture.Value, pos, fr, dC, 0, orig, sc, SpriteEffects.None, 0);

            base.C_PostDrawInInv(it, sB, pos, fr, dC, iC, orig, sc);
        }

        public override void C_PostDrawInWorld(Item it, SpriteBatch sB, Color lC, Color aC, float rot, float sc, int wAI)
        {
            if (drawInWorld)
                sB.Draw(glowmaskTexture.Value,
                    new Vector2(it.position.X - Main.screenPosition.X + it.width * 0.5f, it.position.Y - Main.screenPosition.Y + it.height * 0.5f + 2f),
                    new Rectangle(0, 0, glowmaskTexture.Value.Width, glowmaskTexture.Value.Height),
                    Color.White, rot, glowmaskTexture.Value.Size() * 0.5f, sc, SpriteEffects.None, 0f);

            base.C_PostDrawInWorld(it, sB, lC, aC, rot, sc, wAI);
        }
    }
}