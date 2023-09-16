using System.Collections.Generic;
using System;
namespace EventArch.Code
{
    public static class EventManager
    {
        private static Dictionary<Type, EventBase> eventsDictionary = new();
        private static Events events;

        public static void InitializeEvents()
        {
            events = new Events();
        }
        public static T GetEvent<T> () where T : EventBase, new()
        {
            var type = typeof(T);
            if (eventsDictionary.TryGetValue(type, out EventBase gameEvent))
            {
                return (T)gameEvent;
            }

            return null;
        }
        public static void AddListener<T>(Action<T> action)
        {
            var type = typeof(T);
            if (eventsDictionary.TryGetValue(type, out EventBase gameEvent))
            {
                if (gameEvent is GameEventBase<T> gameEventBase)
                {
                    gameEventBase.AddListener(action);
                }
            }
        }
    }
}