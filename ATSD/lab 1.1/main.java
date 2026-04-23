public class Main {

    // Клас вузла двоспрямованого списку
    static class Node {
        int data;
        Node prev;
        Node next;

        Node(int data) {
            this.data = data;
        }
    }

    // Клас двоспрямованого списку
    static class DoublyLinkedList {
        Node head;
        Node tail;

        // Перевірка на порожність списку
        public boolean isEmpty() {
            return head == null;
        }

        // Додавання елемента в кінець списку
        public boolean add(int value) {
            Node newNode = new Node(value);

            if (isEmpty()) {
                head = newNode;
                tail = newNode;
            } else {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }

            return true;
        }

        // Видалення першого знайденого елемента за значенням
        public int remove(int value) throws Exception {
            if (isEmpty()) {
                throw new Exception("Список порожній");
            }

            Node current = head;

            while (current != null) {
                if (current.data == value) {
                    int deletedValue = current.data;

                    // Якщо у списку один елемент
                    if (head == tail) {
                        head = null;
                        tail = null;
                    }
                    // Якщо видаляється перший елемент
                    else if (current == head) {
                        head = head.next;
                        head.prev = null;
                    }
                    // Якщо видаляється останній елемент
                    else if (current == tail) {
                        tail = tail.prev;
                        tail.next = null;
                    }
                    // Якщо видаляється елемент із середини
                    else {
                        current.prev.next = current.next;
                        current.next.prev = current.prev;
                    }

                    return deletedValue;
                }

                current = current.next;
            }

            throw new Exception("Елемент не знайдено");
        }

        // Виведення списку
        public void printList() {
            if (isEmpty()) {
                System.out.println("Список порожній");
                return;
            }

            Node current = head;

            while (current != null) {
                System.out.print(current.data + " ");
                current = current.next;
            }

            System.out.println();
        }
    }

    public static void main(String[] args) {
        DoublyLinkedList list = new DoublyLinkedList();

        // Вставка елементів
        list.add(10);
        list.add(20);
        list.add(30);
        list.add(40);
        list.add(50);

        System.out.println("Список після додавання елементів:");
        list.printList();

        try {
            // Видалення декількох елементів
            int deleted1 = list.remove(20);
            System.out.println("Видалено елемент: " + deleted1);

            int deleted2 = list.remove(40);
            System.out.println("Видалено елемент: " + deleted2);
        } catch (Exception e) {
            System.out.println("Помилка: " + e.getMessage());
        }

        System.out.println("Список після видалення елементів:");
        list.printList();
    }
}