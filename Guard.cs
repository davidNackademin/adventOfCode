using System.Collections.Generic;

namespace advent4
{
    internal class Guard
    {
        public int id;
        public List<Nap> naps = new List<Nap>();
        public int sleepTime;
        public int[] napMinutes = new int[60];

        public Guard(int id)
        {
            this.id = id;
            sleepTime = 0;
        }

        public override string ToString()
        {
            return "#" + id + " : " + sleepTime;
        }
    }
}