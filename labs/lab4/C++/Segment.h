#pragma once
#include "Line.h"

class Segment : public Line {
public:
    // Конструктор за замовчуванням
    Segment();

    // Конструктор із параметрами (тут 3, але можна й 4)
    // Для прикладу припустимо, що ми задаємо (x1, y1) і кут angle,
    // а кінцеві координати рахуємо з якоюсь фіксованою довжиною (наприклад 1).
    Segment(double x, double y, double angle);

    // Конструктор копіювання
    Segment(const Segment &other);

    // Метод обчислення кута з віссю OX
    double angleWithOx() const;
};
