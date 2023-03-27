using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;
using Remoting_Server;
using System.IO;
using System.Runtime.CompilerServices;

namespace Remoting_BusinessTier
{
    internal class BusinessServer: BusinessServerInterfacae
    {
        private data_Server foob;
        private uint LogNumber = 0;
        public BusinessServer()
        {
            ChannelFactory<data_Server> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            //Set the URL and create the connection!
            string URL = "net.tcp://localhost:8100/StudentService";
            foobFactory = new ChannelFactory<data_Server>(tcp, URL);
            foob = foobFactory.CreateChannel();
        }


        public int GetNumEntries()
        {
            Log(" - Get number of entries called at " + DateTime.Now);
            return foob.GetNumEntries();
        }

        public void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out
        string fName, out string lName, out string img)
        {
            Log(" - Get entry details by index: " + index + ". Called at " + DateTime.Now);
            foob.GetValuesForEntry(index, out acctNo, out pin, out bal, out fName, out lName, out img);
        }


        public void GetValuesForSearch(string search, out uint acctNo, out uint pin, out int bal, out
        string fName, out string lName, out string img)
        {
            Log(" - Get entry by last name: " + search + ". Called at " + DateTime.Now);
            acctNo = 0;
            pin = 0;
            bal = 0;
            fName = "";
            lName = "";
            img = "https://source.unsplash.com/user/c_v_r";



            int numEntry = foob.GetNumEntries();
            for (int i = 1; i <= numEntry; i++)
            {
                string fname, lname, image;
                int balance;
                uint acctNum, pinNo;
                foob.GetValuesForEntry(i, out acctNum, out pinNo, out balance, out fname, out lname, out image);
                if (String.Equals(lname, search, StringComparison.OrdinalIgnoreCase))
                {
                    acctNo = acctNum;
                    pin = pinNo;
                    bal = balance;
                    fName = fname;
                    lName = lname;
                    img = image;

                    break;
                }
            }
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        void Log(string logString)
        {
            LogNumber += 1;
            Console.WriteLine("Log Number #" + LogNumber + logString);

            // The code to save my logs to a text file -  https://www.c-sharpcorner.com/Blogs/write-a-log-file-in-net-application
            FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", "C:\\Users\\Nuzha\\source\\repos\\DCTutorial1\\Remoting_BusinessTier\\bin\\Debug", "Log.txt"), FileMode.Append, FileAccess.Write);
            StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
            objStreamWriter.WriteLine("Log Number #" + LogNumber + logString);
            objStreamWriter.Close();
            objFilestream.Close();
        }

    }
}
