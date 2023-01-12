using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Statistics
{
    public class TableEntry
    {
        public string EventName { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Total { get; set; }

        public TableEntry(string row) 
        {
            string[] data=row.Split(' ');
            EventName= data[0];
            Min= int.Parse(data[1]);
            Max= int.Parse(data[2]);
            Total= int.Parse(data[3]);
        }

        
    }
}
