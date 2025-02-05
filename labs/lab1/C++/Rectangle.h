#ifndef RECTANGLE_H
#define RECTANGLE_H

class Rectangle
{
private:
    double x1, y1, x2, y2, x3, y3, x4, y4;

public:
    // Конструктор з параметрами – координатами 4-х вершин
    Rectangle(double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        double x4, double y4);

    // Метод обчислення площі
    double getArea();
    

    // Метод обчислення периметра
    double getPerimeter();

    // Метод для обнулення даних (скидання координат у 0)
    void reset();

    // Гетери (повертають значення приватних змінних)
    double getX1();
    double getY1();
    double getX2();
    double getY2();
    double getX3();
    double getY3();
    double getX4();
    double getY4();
};

#endif
