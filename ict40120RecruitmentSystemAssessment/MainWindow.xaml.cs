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

        //TODO: change to be updated automatically
        //TODO: change to apply to things other than contractors
        void RefreshContractorList() 
        {
            ContractorsList.ItemsSource = null;
            ContractorsList.ItemsSource = recruitmentSystem.GetContractors();
        }


        //Create a new contractor from input and automatically add it to the recruitmentSystem
        private void AddContractorButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: handle exceptions and dont accept non-null inputs
            recruitmentSystem.AddContractor(idText.Text, firstNameText.Text, LastNameText.Text, WageText.Text);
            RefreshContractorList();
        }

        //fix
        private void RemoveContractorButton_Click(object sender, RoutedEventArgs e)
        {
            recruitmentSystem.RemoveContractor((Contractor)ContractorsList.SelectedItem);
            RefreshContractorList();
        }

        //populate list on startup
        private void ContractorsList_Initialized(object sender, EventArgs e)
        {
            RefreshContractorList();
        }
    }
}
