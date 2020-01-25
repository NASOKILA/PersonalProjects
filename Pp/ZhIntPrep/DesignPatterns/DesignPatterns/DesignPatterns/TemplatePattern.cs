
namespace DesignPatterns.DesignPatterns
{
    public class TemplatePattern
    {
        public static void ExecuteExample()
        {
            CustomerDataLayer customerDataLayer = new CustomerDataLayer();
            customerDataLayer.ProcessOperation();
        }
    }

    //I have an abstract class which defines some steps to follow to complete some operation.
    public abstract class DataLayer
    {
        public abstract void Open();

        public abstract void Execute();

        public abstract void Close();

        public void ProcessOperation()
        {
            Open();
            Execute();
            Close();
        }
    }

    //We can override the individual steps without changing the algorithm structure
    public class CustomerDataLayer : DataLayer
    {
        public override void Open()
        {
            System.Console.WriteLine("Opening...");
        }

        public override void Execute()
        {
            System.Console.WriteLine("Execute...");
        }

        public override void Close()
        {
            System.Console.WriteLine("Closing...");
        }

    }
}

/*
    It was very used in the beginning of the 2000 ts.

    We have some steps which have been defined by the parent class which nobody can change.
    But we can override certain logic of those steps.

    Lets say we have a sequence of steps to perform an opertaiton.
    We can override the individual steps without changing the algorithm structure.  
    
    The structure is the same but we can override and change every individual step.
    That is it.

*/
