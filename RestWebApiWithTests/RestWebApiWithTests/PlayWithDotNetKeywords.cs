
using RestWebApiWithTests.Services;
using System;

namespace RestWebApiWithTests
{
    public class PlayWithDotNetKeywords
    {
        public PlayWithDotNetKeywords()
        {

            //Static Methods
            //A static method can be called even if the it's containing class is NOT static, BUT I CANNOT CALL IT IF I CREATE AN INSTANCE OF THAT CLASS.
            //A static class is a class which does not need an instance
            Console.WriteLine(PrimeService.Example());
        }
    }
}


//An abstract method need to live in an abstract class, people use Interfaces for that
public abstract class AbstractClassExample
{
    public AbstractClassExample()
    { }

    public int MyProperty { get; set; } //we can have normal properties

    public abstract string AbstractMethod(string something);

    //We can have normal methods in an abstract class
    public string NonAbstractMethod(string something)
    {
        return something + " changed !";
    }
}


public class Person : AbstractClassExample
{

    public string Name { get; set; }

    private static string FamilyName { get; set; }

    private int Age { get; set; }

    protected int GetMyAge()
    {
        return this.Age;
    }

    protected static string GetMyFamilyName()
    {
        return FamilyName;
    }


    //Virtual methods are like abstract methods but they can provide a body with functionality, but the abstract class cannot because it does not have a body
    protected virtual string VirtualMehtodExample()
    {
        return "I am a virtual method !";
    }

    public override string AbstractMethod(string something)
    {
        return "I AM OVERRITTEN BY THE AbstractClassExample";
    }
}

public class User : Person
{
    public new string Name { get; set; }  //Hides the inherited member and sets up a new one

    public User()
    {
        var name = this.Name;

        var familyName = Person.GetMyFamilyName();
    }


    protected override string VirtualMehtodExample()
    {
        return base.VirtualMehtodExample();
    }
}

public class Dog
{
    public string Name { get; set; }  //Hides the inherited member and sets up a new one

    public Dog()
    {
        // Person.         Cannot get the protected static method from Person class
    }

    //override.        Cannot override the protected virtual method because the Don class is not a child of the Person class
}


public static class Names
{

    //Static classes CANNOT have NON STATIC methods

    public const string NamesCount = "3";

    public static string GetNames()
    {
        return "Atanas, Asen, Anton";
    }

    /*
     public string CarsNames() //Static classes CANNOT have NON STATIC methods
    {
        return "BMW, Subaru, Fiat, Mercedes";
    }
     */
}

public class Cars
{
    public const string CarsCount = "4";

    public string CarsNames() //BUT NON Static classes CAN have STATIC methods in them
    {
        return "BMW, Subaru, Fiat, Mercedes";
    }
}