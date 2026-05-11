import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.println("Домашня робота");
        System.out.println("Тема: Обчислювальні алгоритми та алгоритми обробки графів");
        System.out.println("Варіант 18");
        System.out.println("Студент: Марченко К.О.");
        System.out.println();

        solveLUP(sc);

        System.out.println("\n--------------------------------------\n");

        workWithGraph(sc);
    }

    // =========================
    // 1 РІВЕНЬ: LUP-РОЗКЛАДАННЯ
    // =========================

    static void solveLUP(Scanner sc) {
        int n = 4;

        double[][] A = new double[n][n];
        double[] b = new double[n];

        System.out.println("ЗАВДАННЯ 1. Розв'язання СЛАР методом LUP-розкладання");
        System.out.println("Введіть коефіцієнти системи.");
        System.out.println("Для кожного рівняння введіть 4 коефіцієнти і праву частину.");
        System.out.println("Наприклад: 0 4 -1 -6 -38");
        System.out.println();

        for (int i = 0; i < n; i++) {
            System.out.println("Рівняння " + (i + 1) + ":");
            for (int j = 0; j < n; j++) {
                A[i][j] = sc.nextDouble();
            }
            b[i] = sc.nextDouble();
        }

        System.out.println("\nЗадана система:");
        printSystem(A, b);

        LUPResult result = lupDecomposition(A);

        System.out.println("\nМатриця L:");
        printMatrix(result.L);

        System.out.println("\nМатриця U:");
        printMatrix(result.U);

        System.out.println("\nМатриця P:");
        printMatrix(result.P);

        double[] x = solve(result.L, result.U, result.P, b);

        System.out.println("\nРозв'язок системи:");
        for (int i = 0; i < x.length; i++) {
            System.out.printf("x%d = %.4f%n", i + 1, x[i]);
        }
    }

    static LUPResult lupDecomposition(double[][] matrix) {
        int n = matrix.length;

        double[][] LU = new double[n][n];
        double[][] P = new double[n][n];

        for (int i = 0; i < n; i++) {
            System.arraycopy(matrix[i], 0, LU[i], 0, n);
            P[i][i] = 1;
        }

        for (int k = 0; k < n; k++) {
            int pivot = k;
            double max = Math.abs(LU[k][k]);

            for (int i = k + 1; i < n; i++) {
                if (Math.abs(LU[i][k]) > max) {
                    max = Math.abs(LU[i][k]);
                    pivot = i;
                }
            }

            if (max == 0) {
                throw new RuntimeException("Матриця вироджена, розв'язок неможливий.");
            }

            if (pivot != k) {
                swapRows(LU, k, pivot);
                swapRows(P, k, pivot);
            }

            for (int i = k + 1; i < n; i++) {
                LU[i][k] = LU[i][k] / LU[k][k];

                for (int j = k + 1; j < n; j++) {
                    LU[i][j] = LU[i][j] - LU[i][k] * LU[k][j];
                }
            }
        }

        double[][] L = new double[n][n];
        double[][] U = new double[n][n];

        for (int i = 0; i < n; i++) {
            L[i][i] = 1;

            for (int j = 0; j < n; j++) {
                if (i > j) {
                    L[i][j] = LU[i][j];
                } else {
                    U[i][j] = LU[i][j];
                }
            }
        }

        return new LUPResult(L, U, P);
    }

    static double[] solve(double[][] L, double[][] U, double[][] P, double[] b) {
        int n = b.length;

        double[] Pb = multiply(P, b);

        double[] y = new double[n];

        for (int i = 0; i < n; i++) {
            double sum = Pb[i];

            for (int j = 0; j < i; j++) {
                sum -= L[i][j] * y[j];
            }

            y[i] = sum / L[i][i];
        }

        double[] x = new double[n];

        for (int i = n - 1; i >= 0; i--) {
            double sum = y[i];

            for (int j = i + 1; j < n; j++) {
                sum -= U[i][j] * x[j];
            }

            x[i] = sum / U[i][i];
        }

        return x;
    }

    static double[] multiply(double[][] matrix, double[] vector) {
        int n = vector.length;
        double[] result = new double[n];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                result[i] += matrix[i][j] * vector[j];
            }
        }

        return result;
    }

    static void swapRows(double[][] matrix, int a, int b) {
        double[] temp = matrix[a];
        matrix[a] = matrix[b];
        matrix[b] = temp;
    }

    // =========================
    // 2 РІВЕНЬ: ГРАФ
    // =========================

    static void workWithGraph(Scanner sc) {
        System.out.println("ЗАВДАННЯ 2. Побудова графа і обхід в ширину");

        int vertices = 41;
        int[][] graph = new int[vertices][vertices];

        buildGraph(graph);

        System.out.println("\nМатриця суміжності графа:");
        printAdjacencyMatrix(graph);

        int edges = countEdges(graph);
        System.out.println("\nКількість вершин: " + vertices);
        System.out.println("Кількість ребер: " + edges);

        System.out.print("\nВведіть вершину, з якої почати обхід в ширину: ");
        int start = sc.nextInt();

        System.out.println("\nОбхід графа в ширину:");
        bfs(graph, start - 1);

        System.out.println("\n\nРозміщення автозаправних колонок:");
        placeGasStations(graph);
    }

    static void buildGraph(int[][] graph) {
        int n = graph.length;

        for (int i = 0; i < n; i++) {
            addEdge(graph, i, (i + 1) % n);
            addEdge(graph, i, (i + 2) % n);
        }
    }

    static void addEdge(int[][] graph, int a, int b) {
        graph[a][b] = 1;
        graph[b][a] = 1;
    }

    static int countEdges(int[][] graph) {
        int count = 0;

        for (int i = 0; i < graph.length; i++) {
            for (int j = i + 1; j < graph.length; j++) {
                if (graph[i][j] == 1) {
                    count++;
                }
            }
        }

        return count;
    }

    static void bfs(int[][] graph, int start) {
        boolean[] visited = new boolean[graph.length];
        Queue<Integer> queue = new LinkedList<>();

        visited[start] = true;
        queue.add(start);

        while (!queue.isEmpty()) {
            int vertex = queue.poll();
            System.out.print((vertex + 1) + " ");

            for (int i = 0; i < graph.length; i++) {
                if (graph[vertex][i] == 1 && !visited[i]) {
                    visited[i] = true;
                    queue.add(i);
                }
            }
        }
    }

    static void placeGasStations(int[][] graph) {
        int n = graph.length;
        boolean[] blocked = new boolean[n];
        ArrayList<Integer> stations = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            if (!blocked[i]) {
                stations.add(i + 1);
                blocked[i] = true;

                for (int j = 0; j < n; j++) {
                    if (graph[i][j] == 1) {
                        blocked[j] = true;
                    }
                }
            }
        }

        System.out.println("АЗС можна поставити на таких перехрестях:");
        for (int v : stations) {
            System.out.print(v + " ");
        }

        System.out.println("\nКількість автозаправних колонок: " + stations.size());
    }

    // =========================
    // ВИВЕДЕННЯ
    // =========================

    static void printSystem(double[][] A, double[] b) {
        for (int i = 0; i < A.length; i++) {
            for (int j = 0; j < A[i].length; j++) {
                System.out.printf("%8.2f*x%d ", A[i][j], j + 1);

                if (j < A[i].length - 1) {
                    System.out.print("+ ");
                }
            }

            System.out.printf("= %8.2f%n", b[i]);
        }
    }

    static void printMatrix(double[][] matrix) {
        for (double[] row : matrix) {
            for (double value : row) {
                System.out.printf("%10.4f", value);
            }
            System.out.println();
        }
    }

    static void printAdjacencyMatrix(int[][] matrix) {
        System.out.print("    ");

        for (int i = 0; i < matrix.length; i++) {
            System.out.printf("%2d ", i + 1);
        }

        System.out.println();

        for (int i = 0; i < matrix.length; i++) {
            System.out.printf("%2d: ", i + 1);

            for (int j = 0; j < matrix[i].length; j++) {
                System.out.printf("%2d ", matrix[i][j]);
            }

            System.out.println();
        }
    }
}

class LUPResult {
    double[][] L;
    double[][] U;
    double[][] P;

    LUPResult(double[][] L, double[][] U, double[][] P) {
        this.L = L;
        this.U = U;
        this.P = P;
    }
}