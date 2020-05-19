using System;
using System.Linq;
using System.Reflection;
using Reflection.Attributes.ClassAttributes;
using Reflection.Attributes.MethodAttribute;
using Reflection.Attributes.PropertyAttributes;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //We need an assembly first
            var assembly = Assembly.GetExecutingAssembly(); // gets all the info about the asembly

            Console.WriteLine($"{assembly.FullName} types:");
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine($"Type: {type.FullName} - BaseType: {type.BaseType}"); // ALL CLASSES COME FROM THE Object CLASS TAHT IS THEIR BASE CALSS.
                //With the typestaken from the assembly we can do anything we want.
                Console.WriteLine();

                Console.WriteLine($"-Type properties:");
                foreach (var prop in type.GetProperties())
                {
                    Console.WriteLine($"--Prop name: {prop.Name}");
                    Console.WriteLine($"--Prop type: {prop.PropertyType}");
                    Console.WriteLine($"--Prop is public ? : {prop.PropertyType.IsPublic}");
                    Console.WriteLine($"--Prop is an array ? : {prop.PropertyType.IsArray}");
                    Console.WriteLine();
                }


                Console.WriteLine();
                Console.WriteLine($"-Type fields");
                foreach (var field in type.GetFields())
                {
                    Console.WriteLine($"--Field name: {field.Name}");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine($"-Type interfaces");
                foreach (var @interface in type.GetInterfaces())
                {
                    Console.WriteLine($"--Field interface: {@interface.FullName}");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine($"-Type methods");
                foreach (var method in type.GetMethods())
                {
                    Console.WriteLine($"--Method name: {method.Name}");
                    Console.WriteLine($"--Method IsStatic: {method.IsStatic}");
                    Console.WriteLine($"--Method IsVirtual: {method.IsVirtual}");
                    Console.WriteLine($"--Method IsPrivate: {method.IsPrivate}");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
            }



            Console.WriteLine();
            Console.WriteLine($"/////////////////////////////////////");
            Console.WriteLine($"-Get properties from a .NET object:");
            Person person = new Person() { FirstName = "Atanas", LastName = "Kambitov", Age = 26, Friends = new string[] { "Goshkata", "Rusnaka", "Vankata", "Vladi" } };
            Type personType = typeof(Person); //Once we get the type we can do alot of things with that class.

            string firstNamePropertyValue = personType.GetProperty("FirstName").GetValue(person).ToString();
            string lastNamePropertyValue = personType.GetProperty("LastName").GetValue(person).ToString();
            int agePropertyValue = int.Parse(personType.GetProperty("Age").GetValue(person).ToString());

            Console.WriteLine($"--{firstNamePropertyValue}");
            Console.WriteLine($"--{lastNamePropertyValue}");
            Console.WriteLine($"--{agePropertyValue}");



            Console.WriteLine();
            Console.WriteLine($"/////////////////////////////////////");
            Console.WriteLine($"-Set properties from a .NET object:");

            personType.GetProperty("FirstName").SetValue(person, "NASO");
            string firstNameModified = personType.GetProperty("FirstName").GetValue(person).ToString();
            Console.WriteLine($"-- Old firstName : {firstNamePropertyValue}");
            Console.WriteLine($"-- New firstName : {firstNameModified}");
            Console.WriteLine();

            personType.GetProperty("LastName").SetValue(person, "KILA");
            string lastNameModified = personType.GetProperty("LastName").GetValue(person).ToString();
            Console.WriteLine($"-- New lastName : {lastNamePropertyValue}");
            Console.WriteLine($"-- Old lastName : {lastNameModified}");
            Console.WriteLine();

            personType.GetProperty("Age").SetValue(person, 20);
            string ageModified = personType.GetProperty("Age").GetValue(person).ToString();
            Console.WriteLine($"-- Old age : {agePropertyValue}");
            Console.WriteLine($"-- New age : {ageModified}");
            Console.WriteLine();


            Console.WriteLine($"Execute code from a class by using reflection:");
            var myMethod = personType.GetMethod("PrintFullName");
            myMethod.Invoke(person, null);
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine($"/////////////////////////////////////");
            Console.WriteLine($"-Get and Set private properties from a .NET object:");

            string[] friendsPropertyValue = personType.GetProperty("Friends").GetValue(person) as string[];
            personType.GetProperty("Friends").SetValue(person, new string[] { "DP", "Steve", "Anish", "Swapna" });
            string[] friendsPrivateArrayModified = personType.GetProperty("Friends").GetValue(person) as string[];


            Console.WriteLine($"-Old FriendsArray : ");
            foreach (var oldFriend in friendsPropertyValue)
            {
                Console.WriteLine($"--Old Friend: {oldFriend}");
            }

            Console.WriteLine();

            Console.WriteLine($"-New FriendsArray : ");
            foreach (var newFriend in friendsPrivateArrayModified)
            {
                Console.WriteLine($"--New Friend: {newFriend}");
            }

            Console.WriteLine();
            Console.WriteLine($"/////////////////////////////////////");
            Console.WriteLine("Filter for classes in your assemply by using ATTRIBUTES, this is a goof flexibility trick:");
            //Take the classes which have the MyFirstClassAttr applied
            var classes = assembly.GetTypes().Where(t => t.GetCustomAttributes<MyFirstClassAttr>().Count() > 0);
            Console.WriteLine("Classes which contain the MyFirstClassAttr attribute: " + classes.Count());
            foreach (var classType in classes)
            {
                Console.WriteLine($"Get the methods from attributes:");
                var methods = classType.GetMethods().Where(m => m.GetCustomAttributes<MyFirstMethodAttr>().Count() > 0);
                foreach (var meth in methods)
                {
                    Console.WriteLine($"-Method : {meth.Name}");
                }

                Console.WriteLine($"Get the properties from attributes:");
                var properties = classType.GetProperties().Where(p => p.GetCustomAttributes<MyFirstPropertyAttr>().Count() > 0);
                foreach (var prop in properties)
                {
                    Console.WriteLine($"-Property : {prop.Name}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////");
            Car car = new Car()
            {
                Brand = "Mercedes",
                Model = "Benz",
                Color = Colors.Red,
                Wheels = new Wheel[4],
                Driver = new Person() { FirstName = "Atanas", LastName = "Kambitov", Age = 26, Friends = new string[3] }
            };
            
            var properties2 = car.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties2)
            {
                var carProp = prop.GetValue(car);
                Console.Write(prop.PropertyType.Name + " " + prop.Name + " ");
                Console.WriteLine(carProp.ToString());
            }
            
            //We cannot inherit a sealed class

            Console.WriteLine("Prass any key to exit...");
            Console.ReadKey();
        }
    }
}
