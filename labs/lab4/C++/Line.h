#pragma once

class Line {
protected:
    double x1, y1;  // Координати початку
    double x2, y2;  // Координати кінця

public:
    // 1) Конструктор за замовчуванням
    Line();

    // 2) Конструктор з параметрами (можна адаптувати під "3 параметри" за потреби)
    Line(double startX, double startY, double endX, double endY);

    // 3) Конструктор копіювання
    Line(const Line &other);

    // Методи-читаючі (гетери)
    double getX1() const;
    double getY1() const;
    double getX2() const;
    double getY2() const;

    // Метод обчислення довжини
    double length() const;
};
