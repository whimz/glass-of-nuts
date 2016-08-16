/*Описать структуру Check: https://ru.wikipedia.org/wiki/%D0%9A%D0%B0%D1%81%D1%81%D0%BE%D0%B2%D1%8B%D0%B9_%D1%87%D0%B5%D0%BA
Предусмотреть функцию добавления информации о товаре (наименование, количество, цена за единицу товара, скидка) в чек, 
функцию распечатки чека на экране консоли.
*/

using System;
using System.Collections.Generic;

namespace _08_1
{
    enum Category { Meat = 1, Alcohol, Confectionery, Bread, Cereals, Drinks, Eggs}
    struct Cheque
    {
        public struct Item
        {
            String name;
            Category ctgry;
            Int32 quantity;
            Double price;
            Double discount;

            public Item(String name, Category ctgry, Int32 quantity, Double price, Double discount)
            {
                this.name = name;
                this.ctgry = ctgry;
                this.quantity = quantity;
                this.price = price;
                this.discount = discount;
            }
            public String Name { get { return name; } set { name = value; } }
            public Category Ctrgy { get { return ctgry; } set { ctgry = value; } }
            public Int32 Quantity { get { return quantity; } set { quantity = value; } }
            public Double Price { get { return price; } set { price = value; } }
            public Double Discount { get { return discount; } set { discount = value; } }


        }
        List<Item> items;
        Double total;
                
        public void AddItem()
        {
            if (items == null)
            {
                items = new List<Item>();
            }
            
            Item i = new Item();

            Int32 option = 1;

            do
            {
                Console.WriteLine("Введите название:");
                i.Name = Console.ReadLine();
                Console.WriteLine("Введите категорию:");
                Console.WriteLine("1 - Мясо\n2 - Алкогольные напитки\n3 - Кондитерские изделия\n4 - Хлебобулочные\n5 - Крупы\n6 - Безалкогольные напитки\n7 - Яйца");
                i.Ctrgy = (Category)Int32.Parse(Console.ReadLine());
                Console.WriteLine("Количество:");
                i.Quantity = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Цена:");
                i.Price = Double.Parse(Console.ReadLine());
                Console.WriteLine("Скидка на товар:");
                i.Discount = Double.Parse(Console.ReadLine());

                items.Add(i);

                Console.WriteLine("Добавить товар? Да - 1 / Нет - 0");
                Int32.TryParse(Console.ReadLine(), out option);
            } while (option == 1);
            
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("\n\nНазвание\tКатегория\tКол-во\tСкидка\tВсего");
            Console.WriteLine("-------------------------------------------------------");
            foreach (var item in items)
            {
                total += item.Quantity * item.Price * (1.00 - item.Discount);
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t{3}\t{4}", 
                    item.Name,
                    item.Ctrgy, 
                    item.Quantity.ToString(), 
                    item.Discount.ToString(), 
                    (item.Quantity * item.Price * (1.00 - item.Discount)).ToString());
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Всего:\t\t\t" + total.ToString());           
            
        }

    }
    class Program
    {
        static void Main(string[] args)
        {            
            Cheque c = new Cheque();
            c.AddItem();
            c.Print();

        }
    }
}

