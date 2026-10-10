// Автор: Паневина С.Е., группа СИд-023
// Вариант: 9
// Лабораторная работа №1, задание 5
// Описание: вывод таблицы умножения N x N в форматированном виде.
// N вводится с проверкой (1 <= N <= 20), ширина столбца зависит от N*N.
using System;

namespace Lab1_Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировка UTF-8, чтобы русские буквы правильно отображались в консоли
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Задание 5. Таблица умножения N x N");
            Console.WriteLine(new string('-', 45));

            int n;
            // цикл do-while: повторяем ввод, пока N не станет корректным
            do
            {
                Console.Write("введите N (от 1 до 20): ");
                var line = Console.ReadLine();
                if (line == null) return; // ввод закончился
                if (!int.TryParse(line, out n))
                {
                    Console.WriteLine("ошибка: введите целое число.");
                    n = 0;
                }
                else if (n <= 0 || n > 20)
                {
                    Console.WriteLine("ошибка: N должно быть от 1 до 20.");
                }
            } while (n <= 0 || n > 20);

            // ширина столбца = количество цифр в самом большом числе + 1
            int w = (n * n).ToString().Length + 1;

            // строка заголовка
            Console.Write(new string(' ', w) + " |");
            for (int j = 1; j <= n; j++)
            {
                Console.Write(j.ToString().PadLeft(w));
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', w + 2 + w * n));

            // строки таблицы
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i.ToString().PadLeft(w) + " |");
                for (int j = 1; j <= n; j++)
                {
                    Console.Write((i * j).ToString().PadLeft(w));
                }
                Console.WriteLine();
            }
        }
    }
}
