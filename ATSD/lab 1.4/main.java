public class Main {

    static class Student {
        String surname;
        String name;
        String faculty;
        double grade;

        Student(String surname, String name, String faculty, double grade) {
            this.surname = surname;
            this.name = name;
            this.faculty = faculty;
            this.grade = grade;
        }

        void print() {
            System.out.println(grade + " | " + surname + " " + name + " | " + faculty);
        }
    }

    public static void main(String[] args) {

        System.out.println("Лабораторна робота 1.4");
        System.out.println("Варіант 18");
        System.out.println("Марченко К.О.\n");

        firstLevel();

        System.out.println("\n-----------------------------\n");

        secondLevel();
    }

    // Перший рівень
    static void firstLevel() {
        System.out.println("ПЕРШИЙ РІВЕНЬ");
        System.out.println("Сортування одновимірного масиву бульбашкою за спаданням бала\n");

        Student[] students = {
                new Student("Іваненко", "Олег", "ФКНТ", 82.5),
                new Student("Петренко", "Анна", "ФКНТ", 91.0),
                new Student("Сидоренко", "Максим", "ФЕБА", 74.0),
                new Student("Коваленко", "Ірина", "ФКНТ", 88.5),
                new Student("Мельник", "Денис", "ФЛСК", 69.0)
        };

        System.out.println("Масив до сортування:");
        printArray(students);

        bubbleSortByGradeDescending(students);

        System.out.println("\nМасив після сортування:");
        printArray(students);
    }

    static void bubbleSortByGradeDescending(Student[] students) {
        for (int i = 0; i < students.length - 1; i++) {
            for (int j = 0; j < students.length - 1 - i; j++) {

                if (students[j].grade < students[j + 1].grade) {
                    Student temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }

            }
        }
    }

    static void printArray(Student[] students) {
        for (Student student : students) {
            student.print();
        }
    }

    // Другий рівень
    static void secondLevel() {
        System.out.println("ДРУГИЙ РІВЕНЬ");
        System.out.println("Двовимірний масив: кожний рядок — студенти одного факультету");
        System.out.println("Сортування стовпчиків кожного рядка за зростанням бала\n");

        Student[][] matrix = {
                {
                        new Student("Іваненко", "Олег", "ФКНТ", 82.5),
                        new Student("Петренко", "Анна", "ФКНТ", 91.0),
                        new Student("Коваленко", "Ірина", "ФКНТ", 76.0)
                },
                {
                        new Student("Сидоренко", "Максим", "ФЕБА", 74.0),
                        new Student("Шевченко", "Марія", "ФЕБА", 89.0),
                        new Student("Бондар", "Артем", "ФЕБА", 67.5)
                },
                {
                        new Student("Мельник", "Денис", "ФЛСК", 69.0),
                        new Student("Ткаченко", "Олена", "ФЛСК", 95.0),
                        new Student("Гончар", "Влад", "ФЛСК", 81.0)
                }
        };

        System.out.println("Двовимірний масив до сортування:");
        printMatrix(matrix);

        sortRowsByIndexes(matrix);

        System.out.println("\nДвовимірний масив після сортування:");
        printMatrix(matrix);
    }

    static void sortRowsByIndexes(Student[][] matrix) {
        for (int i = 0; i < matrix.length; i++) {

            for (int j = 0; j < matrix[i].length - 1; j++) {
                int minIndex = j;

                for (int k = j + 1; k < matrix[i].length; k++) {
                    if (matrix[i][k].grade < matrix[i][minIndex].grade) {
                        minIndex = k;
                    }
                }

                Student temp = matrix[i][j];
                matrix[i][j] = matrix[i][minIndex];
                matrix[i][minIndex] = temp;
            }

        }
    }

    static void printMatrix(Student[][] matrix) {
        for (int i = 0; i < matrix.length; i++) {
            System.out.println("Факультет: " + matrix[i][0].faculty);

            for (int j = 0; j < matrix[i].length; j++) {
                matrix[i][j].print();
            }

            System.out.println();
        }
    }
}