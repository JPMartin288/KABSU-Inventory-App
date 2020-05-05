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
    /// Object denoting the morphology info in a sample's record card.
    /// </summary>
    public class Morph
    {
        private string notes;
        /// <summary>
        /// Public accessor to the Notes variable
        /// </summary>
        public string Notes
        {
            get
            {
                return this.notes;
            }
            set
            {
                this.notes = value;
            }
        }
        private string date;
        /// <summary>
        /// Public accessor to the Morphology Date variable
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
        private string vigor;
        /// <summary>
        /// Public accessor to the Vigor variable
        /// </summary>
        public string Vigor
        {
            get
            {
                return this.vigor;
            }
            set
            {
                this.vigor = value;
            }
        }
        private string mot;
        /// <summary>
        /// Public accessor to the Mot variable
        /// </summary>
        public string Mot
        {
            get
            {
                return this.mot;
            }
            set
            {
                this.mot = value;
            }
        }
        private string morph;
        /// <summary>
        /// Public accessor to the Morphology variable
        /// </summary>
        public string Morphology
        {
            get
            {
                return this.morph;
            }
            set
            {
                this.morph = value;
            }
        }
        private string code;
        /// <summary>
        /// Public accessor to the Morphology Code variable
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
        private string units;
        /// <summary>
        /// Public accessor to the Morpgology Units variable
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
        private string id;
        /// <summary>
        /// Public accessor to the Animal ID variable
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        private string canNum;
        /// <summary>
        /// Public accessor to the Can Number variable
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

        /// <summary>
        /// Constructor for the Morphology Object
        /// </summary>
        /// <param name="notes">any misc. notes for the anima</param>
        /// <param name="date">the date corresponding to the morphology</param>
        /// <param name="vigor">the vigor of the animal</param>
        /// <param name="mot">the mot of the animal</param>
        /// <param name="morph">the morphology of the animal</param>
        /// <param name="code">the morphology code of the animal</param>
        /// <param name="units">the morphology units of the animal</param>
        /// <param name="id">the animal ID</param>
        public Morph(string notes, string date, string vigor, string mot, string morph, string code, string units, string id, string canNum, string collDate)
        {
            this.notes = notes;
            this.date = date;
            this.vigor = vigor;
            this.mot = mot;
            this.morph = morph;
            this.code = code;
            this.units = units;
            this.id = id;
            this.canNum = canNum;
            this.collDate = collDate;
        }

        /// <summary>
        /// Default Constructor, initializes empty strings
        /// </summary>
        public Morph()
        {
            this.notes = "";
            this.date = "";
            this.vigor = "";
            this.mot = "";
            this.morph = "";
            this.code = "";
            this.units = "";
            this.id = "";
        }
    }
}
