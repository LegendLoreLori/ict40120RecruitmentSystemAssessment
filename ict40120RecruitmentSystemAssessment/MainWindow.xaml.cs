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

        void RefreshList() 
        {
            ContractorsList.ItemsSource = recruitmentSystem.GetContractors()
                .Select(Contractor => $"{Contractor.Id}: {Contractor.FirstName} {Contractor.LastName}  Wage: ${Contractor.HourlyWage}/hr")
                .ToString();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void ContractorsButton_Click(object sender, RoutedEventArgs e)
        {
            recruitmentSystem.AddContractor(idText.Text, firstNameText.Text, LastNameText.Text, WageText.Text);
            RefreshList();
        }
    }
}
