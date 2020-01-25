using System;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test test = new Test();
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
        public class SampleClassAttribute : Attribute
        {
            public string name { get; set; }
            public int age { get; set; }
        }

        [AttributeUsage(AttributeTargets.Method)]
        public class SampleMethodAttribute : Attribute
        {
        }
        
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
        public class SamplePropertyOrFiedAttribute : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Constructor)]
        public class SampleConstructorAttribute : Attribute
        {
        }

        [SampleClass(name ="Atanas", age =20)]
        public class Test
        {
            [SampleConstructor]
            public Test()
            {}

            [SamplePropertyOrFied]
            public int IntProperty { get; set; }

            //Field
            [SamplePropertyOrFied]
            private int _number;

            //Property for that field
            [SamplePropertyOrFied]
            public int Number
            {
                get { return _number; }
                set { _number = value; }
            }

            [SampleMethod]
            public void MyMethod() { }
        }
    }
}
