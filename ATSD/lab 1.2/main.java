import java.util.Random;
import java.util.Scanner;

public class Main {

    // Клас точки
    static class Point {
        double x;
        double y;

        public Point(double x, double y) {
            this.x = x;
            this.y = y;
        }
    }

    // Клас Ромб
    static class Rhombus {
        Point a, b, c, d;

        public Rhombus(Point a, Point b, Point c, Point d) {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        // Обчислення відстані між двома точками
        private double distance(Point p1, Point p2) {
            return Math.sqrt(Math.pow(p2.x - p1.x, 2) + Math.pow(p2.y - p1.y, 2));
        }

        // Обчислення площі ромба
        public double getArea() {
            double d1 = distance(a, c);
            double d2 = distance(b, d);
            return (d1 * d2) / 2.0;
        }

        // Обчислення периметра ромба
        public double getPerimeter() {
            return 4 * distance(a, b);
        }

        @Override
        public String toString() {
            return String.format(
                    "A(%.1f, %.1f) B(%.1f, %.1f) C(%.1f, %.1f) D(%.1f, %.1f), S=%.2f, P=%.2f",
                    a.x, a.y, b.x, b.y, c.x, c.y, d.x, d.y, getArea(), getPerimeter()
            );
        }
    }

    // Клас хеш-таблиці
    static class HashTable {
        private Rhombus[] table;
        private int size;

        public HashTable(int size) {
            this.size = size;
            table = new Rhombus[size];
        }

        // Метод хешування множенням
        private int hash(double key) {
            double A = 0.618033;
            double value = key * A;
            double fractionalPart = value - Math.floor(value);
            return (int)(size * fractionalPart);
        }

        // Завдання першого рівня:
        // вставка без вирішення колізії
        public boolean insertFirstLevel(Rhombus rhombus) {
            double key = rhombus.getArea();
            int index = hash(key);

            if (table[index] == null) {
                table[index] = rhombus;
                return true;
            }

            return false;
        }

        // Завдання другого рівня:
        // вставка з вирішенням колізії методом квадратичного зондування
        public boolean insertSecondLevel(Rhombus rhombus) {
            double key = rhombus.getArea();
            int index = hash(key);

            for (int i = 0; i < size; i++) {
                int newIndex = (index + i * i) % size;

                if (table[newIndex] == null) {
                    table[newIndex] = rhombus;
                    return true;
                }
            }

            return false;
        }

        // Виведення хеш-таблиці
        public void printTable() {
            System.out.println("\nВміст хеш-таблиці:");
            System.out.println("--------------------------------------------------------------------------");

            for (int i = 0; i < size; i++) {
                if (table[i] == null) {
                    System.out.printf("%2d | позиція порожня%n", i);
                } else {
                    System.out.printf("%2d | ключ = %8.2f | %s%n",
                            i, table[i].getArea(), table[i]);
                }
            }
        }
    }

    // Метод для створення випадкового ромба
    public static Rhombus createRandomRhombus(Random random) {
        double cx = random.nextInt(20);
        double cy = random.nextInt(20);
        double dx = 1 + random.nextInt(10);
        double dy = 1 + random.nextInt(10);

        Point a = new Point(cx, cy + dy);
        Point b = new Point(cx + dx, cy);
        Point c = new Point(cx, cy - dy);
        Point d = new Point(cx - dx, cy);

        return new Rhombus(a, b, c, d);
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.print("Введіть розмір хеш-таблиці: ");
        int size = scanner.nextInt();

        System.out.print("Введіть кількість ромбів: ");
        int count = scanner.nextInt();

        // Перший рівень
        System.out.println("\n=== Завдання першого рівня ===");
        System.out.println("Вставка без вирішення колізій");

        HashTable tableFirstLevel = new HashTable(size);

        for (int i = 0; i < count; i++) {
            Rhombus rhombus = createRandomRhombus(random);

            boolean result = tableFirstLevel.insertFirstLevel(rhombus);

            if (result) {
                System.out.println("Додано: " + rhombus);
            } else {
                System.out.println("Колізія. Елемент не додано: " + rhombus);
            }
        }

        tableFirstLevel.printTable();

        // Другий рівень
        System.out.println("\n=== Завдання другого рівня ===");
        System.out.println("Вставка з вирішенням колізій методом квадратичного зондування");

        HashTable tableSecondLevel = new HashTable(size);

        for (int i = 0; i < count; i++) {
            Rhombus rhombus = createRandomRhombus(random);

            boolean result = tableSecondLevel.insertSecondLevel(rhombus);

            if (result) {
                System.out.println("Додано: " + rhombus);
            } else {
                System.out.println("Не вдалося додати елемент: " + rhombus);
            }
        }

        tableSecondLevel.printTable();

        scanner.close();
    }
}