using System;
using System.Collections.Generic;
using System.Linq;
using Cassandra;

namespace ConsoleApplication1
{   
    public class DataStaxSample
    {
        private Cluster _cluster;

        public Cluster Cluster { get { return _cluster; } }

        private Session _session;

        public Session Session { get { return _session; } }

        public void GetPosts()
        {
            Console.WriteLine("Getting posts with DataStaxSample...");
            _session = _cluster.Connect("blog");
            RowSet results = _session.Execute("SELECT * FROM posts;");

            foreach (Row row in results.GetRows())
            {
                var user = row.GetValue<String>("user");
                var text = row.GetValue<String>("text");
                Console.WriteLine("{0} : {1}", user, text);
            }
        }

        public void Connect(String node)
        {
            _cluster = Cluster.Builder()
                .AddContactPoint(node).Build();
            Metadata metadata = this.Cluster.Metadata;
            Console.WriteLine("Connected to cluster: "
                + metadata.ClusterName.ToString());
        }

        public void Close()
        {
            this.Cluster.Shutdown(); 
        }
    }
}