using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Продаж смартфонів. Визначити ієрархію телефонів. 
 * Відсортувати телефони по розміру дисплею. 
 * Знайти телефон, який відповідає вказаним параметрам. 
 * Підрахувати загальну кількість девайсів на складі. 
 * Реалізувати пошук телефону по діапазону цін.
*/
namespace Laba_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Phones phone1 = new Phones("1", "Lg","L300", 4.5, 900);  // №, Manufacture, Model, Display size, Price
            Phones phone2 = new Phones("2", "Samsung", "6h", 8.7, 6700);
            Phones phone3 = new Phones("3", "Nokia", "3025", 3.2, 500);
            Phones phone4 = new Phones("4", "Motorolla", "NewEra", 3.4, 1000000);
            Phones phone5 = new Phones("5", "Huawei", "P_34", 7.5, 4300);
            Phones phone6 = new Phones("6", "Apple", "X", 8.8, 100000);
            Phones phone7 = new Phones("7", "Meizu", "M6", 5.5, 2000);
            Phones phone8 = new Phones("8", "Xiaomi", "Redmi Note 5", 6.3, 2500);
            Phones phone9 = new Phones("9", "Sony", "Xperia 5800", 5.5, 8000);
            Phones phone10 = new Phones("10", "Google", "Pixel 2", 4.5, 12000);
            Stock stock = new Stock(phone1, phone2, phone3, phone4, phone5, phone6, phone7, phone8, phone9, phone10);
            //stock.ShowList();
            //Console.WriteLine(" ");
            stock.SortByDisplaySize();
            stock.ShowList();
            Console.WriteLine(" ");
            stock.PhoneSearch();
            Console.WriteLine(" ");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("Phones in stock: " + stock.CountPhone());
            Console.WriteLine(" ");
            stock.SearchByPrice();
            Console.ReadKey();
        }
    }
    class Phones
    {
        public string phone;
        public string model;
        public string manuf;
        public double displaySize;
        public int price;

        public Phones(string Phone, string Manuf, string Model, double DisplaySize, int Price)
        {
            this.phone = Phone;  //this - ссылается на текущий экземпляр класса
            this.model = Model;
            this.manuf = Manuf;
            this.displaySize = DisplaySize;
            this.price = Price;
        }
    }
    class Stock 
    {
        public List<Phones> ListOfPhones = new List<Phones>();
        public Stock(params Phones[] nodes)
        {
            foreach (var m in nodes)
            {
                AddOne(m);
            }
        }
        public void AddOne(Phones phone)
        {
            ListOfPhones.Add(phone);
        }
        public void ShowList()
        {
            string model = "MODEL", manuf = "MANUF", displaySize = "DISPLAY_SIZE", price = "PRICE";
            Console.WriteLine($"{manuf,22}{model,35}{displaySize,26}{price,28}");
            Console.WriteLine(" ");
            foreach (var n in ListOfPhones)
            {
                Console.WriteLine($"{n.manuf,22}   |   {n.model,27}   |   {n.displaySize,20}  |   {n.price,22}");
            }
        }
        public void SortByDisplaySize()
        {
            for (int i = 0; i < ListOfPhones.Count; i++)
            {
                for (int j = i + 1; j < ListOfPhones.Count; j++)
                {
                    if (ListOfPhones[i].displaySize < ListOfPhones[j].displaySize)
                    {
                        var temp = ListOfPhones[i];
                        ListOfPhones[i] = ListOfPhones[j];
                        ListOfPhones[j] = temp;
                    }
                }
            }
        }
        public void PhoneSearch()
        {
            Console.Write("Manufacture: ");
            string searchManuf = Console.ReadLine();
            Console.Write("Модель: ");
            string searchModel = Console.ReadLine();
            Console.Write("Display size: ");
            double searchDis = Convert.ToDouble(Console.ReadLine());
            foreach (var n in ListOfPhones)
            {
                if (n.model == searchModel && n.manuf == searchManuf && n.displaySize == searchDis)
                    Console.WriteLine("There is such a phone in stock: " + n.manuf +" "+ n.model);
               /* else
                {
                    Console.WriteLine("Такого телефона немає на складі. Будь ласка, оберіть інший телефон");
                }
                */
            }
        }
        public int CountPhone()
        {
            int count = ListOfPhones.Count;
            return count;
        }
        public void SearchByPrice()
        {
            Console.Write("Price from  ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Write("to ");
            int d = Convert.ToInt32(Console.ReadLine());
            foreach (var n in ListOfPhones)
            {
                if (n.price >= z && n.price <= d)
                    Console.WriteLine("Your phone is: " + n.manuf + " " + n.model);
               /* else
                {
                    Console.WriteLine("There is no phones with this price :( ");
                }
                */
            }
        }
    }
}