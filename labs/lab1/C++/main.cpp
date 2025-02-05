#include <iostream>
#include "Rectangle.h"
using namespace std;

int main()
{
    setlocale(LC_CTYPE, "ukr"); 

    double x1, y1, x2, y2, x3, y3, x4, y4;

    cout << "Введіть координати (x1, y1): ";
    cin >> x1 >> y1;
    cout << "Введіть координати (x2, y2): ";
    cin >> x2 >> y2;
    cout << "Введіть координати (x3, y3): ";
    cin >> x3 >> y3;
    cout << "Введіть координати (x4, y4): ";
    cin >> x4 >> y4;

    // Створюємо об’єкт класу Rectangle
    Rectangle rect(x1, y1, x2, y2, x3, y3, x4, y4);

    // Виводимо збережені координати
    cout << "\nВведений прямокутник має вершини:\n";
    cout << "(" << rect.getX1() << ", " << rect.getY1() << "), "
        << "(" << rect.getX2() << ", " << rect.getY2() << "), "
        << "(" << rect.getX3() << ", " << rect.getY3() << "), "
        << "(" << rect.getX4() << ", " << rect.getY4() << ")\n";

    // Виводимо площу та периметр
    cout << "Площа: " << rect.getArea() << "\n";
    cout << "Периметр: " << rect.getPerimeter() << "\n\n";

    // Виклик методу reset() – обнулення
    rect.reset();
    cout << "Після обнулення даних:\n";
    cout << "Площа: " << rect.getArea() << "\n";
    cout << "Периметр: " << rect.getPerimeter() << "\n";

    return 0;
}
