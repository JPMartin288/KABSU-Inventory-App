using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Morph
    {
        private string notes;
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
        public Morph(string notes, string date, string vigor, string mot, string morph, string code, string units, string id)
        {
            this.notes = notes;
            this.date = date;
            this.vigor = vigor;
            this.mot = mot;
            this.morph = morph;
            this.code = code;
            this.units = units;
            this.id = id;
        }

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
