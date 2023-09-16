# EventArch Guide

## Purpose and Objective

This EventManager system provides a framework for managing and communicating events. It can be used independently of
Unity and supports type safety. Its primary purpose is to facilitate event communication and processing.

## Advantages

**Simplicity:** The system employs a minimalistic structure to provide essential functionality, reducing complexity.
This speeds up your development process.

**Independence from Unity:** EventManager can be used without relying on Unity, making your code more portable and
increasing its usability across different platforms or game engines.

**Type Safety:** It ensures type safety by using generic structures, minimizing errors and helping you write more secure
code.

## How to Use It

**Defining Events**
First, you need to define the events you want to use. For example:

``` csharp 
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
```

**Adding Event Listeners**
If an object needs to listen to events, you can add listeners using AddListener. For example:

``` csharp 
private void OnEnable()
{
    EventManager.AddListener<OnStartGame>(OnStartGame);
    EventManager.AddListener<OnStartGame>(StartGame2);
    EventManager.AddListener<OnFinishGame>(OnFinishGame);
}
```

**Broadcasting Events**
To trigger an event, you can use Broadcast. For example:

``` csharp 
if (Input.GetKeyDown(KeyCode.Space))
{
    EventManager.Broadcast(Events.onStartGame);
}

if (Input.GetKeyDown(KeyCode.Escape))
{
    Events.onFinishGame.WinState = true;
    EventManager.Broadcast(Events.onFinishGame);
}

```

**Removing Event Listeners**
You can remove a listener using RemoveListener. For example:

``` csharp 
if (Input.GetKeyDown(KeyCode.R))
{
    EventManager.RemoveListener<OnStartGame>(StartGame2);
}
```

## Example Usage

Below is an example EventController class that listens to and processes events using the guidelines mentioned above:

``` csharp 
private void OnStartGame(OnStartGame obj)
{
    Debug.Log("Game started");
}
private void StartGame2(OnStartGame obj)
{
    Debug.Log("Game started 2");
}
private void OnFinishGame(OnFinishGame obj)
{
    SceneManager.LoadScene(0);
    Debug.Log("Game finished " + obj.WinState);
}
```
