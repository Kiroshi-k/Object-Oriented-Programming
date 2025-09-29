#include <iostream>
#include <vector>
#include "Expr.h"

int main() {
    std::vector<Expr> arr = {
        Expr(1, 3, 5),
        Expr(4.1, 2, 10),   // викличе виняток: ln(1‑a/4)=ln(0)=‑inf
        Expr(-2, 0, 0)
    };

    for (size_t i = 0; i < arr.size(); ++i) {
        try {
            std::cout << "Obj " << i << " = "
                      << arr[i].Evaluate() << '\n';
        }
        catch (const InvalidArgument& ex) {
            std::cout << "Obj " << i
                      << " ERROR: " << ex.what() << '\n';
        }
    }
}
