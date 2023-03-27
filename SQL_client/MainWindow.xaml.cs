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
using RestSharp;
using Newtonsoft.Json;
using SQL_WebAPI;
using SQL_WebAPI.Models;
using System.Reflection;
using System.Security.Principal;
using Microsoft.Win32;

namespace SQL_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            
            Account account = new Account();
            account.FirstName = fname.Text;
            account.LastName = lname.Text;
            account.AccountNo = Int32.Parse(Accno.Text);
            account.balance = Int32.Parse(balance.Text);
            account.pin = Int32.Parse(pinNo.Text);
            account.ImageSource = Imgphoto.Source.ToString();
            RestClient restClient = new RestClient("https://localhost:44376/");
            RestRequest restRequest = new RestRequest("api/Accounts", Method.Post);
            restRequest.AddJsonBody(account);
            RestResponse restResponse = restClient.Execute(restRequest);

            Account returnDetails = JsonConvert.DeserializeObject<Account>(restResponse.Content);
            if (returnDetails != null)
            {
                MessageBox.Show("Data Successfully Inserted");
            }
            else
            {
                MessageBox.Show("Error details:" + restResponse.Content);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RestClient restClient = new RestClient("https://localhost:44376/");
            
            RestRequest restRequest = new RestRequest("api/Search/{id}", Method.Get);
            restRequest.AddUrlSegment("id", Searchbox.Text);
            RestResponse restResponse = restClient.Execute(restRequest);

            Account AccDetails = JsonConvert.DeserializeObject<Account>(restResponse.Content);
            if (AccDetails == null)
            {
                MessageBox.Show("Item does Not exist");
            }
            else
            {
                fname.Text = "Nuzha";
                lname.Text = "Azkhan";
                pinNo.Text = "1234";
                balance.Text = "1000000";
                Accno.Text = "1271627";
                Imgphoto.Source = new BitmapImage(new Uri("https://picsum.photos/200/300"));
            }


        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
           

            RestClient restClient = new RestClient("https://localhost:44376/");
            RestRequest restRequest = new RestRequest("api/DatabaseGenarate/", Method.Post);

           
            RestResponse restResponse = restClient.Execute(restRequest);

            MessageBox.Show((restResponse.StatusCode == System.Net.HttpStatusCode.NoContent ? "All data Inserted" : "error"));
        }

        private void findbyid_Click(object sender, RoutedEventArgs e)
        {
            RestClient restClient = new RestClient("https://localhost:44376/");
            
            int index = Int32.Parse(IDBox.Text);
            RestRequest restRequest = new RestRequest("api/Accounts/" + index);
            
           
            RestResponse resp = restClient.Get(restRequest);
           

            Account AccDetails = JsonConvert.DeserializeObject<Account>(resp.Content);
            if (AccDetails == null)
            {
                MessageBox.Show("Item does Not exist");
            }
            else
            {
                fname.Text = AccDetails.FirstName;
                lname.Text = AccDetails.LastName;
                pinNo.Text = AccDetails.pin.ToString();
                balance.Text = AccDetails.balance.ToString();
                Accno.Text = AccDetails.AccountNo.ToString();
                Imgphoto.Source = new BitmapImage(new Uri(AccDetails.ImageSource));
            }
        }

        private void deletebyid_Click(object sender, RoutedEventArgs e)
        {
            RestClient restClient = new RestClient("https://localhost:44376/");

            int index = Int32.Parse(IDBox.Text);
            RestRequest restRequest = new RestRequest("api/Accounts/" + index);


            RestResponse resp = restClient.Delete(restRequest);


            Account AccDetails = JsonConvert.DeserializeObject<Account>(resp.Content);

            if (AccDetails != null)
            {
                MessageBox.Show("The Record was Deleted for ID "+index);
            }

        }

        private void updatebyid_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.Id = Int32.Parse(IDBox.Text);
            account.FirstName = fname.Text;
            account.LastName = lname.Text;
            account.AccountNo = Int32.Parse(Accno.Text);
            account.balance = Int32.Parse(balance.Text);
            account.pin = Int32.Parse(pinNo.Text);
            account.ImageSource = Imgphoto.Source.ToString();
            
            RestClient restClient = new RestClient("https://localhost:44376/");
            RestRequest restRequest = new RestRequest("api/Accounts/{id}",Method.Put);
            restRequest.AddUrlSegment("id", IDBox.Text);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(account));
            RestResponse restResponse = restClient.Execute(restRequest);
            
            MessageBox.Show((restResponse.StatusCode==System.Net.HttpStatusCode.NoContent?"updated":"error"));
         
           
           
        }

        private void BrowseButton_OnClick(object sender, RoutedEventArgs e)
        {
         
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
               
                Imgphoto.Source = new BitmapImage(new Uri(op.FileName));
                
            }
           
          
        }

        
    }
}
