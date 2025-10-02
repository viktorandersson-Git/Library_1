namespace Library_1
{
    internal class Program
    {
        static string[] books = ["Harry potter och det vise sten", "The good guy", "The bad guy", "Eragon", "Hail Mary",];
        static void Main(string[] args)
        {
            Welcome();

            bool runProgram = Logattampts();
            if (!runProgram)
            {
                return;
            }
            Menu();
        }



        static void Welcome()
        {
            Console.WriteLine("Välkommen till ditt biblotek!");
            Console.WriteLine("_____________________________");
            Console.WriteLine();
            Console.WriteLine("Klicka enter för att logga in: ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Ange användarnamn och lösenord: ");
            Console.WriteLine("_______________________________:");
            Console.WriteLine();
        }

        static bool Login(string userNameInput, string userPasswordInput)
        {
            bool correctLogin = false;
            string[] userName = ["Olivia", "Viktor", "Doris", "Nemo", "Egon"];
            string[] userPassword = ["Olivia1", "Viktor1", "Doris1", "Nemo1", "Egon1"];

            for (int i = 0; i < userName.Length; i++)
            {
                if (userName[i] == userNameInput && userPassword[i] == userPasswordInput)
                {
                    correctLogin = true;
                    break;
                }
            }
            return correctLogin;
        }

        static bool Logattampts()
        {
            int logCount = 0;
            bool correctLogin = false;
            string userNameInput;
            string userPasswordInput;
            bool runProgram = false;
            while (!correctLogin && logCount < 3)
            {
                Console.WriteLine("Användarnamn: ");
                userNameInput = Console.ReadLine();
                Console.WriteLine("Lösenord: ");
                userPasswordInput = Console.ReadLine();
                correctLogin = Login(userNameInput, userPasswordInput);
                if (correctLogin)
                {
                    break;
                }

                if (!correctLogin)
                {
                    Console.Clear();
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen.");
                    Console.WriteLine($"försök {logCount + 1} av 3");
                    logCount++;
                }
            }
            return runProgram;
        }
        static void Menu()
        {
            int choice;
            Console.WriteLine("Bibloteks meny");
            Console.WriteLine("Du får nu 5 valmöjligheter. Välj med siffrorna 1 till 5");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > 5)
            {
                Console.WriteLine("Du måste välja mellan valen 1 till 5");
            }

            switch (choice)
            {
                case 1:
                    //Visa böcker
                    break;
                case 2:
                    // Låna Bok
                    break;
                case 3:
                    //Lämna till bok
                    break;
                case 4:
                    //Mina lån
                    break;
                case 5:
                    //Logga ut
                    break;
            }
        }
        static void ShowBooks()
        {

        }
    }
}
