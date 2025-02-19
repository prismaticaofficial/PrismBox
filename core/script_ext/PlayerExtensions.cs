using PrismBox.core.script_plr;
using PrismBox.core.script_plr.prism_plr_comps;

namespace PrismBox.core.script_ext
{
    internal static class PlayerExtensions
    {
        public static bool InLiquid(this Player plr) => plr.wet || plr.lavaWet || plr.honeyWet || plr.shimmerWet;

        public static bool IsAlive(this Player plr) => plr.active && !plr.dead;

        public static bool IsStill(this Player plr) => plr.velocity == Vector2.Zero;

        public static bool PlayerIsInRange(this Player plr, float chkRange) => Main.player.Any(x => x.WithinRange(plr.Center, chkRange));

        public static int PlayersInRange(this Player plr, float chkRange) => Main.player.Count(x => x.WithinRange(plr.Center, chkRange));

        public static int NextOpenInvSlot(this Player plr) 
        {
            int ind = Array.FindIndex(plr.inventory, x => x.IsAir);

            if (ind < Main.InventoryItemSlotsStart || ind > Main.InventoryItemSlotsCount)
                return -1;

            return ind;
        }

        public static Player ClosestPlayer(this Player plr)
        {
            float closest = float.PositiveInfinity;
            Player closePlr = null;

            foreach (Player other in Main.ActivePlayers)
            {
                float dist = other.DistanceSQ(plr.Center);
                if (dist < closest)
                {
                    closest = dist;
                    closePlr = other;
                }
            }

            return closePlr;
        }

        public static bool TryEnableComponent<T>(this Player plr, Action<T> init = null) where T : PlayerComponent
        {
            if (!plr.TryGetModPlayer(out T temp))
                return false;

            temp.Enabled = true;
            temp.OnEnabled();
            init?.Invoke(temp);
            return true;
        }

        public static bool TryDisableComponent<T>(this Player plr) where T : PlayerComponent
        {
            if (!plr.TryGetModPlayer(out T temp))
                return false;

            temp.Enabled = false;
            return true;
        }

        public static bool TryGetComponent<T>(this Player plr, out T comp) where T : PlayerComponent
        {
            if (!plr.TryGetModPlayer(out T temp))
            {
                comp = null;
                return false;
            }

            comp = temp;
            return true;
        }

        public static bool IsEnabled<T>(this Player plr) where T : PlayerComponent => plr.TryGetComponent(out T comp) && comp.Enabled; 

        public static bool ApplyStatusEffect<T>(this Player plr, short effectTime, short stackCount = 0) where T : StatusEffectComponent
        {
            if (!plr.TryGetComponent(out T comp))
                return false;

            if (plr.IsEnabled<T>())
            {
                if (comp.canStack)
                    comp.stackCur = (short)Math.Clamp(comp.stackCur + stackCount, 0, comp.stackMax);

                comp.effectTimeCur = (short)Math.Clamp(comp.effectTimeCur + effectTime, 0, comp.effectTimeMax);
                comp.OnReapply();
                return true;
            }

            else
            {
                plr.TryEnableComponent<T>(x =>
                {
                    x.stackCur += (short)Math.Clamp((int)stackCount, 0, x.stackMax);
                    x.effectTimeCur += (short)Math.Clamp((int)effectTime, 0, x.effectTimeMax);
                });
                return true;
            }
        }
    }
}