namespace Library_1
{
    internal class Program
    {
        static string[] userName = ["Olivia", "Viktor", "Doris", "Nemo", "Egon"];
        static string[] userPassword = ["Olivia1", "Viktor1", "Doris1", "Nemo1", "Egon1"];
        static string[] titles = ["Harry potter och det vise sten", "The good guy", "The bad guy", "Eragon", "Hail Mary",];
        static int[] nrTitles = [3, 2, 4, 0, 1];
        static int[,] userLoan = new int[5, 5];
        static int currentUser = -1;
        static void Main(string[] args)
        {
            Welcome();

            bool runProgram = Logattampts();
            if (!runProgram)
            {
                return;
            }
            while (runProgram)
            {
                Menu();
            }
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

        static int Login(string userNameInput, string userPasswordInput)
        {
            bool correctLogin = false;


            for (int i = 0; i < userName.Length; i++)
            {
                if (userName[i] == userNameInput && userPassword[i] == userPasswordInput)
                {
                    return i;
                }
            }
            return -1;
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

                int userIndex = Login(userNameInput, userPasswordInput);
                if (userIndex != -1)
                {
                    currentUser = userIndex;
                    correctLogin = true;
                }

                if (!correctLogin)
                {
                    Console.Clear();
                    Console.WriteLine("Fel användarnamn eller lösenord, försök igen.");
                    Console.WriteLine($"försök {logCount + 1} av 3");
                    logCount++;
                }
            }
            return correctLogin;
        }
        static void Menu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("Bibloteks meny");
            Console.WriteLine("_______________");
            Console.WriteLine("Du får nu 5 valmöjligheter. Välj med siffrorna 1 till 5");
            Console.WriteLine();
            Console.WriteLine("1: Visa böcker.");
            Console.WriteLine("2: Låna böcker.");
            Console.WriteLine("3: Lämna tillbaka böcker.");
            Console.WriteLine("4: Mina lån.");
            Console.WriteLine("5: Logga ut.");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > 5)
            {
                Console.WriteLine("Du måste välja mellan valen 1 till 5");
            }

            switch (choice)
            {
                case 1:
                    ShowBooks();
                    break;
                case 2:
                    BorrowBook();
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
            Console.Clear();
            Console.WriteLine("Vi har dessa böcker att låna idag: ");
            Console.WriteLine("__________________________________");
            for (int i = 0; i < titles.Length; i++)
            {
                Console.WriteLine($"{i + 1}: Titel :{titles[i]}, Exemplar {nrTitles[i]}");
            }
        }
        static int BorrowBook()
        {
            int choice;
            Console.WriteLine("Låna bok");
            Console.WriteLine("________");
            Console.WriteLine("");
            ShowBooks();
            Console.WriteLine();
            Console.WriteLine("Vilken bok hade du velat låna?");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
            {
                Console.WriteLine("Du måste välja med hjälp av siffrorna 1-5");
            }
            if (nrTitles[choice - 1] == 0)
            {
                Console.WriteLine("Denna boken har inga exemplar att låna ut just nu. ");
            }
            else
            {
                nrTitles[choice - 1]--;
            }


            return choice;
        }

        static void UsersBooks()
        {

        }
    }
}
