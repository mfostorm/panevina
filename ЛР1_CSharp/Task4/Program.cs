// Автор: Паневина С.Е., группа СИд-023
// Вариант: 9
// Лабораторная работа №1, задание 4
// Описание: из введённой строки удаляются все знаки препинания.
// Используются только методы string и циклы (без Regex).
using System;

namespace Lab1_Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировка UTF-8, чтобы русские буквы правильно отображались в консоли
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Задание 4. Удаление знаков препинания");
            Console.WriteLine(new string('-', 45));

            Console.Write("введите строку: ");
            string text = Console.ReadLine() ?? "";

            if (text.Trim().Length == 0)
            {
                Console.WriteLine("ошибка: введена пустая строка.");
                return;
            }

            // набор знаков препинания, которые нужно удалить
            string punctuation = ".,;:!?-—–\"'«»()[]{}…/";

            string result = "";
            int removed = 0;

            // перебираем символы: если символ есть в наборе - пропускаем его
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (punctuation.IndexOf(c) >= 0)
                {
                    removed++;
                }
                else
                {
                    result += c;
                }
            }

            // убираем двойные пробелы, которые могли остаться после удаления
            while (result.IndexOf("  ") >= 0)
            {
                result = result.Replace("  ", " ");
            }
            result = result.Trim();

            Console.WriteLine($"исходная строка:  {text}");
            Console.WriteLine($"результат:        {result}");
            Console.WriteLine($"удалено знаков:   {removed}");
            Console.WriteLine($"длина: было {text.Length}, стало {result.Length}");
        }
    }
}
