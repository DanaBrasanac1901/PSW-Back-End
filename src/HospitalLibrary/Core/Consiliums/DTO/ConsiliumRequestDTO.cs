using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class ConsiliumRequestDTO
    {
        public DateTime Start {
            get {
                //string[] startStrSplit = StartStr.Split(' ');
                string[] dateStrSplit = StartStr.Split('/');

                int day = Int32.Parse(dateStrSplit[0]);
                int month = Int32.Parse(dateStrSplit[1]);
                int year = Int32.Parse(dateStrSplit[2]);

                //string[] timeStrSplit = startStrSplit[1].Split(':');
                //int hours = Int32.Parse(timeStrSplit[0]);
                //int minutes = Int32.Parse(timeStrSplit[1]);

                return new DateTime(year, month, day, 0, 0, 0);
            }
        }
        public DateTime End {
            get
            {
                //string[] startStrSplit = EndStr.Split(' ');
                string[] dateStrSplit = EndStr.Split('/');

                int day = Int32.Parse(dateStrSplit[0]);
                int month = Int32.Parse(dateStrSplit[1]);
                int year = Int32.Parse(dateStrSplit[2]);

                //string[] timeStrSplit = startStrSplit[1].Split(':');
                //int hours = Int32.Parse(timeStrSplit[0]);
                //int minutes = Int32.Parse(timeStrSplit[1]);

                return new DateTime(year, month, day, 0, 0, 0);
            }
        }

        public string Topic { get; set; }
        public string StartStr { get; set; }
        public string EndStr { get; set; }
        public int Duration { get; set; }
        public string DoctorIds { get; set; }
        public string Specialties { get; set; }


        public ConsiliumRequestDTO() { }
        public ConsiliumRequestDTO(string topic, string start, string end, int duration=0, string doctorIds="", string specialties="")
        {
            Topic = topic;
            StartStr = start;
            EndStr = end;
            Duration = duration;
            DoctorIds = doctorIds;
            Specialties = specialties;
        }

        public Consilium ConvertToConsilium()
        {
            return new Consilium(0, Topic, Duration, Start, DoctorIds, Specialties, "DOC1");
        }

    }
}
