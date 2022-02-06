using System;
using System.Collections.Generic;
using System.Linq;





namespace Homework1
{
    public class Program
    {
        /*Привет, Юра! Данная программа, а точнее код является настоящим бредом сумасшедшего.
        Я реализовал её после 1 семинара, поэтому огромного количества методов, и тем более ООП тут нет.
        Да и методов тут особо не выдумаешь, по крайней мере я так вижу.
        Менять на ООП не стал, так как пришлось бы менять половину кода и его логику. А это жалко да и я человек ленивый =)
        Но задание мне понравилось, нашёл для себя такую интересную штуку как goto, и решил что буду
        делать это ДЗ через неё, вместо while(true), хотя частично ради разнообразия и её тоже.
        Что я реализовал помимо самого ДЗ:
        - Для каждого ввода пользователя реализовал защиту от неправильного ввода (использовал try catch + доп.условия, всё время забываю спросить почему лучше не злоупотреблять этим)
        - Использовал метод Random, чтобы сделать мини-рулетку пользователю
        - Поменял все цвета, чтобы было удобнее и приятнее смотреть на текст в консоле
        - Использовал Console.Beep чтобы сыграть мелодию для победы в лотерее
        Для каждого элемента кода я оставил немного комментариев, иначе трезвым тут не разобраться
        Также РЕКОМЕНДУЮ РАЗВЕРНУТЬ В ПОЛНЫЙ ЭКРАН консоль хотя бы 1 раз при каждом запуске, а то цвета фона и текста будут забагованными!

                                                                                                */

        static Random rnd = new Random(); //Random для рулетки

        public enum tembr                //частота звуков
        {
            A = 300,
            B = 200,
            C = 150,
            D = 100,
            F = 50,
            E = 230,
        }

        public enum duration        //длительность проигрыша мелодии
        {
            dolgo = 1000,
            sredne = 500,
            malo = 250,
            ochenmalo = 100,
            pauza = 0,

        }

        static void pobedaVLotereeSong()        //метод для проигрыша звуков
        {
            for (int i = 1; i < 4; i++)
            {
                Console.Beep((int)tembr.B, (int)duration.malo);
                Console.Beep((int)tembr.C, (int)duration.ochenmalo);
                Console.Beep((int)tembr.A, (int)duration.malo);
            }

        }




        static void viigranniemesta(int[,] arr)  //метод который считывает матрицу (в данном случае матрица для выйграшных билетов в лотерее)
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Это ваши выйгранные билеты! Подойдите к кассе чтобы уточнить выйгрыш!");
            Console.ForegroundColor = ConsoleColor.White;

            for (int n = 0; n < arr.GetLength(0); n++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    Console.Write("{0} ", arr[n, k]);

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }






        static void zanyatiemesta1(int[,] arr)  //метод который считывает матрицу и выводит её (в данном случае занятость мест)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Занятость зала: 1 - Место занято 0 - Место не занято");

            for (int n = 0; n < arr.GetLength(0); n++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    Console.Write("{0} ", arr[n, k]);

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }




        static void pricesofmesta(int[,] arr)   // Метод с той же логикой что и верхний, только с ценами.
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Цены на места");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0} ", arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }



        static void exitFromProgram()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Чтобы выйти из программы нажмите клавишу Enter! Если не хотите - Любую другую");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                System.Environment.Exit(0);
            }
        }




        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkBlue;    //Поменял цвета фона и самого текста (как и буду делать в дальнейшем)
            Console.ForegroundColor = ConsoleColor.Yellow;

            List<int> boughttickets = new List<int>(); //Ввёл динам.массив, чтобы давать пользователю информацию о купленных билетах
            List<int> boughtticketssave = new List<int>();





        ryad:                                           //Штуки, по типу ryad: являются чек-поинтами для goto. Используя их я могу вернуться к ним с любой части кода                                                        
                                                        //Некий аналог while(true)
            Console.Write("Рядов и длина рядов: ");     //Тут типичный запрос у пользователя данных матрицы и защита от ввода
            int x, y;                                   //Дальнейшее комментирование чек-поинтов делать не буду, я думаю ты и так всё прекрасно понимаешь

            try
            {
                var razmerRyadaIKolichestvo = Console.ReadLine()?.Split().Select(int.Parse).ToList();
                if (razmerRyadaIKolichestvo.Count > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Извините, введите количество рядов и их длину ДВУМЯ цифрами через пробел");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto ryad;
                }

                x = razmerRyadaIKolichestvo[0];
                y = razmerRyadaIKolichestvo[1];
                if (x <= 0 || y <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите положительные числа");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto ryad;
                }


            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите адекватное число");
                Console.ForegroundColor = ConsoleColor.Yellow;
                goto ryad;
            }


            Console.WriteLine();

            Console.WriteLine("Заполни цены на зал");       //Далее заполняем цены на зал, тоже ничего особенного
            int[,] cinema = new int[x, y];
            string[] ryadkinoprices;

            for (int i = 0; i < x; ++i)
            {
            revvod:

                ryadkinoprices = (Console.ReadLine()).Split(' ');
                if (ryadkinoprices.Length > y)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы вводите цены на бОльшее количество мест в ряду, повторите ввод");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto revvod;
                }




                for (int j = 0; j < y; j++)
                {

                    try
                    {
                        cinema[i, j] = Convert.ToInt32(ryadkinoprices[j]);
                        if (cinema[i, j] < 0)
                        {
                            Console.WriteLine("Введите полож.значение");
                            goto revvod;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ваша попытка неправильная");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto revvod;
                    }
                }

            }
            Console.WriteLine();

            int[,] cinemalottery = new int[x, y]; //Матрица для того, чтобы запоминать какое место выйграли в лотерее

            //Затем выводим пользователю информацию о всех данных и просим зарегистрироваться

            pricesofmesta(cinema);
            int[,] cinemaPlaces = new int[x, y];
            zanyatiemesta1(cinemaPlaces);
            Console.WriteLine();


            //Сам метод регистрации очень казуален. Просто не хотел хардкодить пароль в программе
            //По-хорошему GoogleFireBase думал использовать, но тогда навыков было очень мало да и ООП я не знал
            Console.WriteLine("***РЕГИСТРАЦИЯ***");
            Console.WriteLine();
            Console.WriteLine("***ВВЕДИТЕ ВАШ ЛОГИН***");
            string login = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("***Логин. После регистрации повторно введите логин***");

            while (true)
            {
                string login1 = Console.ReadLine();
                if (login1 == login)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("***Ваш Логин верный***");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Ваш Логин неверный, введите повторно:***");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }


            }
            Console.WriteLine();
            Console.WriteLine("***Введите ваш пароль***");
            string password = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("***Пароль успешно введён. После регистрации повторно введите пароль***");
            Console.ForegroundColor = ConsoleColor.Yellow;

            while (true)        //while(true), про который я говорил
            {
                string vvod = Console.ReadLine();
                if (vvod == password)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("***Ваш пароль верный***");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Ваш пароль неверный, введите повторно:***");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }


            }

            Console.WriteLine("***После успешной регистрации авторизируйтесь:***");
            Console.WriteLine();
            Console.WriteLine("***Введите ваш логин и пароль БЕЗ ПРОБЕЛОВ одним сообщением:***");
            string summadannih = login + password;
            while (true)
            {
                string summadannih2 = Console.ReadLine();
                if (summadannih == summadannih2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("***Вы успешно авторизовались***");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Неверно введены логин и пароль, повторите попытку:***");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            Console.WriteLine();
            Console.WriteLine("***Вы успешно авторизовались***");
            Console.WriteLine();
        vibor0:                                                                //Как и говорил vibor0: , vibor1: и так далее это чек-поинты

            Console.WriteLine("Пожалуйста, выберите кем вы являетесь. Администратор 1, Пользователь 2");    //Любые vibor, choice и цифра рядом с ними не имеют
            int vibor1;                                                                                     //особого значения, они являются просто переменными условия(выбора пользователя)
            int balance = 0;


        vibor1:
            try
            {
                vibor1 = Convert.ToInt32(Console.ReadLine());
                if (vibor1 != 1 & vibor1 != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пожалуйста, введите либо 1, либо 2");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto vibor0;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введите адекватное число:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                goto vibor1;
            }


            if (vibor1 == 1)            //Поле администратора
            {


                Console.WriteLine("Для того, чтобы зайти как администратор, введите пароль, который указали при регистрации!");
            proverkaparolya:
                string proverkaadmina = Console.ReadLine();
                if (proverkaadmina != password)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пароль неверный, введите его повторно:");            //Проверяем пароль
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto proverkaparolya;
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Добро пожаловать, администратор" + " " + login);
                Console.ForegroundColor = ConsoleColor.Yellow;

            menu2:
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Введите 1: Количество проданных мест" + '\t' + "2: Количество свободных мест" + '\t' + "3: Выручка за все проданные билеты" + '\t' + "4: Изменить цену места" + '\t' + "5: Выйти к выбору роли" + '\t' + "6 - выход из программы");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int vibor10;                                                                 //очередная переменная условия
                try
                {
                    vibor10 = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите число нормально");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu2;
                }
                if (vibor10 == 1)                                                           //кол-во проданных мест
                {
                    int amoutsoldtickets;
                    amoutsoldtickets = boughtticketssave.Count();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Количество проданных мест:" + " " + amoutsoldtickets);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu2;
                }
                else if (vibor10 == 2)                                              //кол-во свободных мест
                {
                    int counter = 0;
                    zanyatiemesta1(cinemaPlaces);
                    for (int n = 0; n < cinemaPlaces.GetLength(0); n++)
                    {
                        for (int k = 0; k < cinemaPlaces.GetLength(1); k++)
                        {
                            if (cinemaPlaces[n, k] == 0)
                            {
                                counter = counter + 1;
                            }


                        }
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Количество свободных мест" + " " + counter);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu2;
                }
                else if (vibor10 == 3)                                      //выручка от всех проданных билетов
                {
                    int counter2 = 0;
                    foreach (var item in boughtticketssave)
                    {
                        counter2 += item;
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Выручка от всех проданных на данный момент билетов" + " " + counter2);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu2;
                }
                else if (vibor10 == 4)                                  //изменить цену любого места
                {
                    pricesofmesta(cinema);
                    Console.WriteLine();
                    Console.WriteLine("Введите пожалуйста ряд места, цену которого вы хотите изменить");
                ryad11:
                    int ryad10, mesto10, newprice;
                    try
                    {
                        ryad10 = Convert.ToInt32(Console.ReadLine());
                        if (ryad10 > x || ryad10 <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("В матрице меньше рядов / они не могут быть отрицательными или равны 0");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto ryad11;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число нормально");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto ryad11;
                    }
                mesto11:
                    Console.WriteLine();
                    Console.WriteLine("Введите пожалуйста место, чью цену вы хотите изменить:");
                    try
                    {
                        mesto10 = Convert.ToInt32(Console.ReadLine());
                        if (mesto10 > y || mesto10 <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("В матрице меньше мест / они не могут быть отриц или равны 0");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto mesto11;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число нормально");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto mesto11;

                    }
                newprice:
                    Console.WriteLine("Введите пожалуйста новую цену места");
                    try
                    {
                        newprice = Convert.ToInt32(Console.ReadLine());
                        if (newprice < 0)
                        {
                            Console.WriteLine("Цена места не может быть отрицательной");
                            goto newprice;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число нормально");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto newprice;
                    }
                    cinema[ryad10 - 1, mesto10 - 1] = newprice;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Цена успешно изменена");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu2;
                }
                else if (vibor10 == 5)          //Выход к выбору роли
                {
                    goto vibor0;
                }
                else if (vibor10 == 6)
                {
                    exitFromProgram();
                    Console.WriteLine();
                    goto menu2;
                }
                else
                {
                    goto menu2;                 //Тоже страховка
                }
            }







            else if (vibor1 == 2)               //Поле пользователя, логика та же самая что и в поле администратора.
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Добро пожаловать, пользователь" + " " + login);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Введите число!");
                Console.WriteLine();
            menu:
                Console.WriteLine("1:Проверить баланс" + '\t' + "2: Пополнить баланс" + '\t' + "3: Цены на места" + '\t' + "4: Занятость мест" + '\t' + "5: Купить место" + '\t' + "6: Посмотреть свои билеты" + '\t' + "\n" + "7: Выйти к выбору роли" + '\t' + "8 - ЛОТЕРЕЯ" + '\t' + "9 - Выход из программы");
                int vibor2 = 0;

                try
                {
                    vibor2 = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите число нормально!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu;

                }


                if (vibor2 == 1)                //Проверить баланс
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Ваш баланс" + " " + balance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu;
                }
                else if (vibor2 == 2)           //Пополнить баланс
                {
                    int add = 0;                    
                    Console.WriteLine("Пополнение баланса");
                    Console.WriteLine();
                addbalance:
                    Console.WriteLine("Напишите, на какую сумму вы хотите пополнить баланс:");
                    try
                    {
                        add = Convert.ToInt32(Console.ReadLine());
                        if (add < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Пополнение баланса не может быть на отрицательную сумму");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto menu;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Укажите адекватное число");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto addbalance;
                    }
                    balance = balance + add;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Состояние баланса:" + " " + balance);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto menu;
                }
                else if (vibor2 == 3)           //Список цен на места (как раз таки методы пошли)
                {
                    pricesofmesta(cinema);
                    goto menu;
                }
                else if (vibor2 == 4)           //Занятость мест (также через метод)
                {
                    zanyatiemesta1(cinemaPlaces);
                    goto menu;
                }
                else if (vibor2 == 5)   //Покупка места пользователем
                {
                    int viborryada, vibormesta, yesno;
                    pricesofmesta(cinema);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Покупка места");
                    Console.WriteLine();
                viborryada1:
                    Console.WriteLine("Введите ряд, начиная сверху");
                    try
                    {
                        viborryada = int.Parse(Console.ReadLine());
                        if (viborryada > x)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("В матрице меньше рядов");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto viborryada1;
                        }

                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите адекватное число");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto viborryada1;
                    }
                vibormesta1:
                    Console.WriteLine();
                    Console.WriteLine("Введите место:");
                    try
                    {
                        vibormesta = int.Parse(Console.ReadLine());
                        if (vibormesta > y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("В ряду меньше мест");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto vibormesta1;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Введите адекватное число");
                        goto vibormesta1;
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Ваше место стоит" + cinema[viborryada - 1, vibormesta - 1]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                yesno1:
                    Console.WriteLine("Вы хотите его купить? 1 - Да, 2 - Нет");
                    Console.WriteLine();
                    try
                    {
                        yesno = Convert.ToInt32(Console.ReadLine());
                        if (yesno != 2 & yesno != 1)
                        {
                            Console.WriteLine("Введите либо 1, либо 2");
                            goto yesno1;
                        }
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число адекватно");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto yesno1;
                    }
                    if (yesno == 1)                     //Если пользователь выбирает опцию "Да" при покупке билета
                    {
                        if (cinemaPlaces[viborryada - 1, vibormesta - 1] == 0)
                        {
                            if (balance >= cinema[viborryada - 1, vibormesta - 1])
                            {
                                balance = balance - cinema[viborryada - 1, vibormesta - 1];
                                boughttickets.Add(cinema[viborryada - 1, vibormesta - 1]);
                                boughtticketssave.Add(cinema[viborryada - 1, vibormesta - 1]);
                                cinemaPlaces[viborryada - 1, vibormesta - 1] = 1;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Вы успешно купили билет");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                goto menu;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Извините, у вас недостаточно денег на балансе");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                goto menu;
                            }



                        }
                        else if (cinemaPlaces[viborryada - 1, vibormesta - 1] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Извините, но это место уже куплено. Выберите другое");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto viborryada1;
                        }

                    }
                    else if (yesno == 2)            //Если нет то улетает в меню
                    {
                        goto menu;
                    }
                    else
                    {
                        goto menu;                  //Доп.защита
                    }

                }


                else if (vibor2 == 6)              //Проверка билетов у пользователя
                {
                    if (boughttickets.Count == 0)
                    {
                        Console.WriteLine("Вы ещё не купили билеты");
                        Console.WriteLine();
                        viigranniemesta(cinemalottery);
                        goto menu;

                    }
                    else
                    {
                        foreach (var item in boughttickets)
                        {
                            Console.WriteLine("Вы купили билет, на стоимость" + " " + item + " " + "рублей");
                        }
                        Console.WriteLine();
                        viigranniemesta(cinemalottery);


                        goto menu;
                    }

                }
                else if (vibor2 == 7)           //Выход к выбору роли (так как ты сказал что считаем что при каждом заходе пользователь становится новым)
                {                               //То я просто зануляю все переменные связанные с пользователем. На данные админа и кинотеатра никак это не влияет. Всё остаётся.
                    balance = 0;
                    boughttickets.Clear();
                    for (int i = 1; i < cinemalottery.GetLength(0); i++)
                    {
                        for (int j = 0; j < cinemalottery.GetLength(1); j++)
                        {
                            cinemalottery[i, j] = 0;
                        }
                    }
                    goto vibor0;

                }
                else if (vibor2 == 8)          //Вот и сама лотерея. Использовал Random. Пользователь выбирает 1 либо 2 и при победе выигрывает рандомное место. Но в целом тут всё описано и так
                {                              //Показалось что в VisualStudio Random на самом деле никакой не рандом, а псевдо-рандом, слишком странно выпадают значения но ладно.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вы зашли в раздел лотереи! Тут вы можете попытать свою удачу!");
                    Console.WriteLine();
                    Console.WriteLine("Сумма ставки будет зависеть от стоимости всех билетов в зале");
                    Console.WriteLine();
                    Console.WriteLine("Она является средним арифметическим всех цен в зале");
                    Console.WriteLine();
                    Console.WriteLine("Угадав число, вы можете выйграть случайное место в зале");
                    Console.WriteLine();
                    Console.WriteLine("В ином случае вы просто потеряете сумму ставки, которая спишется с вашего баланса");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                casinochoice:
                    Console.WriteLine("Вы согласны играть? 1 - Да, 2 - Нет");


                    int vibor666 = 0;

                    try
                    {
                        vibor666 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число нормально!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        goto casinochoice;

                    }
                    if (vibor666 == 1)                  //Тут тоже ничего сверхъестественного. Считаем среднее арифм, проверяем баланс пользователя и т.п
                    {
                        bool allPlacesReserved = true;
                        foreach (var pipka in cinemaPlaces)
                        {                           
                            if (pipka == 0)
                            {
                                allPlacesReserved = false;
                            }                            
                        }
                        if (allPlacesReserved)
                        {
                            Console.WriteLine("Извините, все места уже заняты!");
                            goto menu;
                        }
                        

                        
                        int sumPrices = 0;
                        int kolichestvomest = x * y;
                        int sredneearifm = 0;
                        int rezerv = 0;
                        foreach (var item in cinema)
                        {
                            sumPrices += item;

                        }

                        sredneearifm = sumPrices / kolichestvomest;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Для игры вам потребуется" + " " + sredneearifm + " " + "рублей");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ваш баланс" + " " + balance);
                        if (balance < sredneearifm)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("К сожалению, у вас недостаточно средств для игры в лотерею!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto menu;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Ваша задача - угадать число, которое загадает наш ИИ. Шанс 50 на 50.");
                        rezerv = balance - (balance - sredneearifm);

                        Console.WriteLine();
                        Console.WriteLine("На данный момент ваш баланс:" + " " + balance + "\n" + "Пока мы оставили у себя :) " + sredneearifm + " " + "рублей. На время вашей игры");
                        int zagadka = rnd.Next(1, 3);
                    rechoicecasino:
                        Console.WriteLine();
                        Console.WriteLine("Введите число. Либо 1, Либо 2");
                        int vibor6666 = 0;
                        try
                        {
                            vibor6666 = Convert.ToInt32(Console.ReadLine());
                            
                        }
                        catch
                        {
                            goto rechoicecasino;
                        }
                        if (vibor6666 == 1 & vibor6666 == zagadka)                  //Проверка выйграл ли пользователь или проиграл
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            pobedaVLotereeSong();
                            Console.WriteLine("Поздравляем, вы победили!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                        prizeplace1:
                            int randomX = rnd.Next(1, x + 1);
                            int randomY = rnd.Next(1, y + 1);
                            if (cinemaPlaces[randomX - 1, randomY - 1] == 1)
                            {
                                goto prizeplace1;
                            }

                            cinemaPlaces[randomX - 1, randomY - 1] = 1;
                            Console.WriteLine("Ваше место имеет" + " " + randomX + " " + "ряд и" + " " + randomY + " " + "место!");
                            Console.WriteLine();
                            Console.WriteLine("Ваш баланс" + " " + balance + ".Остаётся прежним! Желаем вам удачи.");
                            cinemalottery[randomX - 1, randomY - 1] = 1;

                            goto menu;


                        }
                        else if (vibor6666 == 2 & vibor6666 == zagadka)         //Проверка выйграл ли пользователь или проиграл
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            pobedaVLotereeSong();
                            Console.WriteLine("Поздравляем, вы выйграли!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        prizeplace2:
                            int randomX = rnd.Next(1, x + 1);
                            int randomY = rnd.Next(1, y + 1);
                            if (cinemaPlaces[randomX - 1, randomY - 1] == 1)
                            {
                                goto prizeplace2;
                            }
                            cinemaPlaces[randomX - 1, randomY - 1] = 1;
                            Console.WriteLine();
                            Console.WriteLine("Ваше место имеет" + " " + randomX + " " + "ряд и" + " " + randomY + " " + "место!");
                            Console.WriteLine();
                            Console.WriteLine("Ваш баланс" + " " + balance + ".Остаётся прежним! Желаем вам удачи.");
                            cinemalottery[randomX - 1, randomY - 1] = 1;
                            goto menu;
                        }
                        else if (vibor6666 != 1 & vibor6666 != 2)           //Проверка выйграл ли пользователь или проиграл
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите число либо 1, либо 2");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            goto rechoicecasino;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;                                             //Проверка выйграл ли пользователь или проиграл
                            Console.WriteLine("К сожалению, вы проиграли! Загаданное число было:" + " " + zagadka);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            balance = balance - rezerv;
                            goto menu;
                        }


                    }
                    else if (vibor666 == 2)         //Если пользователь не хочет играть
                    {
                        goto menu;
                    }
                    else
                    {                                   //Проверка на ввод
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введи число нормально!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }



                }
                else if (vibor2 == 9)       //Выход из программы
                {
                    exitFromProgram();
                    Console.WriteLine();
                    goto menu;


                }
                else
                {
                    goto menu;
                }

            }


        }

    }
}



