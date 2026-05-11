import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.Scanner;

public class Main {

    enum State {
        START,
        LETTERS,
        UNDERSCORE,
        AFTER_UNDERSCORE_LETTERS,
        DIGITS,
        ERROR
    }

    public static void main(String[] args) {
        System.out.println("Розробник: Марченко К.О.");
        System.out.println("Лабораторна робота 2.2");
        System.out.println("Варіант 18\n");

        // ---------- ПЕРШИЙ РІВЕНЬ ----------
        System.out.println("=== Перший рівень: пошук слів у файлі ===");

        String regexLevel1 = "^%[5-9]*[%*][A-Z]+\\)$";

        try (BufferedReader reader = new BufferedReader(new FileReader("words.txt"))) {
            String word;

            while ((word = reader.readLine()) != null) {
                if (word.matches(regexLevel1)) {
                    System.out.println("Підходить: " + word);
                }
            }

        } catch (IOException e) {
            System.out.println("Помилка читання файлу words.txt");
        }

        // ---------- ДРУГИЙ РІВЕНЬ ----------
        System.out.println("\n=== Другий рівень: синтаксичний аналізатор ===");
        System.out.println("Регулярний вираз: [A-Z]*_?([A-Z]+|\\d+)");

        Scanner scanner = new Scanner(System.in);

        System.out.print("Введіть рядок: ");
        String input = scanner.nextLine();

        if (checkByAutomaton(input)) {
            System.out.println("Рядок правильний.");
        } else {
            System.out.println("Рядок неправильний.");
        }
    }

    public static boolean checkByAutomaton(String text) {
        State state = State.START;

        for (int i = 0; i < text.length(); i++) {
            char ch = text.charAt(i);

            switch (state) {

                case START:
                    if (isUpperLetter(ch)) {
                        state = State.LETTERS;
                    } else if (ch == '_') {
                        state = State.UNDERSCORE;
                    } else if (isDigit(ch)) {
                        state = State.DIGITS;
                    } else {
                        state = State.ERROR;
                    }
                    break;

                case LETTERS:
                    if (isUpperLetter(ch)) {
                        state = State.LETTERS;
                    } else if (ch == '_') {
                        state = State.UNDERSCORE;
                    } else if (isDigit(ch)) {
                        state = State.DIGITS;
                    } else {
                        state = State.ERROR;
                    }
                    break;

                case UNDERSCORE:
                    if (isUpperLetter(ch)) {
                        state = State.AFTER_UNDERSCORE_LETTERS;
                    } else if (isDigit(ch)) {
                        state = State.DIGITS;
                    } else {
                        state = State.ERROR;
                    }
                    break;

                case AFTER_UNDERSCORE_LETTERS:
                    if (isUpperLetter(ch)) {
                        state = State.AFTER_UNDERSCORE_LETTERS;
                    } else {
                        state = State.ERROR;
                    }
                    break;

                case DIGITS:
                    if (isDigit(ch)) {
                        state = State.DIGITS;
                    } else {
                        state = State.ERROR;
                    }
                    break;

                case ERROR:
                    return false;
            }
        }

        return state == State.LETTERS
                || state == State.AFTER_UNDERSCORE_LETTERS
                || state == State.DIGITS;
    }

    public static boolean isUpperLetter(char ch) {
        return ch >= 'A' && ch <= 'Z';
    }

    public static boolean isDigit(char ch) {
        return ch >= '0' && ch <= '9';
    }
}