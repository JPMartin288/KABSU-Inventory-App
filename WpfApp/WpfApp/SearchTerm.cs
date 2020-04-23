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
    /// Object containing possible search terms, used for a database search query
    /// </summary>
    public class SearchTerm
    {
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
        private string breed;
        /// <summary>
        /// Public accessor to the Animal Breed variable
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
        private string canNum;
        /// <summary>
        /// Public accessor to the Sample Can Number variable
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
        /// <summary>
        /// Constructor for the search term, taking in search fields from the Search Window
        /// </summary>
        /// <param name="canNum">The cane number of the animal</param>
        /// <param name="code">The unique id of the animal</param>
        /// <param name="animalName">The name of the animal</param>
        /// <param name="breed">A breed of animal</param>
        /// <param name="owner">The owner of an animal</param>
        /// <param name="town">The town of the owner</param>
        /// <param name="state">The state of the oener</param>
        public SearchTerm(string canNum, string code, string animalName, string breed, string owner, string town, string state)
        {
            this.CanNum = canNum;
            this.Code = code;
            this.AnimalName = animalName;
            this.Breed = breed;
            this.Owner = owner;
            this.Town = town;
            this.State = state;
        }
    }
}
