using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp2
{
    [Serializable]
    internal class Train
    {
        public int TrainNumber { get; set; }
        public string DestinationStation { get; set; }
        public DateTime DepartureTime { get; set; }

        public Train(int trainNumber, string destinationStation, DateTime departureTime)
        {
            TrainNumber = trainNumber;
            DestinationStation = destinationStation;
            DepartureTime = departureTime;
        }

        public override string ToString()
        {
            return $"Поезд №{TrainNumber} отправляется в {DestinationStation} в {DepartureTime}";
        }
    }
}

