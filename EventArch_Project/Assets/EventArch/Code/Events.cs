namespace EventArch.Code
{ 
    public class Events
    {
        public OnStartGame OnStartGame { get; } = new();
        public OnFinishGame OnFinishGame { get; } = new();  
    }

    public class OnStartGame : GameEventBase { }

    public class OnFinishGame : GameEventBase
    {
        public bool WinState { get; private set; }
    }
    public class OnTakeDamage : GameEventBase<int> { }
}
