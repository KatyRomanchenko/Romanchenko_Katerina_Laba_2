using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Авіакомпанія.Визначити ієрархію літаків.
Створити авіакомпанію.
Порахувати загальну місткість і вантажопідйомність. 
Провести сортування літаків компанії по дальності польоту.
Знайти літак в компанії, 
що відповідає заданому діапазону параметрів 
споживання пального.*/

namespace Laba_2._2_var1
{
    class Program
    {
        static void Main(string[] args)
        {
            Aircraft aircraft1 = new Aircraft("1", "Lg", 300, 400, 10000,2);  // №, name, total capacity, carrying capacity, distance, fuel
            Aircraft aircraft2 = new Aircraft("2", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft3 = new Aircraft("3", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft4 = new Aircraft("4", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft5 = new Aircraft("5", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft6 = new Aircraft("6", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft7 = new Aircraft("7", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft8 = new Aircraft("8", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft9 = new Aircraft("9", "Lg", 300, 400, 10000, 2);
            Aircraft aircraft10 = new Aircraft("10", "Lg", 300, 400, 10000, 2);
            Stock stock = new Stock(aircraft1, aircraft1, aircraft1, aircraft1, aircraft1, aircraft1, aircraft1, aircraft1, aircraft1, aircraft1);
            //stock.ShowList();
            //Console.WriteLine(" ");
            stock.SortByDistance();
            stock.ShowList();
            Console.WriteLine(" ");
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine(" ");
            Console.WriteLine("Aircrafts in stock: " + stock.CountAircraft());
            Console.WriteLine(" ");
            stock.SearchByFuel();
            Console.ReadKey();
        }
    }
    class Aircraft
    {
        public string aircraft;
        public string name_of_plane;
        public int total_capacity;
        public int carrying_capacity;
        public int distance;
        public int fuel;

        public Aircraft(string Aircraft, string Name_of_plane, int Total_capacity, int Carrying_capacity, int Distanse, int Fuel)
        {
            this.aircraft = Aircraft; //this - ссылается на текущий экземпляр класса
            this.name_of_plane = Name_of_plane;
            this.total_capacity = Total_capacity;
            this.carrying_capacity = Carrying_capacity;
            this.distance = Distanse;
            this.fuel = Fuel;
        }
    }
    class Stock
    {
        public List<Aircraft> ListOfAircraft = new List<Aircraft>();
        public Stock(params Aircraft[] nodes)
        {
            foreach (var m in nodes)
            {
                AddOne(m);
            }
        }
        public void AddOne(Aircraft aircraft)
        {
            ListOfAircraft.Add(aircraft);
        }
        public void ShowList()
        {
            string name_of_plane = "NAME", total_capcity = "TOTAL CAPACITY", carrying_capacity = "CARRYING CAPACITY", distance = "DISTANCE", fuel = "FUEL";
            Console.WriteLine($"{name_of_plane,15}{total_capcity,30}{carrying_capacity,26}{distance,23}{fuel,20}");
            Console.WriteLine(" ");
            foreach (var n in ListOfAircraft)
            {
                Console.WriteLine($"{n.name_of_plane,10}       |       {n.total_capacity,10}       |       {n.carrying_capacity,10}       |       {n.distance,10}       |       {n.fuel,10}");
            }
        }
        public void SortByDistance()
        {
            for (int i = 0; i < ListOfAircraft.Count; i++)
            {
                for (int j = i + 1; j < ListOfAircraft.Count; j++)
                {
                    if (ListOfAircraft[i].distance < ListOfAircraft[j].distance)
                    {
                        var x = ListOfAircraft[i];
                        ListOfAircraft[i] = ListOfAircraft[j];
                        ListOfAircraft[j] = x;
                    }
                }
            }
        }
        public int CountAircraft()
        {
            int count = ListOfAircraft.Count;
            return count;
        }
        public void SearchByFuel()
        {
            Console.Write("Fuel from  ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Write("to ");
            int d = Convert.ToInt32(Console.ReadLine());
            foreach (var n in ListOfAircraft)
            {
                if (n.fuel >= z && n.fuel <= d)
                    Console.WriteLine("Your aircraft is: " + n.name_of_plane);
            }
        }
    }
}
