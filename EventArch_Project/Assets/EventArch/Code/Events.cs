namespace EventArch
{
    public static class Events
    {
       public static OnStartGame onStartGame = new OnStartGame();
       public static OnFinishGame onFinishGame = new OnFinishGame();
    }
    public class OnStartGame : GameEvent { }

    public class OnFinishGame : GameEvent
    {
        public bool WinState { get; set; }
    }
}
