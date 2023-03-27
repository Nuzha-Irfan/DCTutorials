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
using System.ServiceModel;
using Remoting_BusinessTier;
using System.Text.RegularExpressions;

namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BusinessServerInterfacae foob;
        public MainWindow()
        {
            InitializeComponent();
            //This is a factory that generates remote connections to our remote class. Thisis what hides the RPC stuff!
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
            int totalNo = 0;
            totalNo = Int32.Parse(total.Text);
            index = Int32.Parse(indexNo.Text);

            if (index <= 0 || index > totalNo)
            {
                MessageBox.Show("Enter a valid Index in range", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                foob.GetValuesForEntry(index, out acct, out pin, out bal, out fName, out lName, out img);
                //And now, set the values in the GUI!
                fname.Text = fName;
                lname.Text = lName;
                balance.Text = bal.ToString("C");
                Accno.Text = acct.ToString();
                pinNo.Text = pin.ToString("D4");





                BitmapImage btm = new BitmapImage(new Uri(img));

                propic.Source = btm;
                propic.Stretch = Stretch.Fill;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fName = null, lName = null, img = null;
            int bal = 0;
            uint acct = 0, pin = 0;
            
            
            if (String.IsNullOrEmpty(Searchbox.Text))
            {
                MessageBox.Show("Enter a Last Name to search","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            else
            {

                foob.GetValuesForSearch(Searchbox.Text, out acct, out pin, out bal, out fName, out lName, out img);
                fname.Text = fName;
                lname.Text = lName;
                balance.Text = bal.ToString("C");
                Accno.Text = acct.ToString();
                pinNo.Text = pin.ToString("D4");

                BitmapImage btm = new BitmapImage(new Uri(img, UriKind.RelativeOrAbsolute));

                propic.Source = btm;
                propic.Stretch = Stretch.Fill;
            }
        }
    }
}
