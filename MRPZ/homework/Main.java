class MyThread extends Thread {
    int number;
    int delay;

    public MyThread(int number, int delay) {
        this.number = number;
        this.delay = delay;
    }

    public void run() {
        try {
            Thread.sleep(delay);
            System.out.println(number);
        } catch (InterruptedException e) {
            System.out.println("Потік перервано");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        MyThread t1 = new MyThread(1, 1000);
        MyThread t2 = new MyThread(2, 2000);
        MyThread t3 = new MyThread(3, 3000);

        t1.start();
        t2.start();
        t3.start();
    }
}