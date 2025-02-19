using PrismBox.core.script_hel;

namespace PrismBox.core.script_plr.prism_plr_comps
{
    internal class TestEffect : StatusEffectComponent
    {
        public override void SetEffectDefaults()
        {
            effectIcon = ModContent.Request<Texture2D>(PathHelper.PrismPlaceholderPath); //set manual because components for this would be annoying

            noClear = false; //if true, this will never clear
            canStack = true; //if true, this buff can accrue "stacks", which can be used for additive/multiplicative effects
            clearStacksOnTimeRunout = true; //if true, this will clear all stacks on time runout, rather than reductive stacks

            base.SetEffectDefaults();
        }

        //effect icons should be drawn on the HUD for the lcoal player, and above their head for others.

        //
    }
}