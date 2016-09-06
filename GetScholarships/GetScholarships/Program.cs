using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetScholarships
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите пол студенета(ки): М или Ж");
                string sex = (Console.ReadLine()).ToLower();

                Console.WriteLine("Введите группу:");
                string group = Console.ReadLine();

                Console.WriteLine("Введите средний балл:");
                double average = Convert.ToDouble(Console.ReadLine());

                switch (sex)
                {
                    case "m":
                    case "м":
                        Console.WriteLine("Введите пороговое значение для парней:");
                        double thresholdValue = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите количество выплачиваемых средств:");
                        double scholarship = Convert.ToDouble(Console.ReadLine());
                        CalculationOfScholarshipsForBoy calculationOfScholarships = new CalculationOfScholarshipsForBoy(sex, group, average, thresholdValue, scholarship);
                        calculationOfScholarships.GetScholarship();
                        Console.WriteLine("\nНажмите Enter для повтора действия");
                        break;
                    case "ж":
                        Console.WriteLine("Введите фиксированный коеффициент для девушек:");
                        double fixedCoefficientForGirls = Convert.ToDouble(Console.ReadLine());
                        CalculationOfScholarshipsForGirl calculationOfScholarshipsForGirl = new CalculationOfScholarshipsForGirl(sex, group, average, fixedCoefficientForGirls);
                        calculationOfScholarshipsForGirl.GetScholarship();
                        Console.WriteLine("\nНажмите Enter для повтора действия");
                        break;
                    default:
                        Console.WriteLine("Не верно введен пол. \nНажмите Enter для повтора действия");
                        break;
                }
                Console.ReadLine();
            }
        }

        abstract class Student
        {
            public string _sex;
            public string _group;
            public double _average;

            public Student(string sex, string group, double average)
            {
                _sex = sex;
                _group = group;
                _average = average;
            }
            abstract public void GetScholarship();
        }

        class CalculationOfScholarshipsForBoy : Student
        {
            public double _thresholdValue;
            public double _scholarship;

            public CalculationOfScholarshipsForBoy(string sex, string group, double average, double thresholdValue, double scholarship) : base(sex, group, average)
            {
                _thresholdValue = thresholdValue;
                _scholarship = scholarship;
            }

            public override void GetScholarship()
            {
                if (_average >= _thresholdValue)
                {
                    Console.WriteLine("Студент из группы {0} получает стипендию в размере {1}, поскольку его средний балл выше или равен {2}", _group, _scholarship, _thresholdValue);
                }
                else
                {
                    Console.WriteLine("Студент из группы {0} не получает стипендию, поскольку его средний балл ниже {1}", _group, _thresholdValue);
                }
            }
        }
        class CalculationOfScholarshipsForGirl : Student
        {
            public double _fixedCoefficientForGirls;

            public CalculationOfScholarshipsForGirl(string sex, string group, double average, double fixedCoefficientForGirls) : base(sex, group, average)
            {
                _fixedCoefficientForGirls = fixedCoefficientForGirls;
            }

            public override void GetScholarship()
            {
                double scholarship = _average * _fixedCoefficientForGirls;
                Console.WriteLine("Студентка из группы {0} получает стипендию {1}", _group, scholarship);
            }
        }
    }
}


