using PrismBox.core.script_def;
using PrismBox.core.script_hel;
using Terraria.GameContent;

namespace PrismBox.core.script_sys
{
    internal class InvasionHandler : ModSystem
    {
        public ModInvasion currentInvasion;

        /// <summary>
        /// Starts an invasion of the designated type at the designated area. <br></br>
        /// EXPERIMENTAL
        /// </summary>
        /// <param name="areaSize">The size of the invasion spawn area.</param>
        /// <param name="type">The type of invasion to spawn</param>
        /// <param name="delay">If the spawn time should be delayed by a given amount.</param>
        /// <returns></returns>
        public bool StartNew(Vector2 areaSize, ModInvasion type, int delay = 0)
        {
            if (currentInvasion != null || Main.invasionType != 0)
                return false;

            while (delay > 0)
                delay--;

            currentInvasion = type;

            IReadOnlyList<TeleportPylonInfo> list = Main.PylonSystem.Pylons;

            Vector2 center = list.Count > 0 ? list[Main.rand.Next(list.Count)].PositionInTiles.ToWorldCoordinates() : WorldHelper.SpawnCoords();
            currentInvasion.invasionArea = new((int)(center.X - areaSize.X / 2), (int)(center.Y + areaSize.Y / 2), (int)areaSize.X, (int)areaSize.Y);

            currentInvasion.isActive = true;
            currentInvasion.OnStart();

            return true;
        }

        public void DefeatInvasion()
        {


            currentInvasion.OnDefeated();
            currentInvasion = null;
        }

        public override void PreUpdateInvasions()
        {
            if (currentInvasion != null)
                Main.invasionType = 0;



            base.PreUpdateInvasions();
        }
    }
}