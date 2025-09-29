#pragma once
#include <string>

class Row {
    std::string data;
public:
    explicit Row(std::string txt = "") : data(std::move(txt)) {}

    const std::string& Get() const { return data; }
    size_t Length() const { return data.length(); }
    bool Contains(const std::string& sub) const {
        return data.find(sub) != std::string::npos;
    }
};
