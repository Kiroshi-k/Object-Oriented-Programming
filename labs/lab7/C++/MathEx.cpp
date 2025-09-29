#include "MathEx.h"
#include <cmath>

double MathEx::SafeLn(double x) {
    if (x <= 0.0)
        throw InvalidArgument("ln(x): x must be > 0");
    return std::log(x);
}
