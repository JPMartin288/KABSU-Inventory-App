/*
Copyright 2019 Shant Haik, Daley Keister, Grady Salzman, & Jacob Schilmoeller

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/
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

        /// <summary>
        /// default constructor for the Search Window
        /// </summary>
        public SearchWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Event Handler for the "Search" Button, calls  the database search method and opens a
        /// SearchWindowResults window containing its contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxSearch_Click(object sender, RoutedEventArgs e)
        {
            windowResults = new SearchWindowResults(CalculateResultList(), searchTerm); // calls the database search method to initialize the window
            windowResults.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Event Handler for the "Calculate Unit Sum" Button, which calculates the sum of the total
        /// unit variables of each row from a database search, and shows a message box with the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Sorts the given term into its variable type based on the contents of the drop down box in SearchWindow
        /// </summary>
        /// <param name="term">unsorted given term</param>
        /// <param name="contents">contents of the drop down box</param>
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
        /// <summary>
        /// Sorts the terms in the text boxes by the SearchContents text, and creates a Search Term to
        /// find the search results with. Returns the results of the search in SearchResults
        /// </summary>
        /// <returns>A list of search results</returns>
        private List<SearchResult> CalculateResultList()
        {
            //Sort the unspecified search terms

            SetTerm(uxSearchTerm1.Text, uxSearchContents1.Text);
            SetTerm(uxSearchTerm2.Text, uxSearchContents2.Text);
            SetTerm(uxSearchTerm3.Text, uxSearchContents3.Text);
            SetTerm(uxSearchTerm4.Text, uxSearchContents4.Text);

            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchTerm = new SearchTerm(canNum, code, animalName, breed, owner, town, state);
            searchResults = new SearchResults();
            List<SearchResult> results = searchResults.retrieveData(searchTerm); //Executes database search procedure, returns SearchResult List
            return results;
        }
    }
}
