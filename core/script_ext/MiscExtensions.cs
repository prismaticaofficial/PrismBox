namespace PrismBox.core.script_ext
{
    internal static class MiscExtensions
    {
        public static bool OutsideWorldBounds(this Vector2 vec) => vec.X < 0 || vec.Y < 0 || vec.X > Main.ActiveWorldFileData.WorldSizeX || vec.Y > Main.ActiveWorldFileData.WorldSizeY;


    }
}