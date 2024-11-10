using Terraria.IO;

namespace PrismBox.core.script_hel
{
    internal class WorldHelper
    {
        /// <summary>
        /// Allows for the easy transfer between or to a particular world file.
        /// </summary>
        /// <param name="pathTo">Path to the specific world file</param>
        /// <param name="fromWorld">Whether or not to save the previous world, if one is active</param>
        /// <param name="isCloud">Whether or not the world is a cloud-saved world</param>
        /// <returns>False if the world file doesn't exist, true otherwise.</returns>
        public static bool ToWorld(string pathTo, bool fromWorld = false, bool isCloud = false)
        {
            if (!WorldFile.IsValidWorld(pathTo, isCloud))
            {
                PrismBox.FormatToLogs(null, $" could not find valid world file at \"{pathTo}\"...", PrismBox.LogType.WARN);
                return false;
            }

            if (fromWorld)
                WorldGen.SaveAndQuit();

            var wF = new WorldFileData(pathTo, isCloud);
            wF.SetAsActive();   
            Main.ActiveWorldFileData = wF;
            WorldGen.playWorld();
            Main.MenuUI.SetState(null);
            return true;
        }

        public static Vector2 SpawnCoords() => new(Main.spawnTileX, Main.spawnTileY);
    }
}