#pragma once
#include <string>

class IVowelWorker {
public:
    virtual size_t CountVowels(const std::string& s) const = 0;
    virtual double VowelPercentage(const std::string& s) const = 0;
    virtual ~IVowelWorker() = default;
};
