using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Remoting_BusinessTier
{

    [ServiceContract]
    public  interface BusinessServerInterfacae
    {
        [OperationContract]
        int GetNumEntries();
        [OperationContract]

        void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out
        string fName, out string lName, out string img);


        [OperationContract]
        void GetValuesForSearch(string search, out uint acctNo, out uint pin, out int bal, out
        string fName, out string lName, out string img);
    }
}
