using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BackUp_
{
    class Program
    {
        const double AVG_WRITE_SPEED_USB_2 = 17.4;
        const double AVG_WRITE_SPEED_USB_3 = 48.2;
        const double DVD_READ_WRITE_SPEED_X16 = 21.12;

        const double FLASH_CAPACITY = 29.8;
        const double HDD_CAPACITY = 465;
        const double DVD5_CAPACITY = 4.37;
        const double DVD9_CAPACITY = 8.95;

        const int TOTAL_SIZE_OF_FILES = 565;
        const double ONE_FILE_SIZE = 0.76;
        static void Main(string[] args)
        {
            Console.WriteLine("Переносимый объем информации: " + TOTAL_SIZE_OF_FILES + " Гб\n" +
                "Размер одного файла: " + ONE_FILE_SIZE + " Гб\n");

            HDD hdd = new HDD("Transcend", "StoreJet", HDD_CAPACITY, AVG_WRITE_SPEED_USB_2);
            DVD dvd = new DVD("Mirex", "DVD5", DVD5_CAPACITY, DVD_READ_WRITE_SPEED_X16);
            Flash flash = new Flash("ADATA", "S102", FLASH_CAPACITY, AVG_WRITE_SPEED_USB_3);
            Storage[] storage = new Storage[] { hdd, dvd, flash };

            for (int i = 0; i < storage.Length; i++)
            {
                storage[i].Show();
                Console.WriteLine("\nНеобходимое количество носителей: " + storage[i].NeededStorageCount(TOTAL_SIZE_OF_FILES, ONE_FILE_SIZE));
                storage[i].CopyToStorageAndToPC(TOTAL_SIZE_OF_FILES);
            }
        }
    }
}
