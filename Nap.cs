namespace advent4
{
    public class Nap
    {
        public Time startTime;
        public Time endTime;

        public override string ToString()
        {
            return startTime + " : " + endTime;
        }
    }

}