using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismPractice
{
    // Create a class called Employee that inherits from the Person class and implements the IQuittable interface
    internal class Employee: Person, IQuittable
    {
        // Give the Employee class a property called Id
        public int eId { get; set; }

        // Implement the Quit() method from the IQuittable interface
        public void Quit()
        {
            Console.WriteLine($"{firstName} {lastName} (EmployeeId:{eId}) has quit the job.");
        }
    }
}
