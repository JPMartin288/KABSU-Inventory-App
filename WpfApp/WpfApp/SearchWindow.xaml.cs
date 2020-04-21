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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public string owner = "*";
        public string breed = "*";
        public string animalName = "*";
        public string code = "*";
        public string canNum = "*";
        public string town = "*";
        public string state = "*";
        private SearchResults searchResults;
        private SearchTerm searchTerm;
        SearchWindowResults windowResults;
        public SearchWindow()
        {
            InitializeComponent();
        }
         

        // Upon clicking "Search," opens a search results window and closes this window
        private void UxSearch_Click(object sender, RoutedEventArgs e)
        {
            windowResults = new SearchWindowResults(CalculateResultList(), searchTerm);
            windowResults.ShowDialog();
            this.Close();
        }

        public void UxUnitSum_Click(object sender, RoutedEventArgs e)
        {
            List<SearchResult> results = CalculateResultList();
            int unitSum = 0;
            foreach (SearchResult sr in results)
            {
                unitSum += Convert.ToInt32(sr.Units);
            }
            MessageBox.Show("Sum of Units: " + unitSum);
        }

        public void SetTerm(string term, string contents)
        {
            switch (term)
            {
                case "Owner":
                    owner = "%" + contents + "%";
                    break;
                case "Breed":
                    breed = "%" + contents + "%";
                    break;
                case "Animal Name":
                    animalName = "%" + contents + "%";
                    break;
                case "Code":
                    code = "%" + contents + "%";
                    break;
                case "Can #":
                    canNum = "%" + contents + "%";
                    break;
                case "Town":
                    town = "%" + contents + "%";
                    break;
                case "State":
                    state = "%" + contents + "%";
                    break;
            }
        }
        private List<SearchResult> CalculateResultList()
        {
            SetTerm(uxSearchTerm1.Text, uxSearchContents1.Text);
            SetTerm(uxSearchTerm2.Text, uxSearchContents2.Text);
            SetTerm(uxSearchTerm3.Text, uxSearchContents3.Text);
            SetTerm(uxSearchTerm4.Text, uxSearchContents4.Text);

            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchResults = new SearchResults();
            List<SearchResult> results = searchResults.retrieveData(searchTerm);
            return results;
        }
    }
}
