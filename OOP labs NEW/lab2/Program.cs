using System;
using System.Collections;
using System.Collections.Generic;
using Lab32.Domain;
using Lab32.Collections;

namespace Lab32
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Лаба 3.2 — Варіант 3 (Товар)\n");

           
            var p1 = new Product(103, "Паяльник", "ProTech", 499.00m, 20);
            var p2 = new Product(101, "Кабель USB-C", "CableCo", 149.50m, 100);
            var p3 = new Product(105, "Мультиметр", "VoltLab", 899.99m, 12);
            var p4 = new Product(102, "Розетка", "ElecUA", 89.00m, 200);
            var p5 = new Product(104, "Подовжувач", "ElecUA", 299.00m, 40);

            // A) Generic: List<Product>
            var list = new List<Product> { p1, p2, p3 };
            Console.WriteLine("List<T> (початково 3 елементи):"); Print(list);

            list.Add(p4);            
            list.Insert(1, p5);      
            Console.WriteLine("\nList<T> після Add + Insert:"); Print(list);

            // пошук
            var found = list.Find(pr => pr.Code == 101);
            if (found != null) found.Price = 135.00m;
            Console.WriteLine("\nList<T> після оновлення ціни (Code=101):"); Print(list);

            // видалення
            list.Remove(p3);
            list.RemoveAll(pr => pr.Producer == "ElecUA" && pr.Price < 100);
            Console.WriteLine("\nList<T> після видалень:"); Print(list);

            // проходи й сортування
            Console.WriteLine("\nforeach по List<T>:");
            foreach (var pr in list) Console.WriteLine(pr);

            list.Sort(); 
            Console.WriteLine("\nList<T> Sort() за Code:"); Print(list);

            list.Sort(new ProductPriceComparer()); // IComparer -> за Price
            Console.WriteLine("\nList<T> Sort(IComparer) за Price:"); Print(list);

            // Non-generic: ArrayList
            var arrList = new ArrayList();
            arrList.Add(p1);
            arrList.Add(p2);
            Console.WriteLine("\nArrayList (non-generic):");
            foreach (var obj in arrList) Console.WriteLine((Product)obj);

            ((Product)arrList[0]).BatchQty += 5;  
            Console.WriteLine("ArrayList після оновлення qty першого:");
            foreach (var obj in arrList) Console.WriteLine((Product)obj);

            arrList.RemoveAt(1);
            Console.WriteLine("ArrayList після RemoveAt(1):");
            foreach (var obj in arrList) Console.WriteLine((Product)obj);

            Console.WriteLine("\n[Різниця] ArrayList — без типобезпеки (касти). List<T> — безпечніше і зручніше.\n");

            // C) Масив
            Product[] array = { p1, p2, p3, p4, p5 };
            Console.WriteLine("Масив Product[]:"); Print(array);
            array[2].Price += 50;
            Console.WriteLine("Масив після оновлення ціни 3-го:"); Print(array);
            int idx = Array.FindIndex(array, pr => pr.Code == 104);
            Console.WriteLine($"Індекс Code=104 у масиві: {idx}");

            // D) Узагальнене бінарне дерево 
            var tree = new BinarySearchTree<Product>();
            foreach (var pr in array) tree.Add(pr);

            Console.WriteLine("\nBST InOrder (Left -> Node -> Right) за Code:");
            foreach (var pr in tree) Console.WriteLine(pr);

            Console.WriteLine("\nTree Contains(Code=105): " + tree.Contains(new Product(105, "X", "X", 0, 0)));
            Console.WriteLine("Tree Contains(Code=999): " + tree.Contains(new Product(999, "X", "X", 0, 0)));

            Console.WriteLine("\nГотово. Натисни будь-яку клавішу...");
            Console.ReadKey();
        }

        static void Print(IEnumerable<Product> seq)
        {
            foreach (var p in seq) Console.WriteLine(p);
        }
    }
}
