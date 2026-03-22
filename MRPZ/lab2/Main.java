import java.util.Random;

public class Main {

    public static void main(String[] args) {
        System.out.println("Лабораторна робота №2");
        System.out.println("Обробка текстових даних мовою Java");
        System.out.println("Розробник: Marchenko K.O.");

        System.out.println("\n==============================");
        System.out.println("Завдання 1");
        System.out.println("==============================");
        task1();

        System.out.println("\n==============================");
        System.out.println("Завдання 2");
        System.out.println("==============================");
        task2();
    }

    // Завдання 1:

    private static void task1() {
        int length = 8; // довжина випадкового натурального числа
        String originalNumber = generateRandomNaturalNumber(length);
        String processedNumber = processNumber(originalNumber);

        System.out.println("Початкове число: " + originalNumber);
        System.out.println("Довжина числа: " + length);
        System.out.println("Результат після обробки: " + processedNumber);
    }

    // Генерація випадкового натурального числа заданої довжини
    private static String generateRandomNaturalNumber(int length) {
        Random random = new Random();
        StringBuilder sb = new StringBuilder();

        // Перша цифра не може бути 0
        sb.append(random.nextInt(9) + 1);

        for (int i = 1; i < length; i++) {
            sb.append(random.nextInt(10));
        }

        return sb.toString();
    }

    // Обробка числа за варіантом 18
    private static String processNumber(String number) {
        char[] digits = number.toCharArray();

        int i = 0;
        while (i < digits.length) {
            int digit = digits[i] - '0';

            if (digit % 2 == 0) {
                int newDigit = (digit + 4) % 10;

                digits[i] = (char) ('0' + newDigit);

                // Міняємо місцями з сусідньою праворуч, якщо вона існує
                if (i < digits.length - 1) {
                    char temp = digits[i];
                    digits[i] = digits[i + 1];
                    digits[i + 1] = temp;
                    i += 2; // пропускаємо оброблену пару
                    continue;
                }
            }

            i++;
        }

        return new String(digits);
    }

    // Завдання 2:
    private static void task2() {
        String javaCode = "public class Demo {\n" +
                "    // Це однорядковий коментар\n" +
                "    public static void main(String[] args) {\n" +
                "        int a = 5; /* багаторядковий\n" +
                "                     коментар */\n" +
                "        int b = 10;\n" +
                "        /**\n" +
                "         * JavaDoc коментар\n" +
                "         * для методу\n" +
                "         */\n" +
                "        System.out.println(a + b); // вивід суми\n" +
                "    }\n" +
                "}\n";

        String processedText = removeComments(javaCode);

        System.out.println("Вхідні дані:");
        System.out.println("- Текст задано рядковим літералом");
        System.out.println("- Потрібно видалити однорядкові, багаторядкові та JavaDoc-коментарі");

        System.out.println("\nТекст до обробки:");
        System.out.println(javaCode);

        System.out.println("Текст після обробки:");
        System.out.println(processedText);
    }

    // Видалення всіх видів коментарів
    private static String removeComments(String text) {
        // Видаляємо багаторядкові та JavaDoc-коментарі
        String withoutBlockComments = text.replaceAll("(?s)/\\*.*?\\*/", "");

        // Видаляємо однорядкові коментарі
        String withoutLineComments = withoutBlockComments.replaceAll("(?m)//.*?$", "");

        return withoutLineComments;
    }
}