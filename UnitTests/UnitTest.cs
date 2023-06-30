using ict40120RecruitmentSystemAssessment;
using System.Windows.Documents;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        RecruitmentSystem testRecruitmentSystem;
        Contractor ?testContractor;

        [TestInitialize]
        public void Initialize() 
        {
            testRecruitmentSystem = new RecruitmentSystem();
        }

        [TestMethod]
        [DataRow("1", "Board Repair", "2023-12-16", 1000)]
        [DataRow("2", "'Mowing'", "1500-01-01", 100000)]
        [DataRow("3", ";21 pilots concert (bad)", "0333-09-01", 0)]
        [DataRow("4", "1", "3000-12-12", -20)]


        public void JobInitialisesWithValidParameters(string id, string name, string dateString, int cost)
        {
            //arrange
            DateOnly date = DateOnly.Parse(dateString);

            //act
            Job job = new(id, name, date, cost);

            //assert
            Assert.AreEqual(id, job.Id);
            Assert.AreEqual(name, job.Name);
            Assert.AreEqual(date, job.CompletionDate);
            if (cost < 0)
            {
                Assert.IsTrue(job.Cost > 0);
            }
            else
            {
                Assert.AreEqual(cost, job.Cost);
            }
            Assert.IsFalse(job.IsComplete);
        }

        [TestMethod]
        [DataRow("1", "Jane", "Dane", 34)]
        [DataRow("2", "99", "Dane", -25)]
        [DataRow("3", ";%^$@%^", "'e'", 10000)]
        public void ContractorInitiliasesWithValidParameters(string id, string firstName, string lastName, int hourlyWage)
        {
            //act
            Contractor contractor = new(id, firstName, lastName, hourlyWage);

            //assert
            Assert.AreEqual(id, contractor.Id);
            Assert.AreEqual(firstName, contractor.FirstName);
            Assert.AreEqual(lastName, contractor.LastName);
            Assert.IsFalse(contractor.IsAssigned);
            if (hourlyWage < 0)
            {
                Assert.IsTrue(contractor.HourlyWage > 0);
            }
            else
            {
                Assert.AreEqual(hourlyWage, contractor.HourlyWage);
            }
        }

        [TestMethod]
        public void RecruitmentSystemCorrectlyRemovesContractor()
        {
            //arrange
            Contractor testContractor = new("1", "Jim", "Bridges", 50);
            testRecruitmentSystem.Contractors.Add(testContractor);

            //act
            testRecruitmentSystem.RemoveContractor(testContractor);

            //assert
            Assert.IsFalse(testRecruitmentSystem.Contractors.Contains(testContractor));
        }
        
        [TestMethod]
        public void GetJobsReturnsCorrectJobs()
        {
            //arange
            var jobs = new List<Job>
            {
                new Job("1", "job1", new DateOnly(2000, 1, 1), 500),
                new Job("2", "job2", new DateOnly(2000, 1, 1), 500),
                new Job("3", "job3", new DateOnly(2000, 1, 1), 500),
                new Job("4", "job4", new DateOnly(2000, 1, 1), 500),
            };

            //act
            jobs[2].ContractorAssigned = new Contractor("1", "Jim", "Bridges", 50);
            testRecruitmentSystem.Jobs = jobs;

            //assert
            Assert.IsTrue(testRecruitmentSystem.GetAssignedJobs().Contains(jobs[2]));
            Assert.IsFalse(testRecruitmentSystem.GetJobs().Contains(jobs[2]));

            Assert.IsTrue(testRecruitmentSystem.Jobs.Contains(jobs[0]));
            Assert.IsTrue(testRecruitmentSystem.Jobs.Contains(jobs[1]));
            Assert.IsTrue(testRecruitmentSystem.Jobs.Contains(jobs[3]));
            Assert.IsFalse(testRecruitmentSystem.GetAssignedJobs().Contains(jobs[0]));
            Assert.IsFalse(testRecruitmentSystem.GetAssignedJobs().Contains(jobs[1]));
            Assert.IsFalse(testRecruitmentSystem.GetAssignedJobs().Contains(jobs[3]));
        }

        [TestMethod]
        public void CompleteJobCorrectlyUpdatesValues()
        {
            //arange
            Job job1 = new("1", "job1", new DateOnly(2000, 1, 1), 500);
            Job job2 = new("2", "job2", new DateOnly(2000, 1, 1), 500);
            Contractor contractor1 = new("1", "Bob", "Ross", 50);

            //act
            job1.ContractorAssigned = contractor1;
            contractor1.IsAssigned = true;

            testRecruitmentSystem.CompleteJob(job1);
            testRecruitmentSystem.CompleteJob(job2);

            //assert
            Assert.IsNull(job1.ContractorAssigned);
            Assert.IsTrue(job1.IsComplete);
            Assert.IsFalse(contractor1.IsAssigned);
            Assert.IsNull(job2.ContractorAssigned);
            Assert.IsFalse(job2.IsComplete);
        }

    }
}