using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BackUp_
{
    public abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public double Capacity { get; set; }
        public double WriteSpeed { get; set; }

        public Storage(string name, string model, double capacity, double writeSpeed)
        {
            Name = name;
            Model = model;
            Capacity = capacity;
            WriteSpeed = writeSpeed;
        }
        public void Show()
        {
            Console.WriteLine("Наименование носителя:\t" + Name +
                "\nМодель:\t\t\t" + Model +
                "\nЕмкость:\t\t" + Capacity + " Гб" +
                "\nСкорость записи\t\t" + WriteSpeed + " Мб/с");
        }
        public double TotalFreeSpace(int totalSize, double oneFileSize)
        {
            double freeSpace = 0;                                           // общее незанятое пространство на носителе
            int fileCountInStorage = (int)(Capacity / oneFileSize);
            for (int i = 0; i < NeededStorageCount(totalSize, oneFileSize); i++)
            {
                freeSpace += Capacity - oneFileSize * fileCountInStorage;
            }

            return freeSpace;
        }
        public int NeededStorageCount(int totalSize, double oneFileSize)
        {
            int totalFileCount = (int)(totalSize / oneFileSize);            // общее кол-во файлов
            int fileCountInStorage = (int)(Capacity / oneFileSize);         // кол-во вмещаемых файлов носителя

            int dataStorageCount = totalFileCount / fileCountInStorage;     // кол-во необходимых носителей

            if (dataStorageCount < (int)(totalSize / oneFileSize)) dataStorageCount++;
            return dataStorageCount;
        }
        public double TimeToWrite(int totalSize)
        {
            const int MEGABYTE_IN_GB = 1024, SECOND_IN_HOUR = 3600;
            return (totalSize * MEGABYTE_IN_GB) / WriteSpeed / SECOND_IN_HOUR;
        }
        public void CopyToStorageAndToPC(int totalSize)
        {
            Console.WriteLine("Требуемое время на перенос информации на носитель: " + Math.Round(TimeToWrite(totalSize), 2) + " часов");
            Console.WriteLine("Общее требуемое время на перенос с рабочего ПК на домашний: " + Math.Round(TimeToWrite(totalSize) * 2, 2) + " часов\n");
        }
        //public double TotalCapacity(int totalSize)
        //{
        //    return Capacity * NeededStorageCount(totalSize);
        //}
    }
}
