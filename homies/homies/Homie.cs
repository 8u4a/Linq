using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homies
{
    class Homie
    {
        //string Address { get; set; }
        public HomieAddress Address { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public List<Homie> Friends { get; set; }

        public Homie(HomieAddress paramAddress, string paramFirstname, string paramLastname, int paramAge)
        {
            this.Address = paramAddress;
            this.Firstname = paramFirstname;
            this.Lastname = paramLastname;
            this.Age = paramAge;
            this.Friends = new List<Homie>();
        }

        public string ShowHomieDetail()
        {
            return Firstname + " " + Lastname + ", " + Age + ", from " + Address.ShowAddress();
        }

    }
}
