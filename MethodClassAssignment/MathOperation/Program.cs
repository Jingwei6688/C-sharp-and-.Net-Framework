namespace MathOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathOperationClass mathOperation = new MathOperationClass();
            
            // Call the DoMath method with two integer arguments
            mathOperation.DoMath(5, 10);
            
            mathOperation.DoMath(one:15, two:20);

            Console.WriteLine("\n Press Enter to exit.");
            Console.ReadLine();
        }
    }

    public class MathOperationClass
    {
        // Create a void method that takes two int parameters
        // param one: math operation integer; param two: integer to print
        public void DoMath(int one, int two)
        {
            // take the first integer and multiply it by 3
            int result = one * 3;

            // print the result of the first integer after the math operation
            Console.WriteLine($"The result of param one：{result}");

            // print the second integer
            Console.WriteLine($"This is param two：{two}");
        }
    }
}
