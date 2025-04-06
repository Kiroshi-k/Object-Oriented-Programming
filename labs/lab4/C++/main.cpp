#include <iostream>
#include "Segment.h"

int main() {
    double x, y, angle;

    std::cout << "Введіть x, y та кут (у радіанах): ";
    std::cin >> x >> y >> angle;

    // Створюємо об'єкт похідного класу Segment
    Segment seg(x, y, angle);

    // Виводимо дані
    std::cout << "Координати початку відрізка: ("
              << seg.getX1() << ", " << seg.getY1() << ")\n";
    std::cout << "Координати кінця відрізка: ("
              << seg.getX2() << ", " << seg.getY2() << ")\n";

    std::cout << "Довжина відрізка: " << seg.length() << "\n";
    std::cout << "Кут із віссю OX: " << seg.angleWithOx() << " (радіан)" << std::endl;

    return 0;
}
