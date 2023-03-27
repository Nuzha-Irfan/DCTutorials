using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API_classes;
namespace WebAPI.Models
{
    public class AccountList
    {
        public static List<DataIntermed> AllData()
        {
            DataIntermed data = new DataIntermed();
            DataIntermed data1 = new DataIntermed();
            DataIntermed data2 = new DataIntermed();
            DataIntermed data3 = new DataIntermed();

            List<DataIntermed> dataList = new List<DataIntermed>();
            data.acct = 123456789;
            data.fname = "James";
            data.lname = "parker";
            data.bal = 1500000;
            data.pin = 1234;
            data.img = "https://random.imagecdn.app/500/150";

            dataList.Add(data);

            data1.acct = 2357842249;
            data1.fname = "Andrew";
            data1.lname = "Garfield";
            data1.bal = 123400000;
            data1.pin = 1334;
            data1.img = "https://random.imagecdn.app/500/150";

            dataList.Add(data1);


            data2.acct = 123464322;
            data2.fname = "Nuzha";
            data2.lname = "Irfan";
            data2.bal = 1872000000;
            data2.pin = 12212;
            data2.img = "https://random.imagecdn.app/500/150";

            dataList.Add(data2);


            data3.acct = 1233211223;
            data3.fname = "James";
            data3.lname = "Bond";
            data3.bal = 12300000;
            data3.pin = 1221;
            data3.img = "https://random.imagecdn.app/500/150";

            dataList.Add(data3);

            return dataList;
        }


        


    }
}