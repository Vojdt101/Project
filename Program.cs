List<string> usernames = new List<string> {"Alice", "Bob", "Petr"};
List<string> passwords = new List<string> {"pass1", "pass2", "pass3"};

Console.WriteLine("Zadej username");
string inputUsername = Console.ReadLine();

Console.WriteLine("Zadej heslo");
string inputPassword = Console.ReadLine();

string password = null;
bool found = false;
int index = 0;

foreach (string username1 in usernames) {
            if (username1 == inputUsername) {
                if (passwords[index] == inputPassword) {
                    Console.WriteLine("Success!");
                } else {
                    Console.WriteLine("Fail!");
                }
                found = true;
                break; // stop searching after match
            }
            index++;
        }

        if (!found) {
            Console.WriteLine("Username not found!");
            return;

}


Console.WriteLine("Vítej!");
Console.WriteLine("Toto je bojovací hra.");
Console.WriteLine("Začínáš");