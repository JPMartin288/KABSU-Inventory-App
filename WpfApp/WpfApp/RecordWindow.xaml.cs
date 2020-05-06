/*
Copyright 2019 Shant Haik, Daley Keister, Grady Salzman, & Jacob Schilmoeller

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MySql.Data.MySqlClient;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {
        SearchResult searchResult; // old search result object, used in case any identifying fields are updated
        private string notes; //classwide string containing misc. notes

        private AdditionalInfo info;
        private static int ID_INDEX = 321; //the index of the animal ID
        private static int CAN_INDEX = 320; //the index of the can number
        private static int DATE_INDEX = 326; //the index of the collection Date
        private static int ROW_SPACING = 32; //the spacing between text boxes in the same record row
        private static int MORPH_ID = 326; //the index of the morphology ID
        private static string CONNECTION_STRING = "Server=mysql.cs.ksu.edu;Database=kabsu; User ID = kabsu; Password = insecurepassword; Integrated Security=true"; //The connection string of the current database location
        private List<Record> recordList;
        private Morph morph;
        private bool isMorph; //boolean determing if the text box containg morphology info
        private bool isOldMorph; //boolean determining if the morphology info is unchanged
        private bool newRecord; //boolean determining if the record is freshly created
        private NoteWindow noteWindow;
        private AdditionalInfoWindow infoWindow;

        /// <summary>
        /// Default constructor for Record Window, opens an empty record card
        /// and initializes empty notes and search result.
        /// </summary>
        public RecordWindow()
        {
            newRecord = true;
            searchResult = new SearchResult();
            InitializeComponent();
            notes = "";
            Closing += RecordWindow_Closing;
        }

        /// <summary>
        /// Constructor for an existing record card window. Populates the necessary sections of the card with existing information.
        /// </summary>
        /// <param name="search">Search Result object containing basic information to populate with.</param>
        public RecordWindow(SearchResult search)
        {
            newRecord = false;
            searchResult = search;

            InitializeComponent();

            uxCode.Text = searchResult.Code;
            uxBreed.Text = searchResult.Breed;
            uxAnimalName.Text = searchResult.AnimalName;
            uxRegNum.Text = searchResult.RegNum;
            uxOwner.Text = searchResult.Owner;
            uxCanNum.Text = searchResult.CanNum;

            notes = "";
            isMorph = false;
            isOldMorph = false;

            Closing += RecordWindow_Closing;

            try
            {
                recordList = RetrieveRecords(searchResult.Code, CONNECTION_STRING); //populates the record card with any existing specific record entries
                morph = RetrieveMorph(searchResult.Code, CONNECTION_STRING); //populates the record card with any existing morphology info
            }
            catch (InvalidOperationException)
            {
                ShowErrorMessage();
            }
}

        /// <summary>
        /// Event handler on closing the window. Prompts the user for additional info, then store the information into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecordWindow_Closing(object sender, CancelEventArgs e)
        {
            CollectAdditionalInfo(); //Opens the additional info window

            this.IsEnabled = false;
            try
            {
                StoreParent(CONNECTION_STRING);
            }
            catch (InvalidOperationException)
            {
                ShowErrorMessage();
            }
            List<string> list = new List<string>();
            List<string> morphList = new List<string>();
            int textCount = 0;
            foreach(TextBox tb in FindVisualChildren<TextBox>(this))
            {
                list.Add(tb.Text);
                if (tb.Text != "" && (tb.Parent != uxBottomGrid && tb.Parent != uxMorphGrid) && tb.Text != "mm/dd/yyyy") //if the text added belongs to record rows
                    textCount++;
                if (tb.Text != "" && (tb.Parent != uxBottomGrid && tb.Parent != uxTopGrid1 && tb.Parent != uxTopGrid2)) //if any morphology data is found
                    isMorph = true;
            }
            recordList = new List<Record>();
            for (int i = 0; textCount > 0; i++) //while there  is record text to be combined into record rows
            {
                if (list[i] != "" || (list[i + ROW_SPACING] != "" && list[i + ROW_SPACING] != "mm/dd/yyyy") || list[i + (ROW_SPACING * 2)] != "" || list[i + (ROW_SPACING * 3)] != "" || list[i + (ROW_SPACING * 4)] != "")
                {
                    recordList.Add(new Record(list[i], list[i + ROW_SPACING], list[i + (ROW_SPACING * 2)], list[i + (ROW_SPACING * 3)], list[i + (ROW_SPACING * 4)], list[ID_INDEX], list[CAN_INDEX], list[DATE_INDEX]));
                    
                    //Decrement text counter
                    if (list[i] != "")
                        textCount--;
                    if (list[i + ROW_SPACING] != "")
                        textCount--;
                    if (list[i + (ROW_SPACING * 2)] != "")
                        textCount--;
                    if (list[i + (ROW_SPACING * 3)] != "")
                        textCount--;
                    if (list[i + (ROW_SPACING * 4)] != "")
                        textCount--;
                }
            }
            if (isMorph) //if morphology info exists
            {
                //create new morphology object
                morph = new Morph(notes, list[MORPH_ID], list[MORPH_ID + 1], list[MORPH_ID + 2], list[MORPH_ID + 3], list[MORPH_ID + 4], list[MORPH_ID + 5], list[ID_INDEX], list[CAN_INDEX], list[DATE_INDEX]);
            }
            try
            {
                StoreRecords(CONNECTION_STRING); //store the record list into the database
                StoreMorph(CONNECTION_STRING); //store the morphology info into the database
            }
            catch (InvalidOperationException)
            {
                ShowErrorMessage();
            }
        }

        /// <summary>
        /// Displays a message box with an error message.
        /// </summary>
        private void ShowErrorMessage()
        {
            MessageBox.Show("Unable to connect to database.");
        }

        /// <summary>
        /// Takes a WPF parent object and returns all child objects contained within it as an Enumerable
        /// </summary>
        /// <typeparam name="T">the object type</typeparam>
        /// <param name="depObj">the parent object</param>
        /// <returns>the object's children</returns>
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        /// <summary>
        /// Method which inserts a list of Record objects into the database after deleting existing records
        /// </summary>
        /// <param name="connectionString">The connection string of the current database location</param>
        private void StoreRecords(string connectionString)
        {
            if (recordList != null)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        using (var command = new MySqlCommand("kabsu.DeleteRecord", connection)) //Initializes command to the DeleteRecord stored procedure
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            //Add the animal ID as an input for the procedure.
                            command.Parameters.AddWithValue("@ID", searchResult.Code);
                            command.Parameters.AddWithValue("@Can", searchResult.CanNum);
                            command.Parameters.AddWithValue("@Date", searchResult.CollDate);

                            connection.Open();
                            int k = command.ExecuteNonQuery(); //Executes the procedure
                            connection.Close();
                        }
                        foreach (Record r in recordList)
                        {

                            using (var command = new MySqlCommand("kabsu.StoreData", connection)) //Initializes command to the StoreData stored procedure
                            {
                                command.CommandType = CommandType.StoredProcedure;

                                //Add variables from the record object as inputs for the procedure.
                                command.Parameters.AddWithValue("@ToFrom", r.ToFrom);
                                command.Parameters.AddWithValue("@Date", r.Date);
                                if (r.Rec != "")
                                    command.Parameters.AddWithValue("@Received", Convert.ToInt32(r.Rec));
                                else
                                    command.Parameters.AddWithValue("@Received", 0);
                                if (r.Ship != "")
                                    command.Parameters.AddWithValue("@Shipped", Convert.ToInt32(r.Ship));
                                else
                                    command.Parameters.AddWithValue("@Shipped", 0);
                                if (r.Balance != "")
                                    command.Parameters.AddWithValue("@Balance", Convert.ToInt32(r.Balance));
                                else
                                    command.Parameters.AddWithValue("@Balance", 0);
                                command.Parameters.AddWithValue("@AnimalID", r.AnimalId);
                                command.Parameters.AddWithValue("@Can", r.CanNum);
                                command.Parameters.AddWithValue("@CollDate", r.CollDate);

                                connection.Open();
                                int k = command.ExecuteNonQuery(); //Executes the procedure
                                connection.Close();
                            }
                        }

                    }
                }
                catch (Exception) //Catches any SQL Exceptions and throws to the caller.
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Method which inserts a list of Record objects into the database after deleting existing records
        /// </summary>
        /// <param name="connectionString">The connection string of the current database location</param>
        public void StoreMorph(string connectionString)
        {
            if (isMorph == true && isOldMorph == false)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        using (var command = new MySqlCommand("kabsu.StoreMorph", connection)) //Initializes command to the StoreMorph stored procedure
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            //Add variables from the record object as inputs for the procedure.
                            command.Parameters.AddWithValue("@Notes", morph.Notes);
                            command.Parameters.AddWithValue("@Date", uxMorphDate.Text);
                            command.Parameters.AddWithValue("@Vigor", Convert.ToInt32(morph.Vigor));
                            command.Parameters.AddWithValue("@Mot", Convert.ToInt32(morph.Mot));
                            command.Parameters.AddWithValue("@Morph", Convert.ToInt32(morph.Morphology));
                            command.Parameters.AddWithValue("@Code", Convert.ToInt32(morph.Code));
                            command.Parameters.AddWithValue("@Units", Convert.ToInt32(uxMorphUnits.Text));
                            command.Parameters.AddWithValue("@ID", morph.Id);
                            command.Parameters.AddWithValue("@Can", searchResult.CanNum);
                            command.Parameters.AddWithValue("@CollDate", searchResult.CollDate);

                            connection.Open();
                            int k = command.ExecuteNonQuery(); //Executes the procedure
                            connection.Close();
                        }

                    }
                }
                catch (Exception) //Catches any SQL Exceptions and throws to the caller.
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Stores the sample and its child animal/person into the database
        /// </summary>
        /// <param name="connectionString">The connection string of the current database location</param>
        public void StoreParent(string connectionString)
        {
            if (newRecord == true) //If the record is freshly created
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        using (var command = new MySqlCommand("kabsu.StoreParent", connection)) //Initializes command to the StoreParent stored procedure
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            //Add variables from the record card as inputs for the procedure.
                            command.Parameters.AddWithValue("@Valid", info.Valid.ToString().ToUpper());
                            command.Parameters.AddWithValue("@CanNum", uxCanNum.Text);
                            command.Parameters.AddWithValue("@AnimalID", uxCode.Text);
                            command.Parameters.AddWithValue("@CollDate", uxMorphDate.Text);
                            command.Parameters.AddWithValue("@NumUnits", uxMorphUnits.Text);
                            command.Parameters.AddWithValue("@City", info.City);
                            command.Parameters.AddWithValue("@State", info.State);
                            command.Parameters.AddWithValue("@Country", info.Country);
                            command.Parameters.AddWithValue("@Owner", uxOwner.Text);
                            command.Parameters.AddWithValue("@AnimalName", uxAnimalName.Text);
                            command.Parameters.AddWithValue("@Breed", uxBreed.Text);
                            command.Parameters.AddWithValue("@Species", info.Species);
                            command.Parameters.AddWithValue("@RegNum", uxRegNum.Text);

                            connection.Open();
                            int k = command.ExecuteNonQuery(); //Executes the procedure
                            connection.Close();
                        }

                    }
                }
                catch (Exception) //Catches any SQL Exceptions and throws to the caller.
                {
                    throw new InvalidOperationException();
                }
            }
            else
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        using (var command = new MySqlCommand("kabsu.UpdateParent", connection)) //Initializes command to the UpdateParent stored procedure
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            //Add variables from the record card as inputs for the procedure.
                            command.Parameters.AddWithValue("@SValid", info.Valid.ToString().ToUpper());
                            command.Parameters.AddWithValue("@SCanNum", uxCanNum.Text);
                            command.Parameters.AddWithValue("@OldAnimalID", searchResult.Code);
                            command.Parameters.AddWithValue("@AAnimalID", uxCode.Text);
                            command.Parameters.AddWithValue("@SCollDate", uxMorphDate.Text);
                            command.Parameters.AddWithValue("@SNumUnits", uxMorphUnits.Text);
                            command.Parameters.AddWithValue("@PCity", info.City);
                            command.Parameters.AddWithValue("@OldCity", searchResult.Town);
                            command.Parameters.AddWithValue("@PState", info.State);
                            command.Parameters.AddWithValue("@OldState", searchResult.State);
                            command.Parameters.AddWithValue("@PCountry", info.Country);
                            command.Parameters.AddWithValue("@POwner", uxOwner.Text);
                            command.Parameters.AddWithValue("@OldOwner", searchResult.Owner);
                            command.Parameters.AddWithValue("@AAnimalName", uxAnimalName.Text);
                            command.Parameters.AddWithValue("@ABreed", uxBreed.Text);
                            command.Parameters.AddWithValue("@ASpecies", info.Species);
                            command.Parameters.AddWithValue("@ARegNum", uxRegNum.Text);

                            connection.Open();
                            int k = command.ExecuteNonQuery(); //Executes the procedure
                            connection.Close();
                        }

                    }
                }
                catch (Exception) //Catches any SQL Exceptions and throws to the caller.
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Retrieves records from the database matching the animal's unique ID
        /// </summary>
        /// <param name="id">the animal ID</param>
        /// <param name="connectionString">The connection string of the current database location</param>
        /// <returns>A list of Record Objects</returns>
        public List<Record> RetrieveRecords(string id, string connectionString)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.RetrieveRecords", connection)) //Initializes command to the RetrieveRecords stored procedure
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //Add the ID as an input for the procedure.
                        command.Parameters.AddWithValue("@AnimalID", id);
                        command.Parameters.AddWithValue("@Can", searchResult.CanNum);
                        command.Parameters.AddWithValue("@CollDate", searchResult.CollDate);
                        connection.Open();

                        var reader = command.ExecuteReader(); //Executes a procedure with a reader returning existing record rows

                        recordList = new List<Record>();
                        Record record;
                        while (reader.Read()) //While there are still rows to return
                        {
                            record = new Record( //Create a record of the current row
                               reader.GetString(reader.GetOrdinal("ToFrom")),
                               reader.GetString(reader.GetOrdinal("Date")),
                               reader.GetInt32(reader.GetOrdinal("NumReceived")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("NumShipped")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("Balance")).ToString(), id, searchResult.CanNum, searchResult.CollDate);
                            recordList.Add(record); //Add the record to the record list
                        }
                        connection.Close();
                        return recordList; //return the populated list of records
                    }
                }
            }
            catch (Exception) //Catches any SQL Exceptions and throws to the caller.
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Retrieves morphology info from the database matching the animal's unique ID
        /// </summary>
        /// <param name="id">animal ID</param>
        /// <param name="connectionString">The connection string of the current database location</param>
        /// <returns>the morphology info in an object</returns>
        public Morph RetrieveMorph(string id, string connectionString)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    using (var command = new MySqlCommand("kabsu.RetrieveMorph", connection)) //Initializes command to the RetrieveMorph stored procedure
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //Add the ID as an input for the procedure.
                        command.Parameters.AddWithValue("@AnimalID", id);
                        command.Parameters.AddWithValue("@Can", searchResult.CanNum);
                        command.Parameters.AddWithValue("@CollDate", searchResult.CollDate);
                        connection.Open();

                        var reader = command.ExecuteReader(); //Executes a procedure with a reader returning existing record rows

                        Morph morph = new Morph();
                        while (reader.Read()) //While there are still rows to return (1 expected)
                        {
                            morph = new Morph( //Create a morphology object from the current row
                               reader.GetString(reader.GetOrdinal("Notes")),
                               reader.GetString(reader.GetOrdinal("Date")),
                               reader.GetInt32(reader.GetOrdinal("Vigor")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("Mot")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("Morph")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("Code")).ToString(),
                               reader.GetInt32(reader.GetOrdinal("Units")).ToString(), id, searchResult.CanNum, searchResult.CollDate);
                            if (morph.Notes != null) //if notes exist, populate private notes string
                                notes = morph.Notes;
                            isMorph = true;
                            isOldMorph = true;
                        }
                        connection.Close();

                        return morph; //return the morphology info
                    }
                }
            }
            catch (Exception) //Catches any SQL Exceptions and throws to the caller.
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Event handler for when the Window loads, which populates the record row text boxes with any existing records
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecordWindow_Load(object sender, RoutedEventArgs e)
        {
            int textCount = 0;
            IEnumerable<TextBox> textBoxEnum = (IEnumerable<TextBox>)FindVisualChildren<TextBox>(this); //populates an enumerable with every text box in the window
            List<TextBox> textBoxes = textBoxEnum.ToList<TextBox>();

            SortListByDate(); //if possible, sort records to populate by oldest record first
            if (!CheckBalance())
            {
                MessageBoxResult result = MessageBox.Show("Unexpected Balance in one or more record rows. Auto-correct?","KABSU App", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:

                        MessageBox.Show(ReplaceBalance() + " rows changed", "KABSU App");
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }

            if (recordList != null)
            {
                foreach (Record r in recordList) // for every existing record row
                {
                    //populate the relevent record text box
                    textBoxes[textCount].Text = r.ToFrom;
                    textBoxes[textCount + ROW_SPACING].Text = r.Date;
                    textBoxes[textCount + ROW_SPACING].Foreground = Brushes.Black;
                    textBoxes[textCount + (ROW_SPACING * 2)].Text = r.Rec;
                    textBoxes[textCount + (ROW_SPACING * 3)].Text = r.Ship;
                    textBoxes[textCount + (ROW_SPACING * 4)].Text = r.Balance;

                    textCount++;

                    if (textCount == 32) //only input records from the start index of each possible row (tab order is weird)
                        textCount += 128;
                }
            }
            if (morph != null)
            {
                //populate the relevent morphology text boxes
                textBoxes[MORPH_ID].Text = morph.Date;
                textBoxes[MORPH_ID + 1].Text = morph.Vigor;
                textBoxes[MORPH_ID + 2].Text = morph.Mot;
                textBoxes[MORPH_ID + 3].Text = morph.Morphology;
                textBoxes[MORPH_ID + 4].Text = morph.Code;
                textBoxes[MORPH_ID + 5].Text = morph.Units;
            }
            if (searchResult.Units != null)
            {
                uxMorphUnits.Text = searchResult.Units;
            }
            if (searchResult.CollDate != null)
            {
                uxMorphDate.Text = searchResult.CollDate;
            }
            isOldMorph = true;
        }

        /// <summary>
        /// Checks to see that every balance is what it is expected to be,
        /// from the order of records and the balances given
        /// </summary>
        /// <returns>whether any rows are percieved as incorrect</returns>
        private bool CheckBalance()
        {
            int expectedBalance = 0;
            bool isCorrectBalance = true;
            foreach(Record r in recordList)
            {
                expectedBalance -= Convert.ToInt32(r.Ship);
                expectedBalance += Convert.ToInt32(r.Rec);
                if (expectedBalance != Convert.ToInt32(r.Balance))
                    isCorrectBalance = false;
            }
            return isCorrectBalance;
        }

        private int ReplaceBalance()
        {
            int expectedBalance = 0;
            int editedRows = 0;
            foreach (Record r in recordList)
            {
                expectedBalance -= Convert.ToInt32(r.Ship);
                expectedBalance += Convert.ToInt32(r.Rec);
                if (Convert.ToInt32(r.Balance) != expectedBalance)
                    editedRows++;
                r.Balance = expectedBalance.ToString();
            }
            return editedRows;
        }

        /// <summary>
        /// Sorts the record list by date if the dates are in the correct format
        /// </summary>
        private void SortListByDate()
        {
            if (recordList != null)
            {
                for (int i = 0; i < recordList.Count; i++)
                {
                    //Replace various other formats
                    if (recordList[i].Date[2] == '-' || recordList[i].Date[1] == '-')
                        recordList[i].Date.Replace('-', '/');
                    if (recordList[i].Date[2] == '\\' || recordList[i].Date[1] == '\\')
                        recordList[i].Date.Replace('\\', '/');

                    //Don't try to sort if the date is in an invalid format
                    if (recordList[i].Date[2] != '/' && recordList[i].Date[1] != '/')
                        return;
                    string[] recordSplit = recordList[i].Date.Split('/');
                    for (int j = 0; j < recordList.Count; j++) //if the date is earlier than the later parts of the list
                    {
                        string[] oldRecordSplit = recordList[j].Date.Split('/');
                        if (Convert.ToInt32(recordSplit[1]) <= Convert.ToInt32(oldRecordSplit[1]) &&
                            Convert.ToInt32(recordSplit[0]) <= Convert.ToInt32(oldRecordSplit[0]) &&
                            Convert.ToInt32(recordSplit[2]) <= Convert.ToInt32(oldRecordSplit[2]))
                        {
                            ExchangeRecord(recordList, i, j); //exchange the places of the two records
                                                              //re-initialize split records
                            recordSplit = recordList[i].Date.Split('/');
                            oldRecordSplit = recordList[j].Date.Split('/');
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Simple method, exchanges places in a list
        /// </summary>
        /// <param name="data">given list of records</param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        public static void ExchangeRecord(List<Record> data, int m, int n)
        {
            Record temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }

        /// <summary>
        /// Event handler for when any morphology info is changed in text boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MorphChanged(object sender, TextChangedEventArgs e)
        {
            isOldMorph = false;
        }

        /// <summary>
        /// Event handler for the "Notes" button, opens a window which holds notes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxNotesButton_Click(object sender, RoutedEventArgs e)
        {
            noteWindow = new NoteWindow(notes);
            noteWindow.Check += value => notes = value; //returns value from window when check is called in note window
            noteWindow.ShowDialog();
            isOldMorph = false;
        }

        /// <summary>
        /// Opens a window allowing additional info to be added and modified. Put in separate window
        /// to keep the original record card format.
        /// </summary>
        private void CollectAdditionalInfo()
        {
            if (newRecord == true)
                info = new AdditionalInfo();
            else
                info = new AdditionalInfo(searchResult.Species, searchResult.Town, searchResult.State, searchResult.Country, Convert.ToBoolean(searchResult.INV.ToLower()));
            infoWindow = new AdditionalInfoWindow(info);
            infoWindow.Check += value => info = value; //returns value from window when check is called in additional info window
            infoWindow.ShowDialog();
        }

        private void DateText_RemoveDateText(object sender, RoutedEventArgs e)
        {
            TextBox dateBox = sender as TextBox;
            if (dateBox.Text == "mm/dd/yyyy")
            {
                dateBox.Text = "";
                dateBox.Foreground = Brushes.Black;
            }
        }
    }

}
