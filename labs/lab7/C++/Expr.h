#pragma once
#include "MathEx.h"

class Expr {
    double a_, c_, d_;
public:
    Expr(double a, double c, double d)
        : a_(a), c_(c), d_(d) {}

    double Evaluate() const;          // обчислює вираз
};
