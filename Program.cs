using System;
using System.Diagnostics;


class Program
{

    static class Statistics
    {
        public static string jmeno = "";
        public static int level = 1;
        public static int health = 50;
        public static int strength = 10;
        public static int gold = 100;
        public static List<string> inventory = new List<string>();

        public static void printOut()
        {
            Console.WriteLine("=== STATISTIKY HRÁČE ===");
            Console.WriteLine("Jméno: " + jmeno);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Životy: " + health);
            Console.WriteLine("Síla: " + strength);
            Console.WriteLine("Gold: " + gold);
            Console.WriteLine("Inventory:");

            if (inventory.Count < 1)
            {
                Console.WriteLine("Nemas nic v inventari.");
            }
            else
            {
                foreach (string item in inventory)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }

    static void Main()
    {
        bool verified = userVerification();
        if (verified)
        {
            welcoming();
            gameLoop();
            openShop();
            Statistics.printOut();

        }
        else
        {
            Console.WriteLine("Uživatel nebyl nalezen nebo špatné heslo.");
        }





    }

    static bool userVerification()
    {
        List<string> usernames = new List<string> { "Alice", "Bob", "Petr" };
        List<string> passwords = new List<string> { "pass1", "pass2", "pass3" };
        Console.Write("Zadej username: ");
        string inputUsername = Console.ReadLine();

        Console.Write("Zadej heslo: ");
        string inputPassword = Console.ReadLine();

        bool found = false;
        int index = 0;

        foreach (string username in usernames)
        {
            if (username == inputUsername)          // zkontroluje jestli se shoduje username, jestli ne, zvetsi se index o 1 a jde to znovu, postupne pro vsechny jmena
            {
                if (passwords[index] == inputPassword)      //jestli password na miste [index] se shoduje s input
                {
                    found = true;                           //found se zmeni na true
                    Statistics.jmeno = inputUsername;
                }

                break;
            }
            index++;
        }

        return found;
    }

    static void welcoming()
    {
        Console.WriteLine("Vítej!");
        Console.WriteLine("Toto je bojovací hra.");
        Console.WriteLine("Začínáš s 100 hp, až ti dojde hp, končí hra. ");
        Console.WriteLine("Postupně budeš procházek levelama.");
        Console.WriteLine("Hodně štěstí!");
    }

    static void gameLoop()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        //tady dejte vasi cast


        Statistics.level++;     //toto dejte u kazdyho levelu

        stopwatch.Stop();
        Console.WriteLine("Dokoncil jsi " + Statistics.level + " levlu v " + stopwatch.Elapsed.TotalSeconds + " vterin.");
    } 

    static void openShop()
    {

        List<string> shop = new List<string>()
            {
            "1. Sword: 30 gold",
            "2. Shield: 20 gold",
            "3. Armour: 10 gold"
            };

        Console.WriteLine("Chceš otevřít shop? ano/ne");
        string answer = Console.ReadLine();

        if (answer == "ano")
        {
            Console.WriteLine("Máš" + Statistics.gold + "gold.");
            Console.WriteLine("Shop items:");
            foreach (string item in shop)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Vyber číslo položky k nákupu nebo zmáčkni 0, abys opustil shop:");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (Statistics.gold >= 30)
                {
                    Statistics.gold -= 30;
                    Console.WriteLine("Koupil jsi Sword! Zbylo ti " + Statistics.gold + " gold.");
                    Statistics.inventory.Add("Sword");
                }
                else
                {
                    Console.WriteLine("Nemáš dostatek gold!");
                }
            }
            else if (choice == "2")
            {
                if (Statistics.gold >= 20)
                {
                    Statistics.gold -= 20;
                    Console.WriteLine("Koupil jsi Shield! Zbylo ti " + Statistics.gold + " gold.");
                    Statistics.inventory.Add("Sheild");
                }
                else
                {
                    Console.WriteLine("Nemáš dostatek gold!");
                }
            }
            else if (choice == "3")
            {
                if (Statistics.gold >= 10)
                {
                    Statistics.gold -= 10;
                    Console.WriteLine("Koupil jsi Armour! Zbylo ti " + Statistics.gold + " gold.");
                    Statistics.inventory.Add("Armour");
                }
                else
                {
                    Console.WriteLine("Nemáš dostatek gold!");
                }
            }
            else if (choice == "0")
            {
                Console.WriteLine("Opouštíš shop.");
            }
            else
            {
                Console.WriteLine("Neplatná volba.");
            }
        }
        else
        {
            Console.WriteLine("Shop byl zavřen.");
        }

        Console.WriteLine("Chceš si ještě něco koupit?");
        string op = Console.ReadLine();

        if (op == "ano")
        {
            openShop();
        }
    }


}