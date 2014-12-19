using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DataAccessLayer;
using DataAccessLayer.DAO;

namespace InteractiveConsole.Views
{
    public class TripView :BaseView
    {
        public TripView()
        {
            
        }

        public override void UpdateMenu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Trip entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = DAO.GetInstance().Repository<Trip>().Find(id);
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
                    var list = DAOManager.GetInstance().Manager<Trip>().FindAll();
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
                Console.WriteLine("Введите номер порта отправки");
                entity.PortFromId = ReadIntValueFromConsole();
                Console.WriteLine("Введите номер порта прибытия");
                entity.PortToId = ReadIntValueFromConsole();
                Console.WriteLine("Введите номер корабля");
                entity.ShipId = ReadIntValueFromConsole();
                Console.WriteLine("Введите дату отправки");
                entity.StartDate = ReadDateTimeFromConsole();
                Console.WriteLine("Введите дату прибытия");
                entity.EndDate = ReadDateTimeFromConsole();
                try
                {
                    DAOManager.GetInstance().Manager<Trip>().SaveChanges(); 
                    Console.WriteLine("Изменения внесены!!!");
                }
                catch (Exception err)
                {
                    Console.WriteLine("Ошибка при сохранении изменений");
                }
                Console.ReadKey();
            }
        }
    }
}
