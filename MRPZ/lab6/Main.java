import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

class Circle {
    private double x;
    private double y;
    private double r;

    public Circle(double x, double y, double r) {
        this.x = x;
        this.y = y;
        this.r = r;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }

    public double getR() {
        return r;
    }

    public double distanceTo(Circle other) {
        double dx = this.x - other.x;
        double dy = this.y - other.y;
        return Math.sqrt(dx * dx + dy * dy);
    }

    @Override
    public String toString() {
        return "Коло{x=" + x + ", y=" + y + ", r=" + r + "}";
    }
}

public class Main {
    private static final double EPS = 0.000001;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Set<Circle> circles = new HashSet<>();

        System.out.print("Введіть кількість кіл: ");
        int n = scanner.nextInt();

        for (int i = 1; i <= n; i++) {
            System.out.println("\nКоло №" + i);

            System.out.print("x = ");
            double x = scanner.nextDouble();

            System.out.print("y = ");
            double y = scanner.nextDouble();

            System.out.print("r = ");
            double r = scanner.nextDouble();

            if (r <= 0) {
                System.out.println("Радіус має бути більшим за 0. Коло не додано.");
                i--;
                continue;
            }

            circles.add(new Circle(x, y, r));
        }

        System.out.println("\nСтворена множина кіл:");
        for (Circle circle : circles) {
            System.out.println(circle);
        }

        System.out.println("\nРезультат перевірки кіл:");
        checkCircles(circles);

        scanner.close();
    }

    private static void checkCircles(Set<Circle> circles) {
        Circle[] array = circles.toArray(new Circle[0]);

        for (int i = 0; i < array.length; i++) {
            for (int j = i + 1; j < array.length; j++) {
                Circle c1 = array[i];
                Circle c2 = array[j];

                double distance = c1.distanceTo(c2);
                double radiusSum = c1.getR() + c2.getR();

                System.out.println("\n" + c1);
                System.out.println(c2);
                System.out.println("Відстань між центрами = " + distance);
                System.out.println("Сума радіусів = " + radiusSum);

                if (Math.abs(distance - radiusSum) < EPS) {
                    System.out.println("Результат: кола дотикаються.");
                } else if (distance < radiusSum) {
                    System.out.println("Результат: кола перетинаються.");
                } else {
                    System.out.println("Результат: кола не перетинаються.");
                }
            }
        }
    }
}