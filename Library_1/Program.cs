using System.Transactions;

namespace Library_1
{
    internal class Program
    {
        static string[] userName = ["Olivia", "Viktor", "Doris", "Nemo", "Egon"];
        static string[] userPassword = ["Olivia1", "Viktor1", "Doris1", "Nemo1", "Egon1"];
        static string[] titles = ["Harry potter och de vise sten", "The good guy", "The bad guy", "Eragon", "Hail Mary",];
        static int[] NumberOfTitles = [3, 2, 4, 0, 1];
        static int[,] userLoan = new int[5, 5];
        // -1 represents that no one is logged in.
        static int currentUser = -1;
        static void Main(string[] args)
        {
            RunProgram();
        }
        static void RunProgram()
        {
            Welcome();

            Logattampts();
            if (currentUser == -1)
            {
                return;
            }
            while (currentUser != -1)
            {
                Menu();
            }
        }


        static void Welcome()
        {
            Console.WriteLine("Välkommen till ditt bibliotek!");
            Console.WriteLine("_____________________________");
            Console.WriteLine();
            Console.WriteLine("Klicka \"Enter\" för att logga in: ");
            Console.ReadKey();
            Console.Clear();
        }

        static int Login(string userNameInput, string userPasswordInput)
        {
            for (int i = 0; i < userName.Length; i++)
            {   // Checking so the username and the password are matching 
                if (userName[i] == userNameInput && userPassword[i] == userPasswordInput)
                {
                    // Determents the user who are logged in.
                    currentUser = i;
                    return i;
                }
            }
            // No one is logged in
            return -1;
        }

        static void Logattampts()
        {
            int logCount = 0;
            bool correctLogin = false;
            string userNameInput;
            string userPasswordInput;

            Console.WriteLine("Ange användarnamn och lösenord: ");
            Console.WriteLine("_______________________________:");
            Console.WriteLine();
            // You have 3 tries to log in.
            while (!correctLogin && logCount < 3)
            {
                Console.WriteLine("Användarnamn: ");
                userNameInput = Console.ReadLine();
                Console.WriteLine("Lösenord: ");
                userPasswordInput = Console.ReadLine();

                int userIndex = Login(userNameInput, userPasswordInput);
                if (userIndex != -1)
                {
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

        }

        static int GetUserNumber(int min, int max)
        {
            int choice;
            Console.WriteLine();
            Console.Write("Ditt val: ");
            
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.WriteLine($"Du måste välja mellan valen {min} till {max}");
            }
            return choice;
        }
        static void Menu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("\tBibloteks meny");
            Console.WriteLine("\t______________");
            Console.WriteLine();
            Console.WriteLine($"\tInloggad: {userName[currentUser]}");
            Console.WriteLine();
            Console.WriteLine("Du får nu 5 valmöjligheter. Välj med siffrorna 1 till 5");
            Console.WriteLine();
            Console.WriteLine("1: Visa böcker.");
            Console.WriteLine("2: Låna böcker.");
            Console.WriteLine("3: Lämna tillbaka böcker.");
            Console.WriteLine("4: Mina lån.");
            Console.WriteLine("5: Logga ut.");

            
            choice = GetUserNumber(1, 5);

            switch (choice)
            {
                case 1:
                    ShowBooks();
                    Console.WriteLine();
                    Console.WriteLine("Klicka \"Enter\" för att komma till menyn.");
                    Console.ReadKey();
                    break;
                case 2:
                    BorrowBook();
                    break;
                case 3:
                    ReturnBook();
                    break;
                case 4:
                    UsersBooks();
                    Console.WriteLine();
                    Console.WriteLine("\"Enter\" för att fortsätta: ");
                    Console.ReadKey();
                    break;
                case 5:
                    currentUser = -1;
                    Console.Clear();
                    RunProgram();
                    break;
            }
        }
        static void ShowBooks()
        {
            Console.Clear();
            Console.WriteLine("Vi har dessa böcker att låna ut idag: ");
            Console.WriteLine("__________________________________");
            // List of all the books that are available
            for (int i = 0; i < titles.Length; i++)
            {
                Console.WriteLine($"{i + 1}: Titel:{titles[i]}: Exemplar: {NumberOfTitles[i]}");
            }
        }
        static void BorrowBook()
        {
            //Makes sure that you dont go over 5 books in your inventory.
            int bookCount = BorrowBookCount();
            while (bookCount != 5)
            {
                Console.WriteLine("Låna bok");
                Console.WriteLine("________");
                Console.WriteLine();
                ShowBooks();
                Console.WriteLine();
                Console.WriteLine("Vilken bok hade du velat låna?");
                
                int choice = GetUserNumber(1, titles.Length);
                // if the book has no examples left.
                if (NumberOfTitles[choice - 1] == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"{titles[choice - 1]} har inga exemplar att låna ut just nu. ");
                    Console.WriteLine("_______________________________________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("Klicka \"Enter\" för att komma tillbaka till menyn: ");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();

                    // Finding an free space on the user to put the borrowed book. 
                    for (int i = 0; i < userLoan.GetLength(1); i++)
                    {
                        if (userLoan[currentUser, i] == 0)
                        {
                            userLoan[currentUser, i] = choice;
                            Console.WriteLine($"Du har nu lånat: {titles[choice - 1]}");
                            Console.WriteLine("___________________________________________");
                            Console.WriteLine();
                            Console.WriteLine("Klicka \"Enter\" för att komma tillbaka till menyn: ");
                            Console.ReadKey();
                            // Takes away one example of the title . 
                            NumberOfTitles[choice - 1]--;
                            break;
                        }
                    }
                    return;
                }
            }
            // If you have borrowed 5 book already
            Console.Clear();
            Console.WriteLine("Du har lånat upp till ditt maxtak: 5 böcker");
            Console.WriteLine("Du måste lämna tillbaka en bok för att få låna mer. ");
            Console.WriteLine("");
            Console.WriteLine("Klicka \"Enter\" för att komma tillbaka till menyn: ");
            Console.ReadKey();
        }

        static void ReturnBook()
        {
            // Checks if the user have any borrowed books
            if (!UsersBooks())
            {
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Vilken bok hade du viljat lämna tillbaka? Svara med siffrorna 1-5: ");
            Console.WriteLine("________________________________________________________________________");
            Console.WriteLine("");
            
            // Tracks how many books the user have
            int borrowBookCount = BorrowBookCount();

            int choice = GetUserNumber(1, borrowBookCount);
            Console.WriteLine();
            //counter are used for matching user (choice) with the right book in the array
            int counter = 1;
            for (int i = 0; i < userLoan.GetLength(1); i++)
            {   //bookIndex are for the books and i is for the place the books are in.
                int bookIndex = userLoan[currentUser, i];
                if (bookIndex != 0)
                {
                    if (counter == choice)
                    {
                        //Replace the space of the userLoan array with 0 and ++ the number of titles. 
                        userLoan[currentUser, i] = 0;
                        NumberOfTitles[bookIndex - 1]++;
                        Console.Clear();
                        Console.WriteLine($"Du har lämnat tillbaka {titles[bookIndex - 1]}. ");
                        Console.WriteLine("_______________________________________________________");
                        Console.WriteLine();
                        Console.WriteLine("Klicka \"Enter\" för att komma tillbaka till menyn: ");
                        Console.ReadKey();
                        return;
                    }
                    counter++;
                }
            }
        }

        static bool UsersBooks()
        {
            Console.Clear();
            int counter = 1;
            //(loans) checks if the user has any borrowed books. 
            bool loans = false;
            Console.WriteLine("Du har lånat: ");
            Console.WriteLine("_______________________________");
            Console.WriteLine();
            for (int i = 0; i < userLoan.GetLength(1); i++)
            {
                int bookIndex = userLoan[currentUser, i];
                if (bookIndex != 0)
                {
                    Console.WriteLine($"{counter}: {titles[bookIndex - 1]}");
                    counter++;
                    loans = true;
                }
            }
            if (!loans)
            {
                Console.WriteLine("Du har inga lånade böcker!");
                Console.WriteLine();
                Console.WriteLine("Klicka \"Enter\" för att fortsätta");
                Console.ReadKey();
                //Make sure that the user comes back to menu. 
                return false;
            }
            return true;
        }

        
        static int BorrowBookCount()
        {
            
            int borrowCount = 0;
            for (int i = 0; i < userLoan.GetLength(1); i++)
            {
                if (userLoan[currentUser, i] > 0)
                {
                    borrowCount++;
                }
            }
            return borrowCount;
        }
    }
}


