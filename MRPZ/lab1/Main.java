import java.util.Random;

public class Main {
    public static void main(String[] args) {
 
        System.out.println("Розробник: Марченко К.О"); 
        System.out.println("Лабораторна робота №1: Робота з масивами мовою Java\n");

       
        int rows = 3;
        int cols = 2;
        int[][] matrixA = new int[rows][cols];
        
    
        Random random = new Random();

      
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                // Випадкове число від 0 до 20 включно
                matrixA[i][j] = random.nextInt(21); 
            }
        }

        System.out.println("Матриця A до обробки:");
        printMatrix(matrixA);

        int[] tempRow = matrixA[0];
        // Переписуємо перший рядок значеннями з другого
        matrixA[0] = matrixA[1];
        // Записуємо в другий рядок збережене значення першого
        matrixA[1] = tempRow;

       
        double sum = 0;
        int count = rows * cols; 
        
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                sum += matrixA[i][j];
            }
        }
        double average = sum / count;

       
        System.out.println("Матриця A після перестановки 1-го та 2-го рядків:");
        printMatrix(matrixA);
        
        System.out.printf("Середнє арифметичне елементів матриці: %.2f\n", average);
    }

    // Допоміжний (простий) метод для гарного виводу матриці
    private static void printMatrix(int[][] matrix) {
        for (int i = 0; i < matrix.length; i++) {
            for (int j = 0; j < matrix[i].length; j++) {
                
                System.out.print(matrix[i][j] + "\t");
            }
            System.out.println(); 
        }
        System.out.println(); 
    }
}
