namespace Reflection
{
    public sealed class Car
    {
        public Car()
        {
            this.FuelType = "default";
            this.Engine = "default";
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        private string Engine { get; set; }

        public string GetEngine() {
            return this.Engine;
        }

        public void SetEngine(string engineName){
            this.Engine = engineName;
        }

        private string FuelType { get; set; }

        public string GetFuelType(){
            return this.FuelType;
        }

        public void SetFuelType(string fuelType){
            this.FuelType = fuelType;
        }
        
        public Colors Color { get; set; }

        public Wheel[] Wheels { get; set; }

        public Person Driver { get; set; }
    }
}

public class Bmw //: Car
{
    //We cannot inherit a sealed class
}