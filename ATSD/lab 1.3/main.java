import java.util.LinkedList;
import java.util.Queue;
import java.util.Scanner;

public class Main {

    // Клас Студент
    static class Student {
        String surname;
        String name;
        int course;
        long studentCard;
        boolean participatesInConferences;
        boolean hasItAcademyCertificate;

        public Student(String surname, String name, int course, long studentCard,
                       boolean participatesInConferences, boolean hasItAcademyCertificate) {
            this.surname = surname;
            this.name = name;
            this.course = course;
            this.studentCard = studentCard;
            this.participatesInConferences = participatesInConferences;
            this.hasItAcademyCertificate = hasItAcademyCertificate;
        }

        @Override
        public String toString() {
            return String.format("%-12s %-12s %-5d %-12d %-12s %-12s",
                    surname,
                    name,
                    course,
                    studentCard,
                    participatesInConferences ? "так" : "ні",
                    hasItAcademyCertificate ? "так" : "ні");
        }
    }

    // Вузол дерева
    static class Node {
        Student data;
        Node left;
        Node right;

        public Node(Student data) {
            this.data = data;
        }
    }

    // Клас бінарного дерева
    static class BinaryTree {
        Node root;

        // Додавання вузла за ключем studentCard
        public void add(Student student) {
            Node newNode = new Node(student);

            if (root == null) {
                root = newNode;
                return;
            }

            Node current = root;

            while (true) {
                if (student.studentCard < current.data.studentCard) {
                    if (current.left == null) {
                        current.left = newNode;
                        return;
                    }
                    current = current.left;
                } else if (student.studentCard > current.data.studentCard) {
                    if (current.right == null) {
                        current.right = newNode;
                        return;
                    }
                    current = current.right;
                } else {
                    // однакові ключі не додаємо
                    return;
                }
            }
        }

        // Виведення дерева у ширину
        public void printBreadthFirst() {
            if (root == null) {
                System.out.println("Дерево порожнє");
                return;
            }

            Queue<Node> queue = new LinkedList<>();
            queue.add(root);

            System.out.printf("%-12s %-12s %-5s %-12s %-12s %-12s%n",
                    "Прізвище", "Ім'я", "Курс", "Квиток", "Конференції", "Сертифікат");

            while (!queue.isEmpty()) {
                Node current = queue.poll();
                System.out.println(current.data);

                if (current.left != null) {
                    queue.add(current.left);
                }
                if (current.right != null) {
                    queue.add(current.right);
                }
            }
        }

        // Пошук за критерієм варіанта 18
        public void search(int course1, int course2, boolean conferences, boolean certificate) {
            if (root == null) {
                System.out.println("Дерево порожнє");
                return;
            }

            Queue<Node> queue = new LinkedList<>();
            queue.add(root);

            boolean found = false;

            System.out.println("\nРезультати пошуку:");
            System.out.printf("%-12s %-12s %-5s %-12s %-12s %-12s%n",
                    "Прізвище", "Ім'я", "Курс", "Квиток", "Конференції", "Сертифікат");

            while (!queue.isEmpty()) {
                Node current = queue.poll();
                Student s = current.data;

                if ((s.course == course1 || s.course == course2)
                        && s.participatesInConferences == conferences
                        && s.hasItAcademyCertificate == certificate) {
                    System.out.println(s);
                    found = true;
                }

                if (current.left != null) {
                    queue.add(current.left);
                }
                if (current.right != null) {
                    queue.add(current.right);
                }
            }

            if (!found) {
                System.out.println("Студентів за заданим критерієм не знайдено.");
            }
        }
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        BinaryTree tree = new BinaryTree();

        // Додаємо елементи
        tree.add(new Student("Іваненко", "Олег", 5, 1005, true, true));
        tree.add(new Student("Петренко", "Марія", 3, 1002, false, true));
        tree.add(new Student("Сидоренко", "Анна", 6, 1010, true, true));
        tree.add(new Student("Коваленко", "Ігор", 2, 1001, false, false));
        tree.add(new Student("Мельник", "Олена", 5, 1007, true, false));
        tree.add(new Student("Ткаченко", "Дмитро", 6, 1012, false, true));
        tree.add(new Student("Бондар", "Ірина", 4, 1003, true, true));

        System.out.println("Вміст дерева (обхід у ширину):");
        tree.printBreadthFirst();

        System.out.println("\nПошук студентів 5-го та 6-го курсів, які беруть участь у конференціях та мають сертифікати:");
        tree.search(5, 6, true, true);

        scanner.close();
    }
}