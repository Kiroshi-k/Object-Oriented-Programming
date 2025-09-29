#pragma once
#include <stdexcept>

class InvalidArgument : public std::runtime_error {
public: explicit InvalidArgument(const char* msg)
        : std::runtime_error(msg) {}
};

struct MathEx {
    static double SafeLn(double x);   // ln(x) з перевіркою
};
