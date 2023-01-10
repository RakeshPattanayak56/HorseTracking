internal class Program
{
    static int[] id = { 1, 2, 3, 4, 5, 6, 7 };
    static string[] horses = { "That Darn Gray Cat", "Fort Utopia", "Count Sheep", "Ms Traitour", "Real Princess", "Pa Kettle", "Gin Stinger" };
    static int[] odds = { 5, 10, 9, 4, 3, 5, 6 };
    static int[] denomination = new int[] { 100, 20, 10, 5, 1 };
    static int[] inventory1 = { 10, 10, 10, 10, 10 };
    static int[] inventory = { 10, 10, 10, 10, 10 };
    static int[] restockInventory = { 10, 10, 10, 10, 10 };
    static int winner = 1;
    static string choice = "";
    static bool retry = false;
    private static void Initial()
    {

        Console.WriteLine("---***Wel Come To Horse Track Programming***---\n");
        Console.WriteLine("---***Enter the action to be performed***---\n");
        Console.WriteLine("\t Press 'C' or 'c' - Current Inventory and Horses");
        Console.WriteLine("\t Press 'R' or 'r' - Restocks the cash inventory");
        Console.WriteLine("\t Press 'W' or 'w' - Check Horses");
        Console.WriteLine("\t Press 'B' or 'b' - getting into the application");
        Console.WriteLine("\t Press 'Q' or 'q' - Quit the application");

        Console.WriteLine("*********************************************");
        Console.WriteLine("Enter your command: ");
    }
    private static void Main(string[] args)
    {
        Initial();
        try
        {
            do
            {
                choice = Console.ReadLine().ToUpper();
                if (choice == "A" || choice == "R" || choice == "W" || choice == "Q" || choice == "C" || choice == "B")
                {
                    Console.WriteLine("\n Taking you into the application:{0}", choice);
                }
                //else if (choice != "A")
                //{
                //    Console.WriteLine("\n Invalid Command:{0}", choice);
                //}
                //else if (choice != "W")
                //{
                //    Console.WriteLine(" \n Invalid Horse Number:{0}", choice);
                //}
                //else if (choice != "R")
                //{
                //    Console.WriteLine(" \n No Payout:{0} ", choice);
                //}
                else
                {
                    Console.WriteLine("\n Invalid Command:{0}", choice);
                    Environment.Exit(0);
                }

                switch (choice)
                {
                    case "C":
                        PrintHorseAndInventory(winner);
                        retry = true;
                        break;
                    case "R":
                        Console.WriteLine("Current Inventory: ");
                        for (int i = 0; i < 5; i++)
                        {
                            inventory[i] = restockInventory[i];
                            inventory1[i] = restockInventory[i];
                            Console.WriteLine(denomination[i] + "$" + "," + inventory[i]);
                        }
                        Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
                        retry = true;
                        break;

                    case "W":
                        Console.WriteLine("Please enter a number for updating the winner horse: ");
                        winner = Convert.ToInt32(Console.ReadLine());
                        PrintHorseAndInventory(winner);
                        retry = true;
                        break;

                    case "Q":
                        Console.WriteLine("\t\t THANKS FOR USING OUR SERVICE");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please bet the horse number followed by the bet Amount: ");
                        int expectedWinnerHorse = int.Parse(Console.ReadLine());
                        int betAmount = 0;
                        string betInput = "";
                        try
                        {
                            betInput = Console.ReadLine();
                            betAmount = int.Parse(betInput);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid bet, please enter integer only {0}", betInput);
                            Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
                            break;
                        }
                        if (expectedWinnerHorse == winner)
                        {
                            int winningAmount = betAmount * odds[winner - 1];
                            Console.WriteLine("Payout: {0},{1}", horses[expectedWinnerHorse - 1], winningAmount);
                            Console.WriteLine("Dispensing:");
                            for (int i = 0; i < 5; i++)
                            {
                                if (winningAmount >= denomination[i])
                                {
                                    inventory[i] = winningAmount / denomination[i];
                                    winningAmount = winningAmount % denomination[i];
                                    inventory1[i] = inventory1[i] - inventory[i];
                                }
                                else
                                {
                                    inventory[i] = 0;
                                }

                                if (inventory1[i] < 0)
                                {
                                    Console.WriteLine("Inventory is out of stock");
                                    break;
                                }
                                Console.WriteLine(denomination[i] + "$" + "," + inventory[i]);
                            }
                            Console.WriteLine("Current Inventory");
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine(denomination[i] + "$" + "," + inventory1[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Payout: " + horses[expectedWinnerHorse - 1]);
                        }
                        Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
                        retry = true;
                        break;
                }
            }
            while (retry);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid command");
            Environment.Exit(0);
        }
    }

    static void PrintHorseAndInventory(int winner)
    {
        Console.WriteLine("\n Inventory :");
        for (int i = 0; i < denomination.Length; i++)
        {
            Console.WriteLine(denomination[i] + "$" + "," + inventory[i]);
        }
        Console.WriteLine("\n Horses: ");
        for (int i = 0; i < id.Length; i++)
        {
            string isWinner = (i == (winner - 1)) ? "won" : "lost";
            Console.WriteLine(id[i] + "," + horses[i] + "," + odds[i] + ", " + isWinner);
        }
        Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
    }
}