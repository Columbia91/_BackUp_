using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BackUp_
{
    class Program
    {
        const double AVG_WRITE_SPEED_USB_2 = 24.2;
        const double AVG_WRITE_SPEED_USB_3 = 60.4;
        const double DVD_READ_WRITE_SPEED_X16 = 21.12;

        const double FLASH_CAPACITY = 29.8;
        const double HDD_CAPACITY = 465;
        const double DVD5_CAPACITY = 4.37;

        const int TOTAL_SIZE_OF_FILES = 565;
        const double ONE_FILE_SIZE = 0.76;

        const int MEGABYTE_IN_GB = 1024;
        const int SECOND_IN_HOUR = 3600;
        const int SECOND_IN_MIN = 60;

        static void Main(string[] args)
        {
            Console.WriteLine("Переносимый объем информации: " + TOTAL_SIZE_OF_FILES + " Гб\n" +
                "Размер одного файла: " + ONE_FILE_SIZE + " Гб\n");

            HDD hdd = new HDD("Transcend", "StoreJet", HDD_CAPACITY, AVG_WRITE_SPEED_USB_2);
            DVD dvd = new DVD("Mirex", "DVD5", DVD5_CAPACITY, DVD_READ_WRITE_SPEED_X16);
            Flash flash = new Flash("ADATA", "S102", FLASH_CAPACITY, AVG_WRITE_SPEED_USB_3);
            Storage[] storage = new Storage[] { hdd, dvd, flash };

            double totalMemory;

            for (int i = 0; i < storage.Length; i++)
            {
                storage[i].Show();

                Console.WriteLine("\nНеобходимое количество носителей: " + NeededStorageCount(storage[i]));
                totalMemory = storage[i].Capacity * NeededStorageCount(storage[i]);

                Console.WriteLine("Общее количество памяти всех носителей: " + totalMemory + 
                    " ({0} x {1})", NeededStorageCount(storage[i]), storage[i].Capacity);

                Console.WriteLine("Общее неиспользуемое пространство в носителях: " + 
                    storage[i].FindFreeSpace(TOTAL_SIZE_OF_FILES, totalMemory) + " Гб ({0} - {1})", totalMemory, TOTAL_SIZE_OF_FILES);

                CopyToStorageAndToPC(storage[i]);

                Console.WriteLine("*************************************");
            }
        }
        static int NeededStorageCount(Storage storage)
        {
            int totalFileCount = (int)(TOTAL_SIZE_OF_FILES / ONE_FILE_SIZE);           // общее кол-во файлов
            int fileCountInStorage = (int)(storage.Capacity / ONE_FILE_SIZE);         // кол-во вмещаемых файлов носителя
            int dataStorageCount = totalFileCount / fileCountInStorage;              // кол-во необходимых носителей

            if (dataStorageCount < totalFileCount / (double)fileCountInStorage) dataStorageCount++;
            return dataStorageCount;
        }
        static double TimeToWrite(Storage storage)
        {
            return TOTAL_SIZE_OF_FILES * MEGABYTE_IN_GB / storage.WriteSpeed;
        }
        static void CopyToStorageAndToPC(Storage storage)
        {
            Console.WriteLine("Общее требуемое время на перенос РАБ_ПК -> носитель -> ДОМ_ПК: " +
                Math.Round(TimeToWrite(storage) / SECOND_IN_HOUR, 2) + " часов (" + Math.Round(TimeToWrite(storage) / SECOND_IN_MIN, 2) +  " мин)\n");
        }
    }
}
