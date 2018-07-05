using System;
using System.Collections.Generic;
namespace GameEngine
{
    static class EventPublisher
    {
        private static Dictionary<string, EventSubcriber> subcribers = new Dictionary<string, EventSubcriber>

        subcribers.Add("input", new EventSubcriber());
        subcribers.Add("update", new EventSubcriber());
        subcribers.Add("render", new EventSubcriber());

        public static void Publish(string name)
        {
        }
    }

    class EventSubcriber
    {
        public string Name { get; }

        public EventSubcriber(string name)
        {
            Name = name;
        }


    }
}
