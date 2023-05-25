﻿using System;
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
                new Job(3.ToString(),"Hardware installation", new DateOnly(2013, 05, 30), 4500)
            };
        }

        public List<Contractor> GetContractors()
        {
            return Contractors;
        }

        public List<Contractor> GetAvailableContractors(List<Contractor> contractors)
        {
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

        public void AddJob(Job job)
        {
            //TODO: implement same as add contractor
            Jobs.Add(job);
        }

        public void AssignJob(Contractor contractor, Job job)
        {
            //TODO: handle null exceptions
            job.ContractorAssigned = contractor;
            contractor.IsAssigned = true;
        }


        public List<Job> GetJobs()
        {
            return Jobs;
        }

        public List<Job> GetUnassignedJobs(List<Job> jobs)
        {
            return jobs;
        }

        public void CompleteJob(Job job)
        {
            job.IsComplete = true;
        }

        public List<Job> GetJobsByCost(List<Job> jobs, int minCost, int maxCost)
        {
            return jobs;
        }
    }   
}
