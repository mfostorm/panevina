"""Вариант 24, версия 1 (первая, до тестирования)."""
def total_odd_classes(line):
    a = [int(x) for x in line.split()]
    s = 0
    k = 1                       # номер класса
    for i in range(0, 10):      # перебор классов
        if k == 1:
            s += a[i]
        k = -k                  # чередование нечётный/чётный класс
    return s

if __name__ == "__main__":
    print(total_odd_classes(input("Число учащихся 1–11 классов через пробел: ")))
