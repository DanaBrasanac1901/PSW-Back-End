using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Repositories;
using HospitalLibrary.Core.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Infrastructure;
using HospitalLibrary.Core.Doctor;

namespace HospitalLibrary.Core.Report.Services
{
    public class EventSourcingStatistics : IEventSourcingStatistics
    {
        private readonly IEventRepository _eventRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IDoctorRepository _doctorRepository;

        public EventSourcingStatistics(IEventRepository eventRepository,IReportRepository reportRepository, IDoctorRepository doctorRepository)
        {
            _eventRepository = eventRepository;
            _reportRepository = reportRepository;
            _doctorRepository = doctorRepository;   


        }

        public List<ReportCreationDurationDTO> GetReportCreationDurations()
        {
            List<TimeSpan> durations = (List<TimeSpan>)_eventRepository.GetDurations();
            List<string> reportIds = (List<string>)_eventRepository.GetReportIds();

            List<ReportCreationDurationDTO> idDurationPairs = new List<ReportCreationDurationDTO>();


            for(int i=0; i<reportIds.Count; i++)
            {
                idDurationPairs.Add(new ReportCreationDurationDTO(reportIds[i], durations[i]));
            }

            return idDurationPairs;
        }

        public int GetNumOfSteps(string reportId)
        {
            int numOfSteps = 0;
            
            Model.Report report = _reportRepository.GetById(reportId);
         
            numOfSteps = report.Version;
                
            
            return numOfSteps;
        }

        public double GetAvgNumOfSteps()
        {
            double avgNumOfSteps = 0.0;
            double numOfSteps = 0.0;
            double numOfReports = 0.0;
            IEnumerable<Model.Report> reports =_reportRepository.GetAll();
            foreach( Model.Report report in reports)
            {
                numOfSteps += report.Version;
                numOfReports++;
            }
            avgNumOfSteps=numOfSteps/numOfReports;
            return avgNumOfSteps;
            
        }

        public NumOfTimeOnEachStepDTO NumOfTimeOnEachStep(string reportId)
        {
            NumOfTimeOnEachStepDTO numOfStep = new NumOfTimeOnEachStepDTO();
            int step0 = 0;
            int step1 = 0;
            int step2 = 0;
            int step3 = 0;
            int step4 = 0;



            IEnumerable<int> listOfNexts = _eventRepository.GetAllStepsForNext(reportId);
            IEnumerable<int> listOfBacks = _eventRepository.GetAllStepsForBack(reportId);

            foreach(var next in listOfNexts)
            {
                if(next == 0)
                {
                    step0++;
                    step1++;
                }
                else if(next == 1)
                {
                    step2++;
                }
                else if (next == 2)
                {
                    step3++;
                }
                else if (next == 3)
                {
                    step4++;
                }


            }
            foreach (var back in listOfBacks)
            {
                if (back == 1)
                {
                    step0++;
                    
                }
                else if (back == 2)
                {
                    step1++;
                }
                else if (back == 3)
                {
                    step2++;
                }
                else if (back == 4)
                {
                    step3++;
                }

            }
            numOfStep.reportId = reportId;
            numOfStep.step0=step0;
            numOfStep.step1=step1;
            numOfStep.step2 = step2;
            numOfStep.step3 = step3;
            numOfStep.step4 = step4;



            return numOfStep;
        }

        public List<NumOfTimeOnEachStepDTO> ListNumOfTimeOnEachStep()
        {
            List<string> reportIds = (List<string>)_eventRepository.GetReportIds();



            List<NumOfTimeOnEachStepDTO> list = new List<NumOfTimeOnEachStepDTO>();


            for (int i = 0; i < reportIds.Count; i++)
            {
                NumOfTimeOnEachStepDTO numOfStep = new NumOfTimeOnEachStepDTO();
                int step0 = 0;
                int step1 = 0;
                int step2 = 0;
                int step3 = 0;
                int step4 = 0;



                IEnumerable<int> listOfNexts = _eventRepository.GetAllStepsForNext(reportIds[i]);
                IEnumerable<int> listOfBacks = _eventRepository.GetAllStepsForBack(reportIds[i]);

                foreach (var next in listOfNexts)
                {
                    if (next == 0)
                    {
                        step0++;
                        step1++;
                    }
                    else if (next == 1)
                    {
                        step2++;
                    }
                    else if (next == 2)
                    {
                        step3++;
                    }
                    else if (next == 3)
                    {
                        step4++;
                    }


                }
                foreach (var back in listOfBacks)
                {
                    if (back == 1)
                    {
                        step0++;

                    }
                    else if (back == 2)
                    {
                        step1++;
                    }
                    else if (back == 3)
                    {
                        step2++;
                    }
                    else if (back == 4)
                    {
                        step3++;
                    }

                }
                //numOfStep.reportId = reportId;
                //numOfStep.step0 = step0;
                //numOfStep.step1 = step1;
                //numOfStep.step2 = step2;
                //numOfStep.step3 = step3;
                //numOfStep.step4 = step4;
                list.Add(new NumOfTimeOnEachStepDTO(reportIds[i], step0, step1, step2, step3, step4));
            }

            return list;
        }
        public int GetDoctorAge(string reportId)
        {
            string doctorId=_reportRepository.GetDoctorIdByReportId(reportId);
            Doctor.Doctor doctor = _doctorRepository.GetById(doctorId);
            int age = doctor.Age;
            return age;
        }

        public List<DurationAndNumOfStepsInCorellationWithDoctorAgeDTO> GetDurationAndNumOfStepsInCorellationWithDoctorAge()
        {
            List<TimeSpan> durations = (List<TimeSpan>)_eventRepository.GetDurations();
            List<string> reportIds = (List<string>)_eventRepository.GetReportIds();



            List<DurationAndNumOfStepsInCorellationWithDoctorAgeDTO> correlations = new List<DurationAndNumOfStepsInCorellationWithDoctorAgeDTO>();


            for (int i = 0; i < reportIds.Count; i++)
            {
                correlations.Add(new DurationAndNumOfStepsInCorellationWithDoctorAgeDTO(reportIds[i], GetDoctorAge(reportIds[i]), GetNumOfSteps(reportIds[i]), durations[i]));
            }

            return correlations;
        } 
        
        public List<NextBackButtonProportionDTO> GetRatioOfSuccess()
        {
            List<string> reportIds = (List<string>)_eventRepository.GetReportIds();
            List<NextBackButtonProportionDTO> listOfSuccess = new List<NextBackButtonProportionDTO>();
            for (int i = 0; i < reportIds.Count; i++)
            {
                List<int> listOfNext = (List<int>)_eventRepository.GetAllStepsForNext(reportIds[i]);
                List<int> listOfBack = (List<int>)_eventRepository.GetAllStepsForBack(reportIds[i]);
                int allSteps=listOfNext.Count+listOfBack.Count;
                int numOfNextSteps = listOfNext.Count;
                double percentOfSuccess= (double)(Decimal.Divide(numOfNextSteps, allSteps) * 100);

                listOfSuccess.Add(new NextBackButtonProportionDTO(reportIds[i], listOfNext.Count, listOfBack.Count, percentOfSuccess));
            }

            return listOfSuccess;

        }
    }
}
