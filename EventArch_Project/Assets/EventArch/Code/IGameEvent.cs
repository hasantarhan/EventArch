using System;

namespace EventArch.Code
{
    public interface IGameEvent
    {
        void Raise();
        void AddListener(Action action);
        void RemoveListener(Action action);
        void RemoveAllListeners();
    }
    public interface IGameEvent<T>
    {
        void Raise(T value);
        void AddListener(Action<T> action);
        void RemoveListener(Action<T> action);
        void RemoveAllListeners();
    }
}