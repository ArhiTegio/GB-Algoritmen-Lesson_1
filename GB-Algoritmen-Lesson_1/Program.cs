using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFastDecisions;
using static System.Console;
using System.Reflection;

namespace GB_Algoritmen_Lesson_1
{
    class Program
    {
        static Dictionary<string, Act> dict = new Dictionary<string, Act>
        {
            { "1", new ArithmeticAverage() },
            { "2", new MaxThree() },
            { "3", new MyRendom() },
            { "4", new AutomorphicIs() },
        };

        static void Main(string[] args)
        {
            var arrayNumForOnlyNum = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8' };

            var ex = new Extension();
            var q = new Questions();
            var n = "";
            WriteLine("С# - Алгоритмы и структуры данных. Задание 1.11-14");
            WriteLine("Кузнецов");
            while (n != "0")
            {
                WriteLine("Введите номер интересующей вас задачи:" + Environment.NewLine +
                    "1. С клавиатуры вводятся числа, пока не будет введён 0. Подсчитать среднее арифметическое всех положительных чётных чисел, оканчивающихся на 8." + Environment.NewLine +
                    "2.Написать функцию нахождения максимального из трёх чисел." + Environment.NewLine +
                    "3. * Написать функцию, генерирующую случайное число от 1 до 100: " + Environment.NewLine +
                    "a.С использованием стандартной функции rand()." + Environment.NewLine +
                    "b.Без использования стандартной функции rand()." + Environment.NewLine +
                    "4. * Автоморфные числа.Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата.Например, 25 \\ :sup: '2' = 625.Напишите программу, которая получает на вход натуральное число N и выводит на экран все автоморфные числа, не превосходящие N." + Environment.NewLine +
                    "0. Нажмите для выхода из программы.");

                n = q.Question<int>("Введите ", new HashSet<char>() { '0', '1', '2', '3', '4' }, true);
                if (n == "0") break;
                dict[n].Work();
            }

            Console.ReadKey();
        }
    }

    abstract class Act
    {
        public abstract void Work();
    }

    class AutomorphicIs: Act
    {
        public override void Work()
        {                        
            if (Automorphic(long.Parse((new Questions()).Question<int>("Введите число:", new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }, true))))
                WriteLine($"Число является автоморфным { Environment.NewLine }");
            else
                WriteLine($"Число неявляется автоморфным { Environment.NewLine }");
        }

        public bool Automorphic(long number) => ((number * number) % Pow10(getCountForNumber(number)) == number);

        public long Pow10(long number)
        {
            long res = 1;
            while (number-- != 0) res *= 10;
            return res;
        }

        long getCountForNumber(long number)
        {
            long length = 0;
            while (number != 0)
            {
                number /= 10;
                length++;
            }
            return length;
        }
    }

    class MyRendom: Act
    {
        int X = 3;
        int m = 10;
        int a = 5;
        int c = 60;
        Random r = new Random();

        public override void Work()
        {
            WriteLine($"Случайное число с использованием стандартной функции:");
            for (int i = 0; i < 20; i++)
                WriteLine($"{ GetNumber_StandardFunc() }");
            WriteLine($"Случайное число с использованием стандартной функции:");
            for (int i = 0; i < 20; i++)
                WriteLine($"{ GetNumber_MyFunc() }");
            WriteLine($"{ Environment.NewLine }");
        }

        public int GetNumber_StandardFunc() => r.Next();

        public int GetNumber_MyFunc()
        {
            m = DateTime.Now.Millisecond;
            a = DateTime.Now.Millisecond / DateTime.Now.Minute;
            c = (DateTime.Now.Second + DateTime.Now.Millisecond) * DateTime.Now.Millisecond;            
            return X = Abs(Abs(a * X + c) * m);
        }

        int Abs(int x) => x < 0 ? -x : x;
    }

    class MaxThree : Act
    {
        public override void Work()
        { 
            var hash = new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };            
            WriteLine($"Максимальным числом является: { Max(new int[] {int.Parse((new Questions()).Question<int>("Введите 1 число:", hash, true)), int.Parse((new Questions()).Question<int>("Введите 2 число:", hash, true)), int.Parse((new Questions()).Question<int>("Введите 3 число:", hash, true)) })} { Environment.NewLine }");
        }

        public int Max(int[] numbers) => numbers[0] > numbers[1] ? (numbers[0] > numbers[2] ? numbers[0] : numbers[2]) : (numbers[1] > numbers[2] ? numbers[1] : numbers[2]);
    }

    class ArithmeticAverage : Act
    {
        public override void Work()
        {
            var summ = 0;
            var length = 0;
            var number = 1;
            while(true)
            {
                number = int.Parse((new Questions()).Question<int>("Введите число (Для выхода нажмите 0):", new HashSet<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-' }, true));
                if (number == 0) break;
                if(number > 0 && number - (number / 10) * 10 == 8)
                {
                    length++;
                    summ += number;
                }
            }

            WriteLine($"Cреднее арифметическое всех положительных чётных чисел введённых с клавиатуры, оканчивающихся на 8, является: { (double)summ / length } { Environment.NewLine }");
        }
    }
}
