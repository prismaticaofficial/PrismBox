namespace PrismBox.core.script_npc
{
    internal class NPCComponent : GlobalNPC
    {
        public bool Enabled { get; set; }

        public sealed override bool InstancePerEntity { get; } = true;
    }
}