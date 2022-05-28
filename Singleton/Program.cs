using System;
using System.Collections.Generic;

namespace Singleton
{
    public class LoadBalancer
    {
        static LoadBalancer instance;
        List<string> servers = new List<string>();
        Random random = new Random();

        private static object locker = new object();

        public LoadBalancer()
        {
            servers.Add("Server 1");
            servers.Add("Server 2");
            servers.Add("Server 3");
            servers.Add("Server 4");
            servers.Add("Server 5");
        }

        public string Server { 
            get 
            {
                int r = random.Next(servers.Count);
                return servers[r].ToString();
            } 
        }

        public static LoadBalancer GetLoadBalancer() 
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if(instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }
            }
            return instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            if(b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for(int i=0; i<15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Request to: "+server);
            }
        }
    }
}
