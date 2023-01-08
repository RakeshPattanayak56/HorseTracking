// See https://aka.ms/new-console-template for more information

Console.WriteLine("---***Wel Come To Horse Track Programming***---\n");
Console.WriteLine("---***Enter the action to be performed***---\n");
Console.WriteLine("\t Press 'A' or 'a' - Inventory and Horses");
Console.WriteLine("\t Press 'C' or 'c' - Current Inventory ");
Console.WriteLine("\t Press 'R' or 'r' - Restocks the cash inventory");
Console.WriteLine("\t Press 'W' or 'w' - Check Horses");
Console.WriteLine("\t Press 'Q' or 'q' - Quit the application");

Console.WriteLine("*********************************************");
Console.WriteLine("Enter your command: ");
int[] id = { 1, 2, 3, 4, 5, 6, 7 };
string[] horses = { "That Darn Gray Cat", "Fort Utopia", "Count Sheep", "Ms Traitour", "Real Princess", "Pa Kettle", "Gin Stinger" };
int[] odds = { 5, 10, 9, 4, 3, 5, 6 };
int[] denomination = new int[] { 100,20,10,5,1 };
int[] inventory1 = { 10, 10, 10, 10, 10 };
int[] inventory = new int[5];
int amount = 136;
string choice;



while (true)
{
    choice = string.Concat(Console.ReadLine());
    if (choice == "A" || choice == "R" || choice == "W" || choice == "Q" || choice == "C")
    {
        Console.WriteLine();
    }
    else if (choice != "A")
    {
        Console.WriteLine("\n Invalid Command:{0}", choice);
    }
    else if (choice != "W")
    {
        Console.WriteLine(" \n Invalid Horse Number:{0}", choice);
    }
    else if (choice != "R")
    {
        Console.WriteLine(" \n No Payout:{0} ", choice);
    }
    else
    {
        Console.WriteLine("\n Invalid Command:{0}", choice);
    }

    switch (choice)
    {
        case "C":
            Console.WriteLine("\n Current Inventory is : {0} ", amount);
            for (int i = 0; i < denomination.Length; i++)
            {
                Console.WriteLine(denomination[i] + "$" + "," + inventory1[i]);
            }
            Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
            break;

        case "A":
            Console.WriteLine("\n Inventory :");
            for (int i = 0; i < denomination.Length; i++)
            {
                Console.WriteLine(denomination[i] + "$" + "," + inventory1[i]);
            }
            Console.WriteLine("\n Horses: ");
            for (int i = 0; i < id.Length; i++)
            {
                Console.WriteLine(id[i] + "," + horses[i] + "," + odds[i]);
            }
            Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
            break;

        case "R":
            for (int i = 0; i < 5; i++)
            {
                if (amount >= denomination[i])
                {
                    inventory[i] = amount / denomination[i];
                    amount = amount % denomination[i];
                }
            }
            Console.WriteLine("Current Inventory", amount);
            for (int i = 0; i < 5; i++)
            {
                    Console.WriteLine(denomination[i]+"$" + "," + inventory[i]);
            }
            Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
            break;

        case "W":
            Console.WriteLine("\n Horses: ");
            for (int i = 0; i < id.Length; i++)
            {
                Console.WriteLine(id[i] + "," + horses[i] + "," + odds[i]);
            }
            Console.WriteLine("\t\t PLEASE ENTER THE COMMAND");
            break;

        case "Q":
            Console.WriteLine("\t\t THANKS FOR USING OUT ATM SERVICE");
            break;

    }
}

