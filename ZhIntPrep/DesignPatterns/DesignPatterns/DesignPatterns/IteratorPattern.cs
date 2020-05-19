using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.DesignPatterns
{
    public static class IteratorPattern
    {
        public static void ExecuteExample()
        {
            Customer customer = new Customer();
            customer.AddAddress(new Address() { Type = 1, StreetName = "Hugh Road 98" });
            customer.AddAddress(new Address() { Type = 2, StreetName = "Wallsgrave Road 102" });

            var addresses = customer.GetAddresses(); // BY DOING THIS WE ONLY GET ASSESS FOR ITERATION, NOTHING MORE
            foreach (var item in addresses)
            {
                Console.WriteLine($"{item.Type} {item.StreetName}!");
            }
        }

        class Customer
        {
            private List<Address> Addresses { get; set; }

            public Customer()
            {
                this.Addresses = new List<Address>();
            }

            public IEnumerable<Address> GetAddresses()
            {
                return this.Addresses;
            }

            public void AddAddress(Address address)
            {
                Addresses.Add(address);
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
    Most people think the iterator design pattern is just a foreach loop  !!!
    When a lsit is set as private in a class you cannot read it ( UNLESS YOU USE REFLECTION ) we need to use an 
    IEnumerable getter to just be able to iterate the collection.

        Use IEnumerable if you want the outsite user of that collectiuon to have less options to work with. 
        If we use .ToList() we will give the user more options to choose with which he can work with our class.

        List<> comes from IEnumerable.

    The Aggreagate root and the Iterator design patterns are connected, because we need to have an aggregate object meaning we need to have an aggragate root.
    The Iterator Pattern needs to have an Aggregate object.

    IList provides more methods than List

*/