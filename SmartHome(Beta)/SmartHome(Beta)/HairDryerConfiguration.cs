using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome_Beta_
{
    public class HairDryerConfiguration
    {
        public HairDryerConfiguration()
        {
            IDictionary<string, HairDryer> hdDictionary = new Dictionary<string, HairDryer>();
            hdDictionary.Add("HairDryer1", new HairDryer(false, HairDryer.Power.Cold));
            hdDictionary.Add("HairDryer2", new HairDryer(false, HairDryer.Power.Cold));

            while (true)
            {
                Console.Clear();
                foreach (var hd in hdDictionary)
                {
                    Console.WriteLine("Название: " + hd.Key + ", " + hd.Value.Info());
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");

                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "x" & commands.Length == 1)
                {
                    return;
                }
                if (commands.Length != 2)
                {
                    Help();
                    continue;
                }
                if (commands[0].ToLower() == "add" && !hdDictionary.ContainsKey(commands[1]))
                {
                    hdDictionary.Add(commands[1], new HairDryer(false, HairDryer.Power.Cold));
                    continue;
                }
                if (commands[0].ToLower() == "add" && hdDictionary.ContainsKey(commands[1]))
                {
                    Console.WriteLine("Устройство с таким именем уже существует");
                    Console.WriteLine("Нажмите ENTER для продолжения");
                    Console.ReadLine();
                    continue;
                }
                if (!hdDictionary.ContainsKey(commands[1]))
                {
                    Help();
                    continue;
                }
                switch (commands[0].ToLower())
                {
                    case "del":
                        hdDictionary.Remove(commands[1]);
                        break;
                    case "on":
                        hdDictionary[commands[1]].On();
                        break;
                    case "off":
                        hdDictionary[commands[1]].Off();
                        break;
                    case "Cold":
                       hdDictionary[commands[1]].SetColdWind();
                        break;
                    case "Hot":
                       hdDictionary[commands[1]].SetHotWind();
                        break;
                    case "VeryHot":
                       hdDictionary[commands[1]].SetVeryHotWind();
                        break;
                    default:
                        Help();
                        break;
                }
            }
        }

        private static void Help()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tadd nameHairDryer");
            Console.WriteLine("\tdel nameHairDryer");
            Console.WriteLine("\ton nameHairDryer");
            Console.WriteLine("\toff nameHairDryer");
            Console.WriteLine("\tPowercold nameHairDryer");
            Console.WriteLine("\tPowermin nameHairDryer");
            Console.WriteLine("\tPowermax nameHairDryer");
            Console.WriteLine("\texit");
            Console.WriteLine("\nНажмите ENTER для продолжения");
            Console.ReadLine();
        }
    }
   }


