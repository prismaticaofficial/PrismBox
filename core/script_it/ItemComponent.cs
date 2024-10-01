using System.IO;

namespace PrismBox.core.script_it
{
    /// <summary>
    /// An EC-based solution to creating and modifying items.
    /// </summary>
    internal class ItemComponent : GlobalItem
    {
        /// <summary>
        /// Whether or not this component is enabled on this item.
        /// </summary>
        public bool Enabled { get; set; }

        public override bool InstancePerEntity { get; } = true;

        public virtual void OnEnable(Item it) { }
        public virtual void OnDisable(Item it) { }

        #region COMPONENT FUNCTION OVERRIDES
        public virtual bool C_CanPickup(Item it, Player plr) => true;
        public virtual bool C_CanRClk(Item it) => false;
        public virtual bool C_OnPickup(Item it, Player plr) => true;

        /// <summary>
        /// Handles both saving and loading in one method, because I hate having separate methods.
        /// </summary>
        /// <param name="it">The item</param>
        /// <param name="t">The tag compound</param>
        /// <param name="save">Whether or not you're saving or loading data</param>
        public virtual void DataHandler(Item it, TagCompound t, bool save) { }
        public virtual void C_Load() { }
        public virtual void C_ModTooltips(Item it, List<TooltipLine> tt) { }
        public virtual void C_NetRecieve(Item it, BinaryReader bR) { }
        public virtual void C_NetSend(Item it, BinaryWriter bW) { }
        public virtual void C_RClk(Item it, Player plr) { }
        public virtual void C_SetDefaults(Item it) { }
        public virtual void C_Unload() { }
        public virtual void C_UpdateInv(Item it, Player plr) { }
        #endregion

        #region SEALED OVERRIDES
        public sealed override bool CanPickup(Item item, Player player)
        {
            if (Enabled)
                return C_CanPickup(item, player);

            else
                return base.CanPickup(item, player);
        }
        public sealed override bool CanRightClick(Item item)
        {
            if (Enabled)
                return C_CanRClk(item);

            else
                return base.CanRightClick(item);
        }
        public sealed override bool OnPickup(Item item, Player player)
        {
            if (Enabled)
                return C_OnPickup(item, player);

            else
                return base.OnPickup(item, player);
        }

        public sealed override void Load()
        {
            if (Enabled)
                C_Load();

            base.Load();
        }
        public sealed override void LoadData(Item item, TagCompound tag)
        {
            if (Enabled)
                DataHandler(item, tag, false);

            base.LoadData(item, tag);
        }
        public sealed override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (Enabled)
                C_ModTooltips(item, tooltips);

            base.ModifyTooltips(item, tooltips);
        }
        public sealed override void NetReceive(Item item, BinaryReader reader)
        {
            if (Enabled)
                C_NetRecieve(item, reader);

            base.NetReceive(item, reader);
        }
        public sealed override void NetSend(Item item, BinaryWriter writer)
        {
            if (Enabled)
                C_NetSend(item, writer);
        }
        public sealed override void RightClick(Item item, Player player)
        {
            if (Enabled)
                C_RClk(item, player);

            base.RightClick(item, player);
        }
        public sealed override void SaveData(Item item, TagCompound tag)
        {
            if (Enabled)
                DataHandler(item, tag, true);

            base.SaveData(item, tag);
        }
        public sealed override void SetDefaults(Item entity)
        {
            if (Enabled)
                C_SetDefaults(entity);

            base.SetDefaults(entity);
        }
        public sealed override void Unload()
        {
            if (Enabled)
                C_Unload();

            base.Unload();
        }
        public sealed override void UpdateInventory(Item item, Player player)
        {
            if (Enabled)
                C_UpdateInv(item, player);

            base.UpdateInventory(item, player);
        }
        #endregion
    }
}