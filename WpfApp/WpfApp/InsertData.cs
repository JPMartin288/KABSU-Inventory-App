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
    class InsertData
    {
        /// <summary>
        /// Inserts a person's information into the database
        /// </summary>
        /// <param name="name">The name of the person</param>
        /// <param name="city">The city where the person lives</param>
        /// <param name="state">The State/Province where the person lives</param>
        /// <param name="country">The country where the person lives</param>
        /// <returns>If unable to insert person into database, returns the error message. Otherwise, returns an empty string.</returns>
        public static string InsertPerson(string name, string city, string state, string country)
        {
            string connectionString = "Server=mysql.cs.ksu.edu;Database=kabsu; User ID = kabsu; Password = insecurepassword; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var insertCommand = new MySqlCommand("kabsu.InsertPerson", connection))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@Name", name);
                        insertCommand.Parameters.AddWithValue("@City", city);
                        insertCommand.Parameters.AddWithValue("@State", state);
                        insertCommand.Parameters.AddWithValue("@Country", country);

                        connection.Open();

                        var reader = insertCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Inserts an animal to the database
        /// </summary>
        /// <param name="animalID">The ID of the animal, also known as the "code"</param>
        /// <param name="name">The name of the animal</param>
        /// <param name="breed">The breed of the animal</param>
        /// <param name="species">The species of the animal</param>
        /// <param name="regNum">The registration number of the animal, may be blank</param>
        /// <returns>If unable to insert into database, returns the error message. Otherwise, returns an empty string.</returns>
        public static string InsertAnimal(string animalID, string name, string breed, string species, string regNum)
        {
            string connectionString = "Server=mysql.cs.ksu.edu;Database=kabsu; User ID = kabsu; Password = insecurepassword; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.InsertAnimal", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AnimalID", animalID);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Breed", breed);
                        command.Parameters.AddWithValue("@Species", species);
                        command.Parameters.AddWithValue("@RegNum", regNum);

                        connection.Open();

                        var reader = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Inserts a sample into the database
        /// </summary>
        /// <param name="valid">Representation of whether the entry has been verified to be accurate</param>
        /// <param name="canNum">The location of the sample(s)</param>
        /// <param name="code">The code/animal ID from the source of the sample</param>
        /// <param name="collectionDate">The date when the sample was collected, may or may not be in a date format</param>
        /// <param name="numUnits">The number of straws that remain from the sample</param>
        /// <param name="notes">Any extraneous notes that might be important</param>
        /// <param name="personName">Name of the owner of the sample(s)</param>
        /// <param name="city">City where the owner lives</param>
        /// <param name="state">State/province where the owner lives</param>
        /// <returns>If unable to insert into database, returns the error message. Otherwise, returns an empty string.</returns>
        public static string InsertSample(string valid, string canNum, string code, string collectionDate, int numUnits, string notes, string personName, string city, string state)
        {
            string connectionString = "Server=mysql.cs.ksu.edu;Database=kabsu; User ID = kabsu; Password = insecurepassword; Integrated Security=true";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.InsertSample", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Valid", valid);
                        command.Parameters.AddWithValue("@CanNum", canNum);
                        command.Parameters.AddWithValue("@Code", code);
                        command.Parameters.AddWithValue("@CollDate", collectionDate);
                        command.Parameters.AddWithValue("@NumUnits", numUnits);
                        command.Parameters.AddWithValue("@Notes", notes);
                        command.Parameters.AddWithValue("@PersonName", personName);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@State", state);

                        connection.Open();

                        var reader = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
