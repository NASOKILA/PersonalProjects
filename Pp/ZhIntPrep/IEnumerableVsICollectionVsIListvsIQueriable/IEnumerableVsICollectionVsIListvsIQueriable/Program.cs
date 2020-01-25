using System;
using System.Collections.Generic;

namespace IEnumerableVsICollectionVsIListvsIQueriable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    
    class EnumerableTest
    {
        public IEnumerable<string> MyIEnumerable { get; set; } = new string[] { };

        public void Test()
        {
            
        }
    }
}

/*
ICollection vs IEnumarable vs IList vs IQueriable:
	They all have separate functionalities good for certain different scenarious.
	
	01.IEnumerable - is the most basic one, it does not provide any CRUD operations apart from the indexes for enumeration, 
		not even the count itself so weneed to iterate to each element to get the total count. It comes from System.Collections

	02.ICollection - is the one that derives from IEnumerable but it has Add, remove and update in the collection and it holds the count. 
		It comes from System.Collections
		
	03.IList - It extends ICollection which in itself extends IEnumerable. IList can use all of the operations provided by IEnumerable
		and ICollection plus some additional operations about inserting or removing elements in the middle of the list.
		We can use a foreach loop as a for loop to iterate over the elements in the list. It comes from System.Collections

	04.IQueryable - It extends IEnumerable and it is used to generate LINQ to SQL so it can be used in the database layer to 
		get data. It comes from System.Linq
*/
