namespace PolymorphismPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Employee class and assign values to its properties
            Employee employee = new Employee();
            employee.firstName = "Jingwei";
            employee.lastName = "Li";
            employee.eId = 12345;

            // Call the Quit method on the Employee instance
            IQuittable iqt = employee;
            iqt.Quit();

            Console.ReadLine();
        }
    }
}
