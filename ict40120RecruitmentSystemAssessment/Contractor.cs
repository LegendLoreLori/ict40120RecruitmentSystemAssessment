using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ict40120RecruitmentSystemAssessment
{
    public class Contractor
    {
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsAssigned { get; set; }
        public int HourlyWage { get; private set; }

        public Contractor(string id, string firstName, string lastName, int hourlyWage)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            IsAssigned = false;
            HourlyWage = hourlyWage;
        }
    }
}
