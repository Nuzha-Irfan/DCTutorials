using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using SQL_WebAPI;
using SQL_WebAPI.Controllers;
using SQL_WebAPI.Models;

namespace SQL_BusinessAPI.Models
{
    public class DataGenarate
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

        public static  List<Account> getDetails()
        {   
            Random r = new Random();
            List <Account> accounts = new List<Account>();  

            for (int i = 0; i < 10; i++)
            {
                accounts[i].FirstName = GenerateName(8);
                accounts[i].LastName = GenerateName(5);
                accounts[i].balance = r.Next();
                accounts[i].AccountNo = r.Next();
                accounts[i].pin = r.Next();
                accounts.Add(accounts[i]);

            }
            return accounts;
            


            
            
        }

      


    }
}