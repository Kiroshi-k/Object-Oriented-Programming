#include "Rectangle.h"
#include <iostream>   
#include <cmath>      

// 1) Конструктор за замовчуванням
Rectangle::Rectangle()
    : x1(0), y1(0), x2(0), y2(0), x3(0), y3(0), x4(0), y4(0)

// 2) Конструктор з параметрами
Rectangle::Rectangle(double px1, double py1,
    double px2, double py2,
    double px3, double py3,
    double px4, double py4)
    : x1(px1), y1(py1), x2(px2), y2(py2),
    x3(px3), y3(py3), x4(px4), y4(py4)


// 3) Конструктор копіювання
Rectangle::Rectangle(const Rectangle& other)
    : x1(other.x1), y1(other.y1),
    x2(other.x2), y2(other.y2),
    x3(other.x3), y3(other.y3),
    x4(other.x4), y4(other.y4)

// 4) Деструктор
Rectangle::~Rectangle()

// Метод обчислення площі.
double Rectangle::getArea() const
{
    double sideAB = std::sqrt(std::pow(x2 - x1, 2) + std::pow(y2 - y1, 2));
    double sideBC = std::sqrt(std::pow(x3 - x2, 2) + std::pow(y3 - y2, 2));
    return sideAB * sideBC;
}

// Метод обчислення периметра
double Rectangle::getPerimeter() const
{
    double sideAB = std::sqrt(std::pow(x2 - x1, 2) + std::pow(y2 - y1, 2));
    double sideBC = std::sqrt(std::pow(x3 - x2, 2) + std::pow(y3 - y2, 2));
    return 2 * (sideAB + sideBC);
}

// Гетери
double Rectangle::getX1() const { return x1; }
double Rectangle::getY1() const { return y1; }
double Rectangle::getX2() const { return x2; }
double Rectangle::getY2() const { return y2; }
double Rectangle::getX3() const { return x3; }
double Rectangle::getY3() const { return y3; }
double Rectangle::getX4() const { return x4; }
double Rectangle::getY4() const { return y4; }
