import java.util.Scanner;

public class Main {

    static long factorial(int n) {
        long result = 1;

        for (int i = 1; i <= n; i++) {
            result *= i;
        }

        return result;
    }

    static long arrangementWithoutRepetition(int n, int k) {
        return factorial(n) / factorial(n - k);
    }

    static long arrangementWithRepetition(int n, int k) {
        long result = 1;

        for (int i = 1; i <= k; i++) {
            result *= n;
        }

        return result;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Лабораторна робота 2.3");
        System.out.println("Дослідження комбінаторних алгоритмів");
        System.out.println("Варіант 18");
        System.out.println();

        System.out.println("Завдання першого рівня");
        System.out.print("Введіть кількість студентів: ");
        int students = scanner.nextInt();

        System.out.print("Введіть кількість керівників: ");
        int supervisors = scanner.nextInt();

        long resultLevel1 = arrangementWithoutRepetition(students, supervisors);

        System.out.println("Тип вибірки: розміщення без повторень");
        System.out.println("Кількість способів: " + resultLevel1);

        System.out.println();

        System.out.println("Завдання другого рівня");
        System.out.print("Введіть кількість букв: ");
        int letters = scanner.nextInt();

        System.out.print("Введіть довжину серії: ");
        int length = scanner.nextInt();

        long resultLevel2 = arrangementWithRepetition(letters, length);

        System.out.println("Тип вибірки: розміщення з повтореннями");
        System.out.println("Кількість чотиризначних серій: " + resultLevel2);

        scanner.close();
    }
}