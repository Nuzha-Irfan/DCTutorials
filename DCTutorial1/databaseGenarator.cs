using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTutorial1
{
    public class databaseGenarator
    {
        string[] firstNames = new string[] { "Aadil", "Abdul", "Malik", "Barrak", "Ibrahim", "Adam", "Adnan", "Adolf", "Hitler", "Trunchbull" };
        string[] lastNames = new string[] { "Anand", "Abigail", "Adele", "Adrian", "James", "Peter", "Parker" };
        string[] imageAddress = new string[] { "https://random.imagecdn.app/500/150", "https://picsum.photos/200/300", "https://source.unsplash.com/user/c_v_r/1600x900" };
        Random random = new Random();
        private string GetFirstname()
        {
            return firstNames[random.Next(0, firstNames.Length)];


        }
        private string GetLastname()
        {
            return lastNames[random.Next(0, lastNames.Length)];
        }
        private uint GetPIN()
        {
            return (uint)random.Next(100, 999);
        }
        private uint GetAcctNo()
        {
            return (uint)random.Next();
        }
        private int GetBalance()
        {
            return random.Next();
        }
        private string GetImageAddress()
        {
            return imageAddress[random.Next(0, imageAddress.Length)];


        }



        public void GetNextAccount(out uint pin, out uint acctNo, out string firstName, out string
        lastName, out int balance, out string img)
        {
            pin = GetPIN();
            acctNo = GetAcctNo();
            firstName = GetFirstname();
            lastName = GetLastname();
            balance = GetBalance();
            img = GetImageAddress();

        }
    }
}
