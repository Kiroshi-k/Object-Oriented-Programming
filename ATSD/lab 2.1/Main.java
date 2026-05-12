import java.util.Scanner;

public class Main {

    static final double EPS = 0.0001;

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.println("Розробник: Марченко К.О.");
        System.out.println("Лабораторна робота 2.1");
        System.out.println("Варіант 18");
        System.out.println("Дослідження математичних алгоритмів\n");

        // ---------- ПЕРШИЙ РІВЕНЬ ----------
        System.out.println("=== Завдання першого рівня ===");
        System.out.println("Інтеграл: sqrt(1 + x^5)");

        System.out.print("Введіть початок інтервалу a: ");
        double a = sc.nextDouble();

        System.out.print("Введіть кінець інтервалу b: ");
        double b = sc.nextDouble();

        System.out.print("Введіть крок h: ");
        double h = sc.nextDouble();

        int n = (int) Math.round((b - a) / h);

        System.out.println("\nКількість відрізків n = " + n);

        System.out.println("\nРезультати обчислення інтеграла:");
        System.out.println("Метод прямокутників: " + rectangleMethod(a, b, h));
        System.out.println("Метод трапецій:       " + trapezoidMethod(a, b, h));

        if (n % 2 == 0) {
            System.out.println("Метод Сімпсона:       " + simpsonMethod(a, b, h));
        } else {
            System.out.println("Метод Сімпсона: неможливо виконати, бо кількість відрізків непарна");
        }

        // ---------- ДРУГИЙ РІВЕНЬ ----------
        System.out.println("\n=== Завдання другого рівня ===");
        System.out.println("Функція: y(x) = (x - 1)^2 - 0.5 * e^x");

        System.out.print("Введіть початок інтервалу для пошуку кореня: ");
        double left = sc.nextDouble();

        System.out.print("Введіть кінець інтервалу для пошуку кореня: ");
        double right = sc.nextDouble();

        if (y(left) * y(right) > 0) {
            System.out.println("\nНа цьому інтервалі корінь не знайдено або методи не можуть гарантувати пошук.");
            System.out.println("Спробуйте інтервал [0; 1].");
        } else {
            System.out.println("\nРезультати пошуку кореня:");
            System.out.println("Метод половинчастого ділення: " + bisectionMethod(left, right));
            System.out.println("Метод дотичних:               " + newtonMethod(left, right));
            System.out.println("Метод хорд:                   " + chordMethod(left, right));
        }

        sc.close();
    }

  
    // Функція для першого рівня: sqrt(1 + x^5)
    
    static double f(double x) {
        return Math.sqrt(1 + Math.pow(x, 5));
    }

 
    // Метод прямокутників
   
    static double rectangleMethod(double a, double b, double h) {
        int n = (int) Math.round((b - a) / h);
        double sum = 0;

        for (int i = 0; i < n; i++) {
            double x = a + i * h + h / 2; // середина відрізка
            sum += f(x);
        }

        return sum * h;
    }

   
    // Метод трапецій
    
    static double trapezoidMethod(double a, double b, double h) {
        int n = (int) Math.round((b - a) / h);

        double sum = (f(a) + f(b)) / 2;

        for (int i = 1; i < n; i++) {
            double x = a + i * h;
            sum += f(x);
        }

        return sum * h;
    }

    
    // Метод Сімпсона
    
    static double simpsonMethod(double a, double b, double h) {
        int n = (int) Math.round((b - a) / h);

        if (n % 2 != 0) {
            System.out.println("Метод Сімпсона неможливий: кількість відрізків має бути парною.");
            return 0;
        }

        double sum = f(a) + f(b);

        for (int i = 1; i < n; i++) {
            double x = a + i * h;

            if (i % 2 == 0) {
                sum += 2 * f(x);
            } else {
                sum += 4 * f(x);
            }
        }

        return sum * h / 3;
    }

    
    // Функція для другого рівня:
    // y(x) = (x - 1)^2 - 0.5 * e^x
   
    static double y(double x) {
        return Math.pow(x - 1, 2) - 0.5 * Math.exp(x);
    }

    
    // Похідна для методу дотичних
    // y'(x) = 2(x - 1) - 0.5 * e^x
   
    static double dy(double x) {
        return 2 * (x - 1) - 0.5 * Math.exp(x);
    }

    
    // Метод половинчастого ділення
    
    static double bisectionMethod(double a, double b) {
        double c;

        while (Math.abs(b - a) > EPS) {
            c = (a + b) / 2;

            if (y(a) * y(c) <= 0) {
                b = c;
            } else {
                a = c;
            }
        }

        return (a + b) / 2;
    }

   
    // Метод дотичних, або метод Ньютона
  
    static double newtonMethod(double a, double b) {
        double x = (a + b) / 2;

        for (int i = 0; i < 100; i++) {
            double derivative = dy(x);

            if (Math.abs(derivative) < EPS) {
                break;
            }

            double nextX = x - y(x) / derivative;

            if (Math.abs(nextX - x) < EPS) {
                return nextX;
            }

            x = nextX;
        }

        return x;
    }

    
    // Метод хорд
   
    static double chordMethod(double a, double b) {
        double x = a;

        while (Math.abs(b - a) > EPS) {
            x = a - y(a) * (b - a) / (y(b) - y(a));

            if (y(a) * y(x) < 0) {
                b = x;
            } else {
                a = x;
            }
        }

        return x;
    }
}