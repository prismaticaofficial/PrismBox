namespace PrismBox.core.script_npc.prism_npc_comps
{
    internal class DeprecatedComponent : NPCComponent
    {
        //todo

        public override void C_SetDefaults(NPC npc)
        {
            npc.aiStyle = 0;
            npc.boss = false;
            npc.life = 1;
            npc.lifeMax = 1;
            npc.midas = false;
            npc.damage = 1;
            npc.defense = 1;

            

            base.C_SetDefaults(npc);
        }
    }
}