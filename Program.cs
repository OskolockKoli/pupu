using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получение данных из БД
            List<Pallet> pallets = GetDataFromDatabase();
            // Группировка паллет по сроку годности и сортировка
            var groupedPallets = pallets.GroupBy(p => p.GetExpirationDate())
                                        .OrderBy(g => g.Key);
            // Вывод результатов
            foreach (var group in groupedPallets)
            {
                Console.WriteLine($"Паллеты с сроком годности {group.Key}:");
                var sortedPallets = group.OrderBy(p => p.GetTotalWeight());
                foreach (var pallet in sortedPallets)
                {
                    Console.WriteLine($"ID: {pallet.ID}, Вес: {pallet.GetTotalWeight()} кг");
                }
                Console.WriteLine();
            }
            // Выбор 3 паллет с наибольшим сроком годности, сортировка по объему
            var top3Pallets = pallets.OrderByDescending(p => p.GetExpirationDate())
                                      .Take(3)
                                      .OrderBy(p => p.GetTotalVolume());
            Console.WriteLine("3 паллетs с наибольшим сроком годности:");
            foreach (var pallet in top3Pallets)
            {
                Console.WriteLine($"ID: {pallet.ID}, Объем: {pallet.GetTotalVolume()} куб. м");
            }
        }
        static List<Pallet> GetDataFromDatabase()
        {
            List<Pallet> pallets = new List<Pallet>();
            string connectionString = "Server=localhost;Database=bd_pupu;Uid=root;Pwd=12345;";
            string query = "SELECT * FROM Pallets";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("ID");
                        double width = reader.GetDouble("Width");
                        double height = reader.GetDouble("Height");
                        double depth = reader.GetDouble("Depth");
                        double weight = reader.GetDouble("Weight");
                        List<Box> boxes = GetBoxesForPallet(id); // Метод для получения коробок для паллеты из БД
                        Pallet pallet = new Pallet(id, width, height, depth, weight, boxes);
                        pallets.Add(pallet);
                    }
                }
            }
            return pallets;
        }
        static List<Box> GetBoxesForPallet(int palletId)
        {
            List<Box> boxes = new List<Box>();
            // Запрос для получения коробок из БД по ID паллеты
            string connectionString = "Server=localhost;Database=bd_pupu;Uid=root;Pwd=12345;";
            string query = $"SELECT * FROM Boxes WHERE PalletID = {palletId}";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int boxId = reader.GetInt32("ID");
                        double width = reader.GetDouble("Width");
                        double height = reader.GetDouble("Height");
                        double depth = reader.GetDouble("Depth");
                        double weight = reader.GetDouble("Weight");
                        DateTime productionDate = reader.GetDateTime("ProductionDate");
                        Box box = new Box(boxId, width, height, depth, weight, productionDate);
                        boxes.Add(box);
                    }
                }
            }
            return boxes;
        }
    }

    public class Pallet
    {
        public int ID { get; }
        public double Width { get; }
        public double Height { get; }
        public double Depth { get; }
        public double Weight { get; }
        public List<Box> Boxes { get; }

        public Pallet(int id, double width, double height, double depth, double weight, List<Box> boxes)
        {
            ID = id;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            Boxes = boxes.Where(b => b.Width <= width && b.Depth <= depth).ToList(); // Фильтрация коробок по размерам паллеты
        }

        public DateTime GetExpirationDate()
        {
            return Boxes.Any() ? Boxes.Min(b => b.ExpirationDate) : DateTime.MaxValue;
        }

        public double GetTotalWeight()
        {
            return Boxes.Sum(b => b.Weight) + 30; // Вес паллеты = сумма веса коробок + 30 кг
        }

        public double GetTotalVolume()
        {
            return Boxes.Sum(b => b.GetVolume()) + (Width * Height * Depth); // Объем паллеты = сумма объема коробок + объем паллеты
        }
    }

    public class Box
    {
        public int ID { get; }
        public double Width { get; }
        public double Height { get; }
        public double Depth { get; }
        public double Weight { get; }
        public DateTime ProductionDate { get; }
        public DateTime ExpirationDate { get; }

        public Box(int id, double width, double height, double depth, double weight, DateTime productionDate)
        {
            ID = id;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            ProductionDate = productionDate;
            ExpirationDate = productionDate.AddDays(100); // Срок годности = дата производства + 100 дней
        }

        public double GetVolume()
        {
            return Width * Height * Depth;
        }
    }
}
