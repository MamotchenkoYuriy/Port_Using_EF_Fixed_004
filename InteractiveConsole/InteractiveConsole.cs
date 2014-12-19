using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using InteractiveConsole.Views;

namespace InteractiveConsole
{
    public class InteractiveConsole
    {

        public void Menu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Работа с городами");
                Console.WriteLine("2 - Работа с портами");
                Console.WriteLine("3 - Работа с капитанами");
                Console.WriteLine("4 - Работа с кораблями");
                Console.WriteLine("5 - Работа с типами грузов");
                Console.WriteLine("6 - Работа с грузами");
                Console.WriteLine("7 - Работа с перевозками");
                Console.WriteLine("8 - Выход");
                var consoleCommand = ReadIntValueFromConsole(1, 3);
                if (consoleCommand == 1)
                {
                    ViewFactory.GetInstance().GetView<City>().EntityMenu<City>(path + " --> Города");
                }
                else if (consoleCommand == 2)
                {
                    ViewFactory.GetInstance().GetView<Port>().EntityMenu<Port>(path + " --> Порты");
                }
                else if (consoleCommand == 3)
                {
                    ViewFactory.GetInstance().GetView<Captain>().EntityMenu<Captain>(path + " --> Капитаны");
                }
                else if (consoleCommand == 4)
                {
                    ViewFactory.GetInstance().GetView<Ship>().EntityMenu<Ship>(path + " --> Корабли");
                }
                else if (consoleCommand == 5)
                {
                    ViewFactory.GetInstance().GetView<CargoType>().EntityMenu<CargoType>(path + " --> Типы грузов");
                }
                else if (consoleCommand == 6)
                {
                    ViewFactory.GetInstance().GetView<Cargo>().EntityMenu<Cargo>(path + " --> Грузы");
                }
                else if (consoleCommand == 7)
                {
                    ViewFactory.GetInstance().GetView<Trip>().EntityMenu<Trip>(path + " --> Первозки");
                }
                else if (consoleCommand == 8)
                {
                    return;
                }
            }
        }


        private int ReadIntValueFromConsole(int min, int max)
        {
            while (true)
            {
                var value = ReadIntValueFromConsole();
                if (Enumerable.Range(1, 10).Contains(value)) { return value; }
            }
        }

        private int ReadIntValueFromConsole()
        {
            var errMessage = string.Empty;
            while (true)
            {
                Console.WriteLine(errMessage);
                var strValue = Console.ReadLine();
                var result = 0;
                if (Int32.TryParse(strValue, out result))
                {
                    return result;
                }
                else { errMessage = "Вы ввели не корректное значение!!!"; }
            }
        }
    }
}
