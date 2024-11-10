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

        public Vector2 InvasionCenter { get => invasionArea.Center.ToVector2(); }
        public Rectangle invasionArea;

        public string LocalizationCategory => "Invasions";
        protected virtual LocalizedText InvasionName => this.GetLocalization(nameof(InvasionName), PrettyPrintName);
        protected virtual LocalizedText InvasionSpawnText => this.GetLocalization(nameof(InvasionSpawnText), () => "");
        protected virtual LocalizedText InvasionDefeatText => this.GetLocalization(nameof(InvasionDefeatText), () => "");

        public virtual void PopulateTypePool(Dictionary<int, (EnemyTypeDesignation type, int creditCost)> enemyTypes) { }

        public virtual void SpawnWave(int waveCurr) { }
        public virtual void OnStart() { }
        public virtual void OnDefeated() { }
        public virtual void OnWaveCompleted() { }
        public virtual void SetDefaults() { }
        public virtual void UpdateInvasion() { }

        protected sealed override void Register() { ModTypeLookup<ModInvasion>.Register(this); }

        public override void Load()
        {
            enemyTypes = [];
            PopulateTypePool(enemyTypes);

            base.Load();
        }

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