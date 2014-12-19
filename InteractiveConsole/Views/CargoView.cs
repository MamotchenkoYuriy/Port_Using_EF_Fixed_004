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
    public class CargoView :BaseView
    {
        public CargoView()
        {
            
        }

        public override void UpdateMenu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Cargo entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = DAO.GetInstance().Repository<Cargo>().Find(id);
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
                    var list = DAOManager.GetInstance().Manager<Cargo>().FindAll();
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

                Console.WriteLine("Введите номер");
                entity.Number = ReadIntValueFromConsole();
                Console.WriteLine("Введите стоимость груза");
                entity.Price = ReadDoubleFromConsole();
                Console.WriteLine("Введите стоимость страховки");
                entity.InsurancePrice = ReadIntValueFromConsole();
                Console.WriteLine("Введите тип груза");
                entity.CargoTypeId = ReadIntValueFromConsole();
                try
                {
                    DAOManager.GetInstance().Manager<Cargo>().SaveChanges();
                    //DAO.GetInstance().Repository<Cargo>().SaveChanges();
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
