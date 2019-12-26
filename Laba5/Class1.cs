using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    struct Log
    {
        public DateTime Time;
        public string Act;
        public string Str;

    }
    public enum TYPE : byte
    {
        Р = 1,
        РБП,
        К

    }
    struct Restaraunts
    {
        public string gr;
        public string Heading;
        public string reductions;
        public string name;
        public string kind;
        public string address;
        public string Rating;
        public TYPE KIND;
    }
    class Program
    {
        static void Main(string[] args)
        {
            const int NameAlignment = -98;
            const int BorN = -33;
            const int BorK = -10;
            const int BorA = -42;
            const int BorR = -10;
            Restaraunts[] res = new Restaraunts[50];
            Restaraunts restaraunts;
            restaraunts.gr = new string('_', 100);
            restaraunts.Heading = $"|{"Рестраны и Кафе",NameAlignment}|";
            restaraunts.name = $"|{"Название",BorN}|";
            restaraunts.kind = $"{"Вид",BorK}|";
            restaraunts.address = $"{"Адресс",BorA}|";
            restaraunts.Rating = $"{"Рейтинг",BorR}|";
            restaraunts.reductions = $"|{"Перечисляемый тип:Р–ресторан,РБП–ресторан быстрого питания,К–кафе",NameAlignment}|";
            restaraunts.KIND = TYPE.К;
            res[0] = restaraunts;

            restaraunts.gr = new string('_', 100);
            restaraunts.name = $"|{"Пафос",BorN}|";
            
            restaraunts.KIND = TYPE.Р;
            restaraunts.address = $"{"Ул.Артема, 300а",BorA}|";
            restaraunts.Rating = $"{"9",BorR}|";
            res[1] = restaraunts;
            Console.WriteLine(res[1].KIND);
            restaraunts.gr = new string('_', 100);
            restaraunts.name = $"|{"Челентано",BorN}|";
            restaraunts.kind = $"{"РБП",BorK}|";
            restaraunts.address = $"{"Бул.Пушкина, 510",BorA}|";
            restaraunts.Rating = $"{"8",BorR}|";

            res[2] = restaraunts;
            restaraunts.gr = new string('_', 100);
            restaraunts.name = $"|{"Вкусняшка",BorN}|";
            restaraunts.kind = $"{"К",BorK}|";
            restaraunts.address = $"{"Просп.Ильича, 320",BorA}|";
            restaraunts.Rating = $"{"6",BorR}|";
            res[3] = restaraunts;

            int f = 3;
            int d = 0;
            Log[] log = new Log[50];
            Log enter;
            enter.Time = DateTime.Now;
            enter.Act = " ";
            enter.Str = " ";

            String prompt = "1 – Просмотр таблицы\n2 – Добавить запись\n3 – Удалить запись\n4 – Обновить запись\n5 – Поиск записей\n6 – Просмотреть лог\n7 - Выход";
            Console.WriteLine(prompt);
            int x = int.Parse(Console.ReadLine());
            for (int y = x; y != 7;)
            {
                if (y == 1)
                {

                    for (int i = 0; i < f + 1; i++)
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("{0}\n{1}\n{0}\n{2}{3}{4}{5}\n{0}", res[i].gr, res[i].Heading, res[i].name, res[i].kind, res[i].address, res[i].Rating);
                            continue;
                        }
                        Console.WriteLine("{0}{1}{2}{3}\n{4}", res[i].name, res[i].kind, res[i].address, res[i].Rating, res[i].gr);
                        if (i == f) { Console.WriteLine("{0}\n{1}", res[0].reductions, res[i].gr); }
                    }
                }

                if (y == 2)
                {
                    f += 1;
                    enter.Time = DateTime.Now;
                    enter.Act = "Добавлена запись ";
                    restaraunts.gr = new string('_', 100);
                    Console.WriteLine("Введите название:");
                    string r = Console.ReadLine();
                    enter.Str = '"' + r + '"';
                    restaraunts.name = $"|{r,BorN}|";
                    Console.WriteLine("Введите вид:");
                    r = Console.ReadLine();
                    restaraunts.kind = $"{r,BorK}|";
                    Console.WriteLine("Введите адрес:");
                    r = Console.ReadLine();
                    restaraunts.address = $"{r,BorA}|";
                    Console.WriteLine("Введите рейтинг:");
                    r = Console.ReadLine();
                    restaraunts.Rating = $"{r,BorR}|";
                    res[f] = restaraunts;
                    log[d] = enter;
                    d += 1;
                }

                if (y == 3)
                {


                    Console.WriteLine("Какую запись вы хотите удалить:");
                    int index = int.Parse(Console.ReadLine());
                    if (index > f || index < 0) { continue; }
                    enter.Time = DateTime.Now;
                    enter.Act = "Удалена запись";
                    enter.Str = '"' + res[index].name.Trim('|').Trim(' ') + '"';
                    log[d] = enter;
                    Restaraunts[] temp = new Restaraunts[res.Length - 1];
                    for (int j = 0; j < temp.Length; j++)
                    {
                        temp[j] = res[j];
                        if (index - 1 < j)
                        {
                            temp[j] = res[j + 1];
                            res[j] = temp[j];
                        }
                    }
                    f -= 1;
                    d += 1;
                }

                if (y == 4)
                {
                    enter.Time = DateTime.Now;

                    Console.WriteLine("Какую запись вы хотите обновить:");

                    int t = int.Parse(Console.ReadLine());
                    enter.Act = "Обновление записи ";
                    enter.Str = '"' + res[t].name.Trim('|').Trim(' ') + '"';
                    if (t > f || t < 0) { continue; }
                    restaraunts.gr = new string('_', 100);
                    Console.WriteLine("Введите название:");
                    string r = Console.ReadLine();
                    restaraunts.name = $"|{r,BorN}|";
                    Console.WriteLine("Введите вид:");
                    r = Console.ReadLine();
                    restaraunts.kind = $"{r,BorK}|";
                    Console.WriteLine("Введите адрес:");
                    r = Console.ReadLine();
                    restaraunts.address = $"{r,BorA}|";
                    Console.WriteLine("Введите рейтинг:");
                    r = Console.ReadLine();
                    restaraunts.Rating = $"{r,BorR}|";
                    res[t] = restaraunts;
                    d += 1;
                }

                if (y == 5)
                {

                    Console.WriteLine("По какому фильтру искать:\n1 - По виду\n2 - По рейтингу");
                    int w = int.Parse(Console.ReadLine());
                    if (w == 1)
                    {
                        Console.WriteLine("Выберите вид заведения:\n1 - Ресторан\n2 - Ресторан быстрого питания\n3 - Кафе");
                        int u = int.Parse(Console.ReadLine());
                        for (int j = 0; j < f + 1; j++)
                        {
                            if (u == 1)
                            {
                                if (res[j].kind == $"{"Р",BorK}|")
                                {
                                    string e = res[j].name.Trim('|');
                                    Console.WriteLine("По вышему поиску:{0}", e);
                                    Console.WriteLine();
                                }
                            }
                            if (u == 2)
                            {
                                if (res[j].kind == $"{"РБП",BorK}|")
                                {
                                    string e = res[j].name.Trim('|');
                                    Console.WriteLine("По вышему поиску:{0}", e);
                                    Console.WriteLine();
                                }
                            }
                            if (u == 3)
                            {
                                if (res[j].kind == $"{"К",BorK}|")
                                {
                                    string e = res[j].name.Trim('|');
                                    Console.WriteLine("По вышему поиску:{0}", e);
                                    Console.WriteLine();
                                }
                            }

                        }
                    }
                    else if (w == 2)
                    {
                        Console.WriteLine("Выберите по какому рейтингу:\n1 - Самый высокий\n2 - Самый низкий\n3 - По своему рейтингу");
                        int u = int.Parse(Console.ReadLine());
                        if (u == 1)
                        {
                            int[] R = new int[f];
                            for (int j = 0; j < f; j++)
                            {
                                string g = res[j + 1].Rating.Trim('|');
                                R[j] = int.Parse(g);

                            }
                            string h = res[max(R)].name.Trim('|');
                            Console.WriteLine("По вашему поиску:{0}", h);
                            Console.WriteLine();
                        }
                        if (u == 2)
                        {
                            int[] R = new int[f];
                            for (int j = 0; j < f; j++)
                            {
                                string g = res[j + 1].Rating.Trim('|');
                                R[j] = int.Parse(g);

                            }
                            string h = res[min(R)].name.Trim('|');
                            Console.WriteLine("По вашему поиску:{0}", h);
                            Console.WriteLine();
                        }
                        if (u == 3)
                        {
                            Console.WriteLine("Введите ваш рейтинг");
                            int k = int.Parse(Console.ReadLine());
                            bool c = true;
                            for (int j = 0; j < f; j++)
                            {
                                int n = int.Parse(res[j + 1].Rating.Trim('|'));
                                if (k == n)
                                {
                                    c = false;
                                    Console.WriteLine("По вашему поиску:{0}", res[j + 1].name.Trim('|'));
                                    Console.WriteLine();
                                }

                            }
                            if (c)
                            {
                                Console.WriteLine("Заведения с таким рейтингом нет");
                            }

                        }
                    }
                    else { continue; }
                    d += 1;
                }

                if (y == 6)
                {
                    DateTime[] T = new DateTime[d];
                    for (int j = 0; j < d; j++)
                    {
                        T[j] = log[j].Time;
                        Console.WriteLine(log[j].Time.ToLongTimeString() + " - " + log[j].Act + " " + log[j].Str);
                    }
                    time(T, d);
                }
                Console.WriteLine(prompt);
                y = int.Parse(Console.ReadLine());

            }
        }

        static int min(int[] arr1)
        {
            int num1 = 0;
            int min = arr1[0];
            for (int i = 0; i < arr1.Length; i++)
            {

                if (min > arr1[i])
                {
                    num1 = i + 1;
                    min = arr1[i];
                }
            }
            return num1;
        }
        static int max(int[] arr2)
        {
            int num2 = 0;
            int max = -1;
            for (int i = 0; i < arr2.Length; i++)
            {
                if (max < arr2[i])
                {
                    num2 = i + 1;
                    max = arr2[i];
                }
            }
            return num2;
        }
        static void time(DateTime[] arr3, int x)
        {
            TimeSpan Diff = new TimeSpan(00, 00, 00);
            for (int i = 0; i < x; i++)
            {
                if (i + 1 == x) { continue; }
                if (Diff < arr3[i + 1].Subtract(arr3[i]))
                {
                    Diff = arr3[i + 1].Subtract(arr3[i]);

                }

            }
            Console.WriteLine(Diff.ToString(@"hh\:mm\:ss") + " - Самый долгий период бездействия пользователя");
        }

    }
}
