using System;

namespace Program2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 11);
            int user = 0;
            bool valid = false;
            int i = 0;
            bool[] array = new bool[10];
            bool continueFlag = true;


            Console.Title = "Zgadnij liczbę";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Zgadnij liczbę od 1 do 10!\n");
            Console.ResetColor();

            do
            {
                do
                {
                    do
                    {
                        Console.Write("Podaj liczbę: ");
                        valid = int.TryParse(Console.ReadLine(), out user);
                        if (!valid)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podaj prawidłową liczbę");
                            Console.ResetColor();
                        }
                    } while (!valid);

                    if (user < 1 || user > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podaj liczbę z zakresu 1-10");
                        Console.ResetColor();
                        continue;

                    }

                    if (array[user - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Podano tą samą liczbę!");
                        Console.ResetColor();
                        continue;
                    }
                    else
                    {
                        array[user - 1] = true;
                    }

                    if (random < user)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Wylosowana liczba jest mniejsza od Twojej");
                        Console.ResetColor();
                    }
                    else if (random > user)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Wylosowana liczba jest większa od Twojej");
                        Console.ResetColor();
                    }
                    i++;
                } while (user != random);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Brawo!! Odgadłeś za {i} razem.");
                Console.ResetColor();

                if (Char.ToUpper(GetKeyPress("Czy chcesz zagrać na nowo (Y/N): ", new Char[] { 'Y', 'N' })) == 'N')
                    continueFlag = false;
                Console.Clear();

            } while (continueFlag);

        }
        private static Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;

            Console.WriteLine();
            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey();
                Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;
            } while (!valid);
            return keyPressed.KeyChar;
        }
    }
}
