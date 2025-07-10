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

        public static void printOut()
        {
            Console.WriteLine("=== STATISTIKY HRÁČE ===");
            Console.WriteLine("Jméno: " + jmeno);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Životy: " + health);
            Console.WriteLine("Síla: " + strength);
        }
    }

    static void Main()
    {

        userVerification();
        welcoming();
        gameLoop();


        Statistics.printOut();

    }

    static void userVerification()
    {
        List<string> usernames = new List<string> { "Alice", "Bob", "Petr" };
        List<string> passwords = new List<string> { "pass1", "pass2", "pass3" };
        Console.Write("Zadej username: ");
        string username = Console.ReadLine();

        Console.Write("Zadej heslo: ");
        string password = Console.ReadLine();

        bool found = false;
        int index = 0;

        foreach (string username1 in usernames)
        {
            if (username1 == username)
            {
                if (passwords[index] == password)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Fail!");
                }
                found = true;
                Statistics.jmeno = username;
                break; // stop searching after match
            }
            index++;
        }

        if (!found)
        {
            Console.WriteLine("Username not found!");
            return;

        }
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

        //naše hra
        Statistics.level++;

        stopwatch.Stop();
        Console.WriteLine("You have completed" + Statistics.level + " in {stopwatch.Elapsed.TotalSeconds} seconds");
    }

    static void openShop()
    {
        int gold = 100;

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
            Console.WriteLine("Máš" + gold + "gold.");
            Console.WriteLine("Shop items:");
            foreach (string item in shop)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Vyber číslo položky k nákupu nebo zmáčkni 0, abys opustil shop:");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (gold >= 30)
                {
                    gold -= 30;
                    Console.WriteLine("Koupil jsi Sword! Zbylo ti " + gold + " gold.");
                }
                else
                {
                    Console.WriteLine("Nemáš dostatek gold!");
                }
            }
            else if (choice == "2")
            {
                if (gold >= 20)
                {
                    gold -= 20;
                    Console.WriteLine("Koupil jsi Shield! Zbylo ti " + gold + " gold.");
                }
                else
                {
                    Console.WriteLine("Nemáš dostatek gold!");
                }
            }
            else if (choice == "3")
            {
                if (gold >= 10)
                {
                    gold -= 10;
                    Console.WriteLine("Koupil jsi Armour! Zbylo ti " + gold + " gold.");
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
System.Console.WriteLine("ahoj");
        }
    }


}