using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ict40120RecruitmentSystemAssessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly RecruitmentSystem recruitmentSystem = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        void RefreshContractors() 
        {
            ContractorsList.ItemsSource = null;
            ContractorsList.ItemsSource = recruitmentSystem.GetContractors();
        }

        void RefreshJobs()
        {
            JobsList.ItemsSource = null;
            JobsList.ItemsSource = recruitmentSystem.GetJobs();
        }

        void RefreshInProgress()
        {
            JobsInProgressList.ItemsSource = null;
            JobsInProgressList.ItemsSource = recruitmentSystem.GetAssignedJobs();
        }

        //Create a new contractor from input and automatically add it to the recruitmentSystem
        private void AddContractorButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdContractorText.Text == "" || FirstNameText.Text == "" || LastNameText.Text == "" || WageText.Text == "") return;
            if (!int.TryParse(WageText.Text, out var x)) return;
            recruitmentSystem.AddContractor(IdContractorText.Text, FirstNameText.Text, LastNameText.Text, WageText.Text);
            RefreshContractors();
        }

        //remove entry from contractor list
        private void RemoveContractorButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: handle null exception
            recruitmentSystem.RemoveContractor((Contractor)ContractorsList.SelectedItem);
            RefreshContractors();
        }

        private void AssignContractorJobButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: handle null exception
            //TODO: select implement alternative way to select contractors/jobs
            recruitmentSystem.AssignJob((Contractor)ContractorsList.SelectedItem, (Job)JobsList.SelectedItem);
            RefreshContractors();
            RefreshJobs();
            RefreshInProgress();
        }

        //create a new job from input and automatically add it to the recruitmentsystem
        private void AddJobButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdJobText.Text == "" || NameJobText.Text == "" || DateJobText.Text == "" || CostJobText.Text == "") return;
            if (!DateTime.TryParse(DateJobText.Text, out var x))
            {
                MessageBox.Show("Please enter a date in the following format: DD/MM/YYYY");
                return;
            }
            recruitmentSystem.AddJob(IdJobText.Text, NameJobText.Text, DateJobText.Text, CostJobText.Text);
            RefreshJobs();
            RefreshInProgress();
        }

        //Update job's completion status and return contractor to available pool
        private void CompleteJobButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: handle null exception
            recruitmentSystem.CompleteJob((Job)JobsInProgressList.SelectedItem);
            RefreshJobs();
            RefreshInProgress();
            RefreshContractors();
        }

        //populates job box with all jobs
        private void AllJobsButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshJobs();
        }

        //populates job box with only jobs whose cost is within a specified range
        private void FilterJobsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(MinCostText.Text, out var x)) return;
            if (!int.TryParse(MaxCostText.Text, out var y)) return;
            if (int.Parse(MinCostText.Text) > int.Parse(MaxCostText.Text)) return;
            if (int.Parse(MaxCostText.Text) < int.Parse(MinCostText.Text)) return;

            JobsList.ItemsSource = null;
            JobsList.ItemsSource = recruitmentSystem.GetJobsWithinRange(int.Parse(MinCostText.Text),int.Parse(MaxCostText.Text));
        }

        //list contractors that arent assigned to a job
        private void AvailableContractorsButton_Click(object sender, RoutedEventArgs e)
        {
            ContractorsList.ItemsSource = null;
            ContractorsList.ItemsSource = recruitmentSystem.GetAvailableContractors();
        }

        //list all contractors
        private void AllContractorsButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshContractors();
        }

        //populate list on startup
        private void ContractorsList_Initialized(object sender, EventArgs e)
        {
            RefreshContractors();
        }

        //populate list on startup
        private void JobsList_Initialized(object sender, EventArgs e)
        {
            RefreshJobs();
        }

        //populate list on startup
        private void JobsInProgressList_Initialized(object sender, EventArgs e)
        {
            RefreshInProgress();
        }
    }
}
