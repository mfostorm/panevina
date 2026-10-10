// Автор: Паневина С.Е., группа СИд-023
// Вариант: 9
// Лабораторная работа №1, задание 1
// Описание: ввод двух чисел с проверкой и вывод суммы, разности,
// произведения и частного (с проверкой деления на ноль).
using System;

namespace Lab1_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировка UTF-8, чтобы русские буквы правильно отображались в консоли
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Лабораторная работа №1. Задание 1");
            Console.WriteLine("Выполнила: Паневина С.Е., группа СИд-023");
            Console.WriteLine(new string('-', 40));

            // ввод первого числа, пока не будет введено корректное значение
            double num1;
            while (true)
            {
                Console.Write("введите первое число: ");
                if (double.TryParse(Console.ReadLine(), out num1))
                {
                    break;
                }
                Console.WriteLine("ошибка ввода. введите корректное число.");
            }

            // ввод второго числа
            double num2;
            while (true)
            {
                Console.Write("введите второе число: ");
                if (double.TryParse(Console.ReadLine(), out num2))
                {
                    break;
                }
                Console.WriteLine("ошибка ввода. введите корректное число.");
            }

            Console.WriteLine(new string('-', 40));

            double sum = num1 + num2;
            double diff = num1 - num2;
            double prod = num1 * num2;

            Console.WriteLine($"сумма: {num1} + {num2} = {sum:F2}");
            Console.WriteLine($"разность: {num1} - {num2} = {diff:F2}");
            Console.WriteLine($"произведение: {num1} * {num2} = {prod:F2}");

            // частное считаем только если делитель не равен нулю
            if (num2 != 0)
            {
                double quot = num1 / num2;
                Console.WriteLine($"частное: {num1} / {num2} = {quot:F2}");
            }
            else
            {
                Console.WriteLine("частное: деление на ноль невозможно");
            }
        }
    }
}
