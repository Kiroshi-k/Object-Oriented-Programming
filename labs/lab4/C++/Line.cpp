#include "Line.h"
#include <cmath>

// Конструктор за замовчуванням
Line::Line() : x1(0), y1(0), x2(0), y2(0) {}

// Конструктор з параметрами
Line::Line(double startX, double startY, double endX, double endY)
    : x1(startX), y1(startY), x2(endX), y2(endY)
{}

// Конструктор копіювання
Line::Line(const Line &other)
    : x1(other.x1), y1(other.y1), x2(other.x2), y2(other.y2)
{}

// Гетери
double Line::getX1() const { return x1; }
double Line::getY1() const { return y1; }
double Line::getX2() const { return x2; }
double Line::getY2() const { return y2; }

// Довжина лінії
double Line::length() const {
    double dx = x2 - x1;
    double dy = y2 - y1;
    return std::sqrt(dx*dx + dy*dy);
}
