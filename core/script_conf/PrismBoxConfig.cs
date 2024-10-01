namespace PrismBox.core.script_conf
{
    internal class PrismBoxConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Debug")]
        [DefaultValue(false)]
        public bool EnableDebug { get; set; }

        [Header("Experimental Features")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool EnableExperiments { get; set; }
    }
}