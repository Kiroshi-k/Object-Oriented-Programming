import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

public class Main {

    static final int N = 100;
    static final int REPEATS = 5;

    public static void main(String[] args) {

        System.out.println("Розробник: Марченко К.О.");
        System.out.println("Лабораторна робота 1.6");
        System.out.println("Варіант 18");
        System.out.println("Алгоритм: карманне сортування");
        System.out.println("Структура даних: одновимірний масив\n");

        int[] sizes = {N, N * N, N * N * N};

        System.out.println("Кількість елементів;Впорядкований масив (нс);Невпорядкований масив (нс)");

        for (int size : sizes) {
            long orderedTime = getAverageTime(size, true);
            long unorderedTime = getAverageTime(size, false);

            System.out.println(size + ";" + orderedTime + ";" + unorderedTime);
        }
    }

    static long getAverageTime(int size, boolean ordered) {
        long totalTime = 0;

        for (int i = 0; i < REPEATS; i++) {
            int[] array;

            if (ordered) {
                array = createOrderedArray(size);
            } else {
                array = createRandomArray(size);
            }

            long start = System.nanoTime();

            bucketSort(array);

            long end = System.nanoTime();

            totalTime += end - start;
        }

        return totalTime / REPEATS;
    }

    static int[] createOrderedArray(int size) {
        int[] array = new int[size];

        for (int i = 0; i < size; i++) {
            array[i] = i;
        }

        return array;
    }

    static int[] createRandomArray(int size) {
        int[] array = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++) {
            array[i] = random.nextInt(size);
        }

        return array;
    }

    static void bucketSort(int[] array) {
        if (array.length == 0) {
            return;
        }

        int min = array[0];
        int max = array[0];

        for (int value : array) {
            if (value < min) {
                min = value;
            }

            if (value > max) {
                max = value;
            }
        }

        int bucketCount = Math.min(array.length, 10000);

        ArrayList<Integer>[] buckets = new ArrayList[bucketCount];

        for (int i = 0; i < bucketCount; i++) {
            buckets[i] = new ArrayList<>();
        }

        for (int value : array) {
            int index = (int) ((long) (value - min) * bucketCount / (max - min + 1));
            buckets[index].add(value);
        }

        int arrayIndex = 0;

        for (ArrayList<Integer> bucket : buckets) {
            Collections.sort(bucket);

            for (int value : bucket) {
                array[arrayIndex] = value;
                arrayIndex++;
            }
        }
    }
}