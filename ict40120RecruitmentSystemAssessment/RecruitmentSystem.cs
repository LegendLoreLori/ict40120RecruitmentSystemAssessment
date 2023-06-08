using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ict40120RecruitmentSystemAssessment
{
    public class RecruitmentSystem
    {
        List<Contractor> Contractors;
        List<Job> Jobs;

        public RecruitmentSystem()
        {
            Contractors = new List<Contractor>()            
            {
                new Contractor(1.ToString(), "Bob", "Ross", 47),
                new Contractor(2.ToString(), "Barry", "Buybax", 63),
                new Contractor(3.ToString(), "Susan", "Dolts", 53),
                new Contractor(4.ToString(), "Fred", "Durst", 43),
                new Contractor(5.ToString(), "Mariah", "Carey", 58)
            };
            Jobs = new List<Job>()
            {
                new Job(1.ToString(),"Carpet renovation", new DateOnly(2023, 03, 12), 12000),
                new Job(2.ToString(),"Fence repair", new DateOnly(2023, 12, 16), 5000),
                new Job(3.ToString(),"Hardware installation", new DateOnly(2033, 05, 30), 4500),
                new Job(4.ToString(),"Water Stoats", new DateOnly(2023, 08, 16), 9000 /*Contractors[4]*/)
            };
            // assigned dummy job on initialisation
            AssignJob(Contractors[2], Jobs[3]);
        }

        public List<Contractor> GetContractors()
        {
            return Contractors;
        }

        //returns list of contractors that can be assigned to a job
        public List<Contractor> GetAvailableContractors()
        {
            List<Contractor> contractors = new List<Contractor>();
            foreach (Contractor contractor in Contractors)
            {
                if (contractor.IsAssigned != true) contractors.Add(contractor);
            }
            return contractors;
        }

        //passes information in from text boxes and creates a contractor from it
        public void AddContractor(string id, string firstName, string lastName, string hourlyWageInput)
        {
            //TODO: handle null exceptions
            int hourlyWage = int.Parse(hourlyWageInput);
            Contractor contractor = new(id, firstName, lastName, hourlyWage);
            Contractors.Add(contractor);
        }

        public void RemoveContractor(Contractor contractor)
        {
            //TODO: handle null exceptions
            Contractors.Remove(contractor);
        }

        //build a list of jobs without a contractor assigned
        public List<Job> GetJobs()
        {
            List<Job> jobs = new List<Job>();
            foreach (Job job in Jobs)
            {
                if (job.ContractorAssigned == null && job.IsComplete == false) jobs.Add(job);
            }
            return jobs;
        }
        
        //build a list of jobs in progress
        public List<Job> GetAssignedJobs()
        {
            List<Job> jobs = new List<Job>();
            foreach (Job job in Jobs)
            {
                if (job.ContractorAssigned is Contractor) jobs.Add(job);
            }
            return jobs;
        }

        //construct a job object from input in ui and add it to jobs list
        public void AddJob(string id, string name, string dateInput, string costInput)
        {
            DateOnly date = DateOnly.Parse(dateInput);
            int cost = int.Parse(costInput);
            Job job = new(id, name, date, cost);
            Jobs.Add(job);
        }

        //adds a contractor object to a selected job
        public void AssignJob(Contractor contractor, Job job)
        {
            if (job.ContractorAssigned != null || contractor.IsAssigned == true) return;
            job.ContractorAssigned = contractor;
            contractor.IsAssigned = true;
        }

        public void CompleteJob(Job job/*, Contractor contractor*/)
        {
            if (job.ContractorAssigned is null) return;
            job.ContractorAssigned.IsAssigned = false;
            job.ContractorAssigned = null;
            job.IsComplete = true;
            //contractor.IsAssigned = false;
        }

        public List<Job> GetJobsWithinRange(int minCost, int maxCost)
        {
            List<Job> jobs = new List<Job>();
            foreach (Job job in Jobs)
            {
                if (job.Cost >= minCost && job.Cost <= maxCost) jobs.Add(job);
            }
            return jobs;
        }
    }   
}
