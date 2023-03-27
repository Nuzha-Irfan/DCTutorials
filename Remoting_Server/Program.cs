﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Remoting_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //This should *definitely* be more descriptive.
                Console.WriteLine("hey so like welcome to my server");
                //This is the actual host service system
                ServiceHost host;
                //This represents a tcp/ip binding in the Windows network stack
                NetTcpBinding tcp = new NetTcpBinding();


                //Bind server to the implementation of DataServer
                host = new ServiceHost(typeof(dataServer_implementation));

                host.AddServiceEndpoint(typeof(data_Server), tcp, "net.tcp://0.0.0.0:8100/StudentService");
                //And open the host for business!
                host.Open();
                Console.WriteLine("System Online");
                Console.ReadLine();
                //Don't forget to close the host after you're done!
                host.Close();

            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                Console.ReadLine();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
                Console.Read();

            }
            catch (Exception e)
            {
                Console.WriteLine("The error is" + e);
                Console.ReadLine();
            }
        }
    }
    
}
