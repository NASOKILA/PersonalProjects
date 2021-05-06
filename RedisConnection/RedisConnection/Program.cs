using System;
using StackExchange.Redis;

namespace RedisConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase database = lazyConnection.Value.GetDatabase();

            //Console.WriteLine(database.StringGet("Employee"));
            //database.StringSet("Employee", "Hey This is an employee");
            //Console.WriteLine(database.StringGet("Employee"));
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection =
            new Lazy<ConnectionMultiplexer>(() => 
            {
                string connectionString = "codewithatanas.redis.cache.windows.net:6380,password=odFa0uOhgwlTkcgxsc2hHsaTmSQabMrV36HV6jh8L8Q=,ssl=True,abortConnect=False";
                return ConnectionMultiplexer.Connect(connectionString);
            });

        public static ConnectionMultiplexer Connection 
        {
            get 
            {
                return lazyConnection.Value;
            }
        }
    }
}
