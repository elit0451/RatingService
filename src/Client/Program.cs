using System;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private void Start()
        {
            int grade = 0;
            string description = "";
            string country = "";
            string gender = "";
            int age = 0;

            Console.WriteLine("Hello from our anonymous questionnaire!");
            Console.WriteLine("\tWhat is the grade you rate our services:");
            
            Int32.TryParse(Console.ReadLine(), out grade);

            Console.Clear();
            Console.WriteLine("Hello from our anonymous questionnaire!");
            Console.WriteLine("\tPlease provide some comments:");
            description = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Hello from our anonymous questionnaire!");
            Console.WriteLine("\tWould you like to continue for 3 more questions?(Y/n)");
            ConsoleKeyInfo response = Console.ReadKey();

            if (response.Key == ConsoleKey.Enter || response.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Console.WriteLine("Hello from our anonymous questionnaire!");
                Console.WriteLine("\tWhat is your current country?");
                country = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Hello from our anonymous questionnaire!");
                Console.WriteLine("\tWhat is your gender?");
                gender = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Hello from our anonymous questionnaire!");
                Console.WriteLine("\tWhat is your age?");
                Int32.TryParse(Console.ReadLine(), out age);
            }

            Console.WriteLine("Thank you for participating!");
            
            MessageGateway.SendAnswers(grade, description, country, gender, age);
        }
    }
}
