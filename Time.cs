using System;
namespace advent4
{
    public class Time
    {
        public int year;
        public int month;
        public int day;
        public int hour;
        public int minute;

        public Time(String [] time)
        {
            //Console.WriteLine(time[0]);
            this.year = Convert.ToInt32(time[1]);
            this.month = Convert.ToInt32(time[2]);
            this.day = Convert.ToInt32(time[3]);
            this.hour = Convert.ToInt32(time[4]);
            this.minute = Convert.ToInt32(time[5]);
        }


        public  override string ToString()
        {
            return year + " " + month + " " + day + " " + hour + " "  + minute;
        }
    }


}
