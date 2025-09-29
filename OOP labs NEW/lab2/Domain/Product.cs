using System;

namespace Lab32.Domain
{
    // Варіант 3: Товар
    // Поля: Код, Назва, Виробник, Вартість, Кількість у партії
    public class Product : IComparable<Product>
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }
        public int BatchQty { get; set; }

        public Product(int code, string name, string producer, decimal price, int batchQty)
        {
            Code = code;
            Name = name;
            Producer = producer;
            Price = price;
            BatchQty = batchQty;
        }

        // За замовчуванням порівнюємо за Code — зручно для дерева і сортування
        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return Code.CompareTo(other.Code);
        }

        public override string ToString()
        {
            return $"[{Code}] {Name} | {Producer} | {Price:C} | qty={BatchQty}";
        }
    }
}
