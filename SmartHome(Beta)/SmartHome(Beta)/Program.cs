using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_Beta_
{
    class Program
    {
        static void Main(string[] args)
        {
            HairDryer myHairDryer = new HairDryer(false, HairDryer.Power.Cold);
            Heating myHeating = new Heating(false, Heating.HeatParams.Hallwayheater);
            Fridge myFridge = new Fridge();
            LoudSpeakers myLoudspeakers = new LoudSpeakers(false, 15);
            TV myTV = new TV(false, 0);
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose device");
                Console.WriteLine("1 - Фен");
                Console.WriteLine("2 - Обогрев квартиры");
                Console.WriteLine("3 - Холодильник");
                Console.WriteLine("4 - Акустическая система");
                Console.WriteLine("5 - Телевизор");
                Console.WriteLine("\n6 - Конфигурация фена");
                Console.WriteLine("\nX to exit");

                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        ShowHairDryerMenu(myHairDryer);
                        break;
                    case '2':
                        ShowHeatingMenu(myHeating);
                        break;
                    case '3':
                        ShowFridgeMenu(myFridge);
                        break;
                    case '4':
                        ShowLoudspeakersMenu(myLoudspeakers);
                        break;
                    case '5':
                        ShowTVMenu(myTV);
                        break;
                    case '6':
                        HairDryerConfiguration myHairDryerConfiguration = new HairDryerConfiguration();
                        break;
                    case 'x':
                    case 'X':
                        return;
                }
            }
        }

        private static void ShowHairDryerMenu(HairDryer hairDryer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hair Dryer Menu:");
                Console.WriteLine(hairDryer.Info() + "\n");
                Console.WriteLine("Нажмите клавишу для выполнения действия:");
                Console.WriteLine("1 - Включить фен");
                Console.WriteLine("2 - Выключить фен");
                Console.WriteLine("3 - Поток холодного воздуха");
                Console.WriteLine("4 - Поток теплого воздуха");
                Console.WriteLine("5 - Поток горячего воздуха");
                Console.WriteLine("\nx - exit to main menu");

                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        hairDryer.On();
                        break;
                    case '2':
                        hairDryer.Off();
                        break;
                    case '3':
                        hairDryer.SetColdWind();
                        break;
                    case '4':
                        hairDryer.SetHotWind();
                        break;
                    case '5':
                        hairDryer.SetVeryHotWind();
                        break;
                    case 'x':
                    case 'X':
                        return;
                }
            }
        }

        private static void ShowHeatingMenu(Heating heating)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Heating Menu:");
                Console.WriteLine(heating.Info() + "\n");
                Console.WriteLine("Нажмите клавишу для выполнения действия:");
                Console.WriteLine("1 - Включить обогрев");
                Console.WriteLine("2 - Выключить обогрев");
                Console.WriteLine("3 - Обогрев кухни");
                Console.WriteLine("4 - Обогрев спальни");
                Console.WriteLine("5 - Обогрев коридора");
                Console.WriteLine("6 - Обогрев ванной комнаты");
                Console.WriteLine("7 - Обогрев гостинной");
                Console.WriteLine("8 - Обогрев всей квартиры");
                Console.WriteLine("\nx - exit to main menu");

                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        heating.On();
                        break;
                    case '2':
                        heating.Off();
                        break;
                    case '3':
                        heating.SetHeatInKitchen();
                        break;
                    case '4':
                        heating.SetHeatInBedroom();
                        break;
                    case '5':
                        heating.SetHeatInHallway();
                        break;
                    case '6':
                        heating.SetHeatInBathroom();
                        break;
                    case '7':
                        heating.SetHeatInLivingRoom();
                        break;
                    case '8':
                        heating.SetAllHeater();
                        break;
                    case 'x':
                    case 'X':
                        return;
                }
            }
        }

        private static void ShowFridgeMenu(Fridge fridge)
        {
            while (true)
            {
                using (FileStream fstream = File.OpenRead(@"C:\Пользователи\hta.txt"))
                {
                    // Преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // Считываем данные
                    fstream.Read(array, 0, array.Length);
                    // Декодируем байты в строку
                    string textFromFile = System.Text.Encoding.Default.GetString(array);
                    Console.Clear();
                    Console.WriteLine(textFromFile + "\n");
                    Console.WriteLine("Нажмите клавишу для выполнения действия:");
                    Console.WriteLine("1 - Включить");
                    Console.WriteLine("2 - Выключить");
                    Console.WriteLine("3 - Слабая заморозка");
                    Console.WriteLine("4 - Средняя заморозка");
                    Console.WriteLine("5 - Сильная заморозка");
                    Console.WriteLine("\nx - exit to main menu");
                }
                
                char key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '1':
                        fridge.On();
                        break;
                    case '2':
                       fridge.Off();
                        break;
                    case '3':
                        fridge.LowFridge();                        
                        break;
                    case '4':
                        fridge.MedFridge();                        
                        break;
                    case '5':
                        fridge.HighFridge();                        
                        break;
                    case 'x':
                        return;
                }
                string text = fridge.Info();
                // Запись в файл
                using (FileStream fstream = new FileStream(@"C:\Пользователи\hta.txt", FileMode.OpenOrCreate))
                {
                    // Преобразуем строку в байты
                    byte[] array = Encoding.Default.GetBytes(text);
                    // Запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                }
            }
        }

        private static void ShowLoudspeakersMenu(LoudSpeakers loudspeakers)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Loudspeakers Menu:");
                Console.WriteLine(loudspeakers.Info() + "\n");
                Console.WriteLine("Нажмите клавишу для выполнения действия:");
                Console.WriteLine("1 - Включить ");
                Console.WriteLine("2 - Выключить ");
                Console.WriteLine("+ - Громкость больше");
                Console.WriteLine("- - Громкость меньше");
                Console.WriteLine("\nx - exit to main menu");

                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        loudspeakers.On();
                        break;
                    case '2':
                        loudspeakers.Off();
                        break;
                    case '+':
                        loudspeakers.VolumeUp();
                        break;
                    case '-':
                        loudspeakers.VolumeDown();
                        break;
                    case 'x':
                    case 'X':
                        return;
                }
            }
        }
        
        private static void ShowTVMenu(TV tv)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("TV Menu:");
                Console.WriteLine(tv.GetInfo() + "\n");
                Console.WriteLine("Нажмите клавишу для выполнения действия:");
                Console.WriteLine("1 - Включить ");
                Console.WriteLine("2 - Выключить ");
                Console.WriteLine("3 - Следующий канал");
                Console.WriteLine("4 - Предыдущий канал");
                Console.WriteLine("\nx - exit to main menu");

                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        tv.SetTvStatus(true);
                        break;
                    case '2':
                        tv.SetTvStatus(false);
                        break;
                    case '3':
                        tv.NextChannel();
                        break;
                    case '4':
                        tv.PreviousChannel();
                        break;
                    case 'x':
                    case 'X':
                        return;
                }
            }
        }
    }
}
