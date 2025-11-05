using System;

namespace Lab34.Var3
{
    internal class Program
    {
        static void Main()
        {
            // 1) Делегат + анонiмний метод
            CharSearch viaAnonymous = delegate (string s, char ch)
            {
                if (string.IsNullOrEmpty(s)) return -1;
                for (int i = 0; i < s.Length; i++)
                    if (s[i] == ch) return i;
                return -1;
            };

            // 1) Делегат + лямбда-вираз 
            CharSearch viaLambda = (s, ch) => string.IsNullOrEmpty(s) ? -1 : s.IndexOf(ch);

            string text = "Laba3";
            char symbol = 'a';
            Console.WriteLine($"[Anon] '{symbol}' у \"{text}\" -> iндекс {viaAnonymous(text, symbol)}");
            Console.WriteLine($"[Lambda] '{symbol}' у \"{text}\" -> iндекс {viaLambda(text, symbol)}");

            // 2) Компонент зi стеком i подiєю переповнення 
            var stack = new LimitedStack<int>(capacity: 3);

            // 3) Пiдписка на подiю (обробник)
            stack.Overflow += msg => Console.WriteLine("[Подiя] " + msg);

            Console.WriteLine("\nПушимо елементи у стек:");
            Console.WriteLine(stack.Push(10)); // true
            Console.WriteLine(stack.Push(20)); // true
            Console.WriteLine(stack.Push(30)); // true
            Console.WriteLine(stack.Push(40)); // false -> спрацює подiя

            Console.WriteLine($"Стек зараз: {stack}");

            if (stack.TryPop(out var x))
                Console.WriteLine($"Pop -> {x}");
            Console.WriteLine($"Стек пiсля pop: {stack}");
        }
    }
}
