#include <iostream>
#include "Vector.h"

using namespace std;

int main()
{
    // 1) Створюємо три вектори
    Vector V1(3.0, 4.0); // Параметричний конструктор
    Vector V2;           // За замовчуванням -> (0,0)
    Vector V3(V1);       // Копіювальний (копія V1)

    // Ініціалізуємо V2 конкретними значеннями (1,1)
    V2 = Vector(1.0, 1.0);

    cout << "Початкові вектори:\n";
    cout << "V1 = (" << V1.getX() << ", " << V1.getY()
        << "), length = " << V1.length() << "\n";
    cout << "V2 = (" << V2.getX() << ", " << V2.getY()
        << "), length = " << V2.length() << "\n";
    cout << "V3 = (" << V3.getX() << ", " << V3.getY()
        << "), length = " << V3.length() << "\n\n";

    // 2) "Збільшити" V2 у 2 рази:
    V2 = V2 + V2;

    cout << "Після збільшення V2 у 2 рази:\n";
    cout << "V2 = (" << V2.getX() << ", " << V2.getY()
        << "), length = " << V2.length() << "\n\n";

    // 3) "Вирівняти" V3 під довжину V1
    double lenV3 = V3.length();
    double lenV1 = V1.length();
    if (lenV3 != 0.0)
    {
        double scale = lenV3 / lenV1;
        // ділимо V3 на scale, щоб довжина стала, як у V1
        V3 = V3 / scale;
    }

    cout << "Після \"вирівнювання\" V3 під довжину V1:\n";
    cout << "V3 = (" << V3.getX() << ", " << V3.getY()
        << "), length = " << V3.length() << "\n\n";

    // 4) "Помістити" результат у V1
    V1 = V3;

    cout << "Після \"поміщення\" V3 у V1:\n";
    cout << "V1 = (" << V1.getX() << ", " << V1.getY()
        << "), length = " << V1.length() << "\n";
    cout << "V2 = (" << V2.getX() << ", " << V2.getY()
        << "), length = " << V2.length() << "\n";
    cout << "V3 = (" << V3.getX() << ", " << V3.getY()
        << "), length = " << V3.length() << "\n\n";

    // --- Демонстрація перевантажених методів length() ---
    double normalLen = V1.length();
    double scaledLen = V1.length(0.5);

    cout << "Length(V1) без параметрів: " << normalLen << "\n";
    cout << "Length(V1) при scale=0.5  : " << scaledLen << "\n";

    return 0;
}
