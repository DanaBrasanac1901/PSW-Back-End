using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using IronPdf;
using Microsoft.AspNetCore.Components.RenderTree;

namespace IntegrationLibrary.Report
{
    public class SendingReportService : ISendingReportService
    {
        public IHttpActionResult SendReport(PdfAttachment pdf, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
