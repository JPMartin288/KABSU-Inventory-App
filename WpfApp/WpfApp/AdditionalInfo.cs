using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    /// <summary>
    /// Object containing any additional info a sample needs in order to be stored/searched.
    /// </summary>
    public class AdditionalInfo
    {
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
        private string city;
        /// <summary>
        /// Public accessor to the City variable
        /// </summary>
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
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
        private bool valid;
        /// <summary>
        /// Public accessor to the Valid/Invalid variable
        /// </summary>
        public bool Valid
        {
            get
            {
                return this.valid;
            }
            set
            {
                this.valid = value;
            }
        }
        /// <summary>
        /// Constructor for the Additional Info Object, which takes in any necessary fields.
        /// </summary>
        /// <param name="species">The species of the animal</param>
        /// <param name="city">The city of the owner</param>
        /// <param name="state">The state of the owner</param>
        /// <param name="country">The country of the owner</param>
        /// <param name="valid">Whether the sample is valid or not</param>
        public AdditionalInfo(string species, string city, string state, string country, bool valid)
        {
            this.species = species;
            this.city = city;
            this.state = state;
            this.country = country;
            this.valid = valid;
        }

        public AdditionalInfo()
        {
            this.species = "";
            this.city = "";
            this.state = "";
            this.country = "";
        }
    }
}
