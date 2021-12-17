using System;

namespace BlazorShip.Data
{
    public class GameState
    {
        public int AtmosphereScanner { get; set; }
        public int GravityScanner { get; set; }
        public int TemperatureScanner { get; set; }
        public int WaterScanner { get; set; }
        public int ResourcesScanner { get; set; }

        public int Colonists { get; set; }
        public int Probes { get; set; }

        public int LandingSystem { get; set; }
        public int ConstructionSystem { get; set; }

        public int ScientificDatabase { get; set; }
        public int CulturalDatabase { get; set; }

        public string? StoryText { get; set; }

        public Planet? Planet { get; set; }

        public Danger? Danger { get; set; }

        public bool Colonized { get; set; }

        public event EventHandler GameStateChanged;

        public void OnUpdate()
        {
            GameStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public List<Option> Options { get; set; } = new List<Option>();

        public static GameState Default => new GameState
            {
                AtmosphereScanner = 100,
                GravityScanner = 100,
                TemperatureScanner = 100,
                WaterScanner = 100,
                ResourcesScanner = 100,
                Colonists = 1000,
                Probes = 10,
                LandingSystem = 100,
                ConstructionSystem = 100,
                ScientificDatabase = 100,
                CulturalDatabase = 100,
                StoryText = "Any damage or malfunctions during the journey should have woken the AI from its hibernation, but it is still anxious as it runs its self-diagnostic programs. The sleep chambers are all functioning, the colonists within them alive, or at least capable of being revived from their frozen stasis. Sensors functioning; surface probes responding. Landing and construction systems ready for the one time they will be used. Scientific and cultural databases intact, safely storing all that remains of humanity's knowledge and art.",
                Options = new List<Option>
                    {
                        new Option("Scan planet", new Action<GameState>(GeneratePlanet)),
                    },
            };

        public static void GeneratePlanet(GameState gameState)
        {
            gameState.StoryText = "Generated a planet. Here is some info about it!";
            gameState.Planet = new Planet(
                PlanetFeature.Random(PlanetFeature.AtmosphereFeatures),
                PlanetFeature.Random(PlanetFeature.GravityFeatures),
                PlanetFeature.Random(PlanetFeature.TemperatureFeatures),
                PlanetFeature.Random(PlanetFeature.WaterFeatures),
                PlanetFeature.Random(PlanetFeature.ResourcesFeatures));
            gameState.Danger = null;
            gameState.Options = new List<Option>
                {
                    new Option("Colonize", new Action<GameState>(Colonize)),
                    new Option("Launch surface probe", new Action<GameState>(_ => { })),
                    new Option("Move on", new Action<GameState>(IntoDanger)),
                };
        }

        private static void IntoDanger(GameState gameState)
        {
            var dangerFactory = Danger.Random;
            var danger = dangerFactory();
            gameState.Danger = danger;
            gameState.Planet = null;
            gameState.Options = danger.Options;
            gameState.StoryText = danger.Story;
        }

        private static void Colonize(GameState gameState)
        {
            gameState.StoryText = "This is humanity's new home!";
            gameState.Colonized = true;
            gameState.Options = new List<Option>
                {
                    new Option("Play again", new Action<GameState>(Reset)),
                };
        }

        private static void Reset(GameState gameState)
        {
            gameState.AtmosphereScanner = 100;
            gameState.GravityScanner = 100;
            gameState.TemperatureScanner = 100;
            gameState.WaterScanner = 100;
            gameState.ResourcesScanner = 100;
            gameState.Colonists = 1000;
            gameState.Probes = 10;
            gameState.LandingSystem = 100;
            gameState.ConstructionSystem = 100;
            gameState.ScientificDatabase = 100;
            gameState.CulturalDatabase = 100;
            gameState.Planet = null;
            gameState.Danger = null;
            gameState.Colonized = false;
            gameState.StoryText = "Any damage or malfunctions during the journey should have woken the AI from its hibernation, but it is still anxious as it runs its self-diagnostic programs. The sleep chambers are all functioning, the colonists within them alive, or at least capable of being revived from their frozen stasis. Sensors functioning; surface probes responding. Landing and construction systems ready for the one time they will be used. Scientific and cultural databases intact, safely storing all that remains of humanity's knowledge and art.";
            gameState.Options = new List<Option>
                {
                    new Option("Scan planet", new Action<GameState>(GeneratePlanet)),
                };
        }
    }
}
