#include "Vector.h"
#include <cmath>

// Конструктор за замовчуванням
Vector::Vector()
    : x(0.0), y(0.0)
{
}

// Конструктор з параметрами
Vector::Vector(double xVal, double yVal)
    : x(xVal), y(yVal)
{
}

// Конструктор копіювання
Vector::Vector(const Vector& other)
{
    x = other.x;
    y = other.y;
}

// 1) length() без параметрів
double Vector::length() const
{
    return std::sqrt(x * x + y * y);
}

// 2) length(double scale)
double Vector::length(double scale) const
{
    // Якщо уявити, що вектор масштабуємо на scale,
    // то довжина змінюється у scale разів.
    return this->length() * scale;
}

// Гетери
double Vector::getX() const { return x; }
double Vector::getY() const { return y; }

// Перевантажений оператор +
Vector Vector::operator+(const Vector& rhs) const
{
    return Vector(x + rhs.x, y + rhs.y);
}

// Перевантажений оператор /
Vector Vector::operator/(double val) const
{
    // Не перевіряємо val на 0 для спрощення
    return Vector(x / val, y / val);
}
