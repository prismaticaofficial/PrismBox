using Terraria.IO;

namespace PrismBox.core.script_hel
{
    internal class WorldHelper
    {
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
    }
}