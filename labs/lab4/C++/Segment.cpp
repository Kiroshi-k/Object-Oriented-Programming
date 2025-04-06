#include "Segment.h"
#include <cmath>

// За замовчуванням просто викликаємо базовий конструктор
Segment::Segment() : Line() {}

// Конструктор із 3 параметрами, де явно викликаємо конструктор базового класу
Segment::Segment(double x, double y, double angle)
    : Line(x, y, x + std::cos(angle), y + std::sin(angle))
{
    // Тут ми явно викликаємо конструктор Line(...) з 4 параметрами
}

// Конструктор копіювання
Segment::Segment(const Segment &other)
    : Line(other)  // виклик базового копіюючого
{}

// Кут з віссю OX (в радіанах)
double Segment::angleWithOx() const {
    double dx = x2 - x1;
    double dy = y2 - y1;
    return std::atan2(dy, dx);
}
