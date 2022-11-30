﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetAll();
        Report GetById(string id);
        void Create(Report report);
        void Update(Report report);
        void Delete(Report report);
    }
}