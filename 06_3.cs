//---------------------------------------------------------------------------------------
//Разработать приложение «Прайс-лист», которое формирует список носителей информации, 
//таких как, Flash-память, DVD - диск, съемный HDD.Каждый носитель информации является объектом соответствующего класса:
//- класс Flash - память;
//- класс DVD - диск;
//- класс съемный HDD.
//Все три класса являются производными от абстрактного класса «Носитель информации». 
//Базовый класс содержит следующие поля: наименование носителя, имя производителя, модель, количество, цена.
//Класс обладает всеми необходимыми свойствами для доступа к полям, а также виртуальными методами печати, 
//загрузки из файла и сохранения в файл.В производных классах переопределяются методы печати, загрузки и сохранения.
//Кроме того, каждый из производных классов дополняется следующими полями:
//- класс Flash-память: объем памяти, скорость USB;
//- класс съемный HDD: размер диска, скорость USB;
//- класс DVD - диск: скорость чтения и скорость записи.
//Работа с объектами соответствующих классов производится через ссылки на базовый класс, которые хранятся в списке.
//Приложение должно предоставлять следующие возможности:
//- добавление носителя информации в список;
//- удаление носителя информации из списка по заданному критерию;
//- печать списка;
//- изменение определённых параметров носителя информации;
//- поиск носителя информации по заданному критерию.
//---------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;


namespace _06_3
{
    abstract class Storage
    {
        protected String name;
        protected String vendor;
        protected String model;
        protected Int32 quantity;
        protected Double price;

        public Storage(String name, String vendor, String model, Int32 quantity, Double price)
        {
            this.name = name;
            this.vendor = vendor;
            this.model = model;
            this.quantity = quantity;
            this.price = price;
        }

        public String Name { get; set; }
        public String Vendor { get; set; }
        public String Model { get; set; }
        public Int32 Quantity { get; set; }
        public Double Price { get; set; }

        public virtual void Print() { }
        public virtual void LoadFromFile() { }
        public virtual void SaveToFile() { }

    }

    class Flash : Storage
    {
        private Double capacity;
        private Int32 speedUSB;

        public Flash(String name, String vendor, String model, Int32 quantity, Double price, Double capacity, Int32 speedUSB)
            : base(name, vendor, model, quantity, price)
        {
            this.capacity = capacity;
            this.speedUSB = speedUSB;
        }

        public Double Capacity { get; set; }
        public Int32 SpeedUSB { get; set; }

        public override void Print()
        {
            Console.WriteLine(
                "Наименование носителя:\t" + name +
                "\nПроизводитель:\t\t" + vendor +
                 "\nМодель:\t\t\t" + model +
                 "\nКоличество:\t\t" + quantity.ToString() + " ед." + 
                 "\nЦена:\t\t\t" + price.ToString() + " UAH" + 
                 "\nОбъем накопителя:\t" + capacity.ToString() + " GB" +
                 "\nСкорость USB:\t\t" + speedUSB.ToString() + " MBps\n");
        }

        public override void LoadFromFile()
        {
            base.LoadFromFile();
        }

        public override void SaveToFile()
        {
            base.SaveToFile();
        }

    }

    class DVD : Storage
    {
        private Int32 speedWrite;
        private Int32 speedRead;

        public DVD(String name, String vendor, String model, Int32 quantity, Double price, Int32 speedWrite, Int32 speedRead)
            : base(name, vendor, model, quantity, price)
        {
            this.speedWrite = speedWrite;
            this.speedRead = speedRead;
        }

        public Int32 SpeedWrite { get; set; }
        public Int32 SpeedRead { get; set; }

        public override void Print()
        {
            Console.WriteLine(
                "Наименование носителя:\t" + name +
                "\nПроизводитель:\t\t" + vendor +
                 "\nМодель:\t\t\t" + model +
                 "\nКоличество:\t\t" + quantity.ToString() + " ед." +
                 "\nЦена:\t\t\t" + price.ToString() + " UAH" +
                 "\nСкорость чтения:\t" + speedWrite.ToString() + " MBps" +
                 "\nСкорость чтения:\t" + speedRead.ToString() + " MBps\n");
        }

        public override void LoadFromFile()
        {
            base.LoadFromFile();
        }

        public override void SaveToFile()
        {
            base.SaveToFile();
        }

    }

    class RemHDD : Storage
    {
        private Double capacityHDD;
        private Int32 speedUSB;

        public RemHDD(String name, String vendor, String model, Int32 quantity, Double price, Double capacityHDD, Int32 speedUSB)
            : base(name, vendor, model, quantity, price)
        {
            this.capacityHDD = capacityHDD;
            this.speedUSB = speedUSB;
        }

        public Double CapacityHDD { get; set; }
        public Int32 SpeedUSB { get; set; }

        public override void Print()
        {
            Console.WriteLine(
                "Наименование носителя:\t" + name +
                "\nПроизводитель:\t\t" + vendor +
                 "\nМодель:\t\t\t" + model +
                 "\nКоличество:\t\t" + quantity.ToString() + " ед." +
                 "\nЦена:\t\t\t" + price.ToString() + " UAH" +
                 "\nОбъем накопителя:\t" + capacityHDD.ToString() + " GB" +
                 "\nСкорость USB:\t\t" + speedUSB.ToString() + " MBps\n");
        }

        public override void LoadFromFile()
        {
            base.LoadFromFile();
        }

        public override void SaveToFile()
        {
            base.SaveToFile();
        }
    }

    class PriceList
    {
        private List<Storage> priceList;

        public PriceList()
        {
            priceList = new List<Storage>();
        }

        private void AddItem(Storage st)
        {
            priceList.Add(st);
        }

        private void RemoveItem(Int32 index)
        {
            priceList.RemoveAt(index);
        }
        
        public void PrintList()
        {
            foreach (var item in priceList)
            {
                item.Print();
            }
        }
        public void UserMenu()
        {
            Int32 option = 1;
                        
            String vendor;
            String model;
            Int32 quantity;
            Double price;
            Double capacity;
            Int32 speedUSB;
            Int32 speedWrite;
            Int32 speedRead;
            Double capacityHDD;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("\tДобавить носитель:................(1)");
                Console.WriteLine("\tУдалить носитель:.................(2)");
                Console.WriteLine("\tПечать списка:....................(3)");
                Console.WriteLine("\tИзменить параметры носителя:......(4)");
                Console.WriteLine("\tПоиск:............................(5)");

                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\tДобавить:");
                        Console.WriteLine("\t\tFlashMemory:.....(1)");
                        Console.WriteLine("\t\tDVD:.............(2)");
                        Console.WriteLine("\t\tRemovable HDD:...(3)");

                        option = Int32.Parse(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Введите производителя");
                                vendor = Console.ReadLine();
                                Console.WriteLine("Введите модель");
                                model = Console.ReadLine();
                                Console.WriteLine("Введите количество");
                                quantity = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите цену");
                                price = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите объем накопителя");
                                capacity = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость USB");
                                speedUSB = Int32.Parse(Console.ReadLine());
                                AddItem(new Flash("FlashMemory", vendor, model, quantity, price, capacity, speedUSB));
                                break;
                            case 2:
                                Console.WriteLine("Введите производителя");
                                vendor = Console.ReadLine();
                                Console.WriteLine("Введите модель");
                                model = Console.ReadLine();
                                Console.WriteLine("Введите количество");
                                quantity = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите цену");
                                price = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость записи");
                                speedWrite = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость чтения");
                                speedRead = Int32.Parse(Console.ReadLine());
                                AddItem(new DVD("DVD", vendor, model, quantity, price, speedWrite, speedRead));
                                break;
                            case 3:
                                Console.WriteLine("Введите производителя");
                                vendor = Console.ReadLine();
                                Console.WriteLine("Введите модель");
                                model = Console.ReadLine();
                                Console.WriteLine("Введите количество");
                                quantity = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите цену");
                                price = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите объем накопителя");
                                capacityHDD = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость USB");
                                speedUSB = Int32.Parse(Console.ReadLine());
                                AddItem(new RemHDD("RemovableHDD", vendor, model, quantity, price, capacityHDD, speedUSB));
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        PrintList();
                        Console.WriteLine("Введите номер носителя для удаления из списка");
                        Int32 index = Int32.Parse(Console.ReadLine());
                        if (index - 1 >=0 && index - 1 < priceList.Capacity)
                        {
                            RemoveItem(index);
                        }
                        else if (priceList.Capacity == 0)
                        {
                            Console.WriteLine("Список пуст");
                        }
                        break;
                    case 3:
                        PrintList();
                        break;
                    case 4:
                        PrintList();
                        Console.WriteLine("Введите номер носителя для изменения");
                        index = Int32.Parse(Console.ReadLine());
                        if (index - 1 >= 0 && index - 1 < priceList.Capacity)
                        {
                            if (priceList[index] is Flash)
                            {
                                Console.WriteLine("Введите производителя");
                                vendor = Console.ReadLine();
                                Console.WriteLine("Введите модель");
                                model = Console.ReadLine();
                                Console.WriteLine("Введите количество");
                                quantity = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите цену");
                                price = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите объем накопителя");
                                capacity = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость USB");
                                speedUSB = Int32.Parse(Console.ReadLine());                                
                                priceList[index] = new Flash("FlashMemory", vendor, model, quantity, price, capacity, speedUSB);
                            }
                            else if (priceList[index] is DVD)
                            {
                                Console.WriteLine("Введите производителя");
                                vendor = Console.ReadLine();
                                Console.WriteLine("Введите модель");
                                model = Console.ReadLine();
                                Console.WriteLine("Введите количество");
                                quantity = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите цену");
                                price = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость записи");
                                speedWrite = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость чтения");
                                speedRead = Int32.Parse(Console.ReadLine());
                                priceList[index] = new DVD("DVD", vendor, model, quantity, price, speedWrite, speedRead);
                            }
                            else if (priceList[index] is RemHDD)
                            {
                                Console.WriteLine("Введите производителя");
                                vendor = Console.ReadLine();
                                Console.WriteLine("Введите модель");
                                model = Console.ReadLine();
                                Console.WriteLine("Введите количество");
                                quantity = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Введите цену");
                                price = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите объем накопителя");
                                capacityHDD = Double.Parse(Console.ReadLine());
                                Console.WriteLine("Введите cкорость USB");
                                speedUSB = Int32.Parse(Console.ReadLine());
                                priceList[index] = new RemHDD("RemovableHDD", vendor, model, quantity, price, capacityHDD, speedUSB);
                            }
                        }

                        break;
                    case 5:
                        Console.WriteLine("Введите производителя для поиска");
                        vendor = Console.ReadLine();

                        foreach (var item in priceList)
                        {
                            if (item.Vendor == vendor)
                            {
                                item.Print();
                            }
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
    class Program
    {
        static void Main(string[] args)
        {
            PriceList pl = new PriceList();
            pl.UserMenu();
            
        }
    }
}
