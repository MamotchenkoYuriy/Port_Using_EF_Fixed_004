﻿using System;
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
    public class ShipView : BaseView
    {
        public ShipView()
        {
            
        }

        public override void UpdateMenu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Ship entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = DAO.GetInstance().Repository<Ship>().Find(id);
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
                    var list = DAOManager.GetInstance().Manager<Ship>().FindAll();
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
                Console.WriteLine("Введите номер");
                entity.Number = Console.ReadLine();
                Console.WriteLine("Введите номер порта");
                entity.PortId = ReadIntValueFromConsole();
                Console.WriteLine("Введите номер капитана");
                entity.CaptainId = ReadIntValueFromConsole();
                Console.WriteLine("Введите грузоподемность");
                entity.Capacity = ReadIntValueFromConsole();
                Console.WriteLine("Введите максимальную дистанцию");
                entity.MaxDistance = ReadIntValueFromConsole();
                Console.WriteLine("Введите количество человек в команде");
                entity.TeamCount = ReadIntValueFromConsole();
                try
                {
                    DAOManager.GetInstance().Manager<Ship>().SaveChanges();
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
