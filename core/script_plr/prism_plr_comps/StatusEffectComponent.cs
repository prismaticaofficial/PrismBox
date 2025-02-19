namespace PrismBox.core.script_plr.prism_plr_comps
{
    internal abstract class StatusEffectComponent : PlayerComponent, ILocalizedModType
    {
        /// <summary>
        /// The icon used to display this effect.
        /// </summary>
        public Asset<Texture2D> effectIcon;

        /// <summary>
        /// If true, this effect does not obey time constraints.
        /// </summary>
        public bool noClear;
        /// <summary>
        /// If true, this effect can accrue stacks.
        /// </summary>
        public bool canStack;
        /// <summary>
        /// If true, when timeleft is 0, all stacks will be cleared on disable.
        /// </summary>
        public bool clearStacksOnTimeRunout;

        /// <summary>
        /// The current timeleft of this effect.
        /// </summary>
        public short effectTimeCur;
        /// <summary>
        /// The maximum timeleft of this effect.
        /// </summary>
        public short effectTimeMax;

        /// <summary>
        /// The current amount of stacks this effect has.
        /// </summary>
        public short stackCur;
        /// <summary>
        /// The maximum amount of stacks available.
        /// </summary>
        public short stackMax;

        public string LocalizationCategory => "StatusEffects/Player";
        public LocalizedText EffectName => this.GetLocalization(nameof(EffectName), PrettyPrintName);
        public LocalizedText EffectDesc => this.GetLocalization(nameof(EffectDesc), () => "");

        public void UpdateEffectTime()
        {
            if (noClear)
                return;
        }

        /// <summary>
        /// Allows you to make stuff happen while this effect is enabled. 
        /// </summary>
        public virtual void UpdateEffect() { }
        /// <summary>
        /// Allows you to make actions when this effect is enabled.
        /// </summary>
        public virtual void OnApply() { }
        /// <summary>
        /// Allows you to make actions when this effect has a stack reduced.
        /// </summary>
        public virtual void OnStackReduce() { }
        /// <summary>
        /// Allows you to make actions when this effect is reapplied.
        /// </summary>
        public virtual void OnReapply() { }
        /// <summary>
        /// Allows you to make actions when this effect is disabled.
        /// </summary>
        public virtual void OnClear() { }

        public virtual void SetEffectDefaults() { }

        public sealed override void OnEnabled() { OnApply(); }
        public sealed override void SetStaticDefaults()
        {
            SetEffectDefaults();

            base.SetStaticDefaults();
        }
    }
}