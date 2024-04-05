using ClassLibrary1;
using System;
using System.Collections;
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
                collection3.Add(lorry.GetBase, lorry);
                collection4.Add(lorry.GetBase.ToString(), lorry);
                collection1.AddLast(lorry);
                collection2.AddLast(lorry.ToString());
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

    public struct Result
    {
        public long timeInLinkedListLorryCar;
        public long timeInLinkedListString;
        public long timeInSortedDictionaryCarLorryCarKey;
        public long timeInSortedDictionaryCarLorryCarValue;
        public long timeInSortedDictionaryStringLorryCarKey;
        public long timeInSortedDictionaryStringLorryCarValue;
        public int index1;
        public int index2;
        public int index3;
        public int index4;
        public int index5;
        public int index6;
    }

    public void Search(int count)
    {
        LorryCar[] lorries = new LorryCar[] { first, middle, last, noExist };
        bool isFound;
        Result[] results = new Result[4];

        for (int i = 0; i < 4; i++)
        {
            long sum1 = 0;
            long sum2 = 0;
            long sum3 = 0;
            long sum4 = 0;
            long sum5 = 0;
            long sum6 = 0;

            LorryCar itemToSearch;

            for (int j = 0; j < count; j++) 
            {
                itemToSearch = lorries[i];

                watch.Restart();
                isFound = collection1.Contains(itemToSearch);
                watch.Stop();
                sum1 += watch.ElapsedTicks;

                string itemToSearchString = itemToSearch.ToString();
                watch.Restart();
                isFound = collection2.Contains(itemToSearchString);
                watch.Stop();
                sum2 += watch.ElapsedTicks;

                Car itemToSearchCar = itemToSearch.GetBase;
                watch.Restart();
                isFound = collection3.ContainsKey(itemToSearchCar);
                watch.Stop();
                sum3 += watch.ElapsedTicks;

                watch.Restart();
                isFound = collection3.ContainsValue(itemToSearch);
                watch.Stop();
                sum4 += watch.ElapsedTicks;

                string itemToSearchCarString = itemToSearch.GetBase.ToString();
                watch.Restart();
                isFound = collection4.ContainsKey(itemToSearchCarString);
                watch.Stop();
                sum5 += watch.ElapsedTicks;

                watch.Restart();
                isFound = collection4.ContainsValue(itemToSearch);
                watch.Stop();
                sum6 += watch.ElapsedTicks;
            }
            itemToSearch = lorries[i];
            int index1 = -1;
            int counter = 0;
            foreach (LorryCar el in collection1)
            {
                if (el.Equals(itemToSearch))
                {
                    index1 = counter;
                }
                counter++;
            }

            int index2 = -1;
            counter = 0;
            foreach (string el in collection2)
            {
                if (el == itemToSearch.ToString())
                {
                    index2 = counter;
                }
                counter++;
            }

            int index3 = -1;
            counter = 0;
            foreach (Car el in collection3.Keys)
            {
                if (el.Equals(itemToSearch.GetBase))
                {
                    index3 = counter;
                }
                counter++;
            }

            int index4 = -1;
            counter = 0;
            foreach (LorryCar el in collection3.Values)
            {
                if (el.Equals(itemToSearch))
                {
                    index4 = counter;
                }
                counter++;
            }

            int index5 = -1;
            counter = 0;
            foreach (string el in collection4.Keys)
            {
                if (el == itemToSearch.GetBase.ToString())
                {
                    index5 = counter;
                }
                counter++;
            }

            int index6 = -1;
            counter = 0;
            foreach (LorryCar el in collection4.Values)
            {
                if (el.Equals(itemToSearch))
                {
                    index6 = counter;
                }
                counter++;
            }

            results[i].timeInLinkedListLorryCar = sum1;
            results[i].timeInLinkedListString = sum2;
            results[i].timeInSortedDictionaryCarLorryCarKey = sum3;
            results[i].timeInSortedDictionaryCarLorryCarValue = sum4;
            results[i].timeInSortedDictionaryStringLorryCarKey = sum5;
            results[i].timeInSortedDictionaryStringLorryCarValue = sum6;
            results[i].index1 = index1;
            results[i].index2 = index2;
            results[i].index3 = index3;
            results[i].index4 = index4;
            results[i].index5 = index5;
            results[i].index6 = index6;
        }

        Console.WriteLine("Если позиция 0, то элемент не найден");
        Console.WriteLine();

        for (int i = 0; i < 4; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Поиск ");
            if (i == 0)
            {
                Console.WriteLine("первого элемента: ");
            }
            else if (i == 1)
            {
                Console.WriteLine("среднего элемента: ");
            }
            else if (i == 2)
            {
                Console.WriteLine("последнего элемента: ");
            }
            else if (i == 3)
            {
                Console.WriteLine("несуществующего элемента: ");
            }
            Console.ResetColor();
            Console.WriteLine($"В LinkedList<LorryCar>: {results[i].timeInLinkedListLorryCar / count}. \tЭлемент находится в позиции {results[i].index1 + 1} из 1000");
            Console.WriteLine($"В LinkedList<string>: {results[i].timeInLinkedListString / count}. \tЭлемент находится в позиции {results[i].index2 + 1} из 1000");
            Console.WriteLine($"В SortedDictionary<Car, LorryCar> по ключу: {results[i].timeInSortedDictionaryCarLorryCarKey / count}. \tЭлемент находится в позиции {results[i].index3 + 1} из 1000");
            Console.WriteLine($"В SortedDictionary<Car, LorryCar> по значению: {results[i].timeInSortedDictionaryCarLorryCarValue / count}. \tЭлемент находится в позиции {results[i].index4 + 1} из 1000");
            Console.WriteLine($"В SortedDictionary<string, LorryCar> по ключу: {results[i].timeInSortedDictionaryStringLorryCarKey / count}. \tЭлемент находится в позиции {results[i].index5 + 1} из 1000");
            Console.WriteLine($"В SortedDictionary<string, LorryCar> по значению: {results[i].timeInSortedDictionaryStringLorryCarValue / count}. \tЭлемент находится в позиции {results[i].index6 + 1} из 1000");
            Console.WriteLine();
        }
    }
}