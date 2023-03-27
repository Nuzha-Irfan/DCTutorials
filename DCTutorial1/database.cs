using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTutorial1
{
    public class database
    {
        List<dataStorage> dataStorage;

        public database()
        {
            dataStorage = new List<dataStorage>();

            //Create storage objects 
            dataStorage storage1 = new dataStorage();
            //Generate a genartor object
            databaseGenarator generator1 = new databaseGenarator();
            //assign geneartor with ranom values from Database
            generator1.GetNextAccount(out storage1.pin, out storage1.acctNo, out storage1.firstName, out storage1.lastName, out storage1.balance, out storage1.img);
            //add the storage object to List
            dataStorage.Add(storage1);

            dataStorage storage2 = new dataStorage();

            generator1.GetNextAccount(out storage2.pin, out storage2.acctNo, out storage2.firstName, out storage2.lastName, out storage2.balance, out storage2.img);
            dataStorage.Add(storage2);

            dataStorage storage3 = new dataStorage();

            generator1.GetNextAccount(out storage3.pin, out storage3.acctNo, out storage3.firstName, out storage3.lastName, out storage3.balance, out storage3.img);
            dataStorage.Add(storage3);


            dataStorage storage4 = new dataStorage();

            generator1.GetNextAccount(out storage4.pin, out storage4.acctNo, out storage4.firstName, out storage4.lastName, out storage4.balance, out storage4.img);
            dataStorage.Add(storage4);


            dataStorage storage5 = new dataStorage();

            generator1.GetNextAccount(out storage5.pin, out storage5.acctNo, out storage5.firstName, out storage5.lastName, out storage5.balance, out storage5.img);
            dataStorage.Add(storage5);


            dataStorage storage6 = new dataStorage();

            generator1.GetNextAccount(out storage6.pin, out storage6.acctNo, out storage6.firstName, out storage6.lastName, out storage6.balance, out storage6.img);
            dataStorage.Add(storage6);






        }

        public uint GetAcctNoByIndex(int index)
        {
            return dataStorage[index].acctNo;
        }

        public uint GetPINByIndex(int index)
        {
            return dataStorage[index].pin;

        }
        public string GetFirstNameByIndex(int index)
        {
            return dataStorage[index].firstName;
        }
        public string GetLastNameByIndex(int index)
        {
            return dataStorage[index].lastName;
        }

        public string GetImagebyindex(int index)
        {
            return dataStorage[index].img;
        }
        public int GetBalanceByIndex(int index)
        {
            return dataStorage[index].balance;
        }

        public int GetNumRecords()
        {
            return dataStorage.Count();
        }

    }

}
