#ifndef RECTANGLE_H
#define RECTANGLE_H

class Rectangle
{
private:
    double x1, y1, x2, y2, x3, y3, x4, y4;

public:
    // За замовчуванням (усі координати = 0)
    Rectangle();

    // Конструктор з параметрами
    Rectangle(double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        double x4, double y4);

    // Конструктор копіювання
    Rectangle(const Rectangle& other);

    // Деструктор
    ~Rectangle();

    // Методи обчислення площі та периметра
    double getArea() const;
    double getPerimeter() const;

    // Методи (гетери) для отримання даних
    double getX1() const;
    double getY1() const;
    double getX2() const;
    double getY2() const;
    double getX3() const;
    double getY3() const;
    double getX4() const;
    double getY4() const;
};

#endif
