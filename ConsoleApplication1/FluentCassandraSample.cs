using FluentCassandra;
using System;
using System.Linq;
using FluentCassandra.Types;

namespace ConsoleApplication1
{
    public class FluentCassandraSample
    {
        public static void GetPosts()
        {
            Console.WriteLine("Getting posts with FluentCassandraSample...");

            using (var db = new CassandraContext(keyspace: "blog", host: "localhost"))
            {
                var family = db.GetColumnFamily("posts");

                var getPost = family.Get("2").FirstOrDefault();
                var user = getPost.GetColumn("user").ColumnValue.ToString();
                var text = getPost.GetColumn("text").ColumnValue.ToString();
                Console.WriteLine(string.Format("User: {0}\tText: {1}", user, text));

            }
        }
    }
}