namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        RecruitmentSystem recruitmentSystem = new RecruitmentSystem();

        [TestInitialize]
        public void Initialize() 
        {
            recruitmentSystem = new RecruitmentSystem();
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
    }
}