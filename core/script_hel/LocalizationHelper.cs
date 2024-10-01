namespace PrismBox.core.script_hel
{
    internal class LocalizationHelper
    {
        public static string GetRandLocalText(string filt)
        {
            LocalizedText[] texts = Language.FindAll(Lang.CreateDialogFilter(filt));
            return Main.rand.Next(texts).Value;
        }

        public static string GetRandLocalTextWithSubs(string filt, params object[] args)
        {
            LocalizedText[] texts = Language.FindAll(Lang.CreateDialogFilter(filt));
            return Main.rand.Next(texts).Value.FormatWith(args);
        }
    }
}