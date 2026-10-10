// Автор: Паневина С.Е., группа СИд-023
// Вариант: 9
// Лабораторная работа №1, задание 3
// Описание: вводятся оценки по трём предметам (целые от 2 до 5).
// Студент переведён, если средний балл >= 3.0 и нет двоек.
using System;

namespace Lab1_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 3. Перевод студента на следующий курс");
            Console.WriteLine(new string('-', 45));

            int m1 = ReadMark("оценка по математике: ");
            int m2 = ReadMark("оценка по информатике: ");
            int m3 = ReadMark("оценка по физике: ");

            double avg = (m1 + m2 + m3) / 3.0;
            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"средний балл: {avg:F2}");

            // первый уровень проверки - есть ли двойки
            if (m1 == 2 || m2 == 2 || m3 == 2)
            {
                Console.WriteLine("решение: НЕ переведён (есть неудовлетворительная оценка)");
            }
            else
            {
                // второй уровень - средний балл
                if (avg >= 3.0)
                {
                    Console.WriteLine("решение: переведён на следующий курс");

                    // дополнительно - характеристика успеваемости через switch
                    switch (Math.Min(m1, Math.Min(m2, m3)))
                    {
                        case 5:
                            Console.WriteLine("успеваемость: отличник");
                            break;
                        case 4:
                            Console.WriteLine("успеваемость: хорошист");
                            break;
                        default:
                            Console.WriteLine("успеваемость: есть тройки");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("решение: НЕ переведён (средний балл ниже 3.0)");
                }
            }
        }

        // ввод оценки с проверкой: должно быть целое число от 2 до 5
        static int ReadMark(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();
                if (input == null) Environment.Exit(0); // ввод закончился

                if (!int.TryParse(input, out int mark))
                {
                    Console.WriteLine("ошибка: введите целое число.");
                }
                else if (mark < 2 || mark > 5)
                {
                    Console.WriteLine("ошибка: оценка должна быть от 2 до 5.");
                }
                else
                {
                    return mark;
                }
            }
        }
    }
}
