// Автор: Паневина С.Е., группа СИд-023
// Вариант: 9
// Лабораторная работа №1, задание 2
// Описание: дальность полёта L = v^2 * sin(2a) / g.
// Угол переводится из градусов в радианы, g проверяется на ноль.
using System;

namespace Lab1_Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // кодировка UTF-8, чтобы русские буквы правильно отображались в консоли
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("задание 2. Дальность полёта");

            double v = ReadDouble("введите начальную скорость v (м/с, >= 0): ", min: 0);
            double alphaDeg = ReadDouble("введите угол alpha (градусы): ");
            double g = ReadDouble("введите ускорение свободного падения g (м/с^2, > 0): ", min: 0.0001);

            // перевод угла в радианы
            double alphaRad = alphaDeg * Math.PI / 180.0;

            // синус двойного угла
            double sin2alpha = Math.Sin(2.0 * alphaRad);

            if (sin2alpha <= 0)
            {
                Console.WriteLine("дальность полёта: 0.00 м (угол не позволяет снаряду улететь вперед)");
            }
            else
            {
                // расчёт по формуле
                double l = (v * v * sin2alpha) / g;
                Console.WriteLine($"дальность полёта: {l:F2} м");
            }
        }

        // ввод вещественного числа с проверкой формата и минимального значения
        static double ReadDouble(string prompt, double min = double.NegativeInfinity)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    if (value < min)
                    {
                        Console.WriteLine($"ошибка: значение должно быть не меньше {min}.");
                    }
                    else
                    {
                        return value;
                    }
                }
                else
                {
                    Console.WriteLine("ошибка: введено не число. Попробуйте еще раз.");
                }
            }
        }
    }
}
