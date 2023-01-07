using HospitalLibrary.Core.ApptSchedulingSession;
using HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses;
using HospitalLibrary.Core.ApptSchedulingSession.Events;
using HospitalLibrary.Core.ApptSchedulingSession.Storage;
using HospitalLibrary.Core.ApptSchedulingSession.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Statistics
{
    public class SchedulingStatisticsService : ISchedulingStatisticsService
    {
        // statisticsList[0] = number of steps and their occurences
        // statisticsList[1] = time spent on each step (in seconds) and their occurences
        // statisticsList[2] = how many times next was clicked in one session and occurences
        // statisticsList[3] = how many times schedule was clicked in one session and occurences
        // statisticsList[4] = how many times back was clicked in one session and occurences
        private List<List<StatisticEntry>> statisticsList;
        private IScheduleAppointment _aggregateService;

        public SchedulingStatisticsService(IScheduleAppointment aggregateService)
        {
            _aggregateService = aggregateService;
        }


        public List<List<StatisticEntry>> GetStatistics()
        {
            List<ScheduleAggregate> aggregates = _aggregateService.GetAggregates();


            IDictionary<Guid, int> stepsInAggregates = new Dictionary<Guid, int>();
            IDictionary<Guid, int> secondsSpentInAggregates = new Dictionary<Guid, int>();
            IDictionary<Guid, int> nextOccurencesInAggregates = new Dictionary<Guid, int>();
            IDictionary<Guid, int> backOccurencesInAggregates = new Dictionary<Guid, int>();
            IDictionary<Guid, int> scheduleOccurencesInAggregates = new Dictionary<Guid, int>();

            // initialize necessary aggregate data for statistics
            foreach (ScheduleAggregate aggregate in aggregates)
            {
                //we only calculate into statistics sessions that have ended or weren't cancelled midway
                if (!aggregate.Changes.OfType<SchedulingEnded>().Any()) continue;

                // calculate num of steps in aggregate
                if (!stepsInAggregates.Keys.Contains(aggregate.Id)) stepsInAggregates.Add(aggregate.Id, aggregate.Changes.Count);
                // calculate lifespan of aggregate
                if (!secondsSpentInAggregates.Keys.Contains(aggregate.Id))
                {
                    secondsSpentInAggregates.Add(aggregate.Id, getAggregateLifespan(aggregate)); // could TECHNICALLY throw error but highly unlikely that the patient is going to spend more than 2.147.483.647 seconds scheduling 
                }

                // init steps for aggregate
                nextOccurencesInAggregates.Add(aggregate.Id, 0);
                backOccurencesInAggregates.Add(aggregate.Id, 0);
                scheduleOccurencesInAggregates.Add(aggregate.Id, 0);

                // increment the list that corresponds to type of action
                foreach (DomainEvent _event in aggregate.Changes)
                {
                    if (_event is NextButtonPressed) nextOccurencesInAggregates = updateOccurencesInDictionary(nextOccurencesInAggregates, aggregate.Id);
                    else if (_event is ScheduleButtonPressed) scheduleOccurencesInAggregates = updateOccurencesInDictionary(scheduleOccurencesInAggregates, aggregate.Id);
                    else if (_event is BackButtonPressed) backOccurencesInAggregates = updateOccurencesInDictionary(backOccurencesInAggregates, aggregate.Id);
                    else throw new NotImplementedException();

                }
            }

            // do actual statistics on our data
            IDictionary<int, int> stepStatistics = groupData(stepsInAggregates);
            IDictionary<int, int> timeSpentStatistics = groupData(secondsSpentInAggregates);
            IDictionary<int, int> nextClickStatistics = groupData(nextOccurencesInAggregates);
            IDictionary<int, int> scheduleClickStatistics = groupData(scheduleOccurencesInAggregates);
            IDictionary<int, int> backClickStatistics = groupData(backOccurencesInAggregates);


            // Dictionary<int,int> ----> List<StatisticEntry> so it can be ready for front
            statisticsList = new List<List<StatisticEntry>>() {
                ConvertToStatisticEntries(stepStatistics), ConvertToStatisticEntries(timeSpentStatistics), ConvertToStatisticEntries(nextClickStatistics),ConvertToStatisticEntries(scheduleClickStatistics), ConvertToStatisticEntries(backClickStatistics) };


            return statisticsList;

        }

        // get current occurence count and increment it by one, then update dictionary
        //used for individual step count
        private IDictionary<Guid, int> updateOccurencesInDictionary(IDictionary<Guid, int> dictionary, Guid key)
        {
            int occurenceCount;
            dictionary.TryGetValue(key, out occurenceCount);
            occurenceCount++;

            dictionary[key] = occurenceCount;

            return dictionary;
        }

        // same but used by group data
        private IDictionary<int, int> updateOccurencesInDictionary(IDictionary<int, int> dictionary, int key)
        {
            int occurenceCount;
            dictionary.TryGetValue(key, out occurenceCount);
            occurenceCount++;

            dictionary[key] = occurenceCount;

            return dictionary;
        }

        // count the number of occurences for each data point
        // example:
        //      dataPoint = numOfSteps
        //      occurences = 0
        // User 1, User 2 and User 3 clicked on buttons 4 times in a session so:
        //      dataPoint = 4
        //      occurences = 3
        private IDictionary<int, int> groupData(IDictionary<Guid, int> data)
        {
            IDictionary<int, int> statistics = new Dictionary<int, int>();
            if (data == null) return statistics;
            foreach (KeyValuePair<Guid, int> dataPoint in data)
            {
                int dataValue = dataPoint.Value;
                if (statistics.ContainsKey(dataValue))  // if entry with same key exists, increment occurence
                    statistics = updateOccurencesInDictionary(statistics, dataValue);

                else statistics.Add(dataValue, 1); // if not, this is the first time it appears so add it
            }

            return statistics;
        }

        // Used for easier shipping to front
        private List<StatisticEntry> ConvertToStatisticEntries(IDictionary<int, int> statisticsDictionary)
        {
            List<StatisticEntry> results = new List<StatisticEntry>();
            foreach (KeyValuePair<int, int> entry in statisticsDictionary)
            {
                results.Add(new StatisticEntry { DataPoint = entry.Key, Occurences = entry.Value });
            }

            return results;
        }

        private int getAggregateLifespan(ScheduleAggregate aggregate)
        {
            SchedulingStarted startEvent = (SchedulingStarted)aggregate.Changes.FirstOrDefault(i => i is SchedulingStarted);
            SchedulingEnded endEvent = (SchedulingEnded)aggregate.Changes.FirstOrDefault(i => i is SchedulingEnded);

            TimeSpan timeSpent = endEvent.TimeStamp - startEvent.TimeStamp;

            return (int)timeSpent.TotalSeconds;
        }
    }
}
    
