using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DCTutorial1;
using Remoting_BusinessTier;
using System.ServiceModel;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;

namespace Delegate_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate dataStorage Search(string value);
    public partial class MainWindow : Window
    {
        private  BusinessServerInterfacae foob;
        private Search search;
        public MainWindow()
        {
            InitializeComponent();
            ChannelFactory<BusinessServerInterfacae> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            //Set the URL and create the connection!
            string URL = "net.tcp://localhost:8200/StudentBusinessService";
            foobFactory = new ChannelFactory<BusinessServerInterfacae>(tcp, URL);
            foob = foobFactory.CreateChannel();
            //Also, tell me how many entries are in the DB.
            total.Text = foob.GetNumEntries().ToString();
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            string fName = null, lName = null, img = null;
            int bal = 0;
            uint acct = 0, pin = 0;

            index = Int32.Parse(indexNo.Text);

            foob.GetValuesForEntry(index, out acct, out pin, out bal, out fName, out lName, out img);
            //And now, set the values in the GUI!
            fname.Text = fName;
            lname.Text = lName;
            balance.Text = bal.ToString("C");
            Accno.Text = acct.ToString();
            pinNo.Text = pin.ToString("D4");
            Searchbox.Text = "";
            progress.Value = 0;


            BitmapImage btm = new BitmapImage(new Uri(img));

            propic.Source = btm;
            propic.Stretch = Stretch.Fill;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            search = SearchDB;
            AsyncCallback callback;
            callback = this.OnSearchCompletion;
            IAsyncResult result = search.BeginInvoke(Searchbox.Text, callback, null);
        }


        private dataStorage SearchDB(string value)
        {
            progress.Dispatcher.Invoke(new Action(() => progress.Value = 10));
            string fName, lName, image;
            int bal;
            uint acct, pinNo;

            foob.GetValuesForSearch(value, out acct, out pinNo, out bal, out fName, out lName, out image);
            if (acct != 0)
            {
                dataStorage data = new dataStorage();
                data.acctNo= acct;
                data.balance=bal;
                data.pin = pinNo;
                data.firstName = fName;
                data.lastName = lName;
                data.img = image;
                progress.Dispatcher.Invoke(new Action(() => progress.Value = 30));
                return data;
            }
            progress.Dispatcher.Invoke(new Action(() => progress.Value = 30));
            return null;
        }

        private void UpdateGui(dataStorage data)
        {
            progress.Dispatcher.Invoke(new Action(() => progress.Value = 100));
            
            fname.Dispatcher.Invoke(new Action(() => fname.Text = data.firstName));
            lname.Dispatcher.Invoke(new Action(() => lname.Text = data.lastName));
            pinNo.Dispatcher.Invoke(new Action(() => pinNo.Text = data.pin.ToString("D4")));
            Accno.Dispatcher.Invoke(new Action(() => Accno.Text = data.acctNo.ToString()));
            balance.Dispatcher.Invoke(new Action(() => balance.Text = data.balance.ToString("C")));
           
            propic.Dispatcher.BeginInvoke(new Action(() => {
                BitmapImage btm = new BitmapImage(new Uri(data.img));

                propic.Source = btm;
                propic.Stretch = Stretch.Fill;
            }));


        }

        private void OnSearchCompletion(IAsyncResult asyncResult)
        {
            progress.Dispatcher.Invoke(new Action(() => progress.Value = 35));
            dataStorage data = null;
            Search search = null;
            AsyncResult asyncobj = (AsyncResult)asyncResult;
            if (asyncobj.EndInvokeCalled == false)
            {
                progress.Dispatcher.Invoke(new Action(() => progress.Value = 55));
                search = (Search)asyncobj.AsyncDelegate;
                data = search.EndInvoke(asyncobj);
                UpdateGui(data);
            }

            asyncobj.AsyncWaitHandle.Close();


        }
    }
}
