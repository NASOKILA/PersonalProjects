using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Redistest
{
    public class Program
    {

        /*
            Redis is a way to store data in the catche. It can be used as an in memory NON-RELATIONAL database ( like monog db ).
            It can be used as a keyvault where we have a key value pair way to store and retreive data.
            
            WE ONLY NEED TO SET THINGS ONCE, AND THEN THEY WILL STAY IN MEMORY.
        */



        //Access cache redis connection string
        private static IConfigurationRoot Configuration { get; set; }

        const string SecretName = "atanas.redis.cache.windows.net:6380,password=j0sjnVBWne9T2TXUMuI5uNwYzZdw5Y7fW7KulKwMO9w=,ssl=True,abortConnect=False";

        private static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>();

            Configuration = builder.Build();
        }

        //Connect to the redis cache
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = Configuration[SecretName];
            return ConnectionMultiplexer.Connect(SecretName);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        static void Main(string[] args)
        {
            InitializeConfiguration();

            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            IDatabase cache = lazyConnection.Value.GetDatabase();

            // Perform cache operations using the cache object...

            // Simple PING command
            string cacheCommand = "PING";
            Console.WriteLine("\nCache command  : " + cacheCommand);
            Console.WriteLine("Cache response : " + cache.Execute(cacheCommand).ToString());

            Console.WriteLine();

            // Simple get and put of integral data types into the cache
            cacheCommand = "GET Message";
            Console.WriteLine("\nCache command  : " + cacheCommand + " or StringGet()");
            Console.WriteLine("Cache response : " + cache.StringGet("Message").ToString());

            Console.WriteLine();

            Console.WriteLine("SET Message 'Atanas first redis chatche message!'");
            Console.WriteLine("Cache response : " + cache.StringSet("Message", "Atanas first redis chatche message").ToString());

            Console.WriteLine();

            // Demonstrate "SET Message" executed as expected...
            Console.WriteLine("GET Message 'Atanas first redis chatche message!'");
            Console.WriteLine("Cache response : " + cache.StringGet("Message").ToString());

            Console.WriteLine();

            
            Console.WriteLine("SET Message 'I am coming switzerland!'");
            Console.WriteLine("Cache response : " + cache.StringSet("Switzerland", "I am coming switzerland!").ToString());

            Console.WriteLine();

            // Demonstrate "SET Message" executed as expected...
            Console.WriteLine("GET Message 'I am coming switzerland!'");
            Console.WriteLine("Cache response : " + cache.StringGet("Switzerland").ToString());

            Console.WriteLine();

            Console.WriteLine(cache.Database.ToString());
            // Get the client list, useful to see if connection list is growing...
            cacheCommand = "CLIENT LIST";
            Console.WriteLine("\nCache command  : " + cacheCommand);
            Console.WriteLine("Cache response : \n" + cache.Execute("CLIENT", "LIST").ToString().Replace("id=", "id="));

            Console.WriteLine();
            

            // Store .NET object to cache
            //Employee e007 = new Employee("007", "Davide Columbo", 100);
            //string serializedEmployeeObject = JsonConvert.SerializeObject(e007);
            //Console.WriteLine("Cache response from storing Employee .NET object : " +
            //    cache.StringSet("e007", serializedEmployeeObject));

            Console.WriteLine();

            // Retrieve .NET object from cache
            Employee e007FromCache = JsonConvert.DeserializeObject<Employee>(cache.StringGet("e007"));
            Console.WriteLine("Deserialized Employee .NET object :\n");
            Console.WriteLine("\tEmployee.Name : " + e007FromCache.Name);
            Console.WriteLine("\tEmployee.Id   : " + e007FromCache.Id);
            Console.WriteLine("\tEmployee.Age  : " + e007FromCache.Age + "\n");

            Console.WriteLine();

            lazyConnection.Value.Dispose();

            Console.WriteLine("Press a key to exit !");
            Console.ReadKey();
        }
    }
}
