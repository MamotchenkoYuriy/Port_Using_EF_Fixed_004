using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer;
using DataAccessLayer.DAO;

namespace InteractiveConsole.Views
{
    public class PortView : BaseView
    {

        public PortView()
        {
            
        }

        public override void UpdateMenu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Port entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = DAO.GetInstance().Repository<Port>().Find(id);
                    if (entity == null)
                    {
                        Console.Write("Сущьность с Id = " + id + " не найденна!!!");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (consoleCommand == 2)
                {
                    Console.WriteLine("Введите номер записи --> ");
                    var pos = ReadIntValueFromConsole();
                    var list = DAOManager.GetInstance().Manager<Port>().FindAll();
                    if (pos >= list.Count())
                    {
                        Console.WriteLine("Вы ввели не корректный номер!!!");
                        Console.ReadKey(); break;
                    }
                    entity = list.ToList()[pos];
                }
                else if (consoleCommand == 3) { break; }
                if (entity == null)
                {
                    break;
                }
                Console.WriteLine(entity.ToString());
                Console.WriteLine();
                Console.WriteLine("Введите название порта");
                entity.Name = Console.ReadLine();
                Console.WriteLine("Введите ID города");
                entity.CityId = ReadIntValueFromConsole();
                DAOManager.GetInstance().Manager<Port>().SaveChanges();
                Console.WriteLine("Изменения внесены!!!");
                Console.ReadKey();
            }
        }
    }
}
