using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Infrastructure
{
    public abstract class DomainEvent
    {

        public DomainEvent() { }

        public DomainEvent(string aggregateId)
        {
            ReportId = aggregateId;
            //Id = 3;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Report")]
        public string ReportId { get; private set; }
    }
}
