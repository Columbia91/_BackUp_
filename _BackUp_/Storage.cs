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

        #region Конструкторы
        public Storage(string name)
        {
            Name = name;
        }
        public Storage(string name, string model) : this(name)
        {
            Model = model;
        }
        public Storage(string name, string model, double capacity) : this(name, model)
        {
            Capacity = capacity;
        }
        public Storage(string name, string model, double capacity, double writeSpeed) : this(name, model, capacity)
        {
            WriteSpeed = writeSpeed;
        }
        #endregion

        #region Методы
        public void Show()
        {
            Console.WriteLine("Наименование носителя:\t" + Name +
                "\nМодель:\t\t\t" + Model +
                "\nЕмкость:\t\t" + Capacity + " Гб" +
                "\nСкорость записи\t\t" + WriteSpeed + " Мб/с");
        }
        public double FindFreeSpace(int totalSizeOfFiles, double totalMemory)
        {
            return totalMemory - totalSizeOfFiles;
        }
        #endregion
    }
}
