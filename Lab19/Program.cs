using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputers = new List<Computer>()
            {
                new Computer() { Code = 1, Brand = "Dell", ProcessorType = "Pentium", ProcessorFrequency = 1.6, RAMSize = 4, HardDiskSpace = 512, VideoCardSize = 10, Cost = 140000.00, AvailableNumber = 10 },
                new Computer() { Code = 2, Brand = "HP", ProcessorType = "AMD", ProcessorFrequency = 1.8, RAMSize = 6, HardDiskSpace = 1000, VideoCardSize = 6, Cost = 90000.00, AvailableNumber = 20 },
                new Computer() { Code = 3, Brand = "HP", ProcessorType = "Pentium", ProcessorFrequency = 2, RAMSize = 6, HardDiskSpace = 800, VideoCardSize = 4, Cost = 150000.00, AvailableNumber = 55 },
                new Computer() { Code = 4, Brand = "MSI", ProcessorType = "AMD", ProcessorFrequency = 1.2, RAMSize = 8, HardDiskSpace = 750, VideoCardSize = 4, Cost = 70000.00, AvailableNumber = 30 },
                new Computer() { Code = 5, Brand = "MSI", ProcessorType = "AMD", ProcessorFrequency = 1.6, RAMSize = 6, HardDiskSpace = 800, VideoCardSize = 10, Cost = 66000.00, AvailableNumber = 80 },
                new Computer() { Code = 6, Brand = "Apple", ProcessorType = "Apple", ProcessorFrequency = 2.5, RAMSize = 32, HardDiskSpace = 2000, VideoCardSize = 20, Cost = 500000.00, AvailableNumber = 1 },
                new Computer() { Code = 7, Brand = "MSI", ProcessorType = "AMD", ProcessorFrequency = 3.6, RAMSize = 6, HardDiskSpace = 960, VideoCardSize = 5, Cost = 80000.00, AvailableNumber = 99 },
                new Computer() { Code = 8, Brand = "Lonovo", ProcessorType = "AMD", ProcessorFrequency = 1.6, RAMSize = 10, HardDiskSpace = 950, VideoCardSize = 5, Cost = 99000.00, AvailableNumber = 5 }
            };


            //все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            Console.WriteLine("Введите название процессора");
            string userProcessorType = Console.ReadLine();
            IEnumerable<Computer> processorType = listComputers
                .Where(c => c.ProcessorType == userProcessorType).ToList();

            foreach (Computer c in processorType)
                Console.WriteLine($"{c.Code} {c.ProcessorType} {c.ProcessorFrequency} {c.RAMSize} {c.HardDiskSpace} {c.VideoCardSize} {c.Cost} {c.AvailableNumber}");


            //все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
            Console.WriteLine("\n\n Введите минимальный требуемый объем ОЗУ");
            double userRAMSize = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Список подходящих компьютеров:");
            IEnumerable<Computer> ramSize = listComputers
                .Where(c => c.RAMSize >= userRAMSize).ToList();

            foreach (Computer c in ramSize)
                Console.WriteLine($"{c.Code} {c.ProcessorType} {c.ProcessorFrequency} {c.RAMSize} {c.HardDiskSpace} {c.VideoCardSize} {c.Cost} {c.AvailableNumber}");


            //вывести весь список, отсортированный по увеличению стоимости;
            IEnumerable<Computer> sortCost = listComputers
                .OrderBy(c => c.Cost)
                .ToList();
            Console.WriteLine($"\n\nСписок компьтером отсортированный по увеличению стоимости:");
            foreach (Computer c in sortCost)
                Console.WriteLine($"{c.Code} {c.ProcessorType} {c.ProcessorFrequency} {c.RAMSize} {c.HardDiskSpace} {c.VideoCardSize} {c.Cost} {c.AvailableNumber}");


            //вывести весь список, сгруппированный по типу процессора;
            IEnumerable<IGrouping<string, int>> query =listComputers
                .GroupBy(c => c.ProcessorType, c => c.Code);

            foreach (IGrouping<string, int> groupComputers in query)
            {
                Console.WriteLine("\n\nКод комьютера(ов) с процессором {0}:", groupComputers.Key);
                foreach (int code in groupComputers)
                    Console.WriteLine("     {0}", code);
            }

            //найти самый дорогой и самый бюджетный компьютер;
            double maxCost = listComputers.Max(c => c.Cost);
            var maxCostComputer = listComputers.Where(c => c.Cost == maxCost).ToList();
            foreach (var c in maxCostComputer)
                Console.WriteLine($"\n\nСамый дорогой компьютер: {c.Code} {c.ProcessorType} {c.ProcessorFrequency} {c.RAMSize} {c.HardDiskSpace} {c.VideoCardSize} {c.Cost} {c.AvailableNumber}");

            double minCost = listComputers.Min(c => c.Cost);
            var minCostComputer = listComputers.Where(c => c.Cost == minCost).ToList();
            foreach (var c in minCostComputer)
                Console.WriteLine($"\n\nСамый бюджетный компьтер: {c.Code} {c.ProcessorType} {c.ProcessorFrequency} {c.RAMSize} {c.HardDiskSpace} {c.VideoCardSize} {c.Cost} {c.AvailableNumber}");

            //есть ли хотя бы один компьютер в количестве не менее 30 штук?
            var availableNumber = listComputers.Any(c => c.AvailableNumber >= 30);
            if (availableNumber == true)
            {
                Console.WriteLine("\n\nХотя бы один компьютер есть в количестве не менее 30 штук");
            }
            else
            {
                Console.WriteLine("\n\nНи одного компьютера нет в количестве не менее 30 штук");
            }
            Console.ReadKey();
        }

    }
    class Computer
    {
        public int Code { get; set; }
        public string Brand { get; set; }
        public string ProcessorType { get; set; }
        public double ProcessorFrequency { get; set; }
        public double RAMSize { get; set; }
        public double HardDiskSpace { get; set; }
        public double VideoCardSize { get; set; }
        public double Cost { get; set; }
        public int AvailableNumber { get; set; }
    }
}
