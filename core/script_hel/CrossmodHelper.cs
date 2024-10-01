namespace PrismBox.core.script_hel
{
    internal class CrossmodHelper
    {
        /// <summary>
        /// Allows for quick modification of a particular ModType entity. <br></br>
        /// If you require more direct or drastic modifications, create a component and enable it in the initializer. <br></br>
        /// An example for the usage of this function is available on the PrismBox GitHub Wiki.
        /// </summary>
        /// <typeparam name="T">The <see cref="ModType"/> of the entity</typeparam>
        /// <param name="modName">The name of the mod you're modifying</param>
        /// <param name="entityName">The name of the entity you're modifying</param>
        /// <param name="init">The initializer to perform changes</param>
        /// <param name="logChange">Whether or not to log the changes</param>
        /// <returns>True if the entity exists, </returns>
        public static bool QuickTryModifyEntity<T>(string modName, string entityName, Action<T> init = null, bool logChange = false) where T : ModType
        {
            if (!ModLoader.TryGetMod(modName, out Mod m))
                return false;

            if (!m.TryFind(entityName, out T ent))
                return false;

            init?.Invoke(ent);

            if (logChange)
                m.Logger.Info($"[PrismBox | {modName}] Modified {ent.Name} \"{entityName}\"");

            return true;
        }
    }
}