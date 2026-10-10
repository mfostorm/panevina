// Автор: Паневина С.Е., группа СИд-023
// Вариант: 9
// Лабораторная работа №1, задание 6
// Описание: консольный калькулятор с меню, объединяющий задания 1-5.
// Каждый пункт меню вынесен в отдельный метод, Main содержит только меню.
using System;

namespace Lab1_Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=========== КАЛЬКУЛЯТОР (вариант 9) ===========");
                Console.WriteLine("1 - Арифметические операции (+, -, *, /, %)");
                Console.WriteLine("2 - Дальность полёта (задание 2)");
                Console.WriteLine("3 - Перевод студента на курс (задание 3)");
                Console.WriteLine("4 - Удаление знаков препинания (задание 4)");
                Console.WriteLine("5 - Таблица умножения N x N (задание 5)");
                Console.WriteLine("0 - Выход");
                Console.Write("выберите пункт меню: ");

                var line = Console.ReadLine();
                if (line == null) return; // ввод закончился - выходим
                string choice = line.Trim();
                switch (choice)
                {
                    case "1": Arithmetic(); break;
                    case "2": FlightDistance(); break;
                    case "3": StudentCheck(); break;
                    case "4": RemovePunctuation(); break;
                    case "5": MultiplicationTable(); break;
                    case "0":
                        Console.WriteLine("работа программы завершена.");
                        return;
                    default:
                        Console.WriteLine("ошибка: такого пункта меню нет.");
                        break;
                }
            }
        }

        /// <summary>Пункт 1: арифметическая операция над двумя числами.</summary>
        static void Arithmetic()
        {
            double a = ReadDouble("первое число: ");
            Console.Write("операция (+, -, *, /, %): ");
            string op = Console.ReadLine() ?? "";
            double b = ReadDouble("второе число: ");

            switch (op)
            {
                case "+": Console.WriteLine($"результат: {a:F2} + {b:F2} = {a + b:F2}"); break;
                case "-": Console.WriteLine($"результат: {a:F2} - {b:F2} = {a - b:F2}"); break;
                case "*": Console.WriteLine($"результат: {a:F2} * {b:F2} = {a * b:F2}"); break;
                case "/":
                case "%":
                    if (b == 0)
                    {
                        Console.WriteLine("ошибка: деление на ноль невозможно.");
                    }
                    else if (op == "/")
                    {
                        Console.WriteLine($"результат: {a:F2} / {b:F2} = {a / b:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"результат: {a:F2} % {b:F2} = {a % b:F2}");
                    }
                    break;
                default:
                    Console.WriteLine("ошибка: неизвестная операция.");
                    break;
            }
        }

        /// <summary>Пункт 2: дальность полёта L = v^2 * sin(2a) / g.</summary>
        static void FlightDistance()
        {
            double v = ReadDouble("скорость v (м/с): ");
            double alpha = ReadDouble("угол alpha (градусы): ");
            double g = ReadDouble("ускорение g (м/с^2): ");

            if (v < 0)
            {
                Console.WriteLine("ошибка: скорость не может быть отрицательной.");
                return;
            }
            if (g <= 0)
            {
                Console.WriteLine("ошибка: g должно быть больше нуля (деление на ноль).");
                return;
            }

            double sin2a = Math.Sin(2 * alpha * Math.PI / 180);
            double l = sin2a > 0 ? v * v * sin2a / g : 0;
            Console.WriteLine($"дальность полёта: {l:F2} м");
        }

        /// <summary>Пункт 3: проверка перевода студента по трём оценкам.</summary>
        static void StudentCheck()
        {
            int m1 = ReadInt("оценка 1 (2-5): ");
            int m2 = ReadInt("оценка 2 (2-5): ");
            int m3 = ReadInt("оценка 3 (2-5): ");

            if (m1 < 2 || m1 > 5 || m2 < 2 || m2 > 5 || m3 < 2 || m3 > 5)
            {
                Console.WriteLine("ошибка: оценки должны быть от 2 до 5.");
                return;
            }

            double avg = (m1 + m2 + m3) / 3.0;
            Console.WriteLine($"средний балл: {avg:F2}");

            if (m1 == 2 || m2 == 2 || m3 == 2)
            {
                Console.WriteLine("решение: НЕ переведён (есть двойка)");
            }
            else if (avg >= 3.0)
            {
                Console.WriteLine("решение: переведён");
            }
            else
            {
                Console.WriteLine("решение: НЕ переведён (средний балл ниже 3.0)");
            }
        }

        /// <summary>Пункт 4: удаление знаков препинания из строки.</summary>
        static void RemovePunctuation()
        {
            Console.Write("введите строку: ");
            string text = Console.ReadLine() ?? "";
            if (text.Trim().Length == 0)
            {
                Console.WriteLine("ошибка: пустая строка.");
                return;
            }

            string punctuation = ".,;:!?-—–\"'«»()[]{}…/";
            string result = "";
            foreach (char c in text)
            {
                if (punctuation.IndexOf(c) < 0)
                {
                    result += c;
                }
            }
            while (result.IndexOf("  ") >= 0)
            {
                result = result.Replace("  ", " ");
            }

            Console.WriteLine($"результат: {result.Trim()}");
        }

        /// <summary>Пункт 5: таблица умножения N x N.</summary>
        static void MultiplicationTable()
        {
            int n = ReadInt("N (1-20): ");
            if (n <= 0 || n > 20)
            {
                Console.WriteLine("ошибка: N должно быть от 1 до 20.");
                return;
            }

            int w = (n * n).ToString().Length + 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write((i * j).ToString().PadLeft(w));
                }
                Console.WriteLine();
            }
        }

        /// <summary>Ввод вещественного числа с повтором при ошибке.</summary>
        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var line = Console.ReadLine();
                if (line == null) Environment.Exit(0); // ввод закончился
                if (double.TryParse(line, out double value))
                {
                    return value;
                }
                Console.WriteLine("ошибка: введено не число.");
            }
        }

        /// <summary>Ввод целого числа с повтором при ошибке.</summary>
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var line = Console.ReadLine();
                if (line == null) Environment.Exit(0); // ввод закончился
                if (int.TryParse(line, out int value))
                {
                    return value;
                }
                Console.WriteLine("ошибка: введите целое число.");
            }
        }
    }
}
