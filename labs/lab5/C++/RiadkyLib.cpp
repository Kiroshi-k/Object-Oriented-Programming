#include "RiadkyLib.h"

// реалізація базового
Riadky::Riadky(const std::string& s) : str(s) {}
Riadky::~Riadky() {}

// VelykiLitery: після кожного символу вставляємо '/'
VelykiLitery::VelykiLitery(const std::string& s) : Riadky(s) {}
int VelykiLitery::getLength() const {
    return static_cast<int>(str.length());
}
std::string VelykiLitery::insertChar() const {
    std::string res;
    for (char c : str) {
        res += c;
        res += '/';
    }
    return res;
}

// MaliLitery: після кожного символу вставляємо '\'
MaliLitery::MaliLitery(const std::string& s) : Riadky(s) {}
int MaliLitery::getLength() const {
    return static_cast<int>(str.length());
}
std::string MaliLitery::insertChar() const {
    std::string res;
    for (char c : str) {
        res += c;
        res += '\\';  // '\\' – це один символ '\'
    }
    return res;
}
