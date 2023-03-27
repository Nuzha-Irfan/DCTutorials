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
using Newtonsoft.Json;
using RestSharp;
using System.ServiceModel;
using API_classes;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using Microsoft.SqlServer.Server;

namespace Web_APi_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RestClient client;
        public MainWindow()
        {
            InitializeComponent();
            Uri uri;
            
            uri = new Uri ("http://localhost:64355/");
            client = new RestClient(uri);
            RestRequest request = new RestRequest("api/Values");
            RestResponse numOfThings = client.Get(request);
            total.Text = numOfThings.Content;
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            //On click, Get the index....
            int index = Int32.Parse(indexNo.Text);
            //Then, set up and call the API method...
            RestRequest request = new RestRequest("api/GetValues/" +index);
            RestResponse resp = client.Get(request);
            //And now use the JSON Deserializer to deseralize our object back to the class we want
            API_classes.DataIntermed dataIntermed = JsonConvert.DeserializeObject<API_classes.DataIntermed>(resp.Content);
            //And now, set the values in the GUI!
            fname.Text = dataIntermed.fname;
            lname.Text = dataIntermed.lname;
            balance.Text = dataIntermed.bal.ToString("C");
            Accno.Text = dataIntermed.acct.ToString();
            pinNo.Text = dataIntermed.pin.ToString("D4");
            BitmapImage btm = new BitmapImage(new Uri(dataIntermed.img));

            propic.Source = btm;
            propic.Stretch = Stretch.Fill;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Make a search class
            API_classes.searchData mySearch = new API_classes.searchData();
            mySearch.searchStr = Searchbox.Text;
            //Build a request with the json in the body
            RestRequest request = new RestRequest("api/Search/",Method.Post);

            
            request.AddJsonBody(mySearch);
            //Do the request
            RestResponse resp = client.Execute(request);
            //Deserialize the result
            API_classes.DataIntermed dataIntermed =JsonConvert.DeserializeObject<API_classes.DataIntermed>(resp.Content);
            //aaaaand input the data
            if (dataIntermed == null)
            {
                MessageBox.Show("Please Enter a Valid Name", "Message", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            else
            {
                fname.Text = dataIntermed.fname;
                lname.Text = dataIntermed.lname;
                balance.Text = dataIntermed.bal.ToString("C");
                Accno.Text = dataIntermed.acct.ToString();
                pinNo.Text = dataIntermed.pin.ToString("D4");

                BitmapImage btm = new BitmapImage(new Uri("https://picsum.photos/200/300"));

                propic.Source = btm;
                propic.Stretch = Stretch.Fill;

            }


            
        }

    }
}
