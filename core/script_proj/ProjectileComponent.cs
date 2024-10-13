namespace PrismBox.core.script_proj
{
    internal class ProjectileComponent : GlobalProjectile
    {
        public bool Enabled { get; set; }

        public override bool InstancePerEntity { get; } = true;

        public virtual void C_AI(Projectile proj) { }
        public virtual void C_OnKill(Projectile proj, int tL) { }
        public virtual void C_SetDefaults(Projectile proj) { }

        public sealed override void AI(Projectile projectile)
        {
            if (Enabled)
                C_AI(projectile);
        }
        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (Enabled)
                C_OnKill(projectile, timeLeft);
        }
        public sealed override void SetDefaults(Projectile entity)
        {
            if (Enabled)
                C_SetDefaults(entity);
        }
    }
}