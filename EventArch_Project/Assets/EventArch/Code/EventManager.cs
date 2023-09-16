using System;
using System.Collections.Generic;

namespace EventArch
{
    public class GameEvent
    {
    }

    public static class EventManager
    {
        private static readonly Dictionary<Type, Action<GameEvent>> eventTypeToListener = new();
        private static readonly Dictionary<Delegate, Action<GameEvent>> listenerToAction = new();

        public static void AddListener<T>(Action<T> listener) where T : GameEvent
        {
            if (!listenerToAction.ContainsKey(listener))
            {
                Action<GameEvent> action = (e) => listener((T)e);
                listenerToAction[listener] = action;

                if (eventTypeToListener.TryGetValue(typeof(T), out Action<GameEvent> existingAction))
                {
                    eventTypeToListener[typeof(T)] += action;
                }
                else
                {
                    eventTypeToListener[typeof(T)] = action;
                }
            }
        }

        public static void RemoveListener<T>(Action<T> listener) where T : GameEvent
        {
            if (listenerToAction.TryGetValue(listener, out var action))
            {
                if (eventTypeToListener.TryGetValue(typeof(T), out var existingAction))
                {
                    existingAction -= action;
                    if (existingAction == null)
                    {
                        eventTypeToListener.Remove(typeof(T));
                    }
                    else
                    {
                        eventTypeToListener[typeof(T)] = existingAction;
                    }
                }

                listenerToAction.Remove(listener);
            }
        }

        public static void Broadcast(GameEvent gameEvent)
        {
            if (eventTypeToListener.TryGetValue(gameEvent.GetType(), out var action))
            {
                action.Invoke(gameEvent);
            }
        }

        public static void Clear()
        {
            eventTypeToListener.Clear();
            listenerToAction.Clear();
        }
    }
}