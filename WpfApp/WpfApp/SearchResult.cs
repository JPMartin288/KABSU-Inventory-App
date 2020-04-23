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

namespace WpfApp
{
    /// <summary>
    /// Object containing the results of a search of samples, used to populate the Search Result Grid.
    /// </summary>
    public class SearchResult
    {
        private string inv;
        /// <summary>
        /// Public accessor to the Valid/Invalid variable
        /// </summary>
        public string INV
        {
            get
            {
                return this.inv;
            }
            set
            {
                this.inv = value;
            }
        }
        private string canNum;
        /// <summary>
        /// Public accessor to the Can Code variable
        /// </summary>
        public string CanNum
        {
            get
            {
                return this.canNum;
            }
            set
            {
                this.canNum = value;
            }
        }
        private string code;
        /// <summary>
        /// Public accessor to the Animal ID variable
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }
        private string collDate;
        /// <summary>
        /// Public accessor to the Collection Date variable
        /// </summary>
        public string CollDate
        {
            get
            {
                return this.collDate;
            }
            set
            {
                this.collDate = value;
            }
        }
        private string units;
        /// <summary>
        /// Public accessor to the Total Units variable
        /// </summary>
        public string Units
        {
            get
            {
                return this.units;
            }
            set
            {
                this.units = value;
            }
        }
        private string animalName;
        /// <summary>
        /// Public accessor to the Animal Name variable
        /// </summary>
        public string AnimalName
        {
            get
            {
                return this.animalName;
            }
            set
            {
                this.animalName = value;
            }
        }
        private string breed;
        /// <summary>
        /// Public accessor to the Breed variable
        /// </summary>
        public string Breed
        {
            get
            {
                return this.breed;
            }
            set
            {
                this.breed = value;
            }
        }
        private string regNum;
        /// <summary>
        /// Public accessor to the Registration Number variable
        /// </summary>
        public string RegNum
        {
            get
            {
                return this.regNum;
            }
            set
            {
                this.regNum = value;
            }
        }
        private string owner;
        /// <summary>
        /// Public accessor to the Owner variable
        /// </summary>
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }
        private string town;
        /// <summary>
        /// Public accessor to the City variable
        /// </summary>
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
            }
        }
        private string state;
        /// <summary>
        /// Public accessor to the State variable
        /// </summary>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        private string country;
        /// <summary>
        /// Public accessor to the Country variable
        /// </summary>
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }
        private string species;
        /// <summary>
        /// Public accessor to the Species variable
        /// </summary>
        public string Species
        {
            get
            {
                return this.species;
            }
            set
            {
                this.species = value;
            }
        }
        /// <summary>
        /// A constructor for the result of a Search in the database.
        /// </summary>
        /// <param name="valid">The specification of whether or not the result is valid</param>
        /// <param name="canNum">The Can Number of the animal in the result</param>
        /// <param name="code">The animal ID of the animal in the result</param>
        /// <param name="collDate">The collection date of the sample</param>
        /// <param name="units">The number of straws available for the sample</param>
        /// <param name="animalName">The name of the animal</param>
        /// <param name="breed">The breed of the animal</param>
        /// <param name="regNum">The registration number of the animal</param>
        /// <param name="owner">The owner of the animal</param>
        /// <param name="town">The town of the owner</param>
        /// <param name="state">The state of the owner</param>
        /// <param name="country">The country of the owner</param>
        /// <param name="species">The species of the animal</param>
        public SearchResult(string valid, string canNum, string code, string collDate, string units, string animalName, string breed, string regNum, string owner, string town, string state, string country, string species)
        {
            this.INV = valid;
            this.CanNum = canNum;
            this.Code = code;
            this.CollDate = collDate;
            this.Units = units;
            this.AnimalName = animalName;
            this.Breed = breed;
            this.RegNum = regNum;
            this.Owner = owner;
            this.Town = town;
            this.State = state;
            this.Country = country;
            this.Species = species;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SearchResult()
        {

        }
    }
}