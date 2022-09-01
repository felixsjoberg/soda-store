using System;

// Struct that holds sodas name and price
public struct theCrate
{
    public string name;
    public double price;
}

public class SodaCrate
{
    // Array holding all the sodas in the crate
    public static theCrate[] Crate = new theCrate[12];
    public static int numberCans = 0;

    // Method crate menu
    public static void CrateMenu()
    {
        // Menu options
        string[] menuOptions = new string[] { "\tFyll din back med läskflaskor\t", "\t* Tillbaks till Huvudmenyn *\t" };
        int menuSelect = 0;

        // Loop
        while (true)
        {
            // Fixing, cleaning the menu and removing cursor
            Console.Clear();
            Console.CursorVisible = false;

            // Text to show in menu
            Console.WriteLine("\t**** Läskback ****\t \n ---------------------------------------");

            // First index with added arrows
            if (menuSelect == 0)
            {
                Console.WriteLine("-->" + menuOptions[0] + "<--");
                Console.WriteLine(menuOptions[1]);
            }
            else if (menuSelect == 1)
            {
                Console.WriteLine(menuOptions[0]);
                Console.WriteLine("-->" + menuOptions[1] + "<--");
            }

            // Catch user input        
            var keyPressed = Console.ReadKey();

            // To make sure that the arrows don't go outside of the meny
            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            // When user press Enter
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {

                    case 0:
                        sodaToCart();
                        break;
                    case 1:
                        return;
                }
            }
        }
    }

    // Creating and adding all the sodas to the crate. Long version array   
    static theCrate[] sodas()
    {
        theCrate[] sodas = new theCrate[10];

        sodas[0].name = "Sockerdricka\t\t";
        sodas[0].price = 9;

        sodas[1].name = "Pepsi\t\t\t\t";
        sodas[1].price = 13.90;

        sodas[2].name = "Pepsi Max\t\t\t";
        sodas[2].price = 13.90;

        sodas[3].name = "Fanta Orange\t\t";
        sodas[3].price = 12.90;

        sodas[4].name = "Fanta Exotic\t\t";
        sodas[4].price = 14.90;

        sodas[5].name = "Dr. Pepper\t\t\t";
        sodas[5].price = 14.90;

        sodas[6].name = "Skogs Cola\t\t\t";
        sodas[6].price = 19;

        sodas[7].name = "Skogs Tranbär\t\t";
        sodas[7].price = 19;

        sodas[8].name = "Coca Cola\t\t\t";
        sodas[8].price = 12.90;

        sodas[9].name = "Coca Cola Zero\t\t";
        sodas[9].price = 12.90;


        return sodas;

    }

    // Method add soda        
    static void sodaToCart()
    {
        theCrate[] listOfSodas = sodas();//making variable so I'm able to check all the sodas in the array(Can't use the function, therefore created "listofsodas"
        int sodaChoice = 0; // Integer variable which is connected to selected drink in the menu.
        Console.Clear();
        // Menu starts here
        Console.WriteLine("\t**** Läskback ****\n ---------------------------------------");
        Console.WriteLine("\tTotalt i Varukorgen: " + cartTotal() + "kr\n\tFyll din back med läsk!\n ---------------------------------------");
        for (int i = 0; i < listOfSodas.Length; i++) // for-loop which is printing out all of the sodas
        {
            Console.WriteLine("{0}.\t" + "{1}" + "Pris: " + "{2}kr", i + 1, listOfSodas[i].name, listOfSodas[i].price);  //Displaying sodas by indexNumber, name & price.
        }
        Console.WriteLine("11. Slumpa innehållet i backen.");
        Console.WriteLine(" ---------------------------------------");
        Console.WriteLine("\n[12.] För att gå tillbaks till menyn.");
        Console.Write("\nSkriv numret på vilken läsk du vill lägga till i din back.");

        try
        {
            sodaChoice = int.Parse(Console.ReadLine());

        }
        catch
        {
            Console.WriteLine("Du behöver skriva in ett nummer, tryck Enter för att försöka igen!");
            Console.ReadLine();

        }

        if ((sodaChoice < 1) || (sodaChoice > 13))
        {
            Console.WriteLine("\nEj giltigt val! Tryck Enter för att försöka igen!");
            Console.ReadLine();
        }
        // Tells user Sodacrate is full and asks which soda user wants to replace
        else if (numberCans == 12)
        {
            Console.WriteLine("Läskbacken är full!");
            Console.ReadKey();
            return;


        }
        else if (sodaChoice == 12)
        {
            return;
        }
        else if (sodaChoice == 11)
        {
            Random randomNumber = new Random(); //creating a variable connected to a random number generator. 
            // Fills the crate with random sodas
            for (int i = numberCans; i < Crate.Length; i++) // numberCans as 0, creates same loop as above
            {
                Crate[i] = listOfSodas[randomNumber.Next(listOfSodas.Length)]; // through listofsodas I'm able to create a random generator inside the array which  
                numberCans++;
            }
            sodaToCart();
        }

        // Adds sodas to crate
        else
        {
            Crate[numberCans] = listOfSodas[sodaChoice - 1];
            numberCans++;
            sodaToCart();

        }
    }

    // Mhetod Print sodacrate        
    public static void print_crate()
    {

        // Shows user all sodas in soda crate
        for (int i = 0; i < numberCans; i++)
        {
            Console.WriteLine("1st " + "{1}" + "{2}kr", i + 1, Crate[i].name, Crate[i].price);
        }


    }

    // Method that calculates totalprice 

    public static double cartTotal()
    {

        Console.WriteLine();
        double cartPrice = 0;

        // Summs upp price of all sodas in sodacrate to toatlprice 
        for (int i = 0; i < numberCans; i++)
        {
            cartPrice = cartPrice + Crate[i].price;

        }

        return cartPrice;


    }

}