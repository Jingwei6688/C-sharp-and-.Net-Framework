namespace PackageExpress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Get the package weight from the user
            Console.Write("Please enter the package weight: ");
            int weight = Convert.ToInt32(Console.ReadLine());

            // Check if the package weight exceeds the limit
            if (weight > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                Console.ReadLine();
                return;
            }

            // Get the package dimensions from the user
            Console.Write("Please enter the package width: ");
            int width = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter the package height: ");
            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter the package length: ");
            int length = Convert.ToInt32(Console.ReadLine());

            // Calculate the total dimensions
            int totalDimensions = width + height + length;

            // Check if the total dimensions exceed the limit
            if (totalDimensions > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                Console.ReadLine();
                return;
            }

            // Calculate the shipping quote
            decimal quote = (width * height * length * weight) / 100m;

            // Output the quote, formatted as a USD amount
            Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
            Console.WriteLine("Thank you!");

            // Wait for Enter any key press
            Console.ReadLine();
        }
    }
}
