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

    // Метод отримання довжини вектора
    double length() const;

    // Гетери (щоб можна було зчитати координати ззовні)
    double getX() const;
    double getY() const;

    // Перевантажений оператор +
    Vector operator+(const Vector& rhs) const;

    // Перевантажений оператор / (ділення на число)
    Vector operator/(double val) const;
};

#endif
