using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;

class Program
{
    static string lineLong  = new string('-', 150);
    static int CorrectInputInt(int left, int right) //Уже стандартная функция, чтобы вводить целое цисло в заддных границах
    {
        Console.Write($"Введите целое число от {left} до {right}: ");
        string input = Console.ReadLine();
        int number;
        bool numberIsCorrect = int.TryParse(input, out number);
        while (!numberIsCorrect || !((left <= number) && (number <= right)))
        {
            Console.WriteLine($"Ошибка. Вам необходимо ввести целое число от {left} до {right}");
            Console.Write($"Введите целое число от {left} до {right}: ");
            input = Console.ReadLine();
            numberIsCorrect = int.TryParse(input, out number);
        }
        return number;
    }

    static void ShowCars(ArrayList array) //Метод для печати машин из ArrayList
    {
        foreach (Car item in array)
        {
            Console.WriteLine(lineLong);
            if (item is OffRoadCar)
            {
                Console.WriteLine($"Машина №{item.id.Number}. Внедорожник");
            }
            else if (item is PassengerCar)
            {
                Console.WriteLine($"Машина №{item.id.Number}. Легковая машина");
            }
            else if (item is LorryCar)
            {
                Console.WriteLine($"Машина №{item.id.Number}. Грузовик");
            }
            else
            {
                Console.WriteLine($"Машина №{item.id.Number}. Машина базовая");
            }
            Console.WriteLine(lineLong);
            Console.WriteLine(item.ToString());
        }
    }

    static void ShowCars(SortedDictionary<int, Car> sd) //Перегрузка метода. Этот используется для SortedDictionary
    {
        foreach (int key in sd.Keys)
        {
            Car item = sd[key];
            Console.WriteLine(lineLong);
            if (item is OffRoadCar)
            {
                Console.WriteLine($"Машина №{key}. Внедорожник");
            }
            else if (item is PassengerCar)
            {
                Console.WriteLine($"Машина №{key}. Легковая машина");
            }
            else if (item is LorryCar)
            {
                Console.WriteLine($"Машина №{key}. Грузовик");
            }
            else
            {
                Console.WriteLine($"Машина №{key}. Машина базовая");
            }
            Console.WriteLine(lineLong);
            Console.WriteLine(item.ToString());
        }
    }

    static string MostExpensiveORC(ArrayList al) //Метод для нахождения самого дорого внедорожника в ArrayList
    {
        int numberCar = -1;
        int maxCost = -1111111111;
        foreach (Car item in al)
        {
            if (item is OffRoadCar)
            {
                if (item.Cost > maxCost)
                {
                    maxCost = item.Cost;
                    numberCar = item.id.Number;
                }
            }
        }
        string message;
        if (numberCar == -1)
        {
            message = "отсутсвует";
        }
        else
        {
            message = $"Машина №{numberCar}";
        }
        return message;
    }

    static string MostExpensiveORC(SortedDictionary<int, Car> dc) //Метод для нахождения самого дорого внедорожника в SortedDictionary
    {
        int numberCar = - 1;
        int maxCost = -1111111111;
        foreach (int key in dc.Keys)
        {
            Car item = dc[key];
            if (item is OffRoadCar)
            {
                if (item.Cost > maxCost)
                {
                    maxCost = item.Cost;
                    numberCar = key;
                }
            }
        }
        string message;
        if (numberCar == -1)
        {
            message = "отсутсвует";
        }
        else
        {
            message = $"Машина №{numberCar}";
        }
        return message;
    }

    static int AverageSpeedPassengerCar(ArrayList al) //Метод для нахождения средней максимальной скорости всех легковых автомобилей в ArrayList
    {
        int sum = 0;
        int count = 0;
        foreach (var item in al)
        {
            PassengerCar pc = item as PassengerCar;
            if (pc != null)
            {
                sum += pc.MaxSpeed;
                count += 1;
            }
        };
        if ((count == 0) && (sum == 0))
        {
            count = 1;
        }
        return sum / count;
    }

    static int AverageSpeedPassengerCar(SortedDictionary<int, Car> dc) //Метод для нахождения средней максимальной скорости всех легковых автомобилей в SortedDictionary
    {
        int sum = 0;
        int count = 0;
        foreach (int key in dc.Keys)
        {
            Car item = dc[key];
            PassengerCar pc = item as PassengerCar;
            if (pc != null)
            {
                sum += pc.MaxSpeed;
                count += 1;
            }
        };
        if ((count == 0) && (sum == 0))
        {
            count = 1;
        }
        return sum / count;
    }

    static long SumCostAllCar(ArrayList al) //Метод для нахождения суммарной стоимости всех автомобилей в ArrayList
    {
        long sum = 0;
        foreach (Car item in al)
        {
            sum += item.Cost;
        };
        return sum;
    }

    static long SumCostAllCar(SortedDictionary<int, Car> dc) //Метод для нахождения суммарной стоимости всех автомобилей в SortedDictionary
    {
        long sum = 0;
        foreach (int key in dc.Keys)
        {
            sum += dc[key].Cost;
        };
        return sum;
    }

    static void Main()
    {
        int numberAnswer = 0;
        string trashAnswer;
        while (numberAnswer != 4)
        {
            Console.Clear();
            Console.WriteLine("1. Задание №1");
            Console.WriteLine("2. Задание №2");
            Console.WriteLine("3. Задание №3");
            Console.WriteLine("4. Завершение работы");
            numberAnswer = CorrectInputInt(1, 4);
            switch (numberAnswer)
            {
                case 1:
                    {
                        Console.Clear();
                        ArrayList cars = new ArrayList(); //Создаём универсальную коллекцию типа ArrayList

                        cars.Add(new Car("Honda", 1974, "White", 32827595, 68, 1)); //Добавляем в неё элементы
                        cars.Add(new Car("Ford", 2013, "Blue", 5010073, 52, 2));
                        cars.Add(new PassengerCar("Ford", 1958, "White", 10006535, 73, 3, 2, 148));
                        cars.Add(new PassengerCar("Ford", 1976, "Brown", 1914537, 123, 4, 2, 370));
                        cars.Add(new PassengerCar("Honda", 1990, "White", 2005231, 90, 5, 4, 300));
                        cars.Add(new OffRoadCar("Volkswagen", 2020, "Brown", 27257576, 197, 6, 1, 936, false, "Dirt"));
                        cars.Add(new OffRoadCar("Volkswagen", 2005, "Orange", 1935523, 150, 7, 2, 800, false, "Sand"));
                        cars.Add(new LorryCar("Nissan", 1971, "Orange", 29121623, 7, 8, 204)); //Четыре одинаковых грузовика, чтобы потом привести пример удаления нескольких элементов
                        cars.Add(new LorryCar("Nissan", 1971, "Orange", 29121623, 7, 8, 204));
                        cars.Add(new LorryCar("Nissan", 1971, "Orange", 29121623, 7, 8, 204));
                        cars.Add(new LorryCar("Nissan", 1971, "Orange", 29121623, 7, 8, 204));
                        cars.Add(new LorryCar("Honda", 1972, "Grey", 10375098, 57, 9, 244));
                        cars.Add(new LorryCar("Nissan", 2000, "Brown", 1005068, 40, 10, 150));
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Изначальная коллекция: ");
                        Console.ResetColor();
                        ShowCars(cars);
                        //Удаление может быть по значению и по индексу. Причём удаление по значению происходит только по первому вхождению элемента
                        cars.Remove(cars[0]); //Удаляем первую базовую машину (Базовая машина - это машина без доп. параметров, то есть без уточнения какая именно это машина легковая, грузовая и т.д.)
                        cars.RemoveAt(1); //Удаялем первую легковую машину. Учитываем, что длина массива уменьшилась и индекс уменьшился.

                        LorryCar oFC = new LorryCar("Nissan", 1971, "Orange", 29121623, 7, 8, 204); //Тот самый повторяющийся грузовик

                        while (cars.Contains(oFC))
                        {
                            int ind = cars.IndexOf(oFC);
                            cars.RemoveAt(ind);
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\nКоллекция после удаления некоторых машин: ");
                        Console.ResetColor();
                        ShowCars(cars);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\n\nСамый дорогой внедорожник: {MostExpensiveORC(cars)}"); //Выполняем запросы
                        Console.WriteLine($"Средняя скорость легковых автомобилей: {AverageSpeedPassengerCar(cars)}");
                        Console.WriteLine($"Суммарная стоимость всех автомобилей: {SumCostAllCar(cars)}");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        ArrayList carsClone = new ArrayList(); //Выполняем клонирование

                        foreach (var car in cars)
                        {
                            if (car is OffRoadCar)
                            {
                                carsClone.Add(((OffRoadCar)car).Clone());
                            }
                            else if (car is PassengerCar)
                            {
                                carsClone.Add(((PassengerCar)car).Clone());
                            }
                            else if (car is LorryCar)
                            {
                                carsClone.Add(((LorryCar)car).Clone());
                            }
                            else
                            {
                                carsClone.Add(((Car)car).Clone());
                            }
                        }

                        Console.WriteLine("\n\nПроизводим клонировании коллекции");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nОтсортированная коллекция: ");
                        Console.ResetColor();
                        cars.Sort(); //Производим сортировку
                        ShowCars(cars);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        LorryCar forSearch = new LorryCar("Nissan", 2000, "Brown", 1005068, 40, 10, 150);
                        Console.WriteLine("\n\nИщем грузовик с данными: Nissan, 2000, Brown, 1005068, 40, 10, 150");
                        int index = cars.BinarySearch(forSearch); //Коллекция отсортирована. Можно воспользаваться бинарным поиском
                        if (index >= 0) //Если элемент не найден, то будет -1
                        {
                            Console.WriteLine($"Элемент найден");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден");
                        }
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nКлон коллекции не изменился: ");
                        Console.ResetColor();
                        ShowCars(carsClone); 

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\n\nВведите что-нибудь, чтобы выйти в меню: ");
                        Console.ResetColor();
                        trashAnswer = Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        SortedDictionary<int, Car> cars = new SortedDictionary<int, Car>();
                        cars.Add(1, new Car("Honda", 1974, "White", 32827595, 68, 1)); //Добавляем в неё элементы
                        cars.Add(2,new Car("Ford", 2013, "Blue", 5010073, 52, 2));
                        cars.Add(3, new PassengerCar("Ford", 1958, "White", 10006535, 73, 3, 2, 148));
                        cars.Add(4, new PassengerCar("Ford", 1976, "Brown", 1914537, 123, 4, 2, 370));
                        cars.Add(5, new PassengerCar("Honda", 1990, "White", 2005231, 90, 5, 4, 300));
                        cars.Add(6, new OffRoadCar("Volkswagen", 2020, "Brown", 27257576, 197, 6, 1, 936, false, "Dirt"));
                        cars.Add(7, new OffRoadCar("Volkswagen", 2005, "Orange", 1935523, 150, 7, 2, 800, false, "Sand"));
                        cars.Add(8, new LorryCar("Nissan", 1971, "Orange", 29121623, 7, 8, 204)); 
                        cars.Add(9, new LorryCar("Honda", 1972, "Grey", 10375098, 57, 9, 244));
                        cars.Add(10, new LorryCar("Nissan", 2000, "Brown", 1005068, 40, 10, 150));

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Изначальная коллекция: ");
                        Console.ResetColor();
                        ShowCars(cars);
                        //В словарях обращение и удаление происходит по ключу
                        cars.Remove(1); //Удаляем первую базовую машину
                        cars.Remove(3); //Удаялем первую легковую машину

                        LorryCar oFC = new LorryCar("Nissan", 1971, "Orange", 29121623, 7, 8, 204); 
                        if (cars.ContainsValue(oFC))
                        {
                            cars.Remove(oFC.id.number);
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\nКоллекция после удаления некоторых машин: ");
                        Console.ResetColor();
                        ShowCars(cars);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\n\nСамый дорогой внедорожник: {MostExpensiveORC(cars)}"); //Выполняем запросы
                        Console.WriteLine($"Средняя скорость легковых автомобилей: {AverageSpeedPassengerCar(cars)}");
                        Console.WriteLine($"Суммарная стоимость всех автомобилей: {SumCostAllCar(cars)}");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        SortedDictionary<int, Car> carsClone = new SortedDictionary<int, Car>(); //Выполняем клонирование
                        foreach (var el in cars)
                        {
                            if (el.Value is OffRoadCar)
                            {
                                carsClone.Add(el.Key, (OffRoadCar)((OffRoadCar)el.Value).Clone());
                            }
                            else if (el.Value is PassengerCar)
                            {
                                carsClone.Add(el.Key, (PassengerCar)((PassengerCar)el.Value).Clone());
                            }
                            else if (el.Value is LorryCar)
                            {
                                carsClone.Add(el.Key, (LorryCar)((LorryCar)el.Value).Clone());
                            }
                            else
                            {
                                carsClone.Add(el.Key, (Car)el.Value.Clone());
                            }
                        }
                        Console.WriteLine("\n\nПроизводим клонировании коллекции");
                        Console.WriteLine("Изменим бренд машины №12 исходной коллекции: ");
                        Console.ResetColor();
                        cars[12] = new LorryCar("CHANGED", 2000, "Brown", 1005068, 40, 10, 150);
                        ShowCars(cars);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nКлон коллекции не изменился: ");
                        Console.ResetColor();
                        ShowCars(carsClone);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nСортировку выполнить невозможно, так как SortedDictionary уже и так отсортирован по ключу");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        LorryCar forSearch = new LorryCar("Nissan", 2000, "Brown", 1005068, 40, 10, 150);
                        Console.WriteLine("\n\nИщем грузовик с данными: Nissan, 2000, Brown, 1005068, 40, 10, 150");
                        if (cars.ContainsValue(forSearch))
                        {
                            Console.WriteLine("Элемент найден");
                        }
                        else
                        {
                            Console.WriteLine("Элемет не найден");
                        }
                        
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\n\nВведите что-нибудь, чтобы выйти в меню: ");
                        Console.ResetColor();
                        trashAnswer = Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        //Console.WriteLine("Необходимо количество повторов замеров времени"); //// Пока  не удаляю, может потом пригодиться
                        //int countRepeat = CorrectInputInt(1, 100);
                        int countRepeat = 100; //Количество повторов замеров времени
                        TestCollections TC = new TestCollections(1000);
                        TC.Search(countRepeat);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\n\nВведите что-нибудь, чтобы выйти в меню: ");
                        Console.ResetColor();
                        trashAnswer = Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Завершаем работу");
                        break;
                    }
            }
        }
    }
}




























