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
    /// Interaction logic for SearchWindowResults.xaml
    /// </summary>
    public partial class SearchWindowResults : Window
    {
        private RecordWindow recordWindow;
        private SearchResults searchResults;
        private SearchTerm searchTerm;
        public SearchWindowResults(List<SearchResult> results, SearchTerm searchTerm)
        {
            this.searchTerm = searchTerm;
            InitializeComponent();
            uxSearchResults.ItemsSource = results;
            ValidColumn.Width = 40;
            CanNumColumn.Width = 50;
            CodeColumn.Width = 110;
            CollDateColumn.Width = 90;
            UnitsColumn.Width = 40;
            AnimalNameColumn.Width = 225;
            BreedColumn.Width = 80;
            RegNumColumn.Width = 80;
            OwnerColumn.Width = 100;
            TownColumn.Width = 100;
            StateColumn.Width = 42;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            SearchResult search= (SearchResult)row.Item;
            recordWindow = new RecordWindow(search);
            recordWindow.ShowDialog();
        }

        private void UxRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            searchResults = new SearchResults();
            List<SearchResult> results = searchResults.retrieveData(searchTerm);
            InitializeComponent();
            uxSearchResults.ItemsSource = results;
            ValidColumn.Width = 40;
            CanNumColumn.Width = 50;
            CodeColumn.Width = 110;
            CollDateColumn.Width = 90;
            UnitsColumn.Width = 40;
            AnimalNameColumn.Width = 225;
            BreedColumn.Width = 80;
            RegNumColumn.Width = 80;
            OwnerColumn.Width = 100;
            TownColumn.Width = 100;
            StateColumn.Width = 42;
        }
    }
}
