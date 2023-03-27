using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQL_WebAPI.Models
{
    public class genartor
    {
        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }

        public static Account getDetails()
        {
            string[] imageAddress = new string[] { "https://random.imagecdn.app/500/150", "https://picsum.photos/200/300", "https://source.unsplash.com/user/c_v_r/1600x900" };
            Random r = new Random();
            Account account = new Account();
            
            
                account.FirstName = GenerateName(8);
                account.LastName = GenerateName(5);
                account.balance = r.Next();
                account.AccountNo = r.Next();
                account.pin = r.Next();
                account.ImageSource = imageAddress[r.Next(0, imageAddress.Length)]; ;

            
            return account;



        }
    }
}