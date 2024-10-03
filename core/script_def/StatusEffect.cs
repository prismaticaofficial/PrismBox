namespace PrismBox.core.script_def
{
    /// <summary>
    /// A data-oriented way of handling Buffs.
    /// <br></br> <br></br>
    /// EXPERIMENTAL
    /// </summary>
    internal class StatusEffect : ModType, ILocalizedModType
    {
        public static Asset<Texture2D> effectIcon;

        /// <summary>
        /// Whether or not this effect can accumulate stacks.
        /// </summary>
        public bool canStack;
        /// <summary>
        /// Whether or not to draw the timer for this effect.
        /// </summary>
        public bool showTimer;
        /// <summary>
        /// Whether or not to use custom time calculations. <br></br>If true, will use <see cref="CustomTimeCalc()"/> instead.
        /// </summary>
        public bool useCustomTime;

        public int ID { get; internal set; }

        /// <summary>
        /// The current amount of stacks this effect has.
        /// </summary>
        public int stackCur;
        /// <summary>
        /// The maximum amount of stacks this effect can have.
        /// </summary>
        public int stackMax;
        /// <summary>
        /// The current amount of time this effect has left.
        /// </summary>
        public int timeLeftCur;
        /// <summary>
        /// The maximum amount of time this effect can have left.
        /// </summary>
        public int timeLeftMax;

        public string LocalizationCategory => "StatusEffects";
        protected virtual LocalizedText EffectName => this.GetLocalization(nameof(EffectName), PrettyPrintName);
        protected virtual LocalizedText EffectTooltip => this.GetLocalization(nameof(EffectTooltip), () => "");

        public virtual void SetDefaults() { }

        public virtual void CustomTimeCalc() { }

        /// <summary>
        /// What effect this Status Effect has on the Player.
        /// </summary>
        /// <param name="plr">The Player in question.</param>
        public virtual void DoEffect(Player plr) { }
        /// <summary>
        /// What effect this Status Effect has on any NPC.
        /// </summary>
        /// <param name="npc">The NPC in question.</param>
        public virtual void DoEffect(NPC npc) { }

        public virtual void OnReapply(Player plr) { }
        public virtual void OnStackReduce(Player plr) { }
        public virtual void OnTimeRunout(Player plr) { }

        protected sealed override void Register() { ModTypeLookup<StatusEffect>.Register(this); }

        public sealed override void SetupContent()
        {
            SetDefaults();

            base.SetupContent();
        }
    }
}