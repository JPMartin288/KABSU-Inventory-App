using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Record
    {
        private string toFrom;
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
