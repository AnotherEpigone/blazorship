namespace BlazorShip.Data
{
    public enum Quality
    {
        Unknown,
        Good,
        Mediocre,
        Bad,
    }

    public class PlanetFeature
    {
        public PlanetFeature(string name, Quality quality)
        {
            Name = name;
            Quality = quality;
        }

        public string Name { get; set; }

        public Quality Quality { get; set; }

        public string QualityClass => Quality switch
            {
                Quality.Good => "good-quality",
                Quality.Mediocre => "mediocre-quality",
                Quality.Bad => "bad-quality",
                Quality.Unknown => "unknown-quality",
            };

        public int Score => Quality switch
        {
            Quality.Good => 500,
            Quality.Mediocre => 250,
            Quality.Bad => 0,
        };

        public static PlanetFeature Random(List<PlanetFeature> list)
        {
            var rng = new Random();
            return list[rng.Next(list.Count)];
        }

        public static List<PlanetFeature> AtmosphereFeatures { get; } = new List<PlanetFeature>
        {
            new PlanetFeature("None", Quality.Bad),
            new PlanetFeature("Toxic", Quality.Bad),
            new PlanetFeature("Marginal", Quality.Mediocre),
            new PlanetFeature("Breathable", Quality.Good),
        };

        public static List<PlanetFeature> GravityFeatures { get; } = new List<PlanetFeature>
        {
            new PlanetFeature("Very high", Quality.Bad),
            new PlanetFeature("Very low", Quality.Bad),
            new PlanetFeature("Low", Quality.Mediocre),
            new PlanetFeature("High", Quality.Mediocre),
            new PlanetFeature("Normal", Quality.Good),
        };

        public static List<PlanetFeature> TemperatureFeatures { get; } = new List<PlanetFeature>
        {
            new PlanetFeature("Very cold", Quality.Bad),
            new PlanetFeature("Very hot", Quality.Bad),
            new PlanetFeature("Hot", Quality.Mediocre),
            new PlanetFeature("Cold", Quality.Mediocre),
            new PlanetFeature("Comfortable", Quality.Good),
        };

        public static List<PlanetFeature> WaterFeatures { get; } = new List<PlanetFeature>
        {
            new PlanetFeature("Trace", Quality.Bad),
            new PlanetFeature("None", Quality.Bad),
            new PlanetFeature("Ice-covered surface", Quality.Mediocre),
            new PlanetFeature("Planet-wide ocean", Quality.Mediocre),
            new PlanetFeature("Oceans", Quality.Good),
        };

        public static List<PlanetFeature> ResourcesFeatures { get; } = new List<PlanetFeature>
        {
            new PlanetFeature("None", Quality.Bad),
            new PlanetFeature("Trace", Quality.Bad),
            new PlanetFeature("Poor", Quality.Mediocre),
            new PlanetFeature("Rich", Quality.Good),
        };
    }
}
