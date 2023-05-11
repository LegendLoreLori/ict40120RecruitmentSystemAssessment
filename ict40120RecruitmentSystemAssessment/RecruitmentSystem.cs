using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ict40120RecruitmentSystemAssessment
{
    public class RecruitmentSystem
    {
        List<Contractor> Contractors = new()   
            {
                new Contractor(1.ToString(), "Bob", "Ross", 47),
                new Contractor(2.ToString(), "Barry", "Buybax", 63),
                new Contractor(3.ToString(), "Susan", "Dolts", 53),
                new Contractor(4.ToString(), "Fred", "Durst", 43),
                new Contractor(5.ToString(), "Mariah", "Carey", 58)
            };
        List<Job> Jobs = new();

        public RecruitmentSystem()
        {
            Jobs = new List<Job>()
            {
                new Job(1.ToString(),"Carpet renovation", new DateOnly(2023, 03, 12), 12000),
                new Job(2.ToString(),"Fence repair", new DateOnly(2023, 12, 16), 5000),
                new Job(3.ToString(),"Hardware installation", new DateOnly(2013, 05, 30), 4500)
            };
        }

        public void AddContractor(string id, string firstName, string lastName, string hourlyWageInput)
        {
            int hourlyWage = int.Parse(hourlyWageInput);
            Contractor contractor = new(id, firstName, lastName, hourlyWage);
            Contractors.Add(contractor);
        }

        public void RemoveContractor(Contractor contractor)
        {
            Contractors.Remove(contractor);
        }

        public void AddJob(Job job)
        {
            Jobs.Add(job);
        }

        public void AssignJob(Contractor contractor, Job job)
        {
            job.ContractorAssigned = contractor;
            contractor.IsAssigned = true;
        }

        public void CompleteJob(Job job)
        {
            job.IsComplete = true;
        }

        public List<Contractor> GetContractors()
        {
            return Contractors;
        }
        public List<Contractor> GetAvailableContractors(List<Contractor> contractors)
        {
            return contractors;
        }

        public List<Job> GetJobs(List<Job> jobs)
        {
            return jobs;
        }

        public List<Job> GetUnassignedJobs(List<Job> jobs)
        {
            return jobs;
        }

        public List<Job> GetJobsByCost(List<Job> jobs, int minCost, int maxCost)
        {
            return jobs;
        }
    }   
}
