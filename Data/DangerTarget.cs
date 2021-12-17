namespace BlazorShip.Data
{
    public class DangerTarget
    {
        public DangerTarget(
            string name,
            Action<GameState, int> onHit)
        {
            Name = name;
            OnHit = onHit;
        }

        public string Name { get; }
        public Action<GameState, int> OnHit { get; }

        public static DangerTarget Random
        {
            get
            {
                var rng = new Random();
                return Targets[rng.Next(Targets.Count)];
            }
        }

        public static DangerTarget AtmosphereScanner => new DangerTarget("atmosphere scanner", (gs, damage) => gs.AtmosphereScanner -= damage);
        public static DangerTarget GravityScanner => new DangerTarget("gravity scanner", (gs, damage) => gs.GravityScanner -= damage);
        public static DangerTarget TemperatureScanner => new DangerTarget("temperature scanner", (gs, damage) => gs.TemperatureScanner -= damage);
        public static DangerTarget WaterScanner => new DangerTarget("water scanner", (gs, damage) => gs.WaterScanner -= damage);
        public static DangerTarget ResourcesScanner => new DangerTarget("resources scanner", (gs, damage) => gs.ResourcesScanner -= damage);
        public static DangerTarget Colonists => new DangerTarget("colonists cryo-bay", (gs, damage) => gs.Colonists -= damage * 3);
        public static DangerTarget ScientificDatabase => new DangerTarget("scientific database", (gs, damage) => gs.ScientificDatabase -= damage);
        public static DangerTarget CulturalDatabase => new DangerTarget("cultural database", (gs, damage) => gs.CulturalDatabase -= damage);

        public static List<DangerTarget> Targets => new List<DangerTarget>
        {
            AtmosphereScanner,
            GravityScanner,
            TemperatureScanner,
            WaterScanner,
            ResourcesScanner,
            Colonists,
            ScientificDatabase,
            CulturalDatabase,
        };
    }
}
