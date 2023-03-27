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
using Remoting_BusinessTier;
using System.ServiceModel;
using DCTutorial1;


namespace Async_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate dataStorage Search(string value);
    public partial class MainWindow : Window
    {
        private BusinessServerInterfacae foob;
        private string value;
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
            progress.Value = 0;


            BitmapImage btm = new BitmapImage(new Uri(img));

            propic.Source = btm;
            propic.Stretch = Stretch.Fill;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            progress.Dispatcher.Invoke(new Action(() => progress.Value = 10));

            value = Searchbox.Text;
            Task<dataStorage> task = new Task<dataStorage>(SearchDB);

            task.Start();

            dataStorage data = await task;

            if(data != null)
            {
                progress.Dispatcher.Invoke(new Action(() => progress.Value = 100));
                UpdateGui(data);
            }
            else
            {
                MessageBox.Show("The Names does not Exist or Invalid entry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private dataStorage SearchDB()
        {
            progress.Dispatcher.Invoke(new Action(() => progress.Value = 30));
            string fName, lName, image;
            int bal;
            uint acct, pinNo;

            foob.GetValuesForSearch(value, out acct, out pinNo, out bal, out fName, out lName, out image);
            if (acct != 0)
            {
                dataStorage data = new dataStorage();
                data.acctNo = acct;
                data.balance = bal;
                data.pin = pinNo;
                data.firstName = fName;
                data.lastName = lName;
                data.img = image;
                progress.Dispatcher.Invoke(new Action(() => progress.Value = 50));
                return data;
            }
            progress.Dispatcher.Invoke(new Action(() => progress.Value = 50));
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


    }
}
