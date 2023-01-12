﻿using HospitalLibrary.Core.Report.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public interface IEventSourcingStatistics
    {
        List<ReportCreationDurationDTO> GetReportCreationDurations();

    }
}
