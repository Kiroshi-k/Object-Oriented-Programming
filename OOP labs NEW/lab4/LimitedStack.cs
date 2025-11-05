using System;

namespace Lab34.Var3
{
    // Компонент багаторазового використання: стек з обмеженою мiсткiстю
    public class LimitedStack<T>
    {
        private readonly T[] _items;
        private int _top = -1;

        public int Capacity { get; }
        public int Count => _top + 1;

        // Подiя переповнення (простий варiант для "добре")
        public delegate void StackOverflowHandler(string message);
        public event StackOverflowHandler? Overflow;

        public LimitedStack(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            Capacity = capacity;
            _items = new T[capacity];
        }

        public bool Push(T item)
        {
            if (_top + 1 >= Capacity)
            {
                Overflow?.Invoke($"Стек переповнений (мiсткiсть {Capacity}). Спроба додати: {item}");
                return false;
            }
            _items[++_top] = item;
            return true;
        }

        public bool TryPop(out T value)
        {
            if (_top < 0)
            {
                value = default!;
                return false;
            }
            value = _items[_top--];
            return true;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";
            var parts = new string[Count];
            for (int i = 0; i < Count; i++)
                parts[i] = _items[i]?.ToString() ?? "null";
            return "[" + string.Join(", ", parts) + "]";
        }
    }
}
