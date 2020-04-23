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
    /// Object denoting a single record in a sample's record card.
    /// </summary>
    public class Record
    {
        private string toFrom;
        /// <summary>
        /// Public accessor to the ToFrom variable
        /// </summary>
        public string ToFrom
        {
            get
            {
                return this.toFrom;
            }
            set
            {
                this.toFrom = value;
            }
        }
        private string date;
        /// <summary>
        /// Public accessor to the Date variable
        /// </summary>
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        private string rec;
        /// <summary>
        /// Public accessor to the Received variable
        /// </summary>
        public string Rec
        {
            get
            {
                return this.rec;
            }
            set
            {
                this.rec = value;
            }
        }
        private string ship;
        /// <summary>
        /// Public accessor to the Shipped variable
        /// </summary>
        public string Ship
        {
            get
            {
                return this.ship;
            }
            set
            {
                this.ship = value;
            }
        }
        private string balance;
        /// <summary>
        /// Public accessor to the Total Balance variable
        /// </summary>
        public string Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }
        private string animalId;
        /// <summary>
        /// Public accessor to the Animal ID variable
        /// </summary>
        public string AnimalId
        {
            get
            {
                return this.animalId;
            }
            set
            {
                this.animalId = value;
            }
        }
        /// <summary>
        /// Constructor for the Record Object
        /// </summary>
        /// <param name="toFrom">Specification of who gave/recieved units in the record</param>
        /// <param name="date">The date corresponding to the record</param>
        /// <param name="rec">How many units are received in the record, if any</param>
        /// <param name="ship">How many units are shipped in the record, if any</param>
        /// <param name="balance">How much the total balance is in the record</param>
        /// <param name="id">The ID of the parent the record associates with</param>
        public Record(string toFrom, string date, string rec, string ship, string balance, string id)
        {
            this.toFrom = toFrom;
            this.date = date;
            this.rec = rec;
            this.ship = ship;
            this.balance = balance;
            this.animalId = id;
        }
    }
}
