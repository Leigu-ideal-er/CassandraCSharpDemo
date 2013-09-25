using System;
using System.Collections.Generic;
using System.Linq;
using Cassandraemon;
using Apache.Cassandra;

namespace ConsoleApplication1
{
    public class CassandraemonSample
    {
        public static void GetPosts()
        {
            Console.WriteLine("Getting posts with Cassandraemon...");

            using (var context = new CassandraContext(
                "127.0.0.1", 9160, "blog"))
            {
                CassandraEntity<List<Column>> last = null;
                IQueryable<CassandraEntity<List<Column>>> entities;

                var posts = (from x in context.ColumnList
                             where x.ColumnFamily == "posts" &&
                                   x.Column == "user"
                             select x.ToObject<Post>()).Reverse();

                foreach (var post in posts)
                {
                    Console.WriteLine(string.Format(
                       "User: {0}\tText: {1}",
                        post.user,
                        post.text));
                }
            }
        }
    }
}