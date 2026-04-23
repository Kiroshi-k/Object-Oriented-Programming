import java.util.Random;
import java.util.Scanner;

public class Main {

    // Клас Ромб
    static class Rhombus {
        double d1; // перша діагональ
        double d2; // друга діагональ

        public Rhombus(double d1, double d2) {
            this.d1 = d1;
            this.d2 = d2;
        }

        // Обчислення площі ромба
        public double getArea() {
            return (d1 * d2) / 2.0;
        }

        @Override
        public String toString() {
            return String.format("Ромб{d1=%.2f, d2=%.2f, S=%.2f}", d1, d2, getArea());
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
            double A = 0.618033; // константа
            double value = key * A;
            double fractionalPart = value - Math.floor(value);
            return (int)(size * fractionalPart);
        }

        // Вставка з квадратичним зондуванням
        public boolean insert(Rhombus rhombus) {
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

        // Виведення таблиці
        public void printTable() {
            System.out.println("\nВміст хеш-таблиці:");
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

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.print("Введіть розмір хеш-таблиці: ");
        int size = scanner.nextInt();

        HashTable hashTable = new HashTable(size);

        // Створюємо і вставляємо декілька ромбів
        for (int i = 0; i < 7; i++) {
            double d1 = 1 + random.nextInt(20);
            double d2 = 1 + random.nextInt(20);

            Rhombus rhombus = new Rhombus(d1, d2);

            boolean result = hashTable.insert(rhombus);

            if (result) {
                System.out.println("Додано: " + rhombus);
            } else {
                System.out.println("Не вдалося додати: " + rhombus);
            }
        }

        hashTable.printTable();

        scanner.close();
    }
}