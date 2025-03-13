#ifndef VECTOR_H
#define VECTOR_H

class Vector
{
private:
    double x;
    double y;

public:
    // Конструктор за замовчуванням
    Vector();

    // Конструктор з параметрами
    Vector(double xVal, double yVal);

    // Конструктор копіювання
    Vector(const Vector& other);

    // --- Перевантаження методів (function overloading) ---
    // 1) Довжина без параметрів
    double length() const;

    // 2) Довжина із масштабом (scale)
    double length(double scale) const;

    // Гетери
    double getX() const;
    double getY() const;

    // --- Перевантаження операторів ---
    // Додавання двох векторів
    Vector operator+(const Vector& rhs) const;

    // Ділення вектора на число
    Vector operator/(double val) const;
};

#endif
