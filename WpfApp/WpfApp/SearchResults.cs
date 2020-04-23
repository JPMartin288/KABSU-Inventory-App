using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    public class SearchResults
    {
        private SearchResult searchResult;

        /// <summary>
        /// Connects to the SQL Database and searches for the SearchTerm st and returns a list of results
        /// </summary>
        /// <param name="st">An instance of SearchTerm containing the different search parameters</param>
        /// <returns>A list containing the results of the search</returns>
        public List<SearchResult> retrieveData(SearchTerm st)
        {
            //Uncomment Line below to use one-time database excel file insertion. Triggers on search, takes A LONG TIME, close and re-comment directly after search.
            //DataLoad.DatabaseLoad();
            string connectionString = "Server=mysql.cs.ksu.edu;Database=kabsu; User ID = kabsu; Password = insecurepassword; Integrated Security=true"; //The connection string of the current database location
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.RetrieveData", connection)) //Initializes command to the RetrieveData stored procedure
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //Add variables from the search term as inputs for the procedure.

                        command.Parameters.AddWithValue("@Owner", st.Owner);
                        command.Parameters.AddWithValue("@Breed", st.Breed);
                        command.Parameters.AddWithValue("@AnimalName", st.AnimalName);
                        command.Parameters.AddWithValue("@Code", st.Code);
                        command.Parameters.AddWithValue("@CanNum", st.CanNum);
                        command.Parameters.AddWithValue("@Town", st.Town);
                        command.Parameters.AddWithValue("@State", st.State);
                        connection.Open();

                        var reader = command.ExecuteReader(); //Executes a procedure with a reader returning the result rows

                        var resultList = new List<SearchResult>();

                        while (reader.Read()) //While there are still rows to return
                        {
                            searchResult= new SearchResult( //Create a search result of the current row
                               reader.GetString(reader.GetOrdinal("Valid")),
                               reader.GetString(reader.GetOrdinal("CanNum")),
                               reader.GetString(reader.GetOrdinal("AnimalID")),
                               reader.GetString(reader.GetOrdinal("CollDate")),
                               reader.GetString(reader.GetOrdinal("NumUnits")),
                               reader.GetString(reader.GetOrdinal("AnimalName")),
                               reader.GetString(reader.GetOrdinal("Breed")),
                               reader.GetString(reader.GetOrdinal("RegNum")),
                               reader.GetString(reader.GetOrdinal("PersonName")),
                               reader.GetString(reader.GetOrdinal("City")),
                               reader.GetString(reader.GetOrdinal("State")),
                               reader.GetString(reader.GetOrdinal("Country")),
                               reader.GetString(reader.GetOrdinal("Species")));
                            resultList.Add(searchResult); //Add the result to the result list
                        }

                        return resultList; //return the populated list of results
                    }
                }
            }
            catch (Exception) //Catches any SQL Exceptions and aborts the procedure while sending an error message.
            {
                MessageBox.Show("Unable to connect to database.");
                return new List<SearchResult>(); //return empty list
            }
        }
    }
}
