using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IntegrationLibrary.Report
{
    public class SendingReportService : ISendingReportService
    {
        public IHttpActionResult SendReport(IronPdf pdf, Guid id)
        {
           throw new NotImplementedException();
        }
    }
}
