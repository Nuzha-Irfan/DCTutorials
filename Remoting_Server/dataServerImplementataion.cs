using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DCTutorial1;

namespace Remoting_Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class dataServer_implementation : data_Server
    {
        database db = new database();

        public dataServer_implementation()
        {

        }

        public int GetNumEntries()
        {
            return db.GetNumRecords();
        }
        public void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string fName, out string lName, out string img)
        {


            acctNo = db.GetAcctNoByIndex(index - 1);
            pin = db.GetPINByIndex(index - 1);
            bal = db.GetBalanceByIndex(index - 1);
            fName = db.GetFirstNameByIndex(index - 1);
            lName = db.GetLastNameByIndex(index - 1);
            img = db.GetImagebyindex(index - 1);



        }

    }


}
