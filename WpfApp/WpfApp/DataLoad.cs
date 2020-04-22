using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WpfApp
{
    /// <summary>
    /// Class to automate filling the database while providing an output of failed entries
    /// </summary>
    class DataLoad
    {
        /// <summary>
        /// Method that inserts data to database
        /// </summary>
        public static void DatabaseLoad()
        {
            using (StreamReader sr = new StreamReader("C:/Users/e10d1/source/repos/KABSU-Inventory-App/Database Files/Database Sample Data/People.csv")) //change this file path to match where it is on your machine
            {
                string line;
                string[] lineTokens;
                string name;
                StringBuilder errorList = new StringBuilder();

                line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    name = "";

                    // Break down line into its constituent parts
                    if (line.Split(new string[] { "\"" }, StringSplitOptions.None).Count() > 1)
                        name = line.Split(new string[] { "\"" }, StringSplitOptions.None)[1];
                    lineTokens = line.Split(',');

                    // Add entry to database
                    if (name == "")
                        errorList.Append(InsertData.InsertPerson(Convert.ToInt32(lineTokens[0]), lineTokens[1], lineTokens[2], lineTokens[3], lineTokens[4]));
                    else
                        errorList.Append(InsertData.InsertPerson(Convert.ToInt32(lineTokens[0]), name, lineTokens[3], lineTokens[4], lineTokens[5]));
                }
            }

            using (StreamReader sr = new StreamReader("C:/Users/e10d1/source/repos/KABSU-Inventory-App/Database Files/Database Sample Data/Animal.csv"))
            {
                string line;
                string[] lineTokens;

                StringBuilder errorList = new StringBuilder();

                line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    // Break down line into its constituent parts
                    lineTokens = PIEBALD.Lib.LibExt.Rive.LibExt.Rive(line, PIEBALD.Lib.LibExt.Rive.Option.HonorQuotes, ',').ToArray();

                    for (int i = 0; i < lineTokens.Length; i++)
                    {
                        lineTokens[i] = lineTokens[i].Replace("\"", "");
                    }

                    // Add entry to database
                    errorList.Append(InsertData.InsertAnimal(lineTokens[0], lineTokens[1], lineTokens[2], lineTokens[3], lineTokens[4]));
                }
            }

            using (StreamReader sr = new StreamReader("C:/Users/e10d1/source/repos/KABSU-Inventory-App/Database Files/Database Sample Data/sample.csv"))
            {
                string line;
                string[] lineTokens;

                StringBuilder errorList = new StringBuilder();

                line = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {

                    // Break down line into its constituent parts
                    lineTokens = PIEBALD.Lib.LibExt.Rive.LibExt.Rive(line, PIEBALD.Lib.LibExt.Rive.Option.HonorQuotes, ',').ToArray();

                    for (int i = 0; i < lineTokens.Length; i++)
                    {
                        lineTokens[i] = lineTokens[i].Replace("\"", "");
                    }

                    // Add entry to database
                    errorList.Append(InsertData.InsertSample(lineTokens[0], lineTokens[1], lineTokens[2], lineTokens[3], Convert.ToInt32(lineTokens[4]), lineTokens[6], lineTokens[9], lineTokens[10], lineTokens[11]));
                }
            }
        }
    }
}
