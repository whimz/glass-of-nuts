//------------------------------------------------------------------------------------------------
//добавить в пример с магазином возможность хранения не только ноутбуков, но также ещё и планшетов, 
//мобильных телефонов, зарядок и чехлов. сделать базовый класс для всех устройств, который обладает 
//свойствами Цена, Производитель, Категория, ГодВыпуска, Гарантия и Модель.+++
//
//реализовать возможности:
//- поиска по цене в указанном диапазоне(методом),+++
//- поиска по названию модели(с применением индексатора и регулярных выражений),+++
//- поиска по году выпуска(с применением индексатора),+++
//- поиска по типу устройства(например, ищем все ноутбуки).+++
//
//в результатах поиска должно быть не только первое найденное устройство, 
//а все устройства, подходящие под выбранный критерий.+++
//------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06_2
{
    public enum Category { None, Laptop, Tablet, Smartphone, MobilePhone, Charger, Cover }

    public enum TradeMarks { Asus, Lenovo, Apple, Philips, Nokia, HTC, Samsung }

    class Item
    {
        public Double price;
        public String vendor;
        public Category category;
        public DateTime issueDate;
        public Int32 warranty;//в месяцах
        public String model;

        public Item(Double price, String vendor, DateTime issueDate, Int32 warranty, String model)
        {
            this.price = price;
            this.vendor = vendor;
            this.issueDate = issueDate;
            this.warranty = warranty;
            this.model = model;
            this.category = Category.None;
        }

        public Double Price
        {
            get;
            set;
        }

        public String Vendor
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;
        }

        public UInt32 YearOfIssue
        {
            get;
            set;
        }

        public UInt32 Warranty
        {
            get;
            set;
        }

        public String Model
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "Vendor:\t\t" + vendor +
                "\nCategory:\t" + category.ToString() +
                "\nYear of issue:\t" + issueDate.ToShortDateString() +
                "\nWarranty:\t" + warranty.ToString() + " months" +
                "\nModel:\t\t" + model +
                "\nPrice:\t\t" + price.ToString() + " UAH" +
                "\n----------------------------------------\n"; ;
        }
    }

    class Laptops : Item
    {       
        public Laptops(Double price, String vendor, DateTime issueDate, Int32 warranty, String model) : 
            base (price, vendor, issueDate, warranty, model)
        {
            category = Category.Laptop;            
        }
                
    }
    
    class Tablets : Item
    {
        public Tablets(Double price, String vendor, DateTime issueDate, Int32 warranty, String model) :
            base(price, vendor, issueDate, warranty, model)
        {
            category = Category.Tablet;
        }
    }

    class Phones : Item
    {
        public Phones(Double price, String vendor, DateTime issueDate, Int32 warranty, String model) :
            base(price, vendor, issueDate, warranty, model)
        {
            category = Category.None;
        }
    }

    class Smartphones : Phones
    {
        public Smartphones(Double price, String vendor, DateTime issueDate, Int32 warranty, String model) :
            base(price, vendor, issueDate, warranty, model)
        {
            category = Category.Smartphone;
        }
    }

    class MobilePhones : Phones
    {
        public MobilePhones(Double price, String vendor, DateTime issueDate, Int32 warranty, String model) :
            base(price, vendor, issueDate, warranty, model)
        {
            category = Category.MobilePhone;
        }
    }

    class Charges : Item
    {
        public Charges(Double price, String vendor, DateTime issueDate, Int32 warranty, String model) :
            base(price, vendor, issueDate, warranty, model)
        {
            category = Category.Charger;
        }
    }

    class Covers : Item
    {
        public Covers(Double price, String vendor, DateTime issueDate, Int32 warranty, String model) :
            base(price, vendor, issueDate, warranty, model)
        {
            category = Category.Cover;
        }
    }


    //-------------------------------------------------------------------------------


    class Store
    {
        public Item[] items;
        private static readonly Int32 incSize = 10;
        public Store()
        {
            items = new Item[incSize];
        }
                
        public Int32 Length
        {
            get
            {
                return items.Length;
            }
        }

        public void IncSize()
        {
            Array.Resize(ref items, items.Length + incSize);
        }

        public Item this[Int32 index]
        {
            get
            {
                if (index < 0 || index >= items.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return items[index];
                }
            }
            set
            {
                if (index < 0 || index >= items.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    items[index] = value;
                }
            }
        }

        public IEnumerable<Item> this[String mNameSample]
        {
            get
            {
                if (mNameSample.Length == 0)
                {
                    throw new ArgumentNullException();
                }
                return FindByModel(mNameSample);    
            }
        }

        public IEnumerable<Item> this[DateTime issueDate]
        {
            get {return FindByYearOfIssue(issueDate);}
        }
        
        public IEnumerable<Item> FindByYearOfIssue(DateTime issueDate)
        {
            foreach (var item in items)
            {
                if (item != null && item.issueDate.Year == issueDate.Year)
                {
                    yield return item;
                }
            }
        }

        public void ViewItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
                
                if (item == null)
                    break;                
            }
        }

        public IEnumerable<Item> FindByModel(String mNameSample)
        {
            Regex regex = new Regex(mNameSample, RegexOptions.IgnoreCase);

            foreach (var item in items)
            {
                if (item != null && regex.IsMatch(item.model))
                {
                    yield return item;
                }
            }
        }

        public void FindByPrice(Double minPrice, Double maxPrice)
        {
            foreach (var item in items)
            {
                if ((item != null) && (item.price >= minPrice && item.price <= maxPrice))
                {
                    Console.WriteLine(item);                    
                }
            }                            
        }

        public void FindByType(String type)
        {
            foreach (var item in items)
            {
                if (item != null && item.GetType().IsAssignableFrom(Type.GetType(type)))
                {
                    Console.WriteLine(item);                    
                }
            }
        }
                
    }
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();

            Random rnd = new Random();

            for (int i = 1; i < 50; i++)
            {
                if (i <= store.Length)
                {
                    store.IncSize();
                }
                if ((i % 2) == 0)
                    store[i - 1] = new Laptops(rnd.Next(1000, 10000),
                            ((TradeMarks)rnd.Next(0, 5)).ToString(), new DateTime(rnd.Next(2010, 2016), 1, 1), rnd.Next(6, 36),
                            ("Model" + i.ToString()));

                else if ((i % 3) == 0)
                    store[i - 1] = new Tablets(rnd.Next(1000, 10000),
                            ((TradeMarks)rnd.Next(0, 5)).ToString(), new DateTime(rnd.Next(2010, 2016), 1, 1), rnd.Next(6, 36),
                            ("Model" + i.ToString()));

                else if ((i % 5) == 0)
                    store[i - 1] = new Smartphones(rnd.Next(1000, 10000),
                            ((TradeMarks)rnd.Next(0, 5)).ToString(), new DateTime(rnd.Next(2010, 2016), 1, 1), rnd.Next(6, 36),
                            ("Model" + i.ToString()));

                else if ((i % 7) == 0)
                    store[i - 1] = new MobilePhones(rnd.Next(1000, 10000),
                            ((TradeMarks)rnd.Next(0, 5)).ToString(), new DateTime(rnd.Next(2010, 2016), 1, 1), rnd.Next(6, 36),
                            ("Model" + i.ToString()));

                else if ((i % 6) == 0)
                    store[i - 1] = new Charges(rnd.Next(1000, 10000),
                            ((TradeMarks)rnd.Next(0, 5)).ToString(), new DateTime(rnd.Next(2010, 2016), 1, 1), rnd.Next(6, 36),
                            ("Model" + i.ToString()));

                else
                    store[i - 1] = new Covers(rnd.Next(1000, 10000),
                            ((TradeMarks)rnd.Next(0, 5)).ToString(), new DateTime(rnd.Next(2010, 2016), 1, 1), rnd.Next(6, 36),
                            ("Model" + i.ToString()));
            }
            
            Int32 option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("\t\tВсе товары..................(1)");
                Console.WriteLine("\t\tПоиск по цене...............(2)");
                Console.WriteLine("\t\tПоиск по модели.............(3)");
                Console.WriteLine("\t\tПоиск по году выпуска.......(4)");
                Console.WriteLine("\t\tПоиск по типу устройства....(5)");

                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        store.ViewItems();
                        break;
                    case 2:
                        Console.WriteLine("Введите начальную цену:");
                        Double minPrice = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите конечную цену:");
                        Double maxPrice = Double.Parse(Console.ReadLine());

                        if ((minPrice >= 0) && (maxPrice >= minPrice))
                        {
                            store.FindByPrice(minPrice, maxPrice);
                        }
                        else
                        {
                            Console.WriteLine("Некорректные данные");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Введите модель:");
                        String mNameSample = Console.ReadLine();

                        foreach (var item in store[mNameSample])
                        {
                            Console.WriteLine(item);
                            Console.WriteLine("---------------------------------------");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Введите дату выпуска (ГГГГ-ММ-ДД):");
                        DateTime issueDate = DateTime.Parse(Console.ReadLine());

                        foreach (var item in store[issueDate])
                        {
                            Console.WriteLine(item);
                            Console.WriteLine("---------------------------------------");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Выберите категорию:");
                        Console.WriteLine("\t\tНоутбки...............(1)");
                        Console.WriteLine("\t\tПланшеты..............(2)");
                        Console.WriteLine("\t\tСмартфоны.............(3)");
                        Console.WriteLine("\t\tМобильные телефоны....(4)");
                        Console.WriteLine("\t\tЗарядные устройства...(5)");
                        Console.WriteLine("\t\tЧехлы.................(6)");

                        option = Int32.Parse(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                store.FindByType("_06_2.Laptops");
                                break;
                            case 2:
                                store.FindByType("_06_2.Tablets");
                                break;
                            case 3:
                                store.FindByType("_06_2.Smartphones");
                                break;
                            case 4:
                                store.FindByType("_06_2.MobilePhones");
                                break;
                            case 5:
                                store.FindByType("_06_2.Charges");
                                break;
                            case 6:
                                store.FindByType("_06_2.Covers");
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Продолжить работу? 1 - (да)");
                option = Int32.Parse(Console.ReadLine());
            } while (option == 1);
        }       
    }
}
