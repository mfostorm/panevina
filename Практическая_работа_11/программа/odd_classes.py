"""Практическая работа №11, вариант 24.

Известно число детей, учащихся во всех первых классах, во всех вторых, …
и во всех одиннадцатых. Определить общее число детей, учащихся в первых,
третьих, пятых и т. д. классах школы. Оператор цикла с шагом, отличным
от 1 и –1, не использовать.
"""
CLASSES = 11


def total_odd_classes(line: str) -> int:
    parts = line.split()
    if len(parts) != CLASSES:
        raise ValueError(f"нужно ввести ровно {CLASSES} чисел, введено {len(parts)}")
    counts = []
    for p in parts:
        if not p.isdigit():                      # отсекает «-5», «12.5», «abc»
            raise ValueError(f"«{p}» — не целое неотрицательное число")
        counts.append(int(p))
    total = 0
    odd = True                                   # класс 1 — нечётный
    for i in range(CLASSES):                     # шаг цикла = 1
        if odd:
            total += counts[i]
        odd = not odd                            # чередуем нечётный/чётный
    return total


if __name__ == "__main__":
    try:
        print("Всего учащихся в нечётных классах:",
              total_odd_classes(input("Число учащихся 1–11 классов через пробел: ")))
    except ValueError as e:
        print("Ошибка:", e)
