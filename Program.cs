using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace advent4
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Event> actionList = new List<Event>();
            List<Guard> guards = new List<Guard>();
            Guard activeGuard = null;

            var lines = File.ReadAllLines("input4.txt");
            char[] delimiter1 = new char[] { ']' };
            char[] delimiter2 = new char[] { '[', '-', ' ', ':' };

            // parse each line and add to actionlist
            foreach (var line in lines)
            {
                var splitLine = line.Split(delimiter1);
                Event ev = new Event()
                {
                    action = splitLine[1]
                };

                var timeSplit = splitLine[0].Split(delimiter2);
                ev.time = new Time(timeSplit);
                actionList.Add(ev);
             }


            //sort actionlist in timeorder
            var sortedList = actionList.OrderBy(s => s.time.year)
                .ThenBy(s => s.time.month)
                .ThenBy(s => s.time.day)
                .ThenBy(s => s.time.hour)
                .ThenBy(s => s.time.minute).ToList();


            int fallAsleepTime = 0;
            foreach (var e in sortedList)
            {
                if (e.action.Contains("#"))
                {
                    var id = Convert.ToInt32(e.action.Split(new char[] { '#', ' ' })[3]);
                    activeGuard = guards.Find(x => x.id == id);
                    if (activeGuard == null)
                    {
                        activeGuard = new Guard(id);
                        guards.Add(activeGuard);
                    }
                }
                else if (e.action.Contains("asleep"))
                {
                    fallAsleepTime = e.time.minute;
                    activeGuard.naps.Add(new Nap() { startTime = e.time });
                }
                else if (e.action.Contains("wakes"))
                {
                    activeGuard.naps.Last().endTime = e.time;
                    int sleepTime = e.time.minute - fallAsleepTime; ;
                    if (e.time.minute < fallAsleepTime)
                        sleepTime += 60;

                    activeGuard.sleepTime += sleepTime;
                }
            }

            Guard biggestSleeper = guards.OrderByDescending(i => i.sleepTime).ToList()[0];

            foreach (var g in guards)
            {
                foreach (var nap in g.naps)
                {
                    for (int i = nap.startTime.minute; i < nap.endTime.minute; i++)
                        g.napMinutes[i]++;
                }
            }

            var guardsBySleepminutes = guards.OrderBy(g => g.napMinutes.Max());


            var winner = guardsBySleepminutes.Last();

            Console.WriteLine("#" + winner.id);

            int min = Array.IndexOf(winner.napMinutes, winner.napMinutes.Max());
            Console.WriteLine("min: " + min + " count: " + winner.napMinutes.Max());

            Console.WriteLine("Answer: " + winner.id * min);

        }
    }
}
