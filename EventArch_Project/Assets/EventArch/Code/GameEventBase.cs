using System;
using System.Collections.Generic;

namespace EventArch.Code
{
    public abstract class EventBase
    {
        
    }
    public abstract class GameEventBase :EventBase, IGameEvent
    {
        private readonly List<Action> actions = new List<Action>();

        public virtual void Raise()
        {
            for (int i = actions.Count - 1; i >= 0; i--)
                actions[i]();
        }

        public virtual void AddListener(Action action)
        {
            if (!actions.Contains(action))
                actions.Add(action);
        }

        public virtual void RemoveListener(Action action)
        {
            if (actions.Contains(action))
                actions.Remove(action);
        }

        public virtual void RemoveAllListeners()
        {
            actions.RemoveRange(0, actions.Count);
        }
    }
    public abstract class GameEventBase<T> : EventBase, IGameEvent<T>
    {
        private readonly List<Action<T>> typedActions = new ();

        public virtual void Raise(T value)
        {
            for (int i = typedActions.Count - 1; i >= 0; i--)
                typedActions[i](value);
        }

        public virtual void AddListener(Action<T> action)
        {
            if (!typedActions.Contains(action))
                typedActions.Add(action);
        }

        public virtual void RemoveListener(Action<T> action)
        {
            if (typedActions.Contains(action))
                typedActions.Remove(action);
        }

        public virtual void RemoveAllListeners()
        {
            typedActions.RemoveRange(0, typedActions.Count);
        }
    }
}