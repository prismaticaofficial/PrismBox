namespace PrismBox.core.script_npc
{
    internal class NPCComponent : GlobalNPC
    {
        public bool Enabled { get; set; }

        public sealed override bool InstancePerEntity { get; } = true;

        public virtual void C_AI(NPC npc) { }
        public virtual void C_SetDefaults(NPC npc) { }

        public sealed override void AI(NPC npc)
        {
            if (Enabled)
                C_AI(npc);
        }
        public sealed override void SetDefaults(NPC entity)
        {
            if (Enabled)
                C_SetDefaults(entity);
        }
    }
}