namespace BlazorShip.Data
{
    public class Planet
    {
        public Planet(
            PlanetFeature atmosphere,
            PlanetFeature gravity,
            PlanetFeature temperature,
            PlanetFeature water,
            PlanetFeature resources)
        {
            Atmosphere = atmosphere;
            Gravity = gravity;
            Temperature = temperature;
            Water = water;
            Resources = resources;
        }

        public PlanetFeature Atmosphere { get; }
        public PlanetFeature Gravity { get; }
        public PlanetFeature Temperature { get; }
        public PlanetFeature Water { get; }
        public PlanetFeature Resources { get; }
    }
}
