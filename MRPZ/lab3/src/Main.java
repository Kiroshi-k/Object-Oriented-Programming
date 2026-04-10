import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeParseException;
import java.util.Random;
import java.util.Scanner;

public class Main {
    private static final Scanner scanner = new Scanner(System.in);
    private static final DateTimeFormatter timeFormatter = DateTimeFormatter.ofPattern("HH:mm");

    public static void main(String[] args) {
        System.out.println("Лабораторна робота №3. Варіант 18.");

        System.out.println("Оберіть спосіб заповнення даних:");
        System.out.println("1 - Випадковим чином (згенерувати)");
        System.out.println("2 - Введення з клавіатури");
        System.out.print("Ваш вибір (1 або 2): ");
        int choice = readIntWithValidation(1, 2);

        System.out.println("Введіть кількість поїздів (не менше 5):");
        int count = readIntWithValidation(5, 100);

        Train[] trains = new Train[count];
        if (choice == 1) {
            generateRandomTrains(trains);
        } else {
            inputTrains(trains);
        }

        System.out.println("\n--- Всі введені поїзди ---");
        printTrains(trains);

        System.out.println("\n--- Поїзди, які мають загальні місця ---");
        findTrainsWithGeneralSeats(trains);

        System.out.println("\n--- Пошук поїздів за пунктом призначення та часом ---");
        String searchDestination = readNonEmptyString("Введіть пункт призначення: ");
        LocalTime searchTime = readTimeWithValidation("Введіть час відправлення (HH:MM), після якого шукати поїзди: ");

        System.out.println("\n--- Результати пошуку ---");
        findTrainsByDestinationAndTime(trains, searchDestination, searchTime);
    }

    private static void generateRandomTrains(Train[] trains) {
        Random random = new Random();
        String[] possibleDestinations = { "Київ", "Львів", "Одеса", "Харків", "Дніпро", "Ужгород", "Запоріжжя" };

        for (int i = 0; i < trains.length; i++) {
            String dest = possibleDestinations[random.nextInt(possibleDestinations.length)];
            int number = 10 + random.nextInt(990); // 10 to 999
            LocalTime time = LocalTime.of(random.nextInt(24), random.nextInt(60));

            int general = random.nextInt(100); // 0-99

            if (random.nextDouble() > 0.7) {
                general = 0;
            }
            int coupe = random.nextInt(50);
            int platskart = random.nextInt(50);
            int sv = random.nextInt(20);

            trains[i] = new Train(dest, number, time, general, coupe, platskart, sv);
        }
        System.out.println("\nЗгенеровано " + trains.length + " поїздів випадковим чином!");
    }

    private static void inputTrains(Train[] trains) {
        for (int i = 0; i < trains.length; i++) {
            System.out.println("\nВведення даних для поїзда #" + (i + 1));
            String dest = readNonEmptyString("Пункт призначення: ");
            System.out.print("Номер поїзда (1-9999): ");
            int number = readIntWithValidation(1, 9999);
            LocalTime time = readTimeWithValidation("Час відправлення (HH:MM): ");

            System.out.print("Кількість загальних місць: ");
            int general = readIntWithValidation(0, 1000);
            System.out.print("Кількість купейних місць: ");
            int coupe = readIntWithValidation(0, 1000);
            System.out.print("Кількість плацкартних місць: ");
            int platskart = readIntWithValidation(0, 1000);
            System.out.print("Кількість місць СВ: ");
            int sv = readIntWithValidation(0, 100);

            trains[i] = new Train(dest, number, time, general, coupe, platskart, sv);
        }
    }

    private static void printTrains(Train[] trains) {
        printTableHeader();
        for (Train train : trains) {
            System.out.println(train);
        }
        System.out.println("-------------------------------------------------------------------------------");
    }

    private static void printTableHeader() {
        System.out.println("-------------------------------------------------------------------------------");
        System.out.printf("| %-15s | %-12s | %-10s | %-8s | %-5s | %-8s | %-2s |\n",
                "Пункт признач.", "Номер поїзда", "Час відпр.", "Загальні", "Купе", "Плацкарт", "СВ");
        System.out.println("-------------------------------------------------------------------------------");
    }

    private static void findTrainsWithGeneralSeats(Train[] trains) {
        boolean found = false;
        printTableHeader();
        for (Train train : trains) {
            if (train.getGeneralSeats() > 0) {
                System.out.println(train);
                found = true;
            }
        }
        if (!found) {
            System.out.println("| За заданим критерієм пошуку поїздів не знайдено.                            |");
        }
        System.out.println("-------------------------------------------------------------------------------");
    }

    private static void findTrainsByDestinationAndTime(Train[] trains, String dest, LocalTime time) {
        boolean found = false;
        printTableHeader();
        for (Train train : trains) {
            if (train.getDestination().equalsIgnoreCase(dest) && train.getDepartureTime().isAfter(time)) {
                System.out.println(train);
                found = true;
            }
        }
        if (!found) {
            System.out.println("| За заданим критерієм пошуку поїздів не знайдено.                            |");
        }
        System.out.println("-------------------------------------------------------------------------------");
    }

    private static int readIntWithValidation(int min, int max) {
        while (true) {
            try {
                String input = scanner.nextLine().trim();
                if (input.isEmpty()) {
                    System.out.print("Помилка: рядок порожній. Введіть число: ");
                    continue;
                }
                int value = Integer.parseInt(input);
                if (value < min || value > max) {
                    System.out.printf("Помилка: число має бути від %d до %d. Спробуйте ще раз: ", min, max);
                } else {
                    return value;
                }
            } catch (NumberFormatException e) {
                System.out.print("Помилка: введено текст замість цілого числа. Спробуйте ще раз: ");
            }
        }
    }

    private static LocalTime readTimeWithValidation(String prompt) {
        while (true) {
            System.out.print(prompt);
            String input = scanner.nextLine().trim();
            if (input.isEmpty()) {
                System.out.println("Помилка: рядок не може бути порожнім. Спробуйте ще раз.");
                continue;
            }
            try {
                return LocalTime.parse(input, timeFormatter);
            } catch (DateTimeParseException e) {
                System.out.println("Помилка: неправильний формат часу. Використовуйте HH:MM (наприклад, 14:30).");
            }
        }
    }

    private static String readNonEmptyString(String prompt) {
        while (true) {
            System.out.print(prompt);
            String input = scanner.nextLine().trim();
            if (input.isEmpty()) {
                System.out.println("Помилка: рядок не може бути порожнім. Спробуйте ще раз.");
            } else {
                return input;
            }
        }
    }
}
