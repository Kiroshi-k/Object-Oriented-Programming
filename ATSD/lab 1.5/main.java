import java.util.LinkedList;
import java.util.Queue;

class Student {
    String surname;
    String group;
    String faculty;
    int medicalPolicyNumber;

    public Student(String surname, String group, String faculty, int medicalPolicyNumber) {
        this.surname = surname;
        this.group = group;
        this.faculty = faculty;
        this.medicalPolicyNumber = medicalPolicyNumber;
    }

    public void print() {
        System.out.printf("%-12s %-8s %-10s %d\n",
                surname, group, faculty, medicalPolicyNumber);
    }
}

class BSTNode {
    Student student;
    BSTNode left;
    BSTNode right;

    public BSTNode(Student student) {
        this.student = student;
    }
}

class BSTTree {
    BSTNode root;

    private BSTNode rotateRight(BSTNode node) {
        BSTNode newRoot = node.left;
        node.left = newRoot.right;
        newRoot.right = node;
        return newRoot;
    }

    private BSTNode rotateLeft(BSTNode node) {
        BSTNode newRoot = node.right;
        node.right = newRoot.left;
        newRoot.left = node;
        return newRoot;
    }

    public void add(Student student) {
        root = insertToRoot(root, student);
    }

    private BSTNode insertToRoot(BSTNode node, Student student) {
        if (node == null) {
            return new BSTNode(student);
        }

        if (student.medicalPolicyNumber < node.student.medicalPolicyNumber) {
            node.left = insertToRoot(node.left, student);
            node = rotateRight(node);
        } else {
            node.right = insertToRoot(node.right, student);
            node = rotateLeft(node);
        }

        return node;
    }

    public Student search(int key) {
        BSTNode current = root;

        while (current != null) {
            if (key == current.student.medicalPolicyNumber) {
                return current.student;
            } else if (key < current.student.medicalPolicyNumber) {
                current = current.left;
            } else {
                current = current.right;
            }
        }

        return null;
    }

    public void printBreadthFirst() {
        if (root == null) {
            System.out.println("Дерево порожнє");
            return;
        }

        Queue<BSTNode> queue = new LinkedList<>();
        queue.add(root);

        while (!queue.isEmpty()) {
            BSTNode current = queue.poll();

            System.out.print(current.student.surname + "(" +
                    current.student.medicalPolicyNumber + ") ");

            if (current.left != null) {
                queue.add(current.left);
            }

            if (current.right != null) {
                queue.add(current.right);
            }
        }

        System.out.println();
    }
}

public class Main {

    public static void printArray(Student[] students) {
        System.out.println("Прізвище     Група    Факультет  Поліс");
        System.out.println("-----------------------------------------");

        for (Student student : students) {
            student.print();
        }
    }

    public static Student binarySearch(Student[] students, int key) {
        int left = 0;
        int right = students.length - 1;

        while (left <= right) {
            int middle = (left + right) / 2;

            if (students[middle].medicalPolicyNumber == key) {
                return students[middle];
            } else if (key < students[middle].medicalPolicyNumber) {
                right = middle - 1;
            } else {
                left = middle + 1;
            }
        }

        return null;
    }

    public static void main(String[] args) {

        Student[] students = {
                new Student("Bondar", "SE-21", "FIT", 1001),
                new Student("Melnyk", "SE-22", "FIT", 1010),
                new Student("Shevchenko", "CS-21", "FCS", 1022),
                new Student("Koval", "SE-23", "FIT", 1035),
                new Student("Tkachenko", "KN-21", "FKN", 1040),
                new Student("Moroz", "CS-22", "FCS", 1055),
                new Student("Boyko", "SE-21", "FIT", 1061),
                new Student("Kravchenko", "KN-22", "FKN", 1073),
                new Student("Savchenko", "CS-23", "FCS", 1088),
                new Student("Polishchuk", "SE-22", "FIT", 1094),
                new Student("Rudenko", "KN-21", "FKN", 1100),
                new Student("Lysenko", "CS-21", "FCS", 1112),
                new Student("Marchenko", "SE-23", "FIT", 1125),
                new Student("Hrytsenko", "KN-22", "FKN", 1130),
                new Student("Pavlenko", "CS-22", "FCS", 1144),
                new Student("Ivanenko", "SE-21", "FIT", 1156),
                new Student("Petrenko", "KN-23", "FKN", 1167),
                new Student("Danylenko", "CS-23", "FCS", 1179),
                new Student("Zakharchuk", "SE-22", "FIT", 1185),
                new Student("Honchar", "KN-21", "FKN", 1199)
        };

        System.out.println("=== Перший рівень ===");
        System.out.println("Одновимірний масив студентів, впорядкований за номером медичного полісу:\n");

        printArray(students);

        int searchPolicy = 1125;

        System.out.println("\nПошук студента з номером медичного полісу: " + searchPolicy);

        Student foundStudent = binarySearch(students, searchPolicy);

        if (foundStudent != null) {
            System.out.println("Студента знайдено.");
            System.out.println("Факультет: " + foundStudent.faculty);
            System.out.println("Група: " + foundStudent.group);
        } else {
            System.out.println("Студента з таким номером полісу не знайдено.");
        }

        System.out.println("\n=== Другий рівень ===");
        System.out.println("Створення BST-дерева з вставкою в корінь:\n");

        BSTTree tree = new BSTTree();

        for (Student student : students) {
            tree.add(student);
            System.out.print("Після додавання " + student.surname + ": ");
            tree.printBreadthFirst();
        }

        int treeSearchKey = 1125;

        System.out.println("\nПошук у BST-дереві за номером полісу: " + treeSearchKey);

        Student foundInTree = tree.search(treeSearchKey);

        if (foundInTree != null) {
            System.out.println("Знайдений вузол:");
            foundInTree.print();
        } else {
            System.out.println("Вузол з таким ключем не знайдено.");
        }
    }
}