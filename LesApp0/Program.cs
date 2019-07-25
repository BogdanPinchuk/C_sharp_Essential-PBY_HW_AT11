using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення списку
            List<int> list = new List<int>();

            Show("\n\tПісля створення колекції:");
            Console.WriteLine("\n\t" + list.ToString());
            list.ShowInfo();

            // тестування додавання елементів
            Show("\n\tДодаємо 2 елементи:");
            list.Add(0);
            list.Add(1);
            Console.WriteLine("\n\t" + list.ToString());
            list.ShowInfo();

            Show("\n\tДодаємо 6 елементів:");
            list.AddRange(2, 3, 4, 5, 6, 7);
            Console.WriteLine("\n\t" + list.ToString());
            list.ShowInfo();

            Show("\n\tДодаємо 10 елементів:");
            list.AddRange(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
            Console.WriteLine("\n\t" + list.ToString());
            list.ShowInfo();

            Show("\n\tВидаляємо 4 елементи по значенню:");
            for (int i = 0; i < 4; i++)
            {
                list.Remove(i);
            }
            Console.WriteLine("\n\t" + list.ToString());
            list.ShowInfo();

            Show("\n\tВидаляємо 2 останні елементи по індексу:");
            for (int i = 0; i < 2; i++)
            {
                list.RemoveAt(list.Count - 1);
            }
            Console.WriteLine("\n\t" + list.ToString());
            list.ShowInfo();

            Show("\n\tКонвертуємо дані в масив:");
            var masiv = list.ToArray();
            Console.WriteLine("\n\tТип масива: " + masiv.GetType().Name);

            Show("\n\tСпроба звернутися до індексу -5:");
            list[-5] = 0;

            Show("\n\tСпроба звернутися до елемента по значенню 10:");
            Console.WriteLine("\n\t" + list.IndexOf(10));

            Show("\n\tСпроба звернутися до елемента по значенню 5:");
            Console.WriteLine("\n\t" + list.IndexOf(3));
            Console.WriteLine("\t" + list.Contains(3));

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Зміна кольору сповіщення
        /// </summary>
        private static void Show(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
