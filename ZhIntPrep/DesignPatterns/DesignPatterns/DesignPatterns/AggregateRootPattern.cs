using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.DesignPatterns
{
    public static class AggregateRootPattern 
    {
        public static void ExecuteExample() {
            Customer customer = new Customer();
            customer.AddAddress(new Address() { Type = 1, StreetName = "Hugh Road 98" });
            customer.AddAddress(new Address() { Type = 2, StreetName = "Wallsgrave Road 102" });
            
            //customer.AddAddress(new Address() { Type = 1, StreetName = "Hugh Road 96" }); //It will throw exeption
        }

        class Customer
        {
            private List<Address> Addresses { get; set; }

            public Customer()
            {
                this.Addresses = new List<Address>();
            }

            public void AddAddress(Address address)
            {
                if (this.Addresses.Any(ad => ad.Type == address.Type))
                {
                    throw new ArgumentException("Address is already been added.");
                }

                Addresses.Add(address);
                Console.WriteLine($"Address [{address.Type}, {address.StreetName}] added!");
            }
        }

        class Address
        {
            public int Type { get; set; }

            public string StreetName { get; set; }
        }
    }
}

/*
    Comments:

    Aggregate root pattern - This is where for exampele we want to add something to a collection in a class, we set the collection to be a private field
        and then we create a public method which when called it will add an item to that private collection property.

        The Aggregate root is the Class itself which is responsible for aggregating - adding the items to the collection. 
        If we add the same object we will throw an exeption.

        This pattern is used everywhere.
*/
