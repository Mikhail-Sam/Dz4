namespace MyApp
{
    internal class Program
    {
        static int Maxx(int numberOne, int numberTwo) // упражнение 5.1
        {
            return (numberOne > numberTwo) ? numberOne : numberTwo;
        }

        static void Meaning(ref int oneNumber, ref int twoNumber) // упражнение 5.2
        {
            int temp = oneNumber;
            oneNumber = twoNumber;
            twoNumber = temp;
        }

        static bool Factorial(int n, out long factorial) // упражнение 5.3
        {
            factorial = 1;
            if (n < 0)
            {
                return false;
            }

            try
            {
                for (int i = 1; i <= n; i++)
                {
                    checked
                    {
                        factorial *= i; // блок checked для отслеживания переполнения
                    }
                }

                return true;
            }
            catch (OverflowException) // выход за переделы (ариф.действия)
            {
                return false;
            }
        }

        static long FactorialRecursion(int numFactorial) // упражнение 5.4
        {
            if (numFactorial < 0)
            {
                throw new ArgumentOutOfRangeException("Отрицательное число");
            }

            if (numFactorial == 0 || numFactorial == 1)
            {
                return 1;
            }

            return numFactorial * FactorialRecursion(numFactorial - 1); // Рекурсия
        }

        static int GCD(int a, int b) //Домашнее задание 5.1
        {
            if (b == 0)
                return a;
            return GCD(b, a % b); //GCD - НОД
        }

        static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a, b), c);
        }

        static int Fibonacci(int n) //Домашнее задание 5.2
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("Число не натуральное");
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2); // Рекурсия
        }

        static void Main(string[] args)
        {
            Console.WriteLine("         Упражнение 5.1");
            Console.WriteLine("Введите два числа: ");

            string numberOnee = Console.ReadLine();
            string numberTwoo = Console.ReadLine();
            if (int.TryParse(numberOnee, out int numberOne) && int.TryParse(numberTwoo, out int numberTwo))
            {
                int result = Maxx(numberOne, numberTwo);
                Console.WriteLine($"{result}");
            }
            else
            {
                Console.WriteLine("Ошибка при вводе целого числа");
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine("         Упражнение 5.2");
            Console.WriteLine("Введите два числа:");

            string oneNumberInput = Console.ReadLine();
            string twoNumberInput = Console.ReadLine();
            if (int.TryParse(oneNumberInput, out int oneNumber) && int.TryParse(twoNumberInput, out int twoNumber))
            {
                Meaning(ref oneNumber, ref twoNumber);
                Console.WriteLine($"После обмена: oneNumber = {oneNumber}, twoNumber = {twoNumber}");
            }
            
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("         Упражнение 5.3");
            Console.WriteLine("Введите число:");
            long resultt;
            string nInput = Console.ReadLine();
            if (int.TryParse(nInput, out int num))
            {
                bool factorialOfNumber = Factorial(num, out resultt);
                if (factorialOfNumber)
                {
                    Console.WriteLine($"Факториал {num} равен: {resultt}");
                }
                else
                {
                    Console.WriteLine($"Переполнено {num}");
                }
            }
            else
            {
                Console.WriteLine("Ошибка при вводе целого числа");
            }   
            
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("         упражнение 5.4");
            Console.WriteLine("Введите число:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int numm))
            {
                try
                {
                    long resultFactorial = FactorialRecursion(numm);
                    Console.WriteLine($"Факториал {numm} равен: {resultFactorial}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Ошибка при вводе целого числа");
            }

            
            Console.WriteLine(string.Empty);
            Console.WriteLine("         Домашнее задание 5.1");
            Console.WriteLine("Введите два натуральных числа для НОД:");
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            if (int.TryParse(input1, out int num1) && int.TryParse(input2, out int num2) && num1 > 0 && num2 > 0)
            {
                int resultGHD = GCD(num1, num2);
                Console.WriteLine($"НОД {num1} и {num2} равен: {resultGHD}");
            }
            else
            {
                Console.WriteLine("Ошибка при вводе натуральных чисел");
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine("         Домашнее задание 5.2");
            Console.WriteLine("Введите номер для числа Фибоначчи:");
            string numberFibonacci = Console.ReadLine();
            if (int.TryParse(numberFibonacci, out int nFibonacci) && nFibonacci > 0)
            {
                int resultFibonacci = Fibonacci(nFibonacci);
                Console.WriteLine($"Число Фибоначчи {nFibonacci} равно: {resultFibonacci}");
            }
            else
            {
                Console.WriteLine("Ошибка при вводе натуральных чисел");
            }
        }
    }
}

    

