namespace PrismBox.core.script_plr
{
    internal class StatusEffectHandler : ModPlayer
    {
        public List<int> activeEffects;

        public int[] immunities;

        public override void PreUpdateBuffs()
        {


            base.PreUpdateBuffs();
        }

        public override void UpdateDead()
        {
            activeEffects.Clear();
            base.UpdateDead();
        }
    }
}