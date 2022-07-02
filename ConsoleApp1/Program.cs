using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        struct Element
        {

            public int Delivery { get; set; }
            public int Value { get; set; }
            public static int FindMinElement(int a, int b)
            {
                if (a > b) return b;
                if (a == b) { return a; }
                else return a;
            }

        }

        static void Main(string[] args)
        {
            bool o = true;
            string s;

            while (o == true)
            {
                try
                {
                    int i = 0;
                    int j = 0;
                    int x = 0;
                    int y = 0;
                    int n;
                    int max = 0;
                    int summa1 = 0;
                    int summa2 = 0;
                    bool check = true;
                    Console.WriteLine("Первоначальное распределение по методу северо-западного угла \n" +
                            " в транспортной задаче с учетом преобразования исходной матрицы \n" +
                            " А в матрицу В по правилу: B = {max(эл) + 1} - А \n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Введите количество поставщиков");
                    n = Convert.ToInt32(Console.ReadLine());
                    int[] a = new int[n];
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Введите количество потребителей");
                    int m = Convert.ToInt32(Console.ReadLine());
                    int[] b = new int[m];
                    Element[,] C = new Element[n, m];
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine();
                    while (check == true)
                    {
                        summa1 = 0;
                        summa2 = 0;
                        Console.WriteLine("Введите численные параметры поставщиков");
                        for (i = 0; i < a.Length; i++)
                        {
                            x = i + 1;
                            Console.Write($"Поставщик {x}: ");
                            a[i] = Convert.ToInt32(Console.ReadLine());
                            summa1 += a[i];
                        }
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine();
                        Console.WriteLine("Введите численные параметры потребителей");
                        for (j = 0; j < b.Length; j++)
                        {
                            y = j + 1;
                            Console.Write($"Потребитель {y}: ");
                            b[j] = Convert.ToInt32(Console.ReadLine());
                            summa2 += b[j];
                        }
                        if (summa1 == summa2)
                        {
                            check = false;
                        }
                        else if (summa1 != summa2)
                        {
                            check = true;
                        }
                        Console.Clear();
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Введите элементы матриц: ");
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            Console.Write("a[{0},{1}] = ", i, j);
                            Console.ForegroundColor = ConsoleColor.Red;
                            C[i, j].Value = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();

                        }
                    }
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            if (max <= C[i, j].Value)
                            {
                                max = C[i, j].Value;
                            }
                        }
                    }
                    max += 1;
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            if (C[i, j].Value != 0)
                            {
                                C[i, j].Value = max - C[i, j].Value;
                            }
                        }
                    }
                    i = j = 0;
                    // действуем по алгоритму 

                    // идём с северо-западного элемента 
                    // если a[i] = 0 i++
                    // если b[j] = 0 j++
                    //  если a[i],b[j] = 0 то i++,j++;
                    // доходим до последнего i , j
                    while (i < n && j < m)
                    {
                        try
                        {
                            if (a[i] == 0) { i++; }
                            if (b[j] == 0) { j++; }
                            if (a[i] == 0 && b[j] == 0) { i++; j++; }
                            C[i, j].Delivery = Element.FindMinElement(a[i], b[j]);
                            a[i] -= C[i, j].Delivery;
                            b[j] -= C[i, j].Delivery;
                        }
                        catch { }
                    }
                    Console.WriteLine("\n Итоговая матрица: \n");
                    //выводим массив на экран
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            if (C[i, j].Delivery != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("{0}", C[i, j].Value);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("({0})", C[i, j].Delivery); Console.ResetColor();
                            }
                            else
                                Console.Write("{0}({1})", C[i, j].Value, C[i, j].Delivery);
                        }
                        Console.WriteLine();
                    }
                    int ResultFunction = 0;
                    //считаем целевую функцию
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++) { ResultFunction += (C[i, j].Value * C[i, j].Delivery); }
                    }

                    Console.WriteLine(" F = {0}", ResultFunction);
                    i = 0;
                    j = 0;
                    int[] u = new int[n];
                    int[] v = new int[m];
                    Console.WriteLine("Хотите продолжать работу?(да/нет)");
                    s = Convert.ToString(Console.ReadLine());
                    if (s == "да")
                    {
                        o = true;
                        Console.Clear();
                    }
                    else if (s == "нет")
                    {
                        o = false;
                        Environment.Exit(0);
                    }
                    else { Environment.Exit(0); }
                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!!Ошибка!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}