namespace BlazorShip.Data
{
    public class Danger
    {
        public Danger(
            string story,
            List<Option> options)
        {
            Story = story;
            Options = options;
        }

        public string Story { get; }

        public string StoryPart2 { get; set; }

        public List<Option> Options { get; }

        public static Func<Danger> Random
        {
            get
            {
                var rng = new Random();
                return DangerFactories[rng.Next(DangerFactories.Count)];
            }
        }

        public static List<Func<Danger>> DangerFactories => new List<Func<Danger>>
        {
            Comet,
        };

        public static Func<Danger> Comet => () =>
        {
            var target = DangerTarget.Random;
            var story = $"As the seedship enters the new system's outer cometary cloud, the collision-avoidance system detects a fast-moving comet surrounded by a cloud of smaller ice fragments. The large comet is on a collision course with the {target.Name}. The seedship could avoid it entirely, but it would then hit one of the smaller fragments, and the collision-avoidance system cannot predict which part of the ship that fragment would hit.";
            return new Danger(story, new List<Option>
            {
                new Option("Avoid the comet", gs =>
                {
                    var newTarget = DangerTarget.Random;
                    newTarget.OnHit(gs, 5);
                    gs.Danger.StoryPart2 = $"The seedship changes course, but an ice fragment tears through the {newTarget.Name}.";
                    gs.Options.Clear();
                    gs.Options.Add(new Option("Continue", GameState.GeneratePlanet));
                }),
                new Option($"Allow it to hit the {target.Name}", gs =>
                {
                    target.OnHit(gs, 10);
                    gs.Danger.StoryPart2 = $"The seedship holds its course, allowing the comet to impact as predicted against the {target.Name}.";
                    gs.Options.Clear();
                    gs.Options.Add(new Option("Continue", GameState.GeneratePlanet));
                })
            });
        };
    }
}
