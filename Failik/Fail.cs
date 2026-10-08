namespace LabWork;

class Program
{
    static void Main()
    {
        Console.WriteLine("         ЗАДАЧА 1");
        Console.WriteLine("Создаем массив из 20 случайных чисел");
        
        Random random = new Random();
        int[] array = new int[20];
        
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 101); // Next(1, 101) дает число от 1 до 100
        }
        
        Console.WriteLine("Исходный массив:");
        PrintArray(array); // Вызываем метод для вывода массива
        
        Console.WriteLine("Введите первое число из массива для обмена: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите второе число из массива для обмена: ");
        int num2 = int.Parse(Console.ReadLine());
        
        int index1 = Array.IndexOf(array, num1); 
        int index2 = Array.IndexOf(array, num2); 

        // Проверяем, что оба числа найдены в массиве
        if (index1 != -1 && index2 != -1)
        {
            int temp = array[index1]; 
            array[index1] = array[index2];
            array[index2] = temp;

            Console.WriteLine("Массив после обмена:");
            PrintArray(array); 
        }
        else
            Console.WriteLine("Одно или оба числа не найдены в массиве!");
        

        
        // ЗАДАЧА 2
        Console.WriteLine(string.Empty);
        Console.WriteLine("         ЗАДАЧА 2");
        
        int[] testArray = { 5, 10, 15, 20, 25 };
        double average;
        long product = 1;
        
        double sum = CalculateStats(testArray, out average, ref product);
        
        Console.WriteLine($"Массив: {string.Join(", ", testArray)}");
        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Произведение: {product}");
        Console.WriteLine($"Среднее арифметическое: {average:F2}");

        
        
        // ЗАДАЧА 3
        Console.WriteLine(string.Empty);
        Console.WriteLine("         ЗАДАЧА 3");
        Console.WriteLine("Вводите цифры от 0 до 9 для рисования: ");

        bool exitProgram = false;
        
        while (!exitProgram)
        {
            Console.WriteLine("Введите число или команду: ");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "exit" || input.ToLower() == "закрыть")
            {
                exitProgram = true; 
                continue;
            }
            try
            {
                int number = int.Parse(input); 
                
                if (number >= 0 && number <= 9)
                {
                    DrawDigit(number);
                }
                else
                {
                    ConsoleColor originalColor = Console.ForegroundColor; // Сохраняем текущий цвет
                    Console.ForegroundColor = ConsoleColor.Red; // Устанавливаем красный цвет
                    Console.WriteLine("Ошибка: число должно быть от 0 до 9!");
                    Console.ForegroundColor = originalColor; // Восстанавливаем цвет
                    
                    Thread.Sleep(3000);
                }
            }
            catch (FormatException) // Если ввод не является числом
            {
                throw new FormatException("Вы ввели не число! Программа завершается.");
            }
            Console.WriteLine(string.Empty);
        }

        
        
        // ЗАДАЧА 4
        Console.WriteLine(string.Empty);
        Console.WriteLine("         ЗАДАЧА 4");
        
        Grandpa grandpa1 = new Grandpa("Иван", GrumpinessLevel.High,
            "Проститутки!", "Гады!", "Блин!", "Черт возьми!");

        Grandpa grandpa2 = new Grandpa("Петр", GrumpinessLevel.Medium,
            "Тьфу ты!", "Ну и денек!", "Ох уж эти внуки!");

        Grandpa grandpa3 = new Grandpa("Сергей", GrumpinessLevel.High,
            "Суки!", "Мрази!", "Подонок!", "Уроды!");

        Grandpa grandpa4 = new Grandpa("Алексей", GrumpinessLevel.Mild,
            "Эх, молодежь...", "Раньше лучше было", "Лень матушка");

        Grandpa grandpa5 = new Grandpa("Николай", GrumpinessLevel.Medium,
            "Хреново!", "Задолбали!", "Отстаньте!");

        // Список матерных слов для проверки
        string[] badWordsList = { "проститутки", "суки", "мрази", "хреново", "гады" };
        
        Console.WriteLine("Проверка дедов на матерные слова:");

        int eyes1 = Grandpa.CheckBadWords(grandpa1, badWordsList);
        Console.WriteLine($"{grandpa1.Name}: {eyes1} фингал(ов)");

        int eyes2 = Grandpa.CheckBadWords(grandpa2, badWordsList);
        Console.WriteLine($"{grandpa2.Name}: {eyes2} фингал(ов)");

        int eyes3 = Grandpa.CheckBadWords(grandpa3, badWordsList);
        Console.WriteLine($"{grandpa3.Name}: {eyes3} фингал(ов)");

        int eyes4 = Grandpa.CheckBadWords(grandpa4, badWordsList);
        Console.WriteLine($"{grandpa4.Name}: {eyes4} фингал(ов)");

        int eyes5 = Grandpa.CheckBadWords(grandpa5, badWordsList);
        Console.WriteLine($"{grandpa5.Name}: {eyes5} фингал(ов)");
        
    }
    
    static void PrintArray(int[] arr)
    {
        // string.Join объединяет элементы массива через запятую
        Console.WriteLine(string.Join(", ", arr));
    } 
    static long CalculateStats(int[] arr, out double average, ref long product)
    {
        long sum = 0; 
        product = 1; 

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i]; 
            product *= arr[i]; 
        }
        average = (double)sum / arr.Length;
        return sum; 
    }
    // Метод для рисования цифры символами #
    static void DrawDigit(int digit)
    {
        
        string[][] digits = new string[][]
        {
            new string[]
            {
                " ### ",
                "#   #",
                "#   #",
                "#   #",
                " ### "
            },
            new string[]
            {
                "  #  ",
                " ##  ",
                "  #  ",
                "  #  ",
                " ### "
            },
            new string[]
            {
                " ### ",
                "#   #",
                "  ## ",
                " #   ",
                "#####",
            },
            new string[]
            {
                " ### ",
                "#   #",
                "  ## ",
                "#   #",
                " ### "
            },
            new string[]
            {
                "#   #",
                "#   #",
                "#####",
                "    #",
                "    #"
            },
            new string[]
            {
                "#####",
                "#    ",
                "#### ",
                "    #",
                "#### "
            },
            new string[]
            {
                " ### ",
                "#    ",
                "#### ",
                "#   #",
                " ### "
            },
            new string[]
            {
                "#####",
                "    #",
                "   # ",
                "  #  ",
                " #   "
            },
            new string[]
            {
                " ### ",
                "#   #",
                " ### ",
                "#   #",
                " ### "
            },
            new string[]
            {
                " ### ",
                "#   #",
                " ####",
                "    #",
                " ### "
            }
        };
    for (int i = 0; i < digits[digit].Length; i++)
        {
            Console.WriteLine(digits[digit][i]);
        }
    }
}
