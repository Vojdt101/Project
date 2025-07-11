using System.Diagnostics;


class Program
{

    static class Statistics
    {
        public static string jmeno = "";
        public static int level = 0;
        public static int health = 100;
        public static int strength = 10;
        public static int gold = 0;
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

            if (inventory.Count < 1)                            //vypíše inventory
            {
                Console.WriteLine("Nemáš nic v inventáři.");
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

            do                      //loopuje kola, dokud hráč umře
            {
                gameLoop();
                if (Statistics.health > 0)
                {
                    openShop();
                }


                Statistics.printOut();
            } while (Statistics.health > 0);


        }
        else
        {
            Console.WriteLine("Uživatel nebyl nalezen nebo špatné heslo.");
        }





    }

    static bool userVerification()
    {
        List<string> usernames = new List<string> { "Alice", "Bob", "Petr" };       //zkontroluje login
        List<string> passwords = new List<string> { "pass1", "pass2", "pass3" };
        Console.Write("Zadej username: ");
        string inputUsername = Console.ReadLine();

        Console.Write("Zadej heslo: ");
        string inputPassword = Console.ReadLine();

        bool found = false;
        int index = 0;

        foreach (string username in usernames)
        {
            if (username == inputUsername)          // zkontroluje jestli se shoduje username, jestli ne, zvětší se index o 1 a spustí se to znovu, postupně pro všechny jména
            {
                if (passwords[index] == inputPassword)      //jestli password na míste [index] se shoduje s input
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
        Console.WriteLine("Vítej v Math Fights!");
        Console.WriteLine("Začínáš s 100 hp, až ti dojde hp, končí hra. ");
        Console.WriteLine("Postupně budeš procházet levelama.");
        Console.WriteLine("Hodně štěstí!");
    }

    static void gameLoop()
    {
        Stopwatch stopwatch = new Stopwatch();          
        stopwatch.Start();                      //zacne novy stopwatch


        // promenne
        int vybranyUtok;
        int damage;
        int vysledek1;
        int vysledek2;
        int vysledek3;
        string vstup;
        int odpoved;
        int enemyHP = 10;
        int enemyDMG = 0;
        int kolo = 0;
        int enemyDmgEXTRA;
        int HitChance;



        // prubeh boje

        while (Statistics.health > 0)
        {
            kolo++;
            enemyDMG = enemyDMG + (7 * kolo); //přidá bonusový damage za každé kolo
            Random enemyHPplus = new Random();
            enemyHP = enemyHP + enemyHPplus.Next(1, 21); //generuje hp nepřítele
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("kolo: " + kolo); //píše kolikáté kolo probíhá 
            Console.ResetColor();
            while (enemyHP > 0 && Statistics.health > 0) //opakuje dokud neumře hráč nebo nepřítel
            {


                Console.WriteLine("Životy neprítele: " + enemyHP); 
                Console.WriteLine("Vyber útok, 1 - slabý útok (sčítání), 2 - slabý útok (odčítání), 3 - silný útok (násobení)");// hráč si vybírá možnost útoku
                vybranyUtok = int.Parse(Console.ReadLine());

                Random rnd1 = new Random(); //generace čísel pro příklady
                int y = rnd1.Next(1, 21);
                Random rnd2 = new Random();
                int x = rnd2.Next(1, 21);
                


                switch (vybranyUtok)
                {
                    case 1: //útok sčítání

                        Console.WriteLine("Vybral jsi slabý útok (sčítání)");
                        Console.WriteLine($"Vypočitej príklad: {y} + {x} =");
                        vstup = Console.ReadLine();
                        odpoved = int.Parse(vstup);
                        vysledek1 = x + y;
                        if (vysledek1 == odpoved)
                        {
                            Random rndDMG = new Random();
                            damage = rndDMG.Next(5, 11); //generuje damage hráče
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Úderil jsi: " + damage + " damage.");
                            Console.ResetColor();
                            enemyHP = enemyHP - damage;
                            Console.WriteLine("Životy neprítele: " + enemyHP);
                            foreach (string Sword in Statistics.inventory)
                            {
                                damage++;
                            }
                            foreach (string Shield in Statistics.inventory)
                            {
                                enemyDMG--;
                            }
                            foreach (string Armour in Statistics.inventory)
                            {
                                enemyDMG--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Minul jsi, správný výsledek je " + vysledek1);
                        }
                        break;
                        
                    case 2: //útok odčítání
                        Console.WriteLine("vybral jsi slabý útok (odčítání)");
                        Console.WriteLine($"vypocítej príklad: {y} - {x} =");
                        vstup = Console.ReadLine();
                        odpoved = int.Parse(vstup);
                        vysledek2 = y - x;
                        if (vysledek2 == odpoved)
                        {
                            Random rndDMG = new Random();
                            damage = rndDMG.Next(5, 11);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Úderil jsi: " + damage + " damage.");
                            Console.ResetColor();
                            enemyHP = enemyHP - damage;
                            Console.WriteLine("Životy neprÍtele: " + enemyHP);
                            foreach (string Sword in Statistics.inventory)
                            {
                                damage++;
                            }
                            foreach (string Shield in Statistics.inventory)
                            {
                                enemyDMG--;
                            }
                            foreach (string Armour in Statistics.inventory)
                            {
                                enemyDMG--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Minul jsi, správný výsledek je " + vysledek2);
                        }
                        break;
                    case 3:  //útok násobení

                        Console.WriteLine("Vybral jsi silný útok(násobení)");
                        Console.WriteLine($"Vypočítej príklad: {y} * {x} =");
                        vstup = Console.ReadLine();
                        odpoved = int.Parse(vstup);
                        vysledek3 = x * y;
                        if (vysledek3 == odpoved)
                        {
                            Random rndDMG = new Random();
                            damage = rndDMG.Next(10, 21);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Údeřil jsi damage " + damage);
                            Console.ResetColor();
                            enemyHP = enemyHP - damage;
                            Console.WriteLine("Životy neprítele: " + enemyHP);
                            foreach (string Sword in Statistics.inventory)
                            {
                                damage++;
                            }
                            foreach (string Shield in Statistics.inventory)
                            {
                                enemyDMG--;
                            }
                            foreach (string Armour in Statistics.inventory)
                            {
                                enemyDMG--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Minul jsi, správný výsledek je " + vysledek3);
                        }
                        break;
                    
                    default:
                        Console.WriteLine("INVALID");
                        break;
                }
                if (enemyHP > 0)    // nepřítel útočí jen pokud žije
                {
                    Random rndHit = new Random();
                    HitChance = rndHit.Next(0, 101);
                    if (HitChance <= 70) //nepřítel má 70% šanci na zásah hráče
                    {
                        Random rndeDMG = new Random();
                        enemyDmgEXTRA = rndeDMG.Next(5, 16);
                        enemyDMG = enemyDMG + enemyDmgEXTRA;
                        Statistics.health = Statistics.health - enemyDMG;
                        if (Statistics.health < 0)
                        {
                            Statistics.health = 0;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nepritel ti ubral " + enemyDMG + "životů.");
                        Console.ResetColor();
                        Console.WriteLine("Zbýva ti " + Statistics.health + "životů.");
                    }
                    else
                    {
                        Console.WriteLine("Nepritel minul.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Nepritel zemrel");
                    Console.ResetColor();
                }
            }

            Statistics.level++;
            Statistics.gold =+ 50;   // přidá goldy za dokončený level
        }

        stopwatch.Stop();
            Console.WriteLine("Dokoncil jsi " + Statistics.level + ". level v " + stopwatch.Elapsed.TotalSeconds + " vteřinách."); //napíše čas splnění levelu
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
                    Console.WriteLine(item); //vypíše všechny položky v shopu
                }

                Console.WriteLine("Vyber číslo položky k nákupu nebo zmáčkni 0, abys opustil shop:");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (Statistics.gold >= 30)
                    {
                        Statistics.gold -= 30;
                        Console.WriteLine("Koupil jsi Sword! Zbylo ti " + Statistics.gold + " gold.");
                        Statistics.inventory.Add("Sword"); //Sword se přidá do inventory
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
                        Statistics.inventory.Add("Sheild"); //přidá se Shield do inventory
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
                        Statistics.inventory.Add("Armour"); //přidá se Armour do inventory
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