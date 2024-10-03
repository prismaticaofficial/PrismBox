using System.Threading.Tasks;

namespace PrismBox.core.script_hel
{
    internal class CrossmodHelper
    {
        /// <summary>
        /// Safely attempts to disable a mod by its provided internal name. Useful for disabling mods that directly conflict with yours. <br></br>
        /// Only call in <see cref="Mod.PostSetupContent()"/> to avoid breakage. <br><br></br></br>
        /// 
        /// It is also advised to not use this ad nauseum, as disabling mods without warrant is generally a poor practice.
        /// </summary>
        /// <param name="modName">The internal name of the mod to disable. Case sensitive.</param>
        /// <returns>True if the mod exists and was disabled, else false.</returns>
        public static void DisableMod(string modName)
        {
            var method = typeof(ModLoader).GetMethod("DisableMod", BindingFlags.Static | BindingFlags.NonPublic);

            if (ModLoader.Mods.Any(x => x.Name == modName))
            {
                method.Invoke(null, [ModLoader.Mods.Where(x => x.Name == modName)]);
                PrismBox.FormatToLogs(null, $"[PrismBox] Disabled {modName}", PrismBox.LogType.INFO);
            }

            while (Main.menuMode != 0)
            {
                Main.menuMode = 10006;
                break;
            }
        }

        /// <summary>
        /// Takes in an array of Mod internal names and disables them if present. <br></br>
        /// Only call in <see cref="Mod.PostSetupContent()"/> to avoid breakage. <br><br></br></br>
        /// 
        /// It is also advised to not use this ad nauseum, as disabling mods without warrant is generally a poor practice.
        /// </summary>
        /// <param name="modNames">An array of mod internal names to disable. Case sensitive.</param>
        public static void DisableModList(string[] modNames)
        {
            var method = typeof(ModLoader).GetMethod("DisableMod", BindingFlags.Static | BindingFlags.NonPublic);

            Task.Run(() =>
            {
                bool success = false;

                for (int i = 0; i < ModLoader.Mods.Length; i++)
                {
                    if (modNames.Contains(ModLoader.Mods[i].Name))
                    {
                        success = true;
                        method.Invoke(null, [ModLoader.Mods[i].Name]);
                        PrismBox.FormatToLogs(null, $"[PrismBox] Disabled {ModLoader.Mods[i].Name}", PrismBox.LogType.INFO);
                    }
                }

                if (!success)
                    return;

                while (Main.menuMode != 0)
                {
                    Main.menuMode = 10006;
                    break;
                }
            });
        }

        //Credit for the above mod disable methods go to Tomat, aka Steviegt6.

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