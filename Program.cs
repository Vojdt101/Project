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
        Console.WriteLine("Toto je bojová hra.");
        Console.WriteLine("Začínáš s 100 hp, až ti dojde hp, končí hra. ");
        Console.WriteLine("Postupně budeš procházek levelama.");
        Console.WriteLine("Hodně štěstí!");
    }

    static void gameLoop()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        // promenne
 int vybranyUtok;
 int damage;
 int vysledek1;
 int vysledek2;
 int vysledek3;
 int vysledek4;
 string vstup;
 int odpoved;
 int enemyHP = 10;
 int enemyDMG = 0;
 int kolo = 0;
 int enemyDmgEXTRA;
 int HitChance;
 


// boj

    while (zivoty > 0)
    {   
        kolo++;
        enemyDMG= enemyDMG+(10*kolo);
        Random enemyHPplus = new Random ();
        enemyHP = enemyHP + enemyHPplus.Next(1, 31);
        while (enemyHP > 0 && zivoty > 0)
        {
            
            
            Console.WriteLine("zivoty nepritele: " + enemyHP);
            Console.WriteLine("kolo: " + kolo);
            Console.WriteLine("vyber utok, 1 - slaby utok (scitani), 2 - slaby utok (odcitani), 3 - silny utok (nasobeni), 4 - silny utok (deleni)");
            vybranyUtok = int.Parse (Console.ReadLine());

            Random rnd1 = new Random ();
            int y = rnd1.Next(1, 100);
            Random rnd2 = new Random ();
            int x = rnd2.Next(1, 100);
            Random rnd3 = new Random ();
            int z = rnd3.Next(1, 10);


            switch (vybranyUtok)
            {
                case 1:
                    
                    Console.WriteLine("vybral jsi slaby utok (scitani)");
                    Console.WriteLine($"vypocitej priklad: {y} + {x} =");
                    vstup = Console.ReadLine();
                    odpoved = int.Parse(vstup); 
                    vysledek1 = x + y;
                    if(vysledek1 == odpoved)
                    {
                        Random rndDMG = new Random ();
                        damage = rndDMG.Next(5, 11);
                        Console.WriteLine("uderil jsi damage " + damage);
                        enemyHP = enemyHP - damage;
                        Console.WriteLine("Zivoty nepritel " + enemyHP);
                    }
                    else
                    {
                        Console.WriteLine("minul jsi, správný výsledek je " + vysledek1);
                    }
                    break;
                case 2:
                    
                    Console.WriteLine("vybral jsi slaby utok (odcitani)");
                    Console.WriteLine($"vypocitej priklad: {y} - {x} =");
                    vstup = Console.ReadLine();
                    odpoved = int.Parse(vstup); 
                    vysledek2 = y - x;
                    if(vysledek2 == odpoved)
                    {
                        Random rndDMG = new Random ();
                        damage = rndDMG.Next(5, 11);
                        Console.WriteLine("uderil jsi damage " + damage);
                        enemyHP = enemyHP - damage;
                        Console.WriteLine("Zivoty nepritel " + enemyHP);
                    }
                    else
                    {
                        Console.WriteLine("minul jsi, správný výsledek je " + vysledek2);
                    }
                    break;
                case 3:
                    
                    Console.WriteLine("vybral jsi silny utok(nasobeni)");
                    Console.WriteLine($"vypocitej priklad: {y} * {x} =");
                    vstup = Console.ReadLine();
                    odpoved = int.Parse(vstup); 
                    vysledek3 = x * y;
                    if(vysledek3 == odpoved)
                    {
                        Random rndDMG = new Random ();
                        damage = rndDMG.Next(10, 21);
                        Console.WriteLine("uderil jsi damage " + damage);
                        enemyHP = enemyHP - damage;
                        Console.WriteLine("Zivoty nepritel " + enemyHP);
                    }
                    else
                    {
                        Console.WriteLine("minul jsi, správný výsledek je " + vysledek3;
                    }
                    break;
                    case 4:
                    
                    Console.WriteLine("vybral jsi silny utok(deleni)");
                    Console.WriteLine($"vypocitej priklad: {y} / {z} =");
                    vstup = Console.ReadLine();
                    odpoved = int.Parse(vstup); 
                    vysledek4 = y / z;
                    if(vysledek4 == odpoved)
                    {
                        Random rndDMG = new Random ();
                        damage = rndDMG.Next(5, 11);
                        Console.WriteLine("uderil jsi damage " + damage);
                        enemyHP = enemyHP - damage;
                        Console.WriteLine("Zivoty nepritel " + enemyHP);
                    }
                    else
                    {
                        Console.WriteLine("minul jsi, správný výsledek je " + vysledek4);
                    }
                    break;
                default:
                    Console.WriteLine("INVALID");
                    break;
            }
            if(enemyHP > 0)
            {
                Random rndHit = new Random ();
                HitChance = rndHit.Next(0, 101);
                if(HitChance <= 70)
                {
                    Random rndeDMG = new Random ();
                    enemyDmgEXTRA = rndeDMG.Next(5, 16);
                    enemyDMG = enemyDMG + enemyDmgEXTRA;
                    health = health - enemyDMG;
                    Console.WriteLine("nepritel ti ubral " + enemyDMG + "zivotu");
                    Console.WriteLine("zbyva ti " + health + "zivotu");
                }
                else
                {
                    Console.WriteLine("nepritel minul");
                }
            }
            else
            {
                Console.WriteLine("nepritel zemrel");
            }
           

            

            


        }


        




    }


        Statistics.level++;     //toto dejte u kazdyho levelu

        stopwatch.Stop();
        Console.WriteLine("Dokoncil jsi " + Statistics.level + " levly v " + stopwatch.Elapsed.TotalSeconds + " vterinach.");
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
            Console.WriteLine("Máš " + Statistics.gold + " gold.");
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