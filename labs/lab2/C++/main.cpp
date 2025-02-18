#include <iostream>
#include "Rectangle.h"

int main()
{
    // 1. Виклик КОНСТРУКТОРА ЗА ЗАМОВЧУВАННЯМ
    Rectangle rectDefault;
    std::cout << "rectDefault (через конструктор за замовчуванням):\n";
    std::cout << "  x1=" << rectDefault.getX1()
        << "  y1=" << rectDefault.getY1()
        << "  ... (усі координати 0)\n\n";

    // 2. Виклик КОНСТРУКТОРА З ПАРАМЕТРАМИ
    double x1, y1, x2, y2, x3, y3, x4, y4;
    std::cout << "Введіть координати x1, y1: ";
    std::cin >> x1 >> y1;
    std::cout << "Введіть координати x2, y2: ";
    std::cin >> x2 >> y2;
    std::cout << "Введіть координати x3, y3: ";
    std::cin >> x3 >> y3;
    std::cout << "Введіть координати x4, y4: ";
    std::cin >> x4 >> y4;

    Rectangle rectParam(x1, y1, x2, y2, x3, y3, x4, y4);
    std::cout << "\nrectParam (через конструктор з параметрами):\n";
    std::cout << "  Кути: (" << rectParam.getX1() << ", " << rectParam.getY1() << ") "
        << "(" << rectParam.getX2() << ", " << rectParam.getY2() << ") "
        << "(" << rectParam.getX3() << ", " << rectParam.getY3() << ") "
        << "(" << rectParam.getX4() << ", " << rectParam.getY4() << ")\n";
    std::cout << "  Площа: " << rectParam.getArea() << "\n";
    std::cout << "  Периметр: " << rectParam.getPerimeter() << "\n\n";

    // 3. Виклик КОНСТРУКТОРА КОПІЮВАННЯ
    Rectangle rectCopy = rectParam;  // або: Rectangle rectCopy(rectParam);
    std::cout << "rectCopy (через конструктор копіювання з rectParam):\n";
    std::cout << "  Кути: (" << rectCopy.getX1() << ", " << rectCopy.getY1() << ") "
        << "(" << rectCopy.getX2() << ", " << rectCopy.getY2() << ") "
        << "(" << rectCopy.getX3() << ", " << rectCopy.getY3() << ") "
        << "(" << rectCopy.getX4() << ", " << rectCopy.getY4() << ")\n";
    std::cout << "  Площа: " << rectCopy.getArea() << "\n";
    std::cout << "  Периметр: " << rectCopy.getPerimeter() << "\n\n";

   
    return 0;
}
