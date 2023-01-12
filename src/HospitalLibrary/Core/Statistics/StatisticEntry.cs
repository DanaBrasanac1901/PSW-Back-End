using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Statistics
{
    public class StatisticEntry
    {
        public int DataPoint { get; set; }
        public int Occurences { get; set; }

        public StatisticEntry() { }

        public StatisticEntry(int dp, int occurences) 
        {
            DataPoint = dp;
            Occurences = occurences;
        }
    }
}
