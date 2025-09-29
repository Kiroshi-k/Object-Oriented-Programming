#include "Text.h"
#include <cctype>
#include <numeric>
#include <algorithm>

// --- приватне ---
bool Text::IsVowel(char ch) const {
    const std::string vowels = "aeiouAEIOUаеєиіоуюяАЕЄИІОУЮЯ";
    return vowels.find(ch) != std::string::npos;
}

// --- IVowelWorker ---
size_t Text::CountVowels(const std::string& s) const {
    return std::count_if(s.begin(), s.end(),
        [this](char c){ return IsVowel(c); });
}

double Text::VowelPercentage(const std::string& s) const {
    size_t letters = std::count_if(s.begin(), s.end(), ::isalpha);
    size_t vowels  = CountVowels(s);
    return letters ? 100.0 * vowels / letters : 0.0;
}

// --- керування рядками ---
void Text::AddRow(const Row& r){ rows.push_back(r); }

bool Text::RemoveRow(size_t idx){
    if(idx >= rows.size()) return false;
    rows.erase(rows.begin() + idx);
    return true;
}

void Text::Clear(){ rows.clear(); }

bool Text::RemoveRowsWithSubstring(const std::string& sub){
    auto oldSize = rows.size();
    rows.erase(std::remove_if(rows.begin(), rows.end(),
        [&](const Row& r){ return r.Contains(sub); }),
        rows.end());
    return oldSize != rows.size();
}

// --- статистика ---
double Text::AverageRowLength() const{
    if(rows.empty()) return 0;
    size_t total = std::accumulate(rows.begin(), rows.end(), size_t{},
        [](size_t acc, const Row& r){ return acc + r.Length(); });
    return static_cast<double>(total) / rows.size();
}

double Text::TotalVowelPercentage() const{
    size_t letters = 0, vowels = 0;
    for(const auto& r : rows){
        const std::string& s = r.Get();
        letters += std::count_if(s.begin(), s.end(), ::isalpha);
        vowels  += CountVowels(s);
    }
    return letters ? 100.0 * vowels / letters : 0.0;
}
