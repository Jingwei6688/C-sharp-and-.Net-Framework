using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismPractice
{
    // Create a class called Person with two properties: firstName and lastName
    // and a method called SayName()
    internal class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public void SayName()
        {
            Console.WriteLine($"Name: {firstName} {lastName}");
        }
    }
}
