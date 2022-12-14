using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public class ConsiliumAppointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public int ConsiliumId { get; set; }
        public virtual Consilium Consilium {get; set;}
        public virtual Doctor.Doctor Doctor { get; set; }
        public ConsiliumAppointment() { }

        public ConsiliumAppointment(int id, string doctorId, int consiliumId)
        {
            Id = id;
            DoctorId = doctorId;
            ConsiliumId = consiliumId;
        }

        public ConsiliumAppointment(string doctorId, int consiliumId)
        {
           
            DoctorId = doctorId;
            ConsiliumId = consiliumId;
        }
    }
}
