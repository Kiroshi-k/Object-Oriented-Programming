#ifndef RIADKYLIB_H
#define RIADKYLIB_H

#include <string>

class Riadky {
protected:
    std::string str;
public:
    Riadky(const std::string& s);
    virtual ~Riadky();
    // отримати довжину рядка
    virtual int getLength() const = 0;
    // повернути оброблений рядок з вставленим символом
    virtual std::string insertChar() const = 0;
};

class VelykiLitery : public Riadky {
public:
    VelykiLitery(const std::string& s);
    int getLength() const override;
    std::string insertChar() const override;
};

class MaliLitery : public Riadky {
public:
    MaliLitery(const std::string& s);
    int getLength() const override;
    std::string insertChar() const override;
};

#endif // RIADKYLIB_H
