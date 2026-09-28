"""Прототип модуля расчётов ИС «Космос» (ООО «Гостиница Космос»).

Расчёт стоимости проживания (функция F6/F8) и показателей загрузки (F10)
по формулам из ТЗ, п. 4.3.1.
"""
from dataclasses import dataclass
from datetime import date, timedelta
from decimal import Decimal, ROUND_HALF_UP

# Базовые тарифы за сутки по категориям номеров, руб.
TARIFFS = {
    "Стандарт": Decimal("3800"),
    "Комфорт": Decimal("4900"),
    "Полулюкс": Decimal("6800"),
    "Люкс": Decimal("9500"),
}

# Сезонные коэффициенты по месяцам (лето и новогодние праздники дороже).
SEASON = {1: Decimal("1.15"), 6: Decimal("1.2"), 7: Decimal("1.25"), 8: Decimal("1.25"), 12: Decimal("1.1")}


def money(x: Decimal) -> Decimal:
    return x.quantize(Decimal("0.01"), rounding=ROUND_HALF_UP)


@dataclass
class Booking:
    category: str
    check_in: date
    check_out: date
    discount_percent: int = 0

    @property
    def nights(self) -> int:
        n = (self.check_out - self.check_in).days
        if n <= 0:
            raise ValueError("Дата выезда должна быть позже даты заезда")
        return n


def stay_cost(b: Booking) -> Decimal:
    """Стоимость проживания: сумма по ночам (тариф × сезонный коэффициент) − скидка."""
    base = TARIFFS[b.category]
    total = Decimal("0")
    for i in range(b.nights):
        day = b.check_in + timedelta(days=i)
        total += base * SEASON.get(day.month, Decimal("1"))
    total *= Decimal(100 - b.discount_percent) / 100
    return money(total)


def occupancy(sold_room_nights: int, available_room_nights: int) -> Decimal:
    """Загрузка номерного фонда, %."""
    return money(Decimal(sold_room_nights) / available_room_nights * 100)


def adr(room_revenue: Decimal, sold_room_nights: int) -> Decimal:
    """ADR — средняя цена проданного номера."""
    return money(room_revenue / sold_room_nights)


def revpar(room_revenue: Decimal, available_room_nights: int) -> Decimal:
    """RevPAR — доход на доступный номер."""
    return money(room_revenue / available_room_nights)


if __name__ == "__main__":
    b = Booking("Комфорт", date(2026, 12, 30), date(2027, 1, 2), discount_percent=5)
    print(f"Бронь: {b.category}, {b.nights} ночи, скидка {b.discount_percent}%")
    print(f"Стоимость проживания: {stay_cost(b)} руб.")

    rooms, days = 80, 30
    sold, revenue = 1600, Decimal("7350000")
    print(f"Загрузка: {occupancy(sold, rooms * days)} %")
    print(f"ADR: {adr(revenue, sold)} руб.")
    print(f"RevPAR: {revpar(revenue, rooms * days)} руб.")
