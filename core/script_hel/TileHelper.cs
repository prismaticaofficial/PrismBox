using Terraria.WorldBuilding;

namespace PrismBox.core.script_hel
{
    internal class TileHelper
    {


        //tile entity on worldgen

        /// <summary>
        /// Scans a particular area starting from the point given for the provided Tile IDs. <br></br>
        /// Useful for getting tile counts in an area and acting upon them. 
        /// </summary>
        /// <param name="x">X position of the starting point</param>
        /// <param name="y">Y position of the starting point</param>
        /// <param name="shape">The shape of the area, use <see cref="Shapes"/> or create your own</param>
        /// <param name="tileIDs">The TileIDs to search for within the area</param>
        /// <returns>A dictionary indexed by TileIDs, storing the counts of each.</returns>
        public static Dictionary<ushort, int> GetTileCounts(int x, int y, GenShape shape, ushort[] tileIDs)
        {
            Dictionary<ushort, int> tileCounts = [];
            WorldUtils.Gen(new Point(x, y), shape, new Actions.TileScanner(tileIDs).Output(tileCounts));
            return tileCounts;
        }
        public static Dictionary<ushort, int> GetTileCounts(Point p, GenShape shape, ushort[] tileIDs)
        {
            Dictionary<ushort, int> tileCounts = [];
            WorldUtils.Gen(p, shape, new Actions.TileScanner(tileIDs).Output(tileCounts));
            return tileCounts;
        }
    }
}