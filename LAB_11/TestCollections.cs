using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

public class TestCollections
{
    static LinkedList<LorryCar> collection1 = new LinkedList<LorryCar>(); //Первая коллекция
    static LinkedList<string> collection2 = new LinkedList<string>(); //Вторая коллекция
    static SortedDictionary<Car, LorryCar> collection3 = new SortedDictionary<Car, LorryCar>(); //Третья коллекция
    static SortedDictionary<string, LorryCar> collection4 = new SortedDictionary<string, LorryCar>(); //Четвёртая коллекция
    static Stopwatch watch = Stopwatch.StartNew(); //Часы для подсчёта времени

    LorryCar? first, middle, last, noExist;
    public TestCollections(int lenght)
    {
        LorryCar lorry;
        for (int i = 0; i < lenght; i++)
        {
            try
            {
                lorry = new LorryCar();
                lorry.RandomInit();
                collection1.AddLast(lorry);
                collection2.AddLast(lorry.ToString());
                collection3.Add(lorry.GetBase, lorry);
                collection4.Add(lorry.GetBase.ToString(), lorry);
                if (i == 0)
                {
                    first = (LorryCar)lorry.Clone();
                }
                else if (i == lenght / 2)
                {
                    middle = (LorryCar)lorry.Clone();
                }
                else if (i == lenght - 1)
                {
                    last = (LorryCar)lorry.Clone();
                }
            }
            catch
            {
                i--;
            };
            
        }
        lorry = new LorryCar();
        lorry.RandomInit();
        lorry.Brend += 0.ToString();
        noExist = (LorryCar)lorry.Clone();
    }

    public void SearchAll(int typeSearch, int count)
    {
        long sum; //Для записи суммы тиков

        List<LorryCar> lorriesLorryCar = new List<LorryCar>(); //Лист для записи грузовиков для поиска в коллекциях с номерами 1, 3, 4
        List<Car> lorriesCar = new List<Car>(); //Лист для записи машин для поиска в коллекции 3
        List<string> lorriesString = new List<string>(); //Лист для записи строк для поиска в коллекциях 2, 4

        List<long> times = new List<long>(); //Лист для записи времени для какждого элемента поиска
        List<bool> carIsFoundList = new List<bool>(); //Лист для записи флага: нашли элемент или нет
        bool carIsFound = false; //Сам флаг

        if (typeSearch == 1) //Поиск в LinkedList<LorryCar>
        {
            lorriesLorryCar.Add(first); //Добавляем в лист
            lorriesLorryCar.Add(middle);
            lorriesLorryCar.Add(last);
            lorriesLorryCar.Add(noExist);
            foreach (LorryCar lorry in lorriesLorryCar) //Перебираем элементы в листе
            {
                sum = 0; //Для какждого элемента своя сумма
                for (int i = 0; i < count; i++) //count раз повторяем замер времени
                {
                    watch.Restart(); //Включили счётчик
                    carIsFound = collection1.Contains(lorry); //Ищем элемент
                    watch.Stop(); //Выключили счётчик
                    sum += watch.ElapsedTicks; //Прибавили время к сумме
                }
                carIsFoundList.Add(carIsFound); //Записали: нашли элемент или нет
                times.Add(sum / count); //Записали среднее время
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Поиск в LinkedList<LorryCar>");
            Console.ResetColor();
        }
        //Далее всё аналогично и имеет место определённое повторение, но сократить код ещё больше не удалось
        else if (typeSearch == 2)
        {
            lorriesString.Add(first.ToString());
            lorriesString.Add(middle.ToString());
            lorriesString.Add(last.ToString());
            lorriesString.Add(noExist.ToString());
            foreach (string lorry in lorriesString)
            {
                sum = 0;
                for (int i = 0; i < count; i++)
                {
                    watch.Restart();
                    carIsFound = collection2.Contains(lorry);
                    watch.Stop();
                    sum += watch.ElapsedTicks;
                }
                carIsFoundList.Add(carIsFound);
                times.Add(sum / count);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Поиск в LinkedList<string>");
            Console.ResetColor();
        }

        else if (typeSearch == 3)
        {
            lorriesCar.Add(first.GetBase);
            lorriesCar.Add(middle.GetBase);
            lorriesCar.Add(last.GetBase);
            lorriesCar.Add(noExist.GetBase);
            foreach (Car lorry in lorriesCar)
            {
                sum = 0;
                for (int i = 0; i < count; i++)
                {
                    watch.Restart();
                    carIsFound = collection3.ContainsKey(lorry);
                    watch.Stop();
                    sum += watch.ElapsedTicks;
                }
                carIsFoundList.Add(carIsFound);
                times.Add(sum / count);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Поиск в SortedDictionary<Car, LorryCar> по ключу");
            Console.ResetColor();
        }

        else if (typeSearch == 4)
        {
            lorriesLorryCar.Add(first);
            lorriesLorryCar.Add(middle);
            lorriesLorryCar.Add(last);
            lorriesLorryCar.Add(noExist);
            foreach (LorryCar lorry in lorriesLorryCar)
            {
                sum = 0;
                for (int i = 0; i < count; i++)
                {
                    watch.Restart();
                    carIsFound = collection3.ContainsValue(lorry);
                    watch.Stop();
                    sum += watch.ElapsedTicks;
                }
                carIsFoundList.Add(carIsFound);
                times.Add(sum / count);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Поиск в SortedDictionary<Car, LorryCar> по значению");
            Console.ResetColor();
        }

        else if (typeSearch == 5)
        {
            lorriesString.Add(first.GetBase.ToString());
            lorriesString.Add(middle.GetBase.ToString());
            lorriesString.Add(last.GetBase.ToString());
            lorriesString.Add(noExist.GetBase.ToString());
            foreach (string lorry in lorriesString)
            {
                sum = 0;
                for (int i = 0; i < count; i++)
                {
                    watch.Restart();
                    carIsFound = collection4.ContainsKey(lorry);
                    watch.Stop();
                    sum += watch.ElapsedTicks;
                }
                carIsFoundList.Add(carIsFound);
                times.Add(sum / count);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Поиск в SortedDictionary<string, LorryCar> по ключу");
            Console.ResetColor();
        }

        else if (typeSearch == 6)
        {
            lorriesLorryCar.Add(first);
            lorriesLorryCar.Add(middle);
            lorriesLorryCar.Add(last);
            lorriesLorryCar.Add(noExist);
            foreach (LorryCar lorry in lorriesLorryCar)
            {
                sum = 0;
                for (int i = 0; i < count; i++)
                {
                    watch.Restart();
                    carIsFound = collection4.ContainsValue(lorry);
                    watch.Stop();
                    sum += watch.ElapsedTicks;
                }
                carIsFoundList.Add(carIsFound);
                times.Add(sum / count);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Поиск в SortedDictionary<string, LorryCar> по значению");
            Console.ResetColor();
        }


        for (int i = 0; i < 4; i++) //Перебираем индексы от 0 до 3. Эти индексы будут соответсовать элементам сразу в двух листах: в carIsFoundList, и в times.
        {
            if (i == 0)
            {
                Console.Write("Первый элемент: ");
            }
            else if (i == 1)
            {
                Console.Write("Средний элемент: ");
            }
            else if (i == 2)
            {
                Console.Write("Последний элемент: ");
            }
            else if (i == 3)
            {
                Console.Write("Несуществующий элемент: ");
            }

            if (carIsFoundList[i])
            {
                Console.WriteLine($"найден в среднем за {times[i]}");
            }
            else
            {
                Console.WriteLine($"не найден в среднем за {times[i]}");
            }
        }
    }

    public void SearchAllLaunch(int count) //Метод для того чтобы запустить все поиски
    {
        SearchAll(1, count);
        Console.WriteLine();
        SearchAll(2, count);
        Console.WriteLine();
        SearchAll(3, count);
        Console.WriteLine();
        SearchAll(4, count);
        Console.WriteLine();
        SearchAll(5, count);
        Console.WriteLine();
        SearchAll(6, count);
        Console.WriteLine();
    }
}