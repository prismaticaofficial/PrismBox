using PrismBox.core.script_sys;

namespace PrismBox.core.script_def
{
    /// <summary>
    /// A special ModType which allows for the creation of custom Invasions. <br></br> <br></br>
    /// EXPERIMENTAL
    /// </summary>
    internal abstract class ModInvasion : ModType, ILocalizedModType
    {
        public bool isActive;
        public bool isContinuous;
        public bool isDefeated;

        public Dictionary<int, (EnemyTypeDesignation type, int creditCost)> enemyTypes;

        public int spawnCredits;

        public int startDelay;
        public int spawnDelay;

        public int invasionProgress;
        public int invasionCompletionRequirement;

        public short waveCount;

        public static InvasionHandler Handler { get; } = ModContent.GetInstance<InvasionHandler>();

        public string LocalizationCategory => "Invasions";
        protected virtual LocalizedText InvasionName => this.GetLocalization(nameof(InvasionName), PrettyPrintName);
        protected virtual LocalizedText InvasionSpawnText => this.GetLocalization(nameof(InvasionSpawnText), () => "");
        protected virtual LocalizedText InvasionDefeatText => this.GetLocalization(nameof(InvasionDefeatText), () => "");

        public static bool StartNew(ModInvasion type, Vector2 startPos)
        {
            if (Handler.currentInvasion is not null || Handler.currentInvasion.isActive)
                return false;

            Handler.currentInvasion = type;
            type.isActive = true;
            return true;
        }

        public static void DefeatInvasion(ModInvasion type)
        {
            Handler.currentInvasion = null;

            type.isDefeated = true;
            type.isActive = false;

            type.OnDefeated();
        }

        public virtual void SpawnWave(int waveCurr) { }
        public virtual void OnDefeated() { }
        public virtual void OnWaveCompleted() { }
        public virtual void SetDefaults() { }
        public virtual void UpdateInvasion() { }

        protected sealed override void Register() { ModTypeLookup<ModInvasion>.Register(this); }

        public override void Unload()
        {

            enemyTypes.Clear();

            base.Unload();
        }

        public enum EnemyTypeDesignation
        {
            MOB,
            MINIBOSS,
            BOSS
        }
    }
}