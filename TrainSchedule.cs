using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [Serializable]
    internal class TrainSchedule
    {
        private List<Train> trains = new List<Train>();

        private const string FilePath = "train_data.bin";

        public void AddTrainAtBeginning(Train train)
        {
            trains.Insert(0, train);
        }

        public void AddTrainAtEnd(Train train)
        {
            trains.Add(train);
        }

        public void AddTrainBefore(int trainNumber, Train train)
        {
            int index = trains.FindIndex(t => t.TrainNumber == trainNumber);
            if (index >= 0)
                trains.Insert(index, train);
            else
                Console.WriteLine("Поезд с таким номером не найден.");
        }

        public void AddTrainAfter(int trainNumber, Train train)
        {
            int index = trains.FindIndex(t => t.TrainNumber == trainNumber);
            if (index >= 0)
                trains.Insert(index + 1, train);
            else
                Console.WriteLine("Поезд с таким номером не найден.");
        }

        public void RemoveTrain(int trainNumber)
        {
            Train trainToRemove = trains.Find(train => train.TrainNumber == trainNumber);
            if (trainToRemove != null)
                trains.Remove(trainToRemove);
            else
                Console.WriteLine("Поезд с таким номером не найден.");
        }

        public void PrintTrainSchedule()
        {
            Console.WriteLine("Информация о поездах дальнего следования:");
            foreach (var train in trains)
            {
                Console.WriteLine(train);
            }
        }

        public void Save()
        {
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, trains);
                }
                Console.WriteLine("Данные успешно сохранены в бинарный файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        public void Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    using (FileStream fs = new FileStream(FilePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        trains = (List<Train>)formatter.Deserialize(fs);
                    }
                    Console.WriteLine("Данные успешно загружены из бинарного файла.");
                }
                else
                {
                    Console.WriteLine("Бинарный файл не найден. Начните с пустого списка.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
    }
}
