﻿namespace Reflection.Interfaces
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        int Age { get; set; }

        void PrintFullName();
    }
}
