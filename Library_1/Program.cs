namespace Library_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
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
    }
}
