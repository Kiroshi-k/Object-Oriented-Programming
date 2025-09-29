#include <iostream>
#include "Text.h"

int main(){
    Text txt;
    txt.AddRow(Row("Hello, student!"));
    txt.AddRow(Row("Object Oriented Programming"));
    txt.AddRow(Row("Kyiv Aviation University"));

    std::cout << "Avg length: "     << txt.AverageRowLength() << "\n";
    std::cout << "Vowel % in text: " << txt.TotalVowelPercentage() << "\n";

    txt.RemoveRowsWithSubstring("Kyiv");
    std::cout << "After removing rows with 'Kyiv', avg length: "
              << txt.AverageRowLength() << "\n";
}
