using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CassandraemonSample.GetPosts();
            Console.ReadKey();

            DataStaxSample client = new DataStaxSample();
            client.Connect("127.0.0.1");
            client.GetPosts();
            client.Close();
            Console.ReadKey();

            FluentCassandraSample.GetPosts();
            Console.ReadKey();
        }

    }
}
