using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ict40120RecruitmentSystemAssessment
{
    public class Job
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly CompletionDate { get; private set; }
        public bool IsAssigned { get; set; }
        public bool IsComplete { get; set; }

        public Job(string id, string name, DateOnly completionDate) 
        {
            Id = id;
            Name = name;
            CompletionDate = completionDate;
            IsAssigned = false;
            IsComplete = false;
        }
    }
}
