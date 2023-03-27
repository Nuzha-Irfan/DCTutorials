using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTutorial1
{
    public class dataStorage
    {

        public uint acctNo;
        public uint pin;
        public int balance;
        public string firstName;
        public string lastName;
        public string img;

        public dataStorage()
        {
            acctNo = 0;
            pin = 0;
            balance = 0;
            firstName = "";
            lastName = "";
            img = "";
        }


        public dataStorage(uint acctNo, uint pin, int balance, string firstName, string lastName, string img)
        {
            this.acctNo = acctNo;
            this.pin = pin;
            this.balance = balance;
            this.firstName = firstName;
            this.lastName = lastName;
            this.img = img;

        }
    }
}
