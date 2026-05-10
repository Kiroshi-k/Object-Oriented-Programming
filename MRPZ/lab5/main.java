import java.util.ArrayList;
import java.util.Scanner;

// Інтерфейс для пошуку інформації
interface Searchable {
    void searchFilm(String filmName);
}

// Зовнішній клас
class Kino implements Searchable {

    private ArrayList<Kinoteatr> kinoteatrs = new ArrayList<>();

    // Метод додавання кінотеатру
    public void addKinoteatr(Kinoteatr k) {
        kinoteatrs.add(k);
        System.out.println("Кінотеатр додано до системи.");
    }

    // Метод виведення всіх кінотеатрів
    public void showAll() {
        System.out.println("\n=== Список кінотеатрів ===");

        for (Kinoteatr k : kinoteatrs) {
            k.showInfo();
        }
    }

    // Реалізація методу пошуку з інтерфейсу
    @Override
    public void searchFilm(String filmName) {
        boolean found = false;

        System.out.println("\n=== Пошук фільму: " + filmName + " ===");

        for (Kinoteatr k : kinoteatrs) {
            if (k.hasFilm(filmName)) {
                System.out.println("Фільм знайдено у кінотеатрі: " + k.getName());
                found = true;
            }
        }

        if (!found) {
            System.out.println("Фільм не знайдено.");
        }
    }

    // Внутрішній клас
    class Kinoteatr {
        private String name;
        private ArrayList<String> films = new ArrayList<>();
        private ArrayList<String> sessions = new ArrayList<>();

        public Kinoteatr(String name) {
            this.name = name;
        }

        public String getName() {
            return name;
        }

        public void addFilm(String film, String session) {
            films.add(film);
            sessions.add(session);
            System.out.println("Фільм додано до кінотеатру " + name);
        }

        public boolean hasFilm(String filmName) {
            for (String film : films) {
                if (film.equalsIgnoreCase(filmName)) {
                    return true;
                }
            }
            return false;
        }

        public void showInfo() {
            System.out.println("\nКінотеатр: " + name);
            System.out.println("Фільми та сеанси:");

            for (int i = 0; i < films.size(); i++) {
                System.out.println("- " + films.get(i) + " | Сеанс: " + sessions.get(i));
            }
        }
    }
}

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Kino kino = new Kino();

        System.out.print("Введіть кількість кінотеатрів: ");
        int count = scanner.nextInt();
        scanner.nextLine();

        for (int i = 0; i < count; i++) {
            System.out.println("\nКінотеатр №" + (i + 1));

            System.out.print("Введіть назву кінотеатру: ");
            String name = scanner.nextLine();

            Kino.Kinoteatr kinoteatr = kino.new Kinoteatr(name);

            System.out.print("Введіть кількість фільмів: ");
            int filmCount = scanner.nextInt();
            scanner.nextLine();

            for (int j = 0; j < filmCount; j++) {
                System.out.print("Введіть назву фільму: ");
                String film = scanner.nextLine();

                System.out.print("Введіть час сеансу: ");
                String session = scanner.nextLine();

                kinoteatr.addFilm(film, session);
            }

            kino.addKinoteatr(kinoteatr);
        }

        kino.showAll();

        System.out.print("\nВведіть назву фільму для пошуку: ");
        String searchName = scanner.nextLine();

        kino.searchFilm(searchName);

        scanner.close();
    }
}