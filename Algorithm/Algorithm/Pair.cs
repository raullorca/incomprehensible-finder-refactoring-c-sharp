using System;

namespace Algorithm
{
    public class Pair
    {
        public Person Oldest { get; set; }
        public Person Younger { get; set; }
        public TimeSpan Difference { get; set; }
    }
}