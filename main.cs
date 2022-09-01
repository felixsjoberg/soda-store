using System;
using System.Linq;
using System.Collections.Generic;

//---------------------0.  Classes---------------------
// Class holding price & brand information for all sodas.
class Sodas
{
    public string brand;
    public double price;
    public Sodas(string sodaName,double sodaPrice)
    {
        brand = sodaName;
        price = sodaPrice;
    }
 

}
class Program
{ //Butik Starts
    /* ********** IMPORTANT ******* Code written by Felix Sjöberg
     How the code is structured. (WITH regions & comments)*
       0 Classes
       1 Objects & Variables
       2 Welcome screen
       3 Main Menu
       4 FIRST option in the (Main menu)
       5 SECOND option in the (Main menu)
       6 THIRD option in the (Main menu)
       7 FOURTH option in the (Main menu)
       8 Methods
      ******************************
    */

    #region Objects & Variables
    //-----------------------------1.Objects & Variables------------------------------
    //Creating all of the different alternatives of soda, as objects.
    static Sodas pepsi = new Sodas("Pepsi ", 13.90);
    static Sodas pepsiMax = new Sodas("Pepsi Max ", 13.90);
    static Sodas coke = new Sodas("Coca Cola ", 12.90);
    static Sodas cokeZero = new Sodas("Coca Cola Zero ", 12.90);
    static Sodas fanta = new Sodas("Fanta Orange ", 12.90);
    static Sodas fantaExotic = new Sodas("Fanta Exotic ", 14.90);
    static Sodas sockerdricka = new Sodas("Sockerdricka ", 9);
    static Sodas drPepper = new Sodas("Dr. Pepper ", 14.90);
    static Sodas skogsCola = new Sodas("Skogs Cola ", 19);
    static Sodas skogsTranbär = new Sodas("Skogs Tranbär ", 19);
    // -----------------------------------------------------
    // Variables used in the program
    public static double prisTotaltVarukorg;
    public static double prisVarukorg;
    static string varorVarukorg;
    static int MenuSelector = 0;
    // -----------------------------------------------------

    // -------------------------1. end of Objects & Variables----------------------------
    #endregion Objects & Variables
    #region Welcome screen 
    //------------------------------2. Welcome Screen (first you see when starting the program)------------------------------
    public static void Welcome()
        {
        
               
            //Prints all existing information to user
            Console.WriteLine("Välkommen till LÄSKMASKINEN stolt leverantör och producent av läsk sedan 1954.\n------------------------------------------------------------------------------\n");

            Console.WriteLine("Instruktioner:\n\nLägg till alla varor och sedan sker ut-checkning via varukorgen.\n");

            Console.WriteLine("Behöver du hjälp eller har frågor vänligen se mer information i menyn,\n eller besök oss på www.läskmaskinen.se eller nå oss på 076-8489040");
            Console.WriteLine("\n------------------------------------------------------------------------------\n");
            //Prompts user to return to "Main Menu" with Enter Key
            Console.WriteLine("**** Tryck på ENTER för att gå vidare till huvudmenyn ****");

            //Holds text until user input (preferably Enter)
            Console.ReadLine();
        }
    //-----------------------------------2. end of Welcome Screen----------------------------------------------------
    #endregion Welcome screen
    #region Main Menu
    //-----------------------------3. MAIN MENU -------------------------------
    public static void mainMenu()
        {
            //Creating menuoptions
            string[] MenuOption = new string[] { "\tLäskflaskor\t", "\tLäskbackar\t", "\tVarukorg\t", "\tInformation och Kontakt", "\tAvsluta Programmet"};
            // create a variable which is used to be changed through user input and by that showing different alternatives depending on the value of it.
            int MenuSelector = 0;
            // While-true loop that keeps menu activated until user goes to other screen
            while (true)
            {
                //Clears screen and removes "cursor"
                Console.Clear();
                Console.CursorVisible = false;


            //Visualizes menuoptions 1 through 6 and adds "arrows" to highlight currently selected option
            Console.WriteLine("\t**** Huvudmeny ****\t \n ---------------------------------");

            if (MenuSelector == 0) // the variable that's being changed & displaying different options (code that dictates change of it is after menu)
                {
                    Console.WriteLine("--->" + MenuOption[0] + "<---");
                    Console.WriteLine(MenuOption[1]);
                    Console.WriteLine(MenuOption[2]);
                    Console.WriteLine(MenuOption[3]);
                    Console.WriteLine(MenuOption[4]);
                }

                else if (MenuSelector == 1)
                {
                    Console.WriteLine(MenuOption[0]);
                    Console.WriteLine("--->" + MenuOption[1] + "<---");
                    Console.WriteLine(MenuOption[2]);
                    Console.WriteLine(MenuOption[3]);
                    Console.WriteLine(MenuOption[4]);
                }

                else if (MenuSelector == 2)
                {
                    Console.WriteLine(MenuOption[0]);
                    Console.WriteLine(MenuOption[1]);
                    Console.WriteLine("--->" + MenuOption[2] + "<---");
                    Console.WriteLine(MenuOption[3]);
                    Console.WriteLine(MenuOption[4]);
                }

                else if (MenuSelector == 3)
                {
                    Console.WriteLine(MenuOption[0]);
                    Console.WriteLine(MenuOption[1]);
                    Console.WriteLine(MenuOption[2]);
                    Console.WriteLine("--->" + MenuOption[3] + "<---");
                    Console.WriteLine(MenuOption[4]);
                }

                else if (MenuSelector == 4)
                {
                    Console.WriteLine(MenuOption[0]);
                    Console.WriteLine(MenuOption[1]);
                    Console.WriteLine(MenuOption[2]);
                    Console.WriteLine(MenuOption[3]);
                    Console.WriteLine("--->" + MenuOption[4] + "<---");
                }

            Console.WriteLine(" ---------------------------------");

            /*
            Allows the user change options "upward" or "downward" with the arrow keys,
            The press of these arrows change the value of menuselector which inturn change the highlighted menuoption.
            */

            var KeyPressed = Console.ReadKey(); 

                if (KeyPressed.Key == ConsoleKey.DownArrow && MenuSelector != MenuOption.Length - 1)
                {
                    MenuSelector++;
                }

                else if (KeyPressed.Key == ConsoleKey.UpArrow && MenuSelector >= 1)
                {
                    MenuSelector--;
                }

                //Allows confirmation with "Enter" key
                else if (KeyPressed.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (MenuSelector) // The highlighted menuoption forwards user to different sections connected to the highlighted option.
                    {
                        case 0:
                            Bottles();
                            break;
                        case 1:
                        SECONDoption();
                        break;
                        case 2:
                            CheckOut();
                            break;
                        case 3:
                            Information();
                            break;
                        case 4:
                            QuitProgram();
                            return; 
                    }
                }
            }
        }
    //-----------------------------3. end of MAIN MENU -------------------------------
    #endregion Main menu
    #region FIRST option in the (Main menu/Läskflaskor)
    //-----------------------------4. FIRST option found in Main menu -------------------------------
    public static void Bottles()
    {
        
      Console.WriteLine("Enstaka läskflaskor till bra pris\nVälj produkt med hjälp av piltangenterna och enter för att lägga till \n vald produkt till din varukorg.\n------------------------------------------------------------------------------\n");
      
             //Creating all different menuoptions
             string[] MenuOption = new string[] { "\t" + sockerdricka.brand + sockerdricka.price + "kr\t" , "\t" + pepsi.brand + pepsi.price + "kr\t\t", "\t" + pepsiMax.brand + pepsiMax.price + "kr\t", "\t" + fanta.brand + fanta.price + "kr\t", "\t" + fantaExotic.brand + fantaExotic.price + "kr\t", "\t" + drPepper.brand + drPepper.price + "kr\t", "\t" + skogsCola.brand + skogsCola.price + "kr\t\t", "\t" + skogsTranbär.brand + skogsTranbär.price + "kr\t", "\t" + coke.brand + coke.price + "kr\t", "\t" + cokeZero.brand + cokeZero.price + "kr", "\t* Tillbaks till Huvudmeny *"};
             // While-true loop that keeps menu activated until user goes to other screen
         while (true)
         {
             //Clears screen and removes the cursor
             Console.Clear();
             Console.CursorVisible = false;


           //Visualizes menuoptions 0 through 9 and adds "arrows" to highlight currently selected option
           Console.WriteLine("\t**** Läskflaskor ****\t \n ---------------------------------");
           Console.WriteLine("\tTotalt i Varukorgen: " + prisVarukorg + "kr" );
           Console.WriteLine(" ---------------------------------");
           
           
           if (MenuSelector == 0)
           {
               Console.WriteLine("--->" + MenuOption[0] + "<---");
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 1)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine("--->" + MenuOption[1] + "<---");
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 2)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine("--->" + MenuOption[2] + "<---");
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 3)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine("--->" + MenuOption[3] + "<---");
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 4)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine("--->" + MenuOption[4] + "<---");
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 5)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine("--->" + MenuOption[5] + "<---");
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 6)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine("--->" + MenuOption[6] + "<---");
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 7)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine("--->" + MenuOption[7] + "<---");
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 8)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine("--->" + MenuOption[8] + "<---");
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine(MenuOption[10]);
           }

           else if (MenuSelector == 9)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine("--->" + MenuOption[9] + "<---");
               Console.WriteLine(MenuOption[10]);



           }
             else if (MenuSelector == 10)
           {
               Console.WriteLine(MenuOption[0]);
               Console.WriteLine(MenuOption[1]);
               Console.WriteLine(MenuOption[2]);
               Console.WriteLine(MenuOption[3]);
               Console.WriteLine(MenuOption[4]);
               Console.WriteLine(MenuOption[5]);
               Console.WriteLine(MenuOption[6]);
               Console.WriteLine(MenuOption[7]);
               Console.WriteLine(MenuOption[8]);
               Console.WriteLine(MenuOption[9]);
               Console.WriteLine("--->" + MenuOption[10] + "<---");



            }

             Console.WriteLine(" ---------------------------------");

        /*
            Allows the user change options "upward" or "downward" with the arrow keys,
            The press of these arrows change the value of menuselector which inturn change the highlighted menuoption.
        */
          
          var KeyPressed = Console.ReadKey();

           if (KeyPressed.Key == ConsoleKey.DownArrow && MenuSelector != MenuOption.Length - 1)
           {
               MenuSelector++;
           }

           else if (KeyPressed.Key == ConsoleKey.UpArrow && MenuSelector >= 1)
           {
               MenuSelector--;
           }

           //Allows confirmation with "Enter" key
           else if (KeyPressed.Key == ConsoleKey.Enter)
           {

               switch (MenuSelector) //switch is used to direct users to given method which the user choosed in the menu above.
               {
                   case 0:
               sellSoda(sockerdricka.brand, sockerdricka.price);
               break;
                   case 1:
               sellSoda(pepsi.brand, pepsi.price);
               break;
                   case 2:
               sellSoda(pepsiMax.brand, pepsiMax.price); ;
               break;
                   case 3:
               sellSoda(fanta.brand, fanta.price);
               break;
                   case 4:
               sellSoda(fantaExotic.brand, fantaExotic.price);
               break;
                   case 5:
               sellSoda(drPepper.brand, drPepper.price);
               break;
                   case 6:
               sellSoda(skogsCola.brand, skogsCola.price);
               break;
                   case 7:
               sellSoda(skogsTranbär.brand, skogsTranbär.price);
               break;
                   case 8:
               sellSoda(coke.brand, coke.price);
               break;
                   case 9:
               sellSoda(cokeZero.brand, cokeZero.price);
               break;
                   case 10:
                   return;
               }
           }
         }
      
    }
    //-----------------------------4. end of FIRST option in the (main menu)-------------------------------
    #endregion FIRST option in the (Main menu/läskflaskor)
    #region SECOND option in the (Main menu/läskbackar)
    //-----------------------------5. SECOND option found in Main menu -------------------------------
    public static void SECONDoption()
    {
        SodaCrate.CrateMenu();
    }
    //-----------------------------5. end of SECOND option found in Main menu -------------------------------

    #endregion SECOND option in the (Main menu)
    #region THIRD option in the (Main menu/Varukorg)
     //-----------------------------6. THIRD option found in Main menu -------------------------------
      static void CheckOut()
      {
        Console.Clear();
        Console.WriteLine("\t**** Min Varukorg ****\t \n ---------------------------------");
        totaltVarukorg();
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkBlue; // Change the background color of the text enstaka flaskor
        Console.ForegroundColor = ConsoleColor.White; // Change the background color of the text enstaka flaskor
        Console.WriteLine("\tEnstaka läskflaskor:");
        Console.ResetColor();
        Console.WriteLine(varorVarukorg);
        Console.WriteLine();
        Console.WriteLine("Totalt pris för läskflaskor = " + prisVarukorg + "kr");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkBlue; // Change the background color of the text äskbacken
        Console.ForegroundColor = ConsoleColor.White; // Change the background color of the text -.-
        Console.WriteLine("\t Max 12 i Läskbacken:   ");
        Console.ResetColor();
        SodaCrate.print_crate();
        Console.WriteLine("Totalt pris för läskbacken = " + SodaCrate.cartTotal() + "kr");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine("[ENTER] för att göra beställning.");
        Console.WriteLine("[SPACEBAR] för att gå tillbaks till huvudmenyn.");

        var KeyPressed = Console.ReadKey();
        //Allows confirmation with "Enter" key
         
            if (KeyPressed.Key == ConsoleKey.Enter)
              {
              Console.Clear();
              Console.WriteLine("********************************************************");
              Console.WriteLine("Tack för din beställning, orderbekräftelse skickas ut omgående.");
              Console.WriteLine("********************************************************");
              Console.ReadKey();
              Environment.Exit(1);   
              }
            else if (KeyPressed.Key == ConsoleKey.Spacebar)
              {
                return;
              }
            else
            {
            Console.WriteLine("\n*Fel inmatning! Försök igen och vänligen följ instruktionerna, för att fortsätta.*");
            Console.ReadKey();
            CheckOut();
            }
       }
    //-----------------------------6. end of THIRD option found in Main menu -------------------------------
    #endregion THIRD option in the (Main menu/Varukorg)
    #region FOURTH option in the (Main menu/Information)
    //-----------------------------7. FOURTH option found in Main menu -------------------------------
 
        // Prompts the user to either exit program by pressing (enter) or return to the main menu by pressing (Spacebar)
        public static void QuitProgram()
        {
           Console.Clear();
           Console.WriteLine("\t**** Avsluta programmet ****\t \n ---------------------------------");
           
           Console.WriteLine("\n[ENTER] för att avsluta programmet \n[SPACEBAR] för att återgå till menyn.\n");
           Console.WriteLine(" ---------------------------------");
           
           var KeyPressed = Console.ReadKey();
           
           
           
           if (KeyPressed.Key == ConsoleKey.Enter) {
               Environment.Exit(1);
           }
           else if(KeyPressed.Key == ConsoleKey.Spacebar){
               mainMenu();
           }
           
           else 
           {
               Console.WriteLine("\n*Fel inmatning! Försök igen och vänligen följ instruktionerna, för att fortsätta.*");
               Console.ReadKey();
               QuitProgram();
           }

        }
    //-----------------------------7. end of FOURTH option found in Main menu -------------------------------

    #endregion FOURTH option in the (Main menu)
    #region Methods
    //-----------------------------8. METHODS -------------------------------
    public static void Information()
    {
        Console.WriteLine("Svenskt läskföretag sedan 1954 med huvudkontor i Stockholm Älvsjö.\n\nStolt leverantör och tillverkare av högkvalité närproducerad läsk i våran fabrik i Älvsjö. \nAtt erbjuda god läsk är någonting som är nära tillvårat hjärta. \n\n*Ingredienserna i våra lokalproducerade två läsksorter Skogs Cola och Skogs Tranbär,\nkommer direkt från leverantörer baserade i Sverige och är av högsta kvalité.\n\n*Kontaktinformation:\nÖppen kundservice alla vardagar emellan 8.00-16.00 både via telefon: 076-8489040 och via mejl läskmaskinen@gmail.com.\nBesök gärna vår hemsida www.läskmaskinen.se");
        Console.WriteLine("\n*Hur beställer jag med detta program?\nProgrammet fungerar genom att man väljer antigen 'enstaka läskflaskor' eller att fylla sin egen 'läskback'. \nAlla val man gör sparas i varukorgen, som man kommer åt via huvudmenyn.\n\n\nTryck på Enter för att återgå till Menyn ");
        Console.ReadLine();
    }

  
    public void Butik() //räknar ut totalsumman av priset för valda varor.
    {
        prisVarukorg = 0;
    }
    //-----------------------test---------------------
         public static void totaltVarukorg()
    {
        prisTotaltVarukorg = SodaCrate.cartTotal() + prisVarukorg;
        Console.WriteLine("Varukorgen är fylld med varor till ett belopp av:" + prisTotaltVarukorg + "kr");
           
    }
    //-----------------------test---------------------
   
    static void sellSoda(string itemName, double cost) //Efter kund valt önskad dryck, så frågar denna metod om hur många hen vill ha av vald produkt och sedan summerar beroende på antal totala priset i heltal och decimal.
    {
        Console.WriteLine($"Vill du köpa {itemName} för {cost}kr? (j/n)");
        string str = Console.ReadLine();
        if (str == "j" || str == "J")
        {
            try
            {
                Console.WriteLine("Hur många vill du köpa?");
                string hurManga = Console.ReadLine();
                int hurMangaSiffra = Convert.ToInt32(hurManga);
                double totalt = cost * hurMangaSiffra;
                prisVarukorg += totalt; //lägger till det totala i totalt till totaltVarukorg
                varorVarukorg += hurMangaSiffra + "st " + itemName + " = " + totalt +"kr\n"; // Registrerar alla val och sparar så det sparas till varukorgen.
                Console.WriteLine($"Okej, {hurMangaSiffra}st {itemName} finns nu i din varukorg för {totalt}kr");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Du skrev inte ett nummer.. försök igen.");
                Console.ReadKey();
            }

        }
        else if (str == "n" || str == "N")
        {
            return;
        }
        else
        {
            sellSoda(itemName, cost);
            return;
        }
       
    }
        // Returns user to "Main menu" on choice
        public static void ReturnToMenu()
        {
           mainMenu();
        }
   
    //-----------------------------8. end of METHODS -------------------------------
    #endregion Methods

    //------------------------- RUN THE PROGRAM ----------------------------------
    //The basic Main enviroment reads product information and boots to main menu after "Enter" key is pressed
    public static void Main(string[] args)
        {
            //Executing Methods containing their respective focus
           Welcome();
           mainMenu();
    }

  }



