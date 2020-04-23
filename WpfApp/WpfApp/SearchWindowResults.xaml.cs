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

        /// <summary>
        /// Constructor for the window, which initializes initial column width and sets the Grid
        /// item source to be a list of search results.
        /// </summary>
        /// <param name="results">A list of database search results</param>
        /// <param name="searchTerm">A collection of search terms to search with</param>
        public SearchWindowResults(List<SearchResult> results, SearchTerm searchTerm)
        {
            this.searchTerm = searchTerm;
            InitializeComponent();
            uxSearchResults.ItemsSource = results; //initializes the data grid's context to be the search results
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

        /// <summary>
        /// Event handler for double clicking a search result, which opens a record card containing further
        /// information on the sample.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            SearchResult search= (SearchResult)row.Item; //casts the row data back to a search result object
            recordWindow = new RecordWindow(search);
            recordWindow.ShowDialog();
        }

        /// <summary>
        /// Event handler for the Refresh button. Re-initializes the current window with refreshed search results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            searchResults = new SearchResults();
            List<SearchResult> results = searchResults.retrieveData(searchTerm); //initializes the data grid's context to be the search results
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
