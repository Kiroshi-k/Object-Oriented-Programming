import java.io.*;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Лабораторна робота №4");
        System.out.println("Робота з файловим введенням/виведенням");
        System.out.println("Варіант 18");
        System.out.println("Розробник: студент 2 курсу\n");

        System.out.print("Введіть шлях до вхідного файлу: ");
        String inputFile = scanner.nextLine();

        System.out.print("Введіть шлях до результуючого файлу: ");
        String outputFile = scanner.nextLine();

        StringBuilder text = new StringBuilder();

        try {
            BufferedReader reader = new BufferedReader(new FileReader(inputFile));

            String line;
            while ((line = reader.readLine()) != null) {
                text.append(line).append("\n");
            }

            reader.close();

            System.out.println("\nФайл успішно прочитано.");

            String result = processText(text.toString());

            BufferedWriter writer = new BufferedWriter(new FileWriter(outputFile));
            writer.write(result);
            writer.close();

            System.out.println("Текст успішно оброблено.");
            System.out.println("Результат записано у файл: " + outputFile);

        } catch (FileNotFoundException e) {
            System.out.println("Помилка: вхідний файл не знайдено.");
        } catch (IOException e) {
            System.out.println("Помилка при роботі з файлом.");
        }
    }

    public static String processText(String text) {
        StringBuilder result = new StringBuilder();

        boolean newWord = true;
        boolean newSentence = true;

        for (int i = 0; i < text.length(); i++) {
            char ch = text.charAt(i);

            if (Character.isLetter(ch)) {
                if (newWord) {
                    ch = Character.toUpperCase(ch);
                    newWord = false;
                }

                if (newSentence) {
                    ch = Character.toLowerCase(ch);
                    newSentence = false;
                }
            } else {
                if (ch == ' ' || ch == '\n' || ch == '\t') {
                    newWord = true;
                }

                if (ch == '.' || ch == '!' || ch == '?') {
                    newSentence = true;
                    newWord = true;
                }
            }

            result.append(ch);
        }

        return result.toString();
    }
}