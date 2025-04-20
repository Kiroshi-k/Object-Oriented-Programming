#include <iostream>
#include <memory>
#include "RiadkyLib.h"

// метод поза класами для демонстрації поліморфізму
void demonstrate(const Riadky& obj) {
    std::cout << "Довжина: " << obj.getLength() << "\n";
    std::cout << "Оброблений рядок: " << obj.insertChar() << "\n";
}

int main() {
    std::string input;
    std::cout << "Введіть рядок: ";
    std::getline(std::cin, input);

    // зберігаємо в масив базових вказівників
    std::unique_ptr<Riadky> arr[2];
    arr[0] = std::make_unique<VelykiLitery>(input);
    arr[1] = std::make_unique<MaliLitery>(input);

    std::cout << "\n--- VelykiLitery ---\n";
    demonstrate(*arr[0]);

    std::cout << "\n--- MaliLitery ---\n";
    demonstrate(*arr[1]);

    return 0;
}
