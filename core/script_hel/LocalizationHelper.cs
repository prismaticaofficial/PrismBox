namespace PrismBox.core.script_hel
{
    internal class LocalizationHelper
    {
        /// <summary>
        /// Gets a random localized text from a particular set.
        /// </summary>
        /// <param name="filt"></param>
        /// <returns></returns>
        public static string GetRandLocalText(string filt)
        {
            LocalizedText[] texts = Language.FindAll(Lang.CreateDialogFilter(filt));
            return Main.rand.Next(texts).Value;
        }

        /// <summary>
        /// Gets a random localized text from a particular set. (with substitutions)
        /// </summary>
        /// <param name="filt"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetRandLocalTextWithSubs(string filt, params object[] args)
        {
            LocalizedText[] texts = Language.FindAll(Lang.CreateDialogFilter(filt));
            return Main.rand.Next(texts).Value.FormatWith(args);
        }
    }
}