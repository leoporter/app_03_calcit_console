using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CalcIt
{
    // klasa do dodawania
    public class Addition
    {
        public double a;
        public double b;
        // konstruktor podaje wartości początkowe obu zmiennych
        public Addition()
        {
            a = 1;
            b = 1;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }
    }
    // klasa do odejmowania
    public class Subtraction
    {
        public double a;
        public double b;

        public Subtraction()
        {
            a = 1;
            b = 1;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }
    }
    // klasa do mnożenia
    public class Multiplication
    {
        public double a;
        public double b;

        public Multiplication()
        {
            a = 1;
            b = 1;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }
    }
    // klasa do dzielenia 
    public class Division
    {
        public double a;
        public double b;

        public Division()
        {
            a = 1;
            b = 1;
        }

        public double Divide(double a, double b)
        {
            // warunek sprawdzający, czy dzielnik jest zerem
            if (b != 0) return a / b;
            else return 0;
        }
    }

    public class Exponentiation
    {
        public double PowerBase;
        public int PowerExponent;
        public double ResultOfPower = 1;

        public Exponentiation()
        {

        }

        public double Power(double PowerBase, int PowerExponent)
        {

            if (PowerExponent >= 1)
            {
                for (int i = 1; i <= PowerExponent; i++)
                {
                    ResultOfPower = ResultOfPower * PowerBase;
                }

                return ResultOfPower;
            }

            else if (PowerExponent == 0)
            {
                return 1;
            }

            else
            {
                Console.WriteLine("Incorrect exponent!");
                return 0;
            }
            
        }

    }

    public class Factorial
    {
        public int number;
        public int result = 1;

        public Factorial()
        {

        }

        public int ProductOfFactorial(int number)
        {
            if (number >= 1)
            {
                for (int i = 1; i <= number; i++)
                {
                    result = result * i;
                }
                return result;
            }
            
            else if (number == 0)
            {
                return 1;
            }

            else
            {
                Console.WriteLine("Incorrect number has been given!");
                return 0;
            }
        }
    }

    // klasa, która pokazuje jakie są opcje kalkuatora oraz, którą operację ma wykonać
    public class ChoiceOptions
    {
        public int choice;

        public ChoiceOptions()
        {

        }

        // pokazuje działania
        public void ShowOptions()
        {
            Console.WriteLine("1. Addition (+)");
            Console.WriteLine("2. Subtraction (-)");
            Console.WriteLine("3. Multiplication (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Exponentiation (^)");
            Console.WriteLine("6. Factorial (!)");
        }

        // wybiera się działanie
        public void PickOption(int choice)
        {
            // wybór użytkownika
            Console.Write("Your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                // przypadek dodawania
                case 1:
                    Addition obj = new Addition();
                    Console.Write("a = ");
                    obj.a = double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    obj.b = double.Parse(Console.ReadLine());
                    Console.Write("result = ");
                    Console.WriteLine(obj.Add(obj.a, obj.b));
                    break;
                // przypadek odejmowania
                case 2:
                    Subtraction obj2 = new Subtraction();
                    Console.Write("a = ");
                    obj2.a = double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    obj2.b = double.Parse(Console.ReadLine());
                    Console.Write("result = ");
                    Console.WriteLine(obj2.Subtract(obj2.a, obj2.b));
                    break;
                // przypadek mnożenia
                case 3:
                    Multiplication obj3 = new Multiplication();
                    Console.Write("a = ");
                    obj3.a = double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    obj3.b = double.Parse(Console.ReadLine());
                    Console.Write("result = ");
                    Console.WriteLine(obj3.Multiply(obj3.a, obj3.b));
                    break;
                // przypadek dzielenia
                case 4:
                    Division obj4 = new Division();
                    Console.Write("a = ");
                    obj4.a = double.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    obj4.b = double.Parse(Console.ReadLine());
                    Console.Write("result = ");
                    Console.WriteLine(obj4.Divide(obj4.a, obj4.b));
                    break;
                case 5:
                    Exponentiation obj5 = new Exponentiation();
                    Console.Write("base = ");
                    obj5.PowerBase = double.Parse(Console.ReadLine());
                    Console.Write("exp = ");
                    obj5.PowerExponent = int.Parse(Console.ReadLine());
                    Console.Write("result = ");
                    Console.WriteLine(obj5.Power(obj5.PowerBase, obj5.PowerExponent));
                    break;
                case 6:
                    Factorial obj6 = new Factorial();
                    Console.Write("number = ");
                    obj6.number = int.Parse(Console.ReadLine());
                    Console.Write("result = ");
                    Console.WriteLine(obj6.ProductOfFactorial(obj6.number));
                    break;
                default:
                    Console.WriteLine("An error occured! You have chosen a wrong number!");
                    break;
            }
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // connection string do bazy danych
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dominik\Documents\CalcIt.mdf;Integrated Security=True;Connect Timeout=30";
            // tworzenie nowego obiektu z parametrem konstruktora będącego naszym connectionString 
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            // otwieram połączenie
            //sqlConnection.Open();
            // tworzy nowy obiekt
            ChoiceOptions ob = new ChoiceOptions();

            while (true)
            {
                // wyświetla opcje kalkulatora
                ob.ShowOptions();
                // użytkownik wybiera swoją opcję
                ob.PickOption(ob.choice);

                // wprowadzenie danych do tabeli
                /*string command = "INSERT INTO CalcIt (Id, Result, Action) VALUES (1, 20, Add)";
                SqlCommand sqlC = new SqlCommand(command, sqlConnection);
                sqlC.ExecuteReader();
                */
                // jeśli chcesz zakończyć, wciśnij Esc
                Console.WriteLine("Click Esc to finish.");
                // jeśli chcesz kontynuować, kliknij Enter
                Console.WriteLine("Click any other key to continue.");
                // pobierz znak, który został wciśnięty
                var PressedKey = Console.ReadKey();
                // jeśli wciśnięto Escape to zakończ
                if (PressedKey.Key == ConsoleKey.Escape) break;
                // przy kliknięciu innego klawisza kontynuuj
                else continue;
            }
            // zamykam połączenie
            //sqlConnection.Close();
            
        }
    }
}
