namespace PrismBox.core.script_ext
{
    internal static class NPCExtensions
    {
        public static bool InLiquid(this NPC npc) => npc.wet || npc.lavaWet || npc.honeyWet || npc.shimmerWet;

        public static bool IsFloater(this NPC npc) => npc.noTileCollide || npc.noGravity;

        public static Player WhoKilledMe(this NPC npc) => (npc.life <= 0 && npc.lastInteraction != byte.MaxValue) ? Main.player[npc.lastInteraction] : null;

        public static bool MoveToPoint(this NPC npc, float speed, Vector2 pos)
        {
            if (pos.OutsideWorldBounds())
                return false;

            while (npc.position != pos)
            {
                npc.velocity *= (1f + speed) * npc.DirectionTo(pos);

                if (npc.IsFloater() && npc.WithinRange(pos, 1f))
                    return true;

                //if not floater, attempt to jump
                //if cannot jump after 3 attempts, give up.
            }

            return false;
        }
    }
}