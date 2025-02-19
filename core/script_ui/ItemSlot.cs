using PrismBox.core.script_ext;
using Terraria.GameContent;
using Terraria.GameInput;

namespace PrismBox.core.script_ui
{
    internal class ItemSlot(Asset<Texture2D> texture = null) : UIElement
    {
        /// <summary>
        /// The texture of the item slot's frame.
        /// </summary>
        public static Asset<Texture2D> frameTexture;
        /// <summary>
        /// The item stored within the slot.
        /// </summary>
        public static Item Item { get; set; } = new();

        /// <summary>
        /// Whether or not to allow the item to be placed into the slot. <para></para>
        /// Useful for limiting item types.
        /// </summary>
        /// <param name="it">The item in question.</param>
        /// <returns></returns>
        public virtual bool AllowItem(Item it) => true;

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsMouseHovering)
            {
                Main.LocalPlayer.mouseInterface = true;

                if (!Item.IsAir)
                {
                    Main.HoverItem = Item.Clone();
                    Main.hoverItemName = " ";

                    if (Main.keyState.PressingShift())
                        Main.cursorOverride = 7;
                }
            }

            frameTexture = texture is null ? TextureAssets.InventoryBack : texture;
            spriteBatch.Draw(frameTexture.Value, GetDimensions().Position(), frameTexture.Value.Frame(), Color.White, 0, Vector2.Zero, 1, 0, 0);

            if (!Item.IsAir)
            {
                Texture2D itemTex = Item.ModItem is not null ? ModContent.Request<Texture2D>(Item.ModItem.Texture).Value : TextureAssets.Item[Item.netID].Value;
                spriteBatch.Draw(itemTex, 
                    new((int)GetDimensions().X + 30, (int)GetDimensions().Y + 30, (int)MathHelper.Min(itemTex.Width, 28), (int)MathHelper.Min(itemTex.Height, 28)), 
                    itemTex.Frame(), Color.White, 0, itemTex.Size() / 2, 0, 0);

                if (Item.stack > 1)
                    Utils.DrawBorderString(spriteBatch, Item.stack.ToString(), GetDimensions().Position() + Vector2.One * 32, Color.White, 0.75f);
            }

            base.Draw(spriteBatch);
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            Player plr = Main.LocalPlayer;

            if (PlayerInput.Triggers.Current.SmartSelect) { //shift click
                if (!Item.IsAir && plr.NextOpenInvSlot() != -1)
                {
                    plr.GetItem(Main.myPlayer, Item.Clone(), GetItemSettings.InventoryUIToInventorySettings);
                    Item.TurnToAir();
                }
            }

            else
            {
                if (Main.mouseItem.IsAir && !Item.IsAir)
                {
                    Main.mouseItem = Item.Clone();
                    Item.TurnToAir();
                }
                if (!Item.IsAir && plr.HeldItem.type == Item.type)
                {
                    Item.stack += plr.HeldItem.stack;
                    plr.HeldItem.TurnToAir();
                }
                if (AllowItem(plr.HeldItem)) {
                    if (Item.IsAir)
                    {
                        Item = plr.HeldItem.Clone();
                        plr.HeldItem.TurnToAir();
                        Main.mouseItem.TurnToAir();
                    }
                    else
                    {
                        if (plr.HeldItem.type == Item.type) {
                            if (Item.stack + plr.HeldItem.stack > Item.maxStack)
                            {
                                Main.mouseItem.stack = Item.stack + plr.HeldItem.stack - Item.maxStack;
                                Item.stack = Item.maxStack;
                            }
                            else
                            {
                                Item.stack += plr.HeldItem.stack;
                                plr.HeldItem.TurnToAir();
                                Main.mouseItem.TurnToAir();
                            }
                        }
                        else
                        {
                            Item temp = Item;
                            Item = plr.HeldItem;
                            Main.mouseItem = temp;
                        }
                    }
                }
            }

            SoundEngine.PlaySound(SoundID.Grab);

            base.LeftClick(evt);
        }

        public override void RightClick(UIMouseEvent evt)
        {
            if (Main.mouseItem.IsAir)
                Main.mouseItem = Item.CloneWithEdits(x => x.stack = 1);

            else if (Main.mouseItem.type == Item.type && Main.mouseItem.stack < Item.maxStack)
                Main.mouseItem.stack++;

            Item.stack--;

            if (Item.stack == 0)
                Item.TurnToAir();

            SoundEngine.PlaySound(SoundID.MenuTick);

            base.RightClick(evt);
        }

        public override void Update(GameTime gameTime)
        {
            if (Item.type == ItemID.None || Item.stack <= 0)
                Item.TurnToAir();

            base.Update(gameTime);
        }
    }
}