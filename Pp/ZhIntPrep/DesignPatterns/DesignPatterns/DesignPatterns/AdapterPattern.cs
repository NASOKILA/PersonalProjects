namespace DesignPatterns.DesignPatterns
{
    public class AdapterPattern
    {
        public static void ExecuteExample()
        {
            IExport exportW = new WordExport();
            exportW.Save();

            IExport exportE = new ExcelExport();
            exportE.Save();

            //We call the adapter class which makes the PdfExport service compatible with our convention.
            IExport exportP = new PdfAdapter();
            exportP.Save();

            //Class adapter pattern it ingherits the third party class and our interface
            IExport exportD = new DocsExport();
            exportD.Save();
        }
    }

    public interface IExport
    {
        void Save();
    }

    public class WordExport : IExport
    {
        public void Save()
        {
            System.Console.WriteLine("Word document saved !");
        }
    }

    public class ExcelExport : IExport
    {
        public void Save()
        {
            System.Console.WriteLine("Excel document saved !");
        }
    }

    //Third party export service wich does not match with our convention and we cannot change it.
    public class PdfExport 
    {
        //It does not implement our interface and it does not have a Save function meaning it is incompatible with our sistem.
        public void Export()
        {
            System.Console.WriteLine("Pdf document saved from a third party service!");
        }
    }

    //Class adapter pattern - it inherit both the third party class and our interface
    public class DocsExport : PdfExport, IExport
    {
        public void Save()
        {
            this.Export();
            System.Console.WriteLine("Docs document exported !");
        }
    }

    public class PdfAdapter : IExport
    {
        public void Save()
        {
            PdfExport pdfExport = new PdfExport();
            pdfExport.Export();
            System.Console.WriteLine("Pdf document exported from the adapter!");
        }
    }
}



/*
    Addapter Pattern : It is a very simple pattern.
         For this examle we have 2 export classes implementing the same interface, they both have a Save() function.

         And a third class which we immagine it comes from a third party service, it does not implement our interface and we cannot touch it and it does not
         have a Save() function but it has an Export() one.

        In this case interfaces are incompatible, it is like the plugin wall when you go to another country, you need an adapter to get electricity.

        In this scenarion we create an ADAPTER class which will inherit our interface and it will take the Pdf from that 3rd party service and return it.
*/