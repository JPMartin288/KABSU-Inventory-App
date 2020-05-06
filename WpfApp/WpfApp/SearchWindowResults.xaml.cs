/*
Copyright 2019 Shant Haik, Daley Keister, Grady Salzman, & Jacob Schilmoeller

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        private static string CONNECTION_STRING = "Server=mysql.cs.ksu.edu;Database=kabsu; User ID = kabsu; Password = insecurepassword; Integrated Security=true"; //The connection string of the current database location
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
            RetrieveAndRefreshResults();
        }

        /// <summary>
        ///  Re-initializes the current window with refreshed search results.
        /// </summary>
        private void RetrieveAndRefreshResults()
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

        /// <summary>
        /// Event handler for the "Delete Selected Result" button. Deletes the sample, and any connecting parent data
        /// if the result is the last occurrance of the parent data (e.g. it won't delete an animal if another can belongs to it).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            bool deleteItem = false;
            if (uxSearchResults.SelectedItem != null) //if an item was selected
            {
                //checks to see if the button was pressed accidentally
                MessageBoxResult result = MessageBox.Show("Are you sure you would like to delete this result? All internal records of the result will be deleted as well.", "KABSU App", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (uxSearchResults.SelectedItems.Count > 1)
                        {
                            //checks to see if the user accidentally dragged the mouse over multiple rows
                            MessageBoxResult extraResult = MessageBox.Show("You have selected multiple rows to delete. Are you SURE you mean to delete multiple results?", "KABSU App", MessageBoxButton.YesNo);
                            switch (extraResult)
                            {
                                case MessageBoxResult.Yes:
                                    deleteItem = true;
                                    break;
                                case MessageBoxResult.No:
                                    break;
                            }
                        }else
                            deleteItem = true;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                if (deleteItem) //if the user actually wants to delete everything selected
                {
                    try
                    {
                        using (var connection = new MySqlConnection(CONNECTION_STRING))
                        {
                            foreach (object o in uxSearchResults.SelectedItems)
                            {
                                SearchResult searchResultToRemove = (SearchResult)o;
                                MessageBox.Show(searchResultToRemove.AnimalName);
                                using (var command = new MySqlCommand("kabsu.DeleteData", connection)) //Initializes command to the DeleteData stored procedure
                                {
                                    command.CommandType = CommandType.StoredProcedure;

                                    //Add the relevant inputs for the delete procedure.
                                    command.Parameters.AddWithValue("@CanNum", searchResultToRemove.CanNum);
                                    command.Parameters.AddWithValue("@CollDate", searchResultToRemove.CollDate);
                                    command.Parameters.AddWithValue("@AnimalID", searchResultToRemove.Code);
                                    command.Parameters.AddWithValue("@Name", searchResultToRemove.Owner);
                                    command.Parameters.AddWithValue("@City", searchResultToRemove.Town);
                                    command.Parameters.AddWithValue("@State", searchResultToRemove.State);

                                    connection.Open();
                                    var reader = command.ExecuteNonQuery(); //Executes the procedure
                                    connection.Close();
                                }
                            }
                        }
                    }
                    catch (Exception ex) //Catches any SQL Exceptions and sends an error message.
                    {
                        MessageBox.Show("Failed to delete selected row(s) from the database.");
                    }
                }
                RetrieveAndRefreshResults();
            }
            else
            {
                MessageBox.Show("Please select a result to delete from the database.");
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            RetrieveAndRefreshResults();
        }
    }
}
