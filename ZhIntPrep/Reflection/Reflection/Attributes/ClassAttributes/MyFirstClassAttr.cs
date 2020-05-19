using System;

namespace Reflection.Attributes.ClassAttributes
{
    [AttributeUsage(AttributeTargets.Class)] //Only be applyed on the class and NOT on a property
    public class MyFirstClassAttr : Attribute
    {
    }
}
