using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Core;
using DataAccessLayer;
using DataAccessLayer.DAO;


namespace InteractiveConsole.Views
{
    public abstract class BaseView
    {
        protected BaseView()
        {
            
        }

        public void AddMenu<T>(string path) where T : BaseEntity
        {
            Console.Clear();
            Console.WriteLine(path);
            var constractor = typeof(T).GetConstructors().FirstOrDefault(m => m.GetParameters().Length > 0);
            if (constractor == null) { return; }
            var constractorAttributes = constractor.GetParameters().ToList();
            var listParameters = new List<object> ();
            foreach (var attribut in constractorAttributes)
            {
                if (attribut.ParameterType == typeof(string))
                {
                    Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + " -->");
                    listParameters.Add(Console.ReadLine());
                }
                else if (attribut.ParameterType == typeof(Int32))
                {
                    Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + "-->");
                    listParameters.Add(ReadIntValueFromConsole());
                }
                else if (attribut.ParameterType == typeof(DateTime))
                {
                    Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + "-->");
                    listParameters.Add(ReadDateTimeFromConsole());
                }
                else if (attribut.ParameterType == typeof(double))
                {
                    Console.WriteLine("Введите значение атрибута " + attribut.Name.ToUpper() + "-->");
                    listParameters.Add(ReadDoubleFromConsole());
                }
            }

            var assembly = Assembly.GetAssembly(typeof(T));
            /*var o = assembly.CreateInstance(typeof(T).FullName, false,
                BindingFlags.ExactBinding,
                null, listParameters.ToArray(), null, null);*/
            var o = Activator.CreateInstance(typeof (T), listParameters.ToArray());
            var addItem = (T)o;
            try
            {
                DAOManager.GetInstance().Manager<T>().Add(addItem);
                //DAO.GetInstance().Repository<T>().Add(addItem);
                Console.WriteLine("Изменения внесены!!!");
                Console.ReadKey();
            }
            catch (Exception err)
            {
                Console.WriteLine("Возникла ошибка при добавлении записи ");
            }
        }

        public void DeleteMenu<T>(string path) where T :BaseEntity
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Console.WriteLine("Выбирите дейтвие: ");
                Console.WriteLine("1 - Удалить по ID: ");
                Console.WriteLine("2 - Удалить по номеру: ");
                Console.WriteLine("3 - Выход");
                var commandNumber = ReadIntValueFromConsole(1, 3);
                if (commandNumber == 1)
                {
                    Console.WriteLine("Введите ID: ");
                    var Id = ReadIntValueFromConsole();
                    var item = DAO.GetInstance().Repository<T>().Find(Id);
                    if (item != null)
                    {
                        DAOManager.GetInstance().Manager<T>().Remove(item);
                        //DAO.GetInstance().Repository<T>().Remove(item);
                        Console.WriteLine("Запись удаленна");
                    }
                    Console.WriteLine("Запись с ID = " + Id + "не найденна");
                }
                else if (commandNumber == 2)
                {
                    Console.WriteLine("Введите номер записи в списке");
                    var number = ReadIntValueFromConsole();
                    var list = DAO.GetInstance().Repository<T>().FindAll();
                    if (number <= list.Count() - 1)
                    {
                        DAOManager.GetInstance().Manager<T>().Remove(list.ToList()[number]);
                        //DAO.GetInstance().Repository<T>().Remove(list.ToList()[number]);
                        Console.WriteLine("Запись удаленна");
                    }
                    Console.WriteLine("Вы ввели число, которое выходит за диаппазон существующих записей");
                }
                else if (commandNumber == 3)
                {
                    break;
                }
            }
        }

        public virtual void UpdateMenu(string path)
        {

        }

        public void ShowAll<T>(string path) where T : BaseEntity
        {
            Console.Clear();
            Console.WriteLine(path);
            foreach (var item in DAOManager.GetInstance().Manager<T>().FindAll())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }


        public void EntityMenu<T>(string path) where T : BaseEntity
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Добавить запись");
                Console.WriteLine("2 - Просмотреть все записи");
                Console.WriteLine("3 - Удалить запись");
                Console.WriteLine("4 - Редактировать запись");
                Console.WriteLine("5 - Выход");
                var consoleCommand = ReadIntValueFromConsole(1, 4);
                if (consoleCommand == 1)
                {
                    AddMenu<T>(path + "->Добавление");
                }
                else if (consoleCommand == 2)
                {
                    ShowAll<T>(path + "->Все записи");
                }
                else if (consoleCommand == 3)
                {
                    DeleteMenu<T>(path + "->Удаление");
                }
                else if (consoleCommand == 4)
                {
                    UpdateMenu(path + "->Редактирование");
                }
                else if (consoleCommand == 5) break;
            }
        }

        protected int ReadIntValueFromConsole(int min, int max)
        {
            while (true)
            {
                var value = ReadIntValueFromConsole();
                if (Enumerable.Range(1, 10).Contains(value)) { return value; }
            }
        }

        protected int ReadIntValueFromConsole()
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

        protected DateTime ReadDateTimeFromConsole()
        {
            while (true)
            {
                var day = ReadIntValueFromConsole(1, 31);
                var mounth = ReadIntValueFromConsole(1, 12);
                var year = ReadIntValueFromConsole(1979, 2020);
                try
                {
                    var dateTime = new DateTime(year, mounth, day);
                    return dateTime;
                }
                catch (Exception errException)
                {
                    Console.WriteLine("Ошибка при вводе даты");
                }
            }
        }

        protected double ReadDoubleFromConsole()
        {
            while (true)
            {
                var text = Console.ReadLine();
                var rez = 0.0;
                if (Double.TryParse(text, out rez))
                {
                    return rez;
                }
                Console.WriteLine("Вы ввели не корректное значение");
            }
        }
    }
}
