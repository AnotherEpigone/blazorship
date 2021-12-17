namespace BlazorShip.Data
{
    public class Option
    {
        public Option(string name, Action<GameState> action)
        {
            Name = name;
            Action = action;
        }

        public string Name { get; init; }

        public Action<GameState> Action { get; init; }
    }
}
