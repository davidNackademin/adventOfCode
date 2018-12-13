using System;
namespace advent4
{
    public class Event
    {
            public Time time;
            public string action;
            public Event() { }

        public override string ToString()
        {
            return time + " : " + action;
        }
    }
}
