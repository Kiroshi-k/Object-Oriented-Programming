#pragma once
#include <vector>
#include "Row.h"
#include "IVowelWorker.h"

class Text : public IVowelWorker {
    std::vector<Row> rows;

    bool IsVowel(char ch) const;                 // допоміжне
public:
    // --- IVowelWorker ---
    size_t CountVowels(const std::string& s) const override;
    double VowelPercentage(const std::string& s) const override;

    // --- керування рядками ---
    void AddRow(const Row& r);
    bool RemoveRow(size_t idx);
    void Clear();
    bool RemoveRowsWithSubstring(const std::string& sub);

    // --- статистика ---
    double AverageRowLength() const;
    double TotalVowelPercentage() const;         // у всьому тексті
};
