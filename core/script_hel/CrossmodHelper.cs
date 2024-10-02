namespace PrismBox.core.script_hel
{
    internal class CrossmodHelper
    {
        /// <summary>
        /// Grabs a particular ModType entity. <br></br>
        /// To quickly (and directly) modify an entity, use <see cref="QuickTryModifyEntity{T}(string, string, Action{T}, bool)"/>
        /// </summary>
        /// <typeparam name="T">The <see cref="ModType"/> of the entity</typeparam>
        /// <param name="modName">The name of the mod the entity is in</param>
        /// <param name="entityName">The name of the entity you're getting</param>
        /// <param name="entity">The entity in question</param>
        /// <returns>False if the mod or entity does not exist, true otherwise.</returns>
        public static bool TryGetEntity<T>(string modName, string entityName, out T entity) where T : ModType
        {
            if (!ModLoader.TryGetMod(modName, out Mod m) || !m.TryFind(entityName, out T ent))
            {
                entity = null;
                return false;
            }

            entity = ent;
            return true;
        }

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