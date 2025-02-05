#include "Rectangle.h"
#include <cmath> 

Rectangle::Rectangle(double x1, double y1,
    double x2, double y2,
    double x3, double y3,
    double x4, double y4)
    : x1(x1), y1(y1), x2(x2), y2(y2),
    x3(x3), y3(y3), x4(x4), y4(y4)
{
}

// Припустимо, що вершини впорядковані так, що AB і BC – суміжні сторони
double Rectangle::getArea()
{
    // Довжина AB
    double sideAB = std::sqrt(std::pow(x2 - x1, 2) + std::pow(y2 - y1, 2));
    // Довжина BC
    double sideBC = std::sqrt(std::pow(x3 - x2, 2) + std::pow(y3 - y2, 2));
    return sideAB * sideBC;
}

double Rectangle::getPerimeter()
{
    double sideAB = std::sqrt(std::pow(x2 - x1, 2) + std::pow(y2 - y1, 2));
    double sideBC = std::sqrt(std::pow(x3 - x2, 2) + std::pow(y3 - y2, 2));
    return 2 * (sideAB + sideBC);
}

void Rectangle::reset()
{
    x1 = y1 = x2 = y2 = x3 = y3 = x4 = y4 = 0;
}

double Rectangle::getX1() { return x1; }
double Rectangle::getY1() { return y1; }
double Rectangle::getX2() { return x2; }
double Rectangle::getY2() { return y2; }
double Rectangle::getX3() { return x3; }
double Rectangle::getY3() { return y3; }
double Rectangle::getX4() { return x4; }
double Rectangle::getY4() { return y4; }


