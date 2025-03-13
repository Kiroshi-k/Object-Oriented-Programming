#include "Vector.h"
#include <cmath>

// Конструктор за замовчуванням
Vector::Vector() : x(0.0), y(0.0)
{
}

// Конструктор з параметрами
Vector::Vector(double xVal, double yVal) : x(xVal), y(yVal)
{
}

// Конструктор копіювання
Vector::Vector(const Vector& other)
{
    x = other.x;
    y = other.y;
}

// Метод отримання довжини
double Vector::length() const
{
    return std::sqrt(x * x + y * y);
}

// Гетери
double Vector::getX() const
{
    return x;
}
double Vector::getY() const
{
    return y;
}

// Перевантаження оператора +
Vector Vector::operator+(const Vector& rhs) const
{
    return Vector(x + rhs.x, y + rhs.y);
}

// Перевантаження оператора /
Vector Vector::operator/(double val) const
{
    // Припустимо, що val != 0.0 (не робимо дод. перевірок для спрощення)
    return Vector(x / val, y / val);
}
