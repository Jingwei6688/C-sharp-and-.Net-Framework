namespace Module7Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name:");
            string playerName = Console.ReadLine();
            Console.WriteLine("And how much money did you bring with you today?");
            int bank = Convert.ToInt32(Console.ReadLine);
            Console.WriteLine($"Hello, {playerName}. Would you like to join a game of 21 right now?");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes" || answer == "y" || answer == "yeah" || answer == "ya") 
            {
                Player player = new Player(playerName, bank);
                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thank you for playing!");
            }

            Console.WriteLine("Feel free to look around the casino. Bye for now.");
            Console.Read();
        }
    }
}
