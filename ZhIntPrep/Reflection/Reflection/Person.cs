using Reflection.Attributes.ClassAttributes;
using Reflection.Attributes.MethodAttribute;
using Reflection.Attributes.PropertyAttributes;
using Reflection.Interfaces;

namespace Reflection
{
     [MyFirstClassAttr]
    public class Person : IPerson
    {
        [MyFirstPropertyAttr]
        public string FirstName { get; set; }

        [MyFirstPropertyAttr]
        public string LastName { get; set; }

        [MyFirstPropertyAttr]
        public int Age { get; set; }

        [MyFirstPropertyAttr]
        public string[] Friends { get; set; }

        public Person()
        {}

        [MyFirstMethodAttr]
        public void PrintFullName() {
            System.Console.WriteLine($"My name is: {this.FirstName} {this.LastName}!");
        }

        [MyFirstMethodAttr]
        private void PrintFriends()
        {
            foreach (var friend in this.Friends)
            {
                System.Console.WriteLine($"{friend}");
            }
        }
    }
}
