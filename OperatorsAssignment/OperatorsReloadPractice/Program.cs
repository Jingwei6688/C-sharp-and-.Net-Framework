namespace OperatorsReloadPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create two Employee objects and assign values to their properties
            Employee emp1 = new Employee { eName = "John", eID = 1001 };
            Employee emp2 = new Employee { eName = "Jane", eID = 1002 };

            // use the overloaded == operator
            bool twoObjIsEqual = emp1 == emp2;

            // use the overloaded != operator
            bool twoObjIsNotEqual = emp1 != emp2;

            // print the results
            Console.WriteLine($"Are emp1 and emp2 equal? {twoObjIsEqual}");
            Console.WriteLine($"Are emp1 and emp2 not equal? {twoObjIsNotEqual}");

            // change the emp2's eID to match emp1's eID
            emp2.eID = 1001;
            bool twoObjIsEqualAfterChange = emp1 == emp2;
            Console.WriteLine($"Are emp1 and emp2 equal after change? {twoObjIsEqualAfterChange}");

        }
    }
}
