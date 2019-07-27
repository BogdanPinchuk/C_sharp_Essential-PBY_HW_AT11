using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp4
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення колекції
            List<string> list = new List<string>();

            // заповнення колекції
            Console.WriteLine("\n\tВведіть 5 слів:");

            // занесення слів у список
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"\n\tВведіть {i + 1} слово: ");
                // занесення в список слів
                list.Add(Console.ReadLine().ToLower());
            }





            // repeat
            DoExitOrRepeat();
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

        /// <summary>
        /// Алфавіти
        /// </summary>
        static class Alphabets
        {
            #region створення алфавітів
            // звичайно, якби не були перемішані укр і рос букви в юнікоді,
            // то простіше б було задатися діапазоном чисел в яких лежать букви,
            // і через каст знаходити нумерацію введеної букви і находити чий це алфавіт
            // а в такому разі просто записуємо малі букви і шукатимемо в них відповідність
            /// <summary>
            /// Український алфавіт
            /// </summary>
            public static readonly string abUA = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя'";   // 33
            /// <summary>
            /// Російський алфавіт
            /// </summary>
            public static readonly string abRU = "абвгдеёжзийклмнопрстуфхцчшъыьэюя";     // 21
            /// <summary>
            /// Англійський алфавіт
            /// </summary>
            public static readonly string abEN = "abcdefhijklmnopqrsyuvwxyz";            // 26
            // смислу вводити великі букви немає, + це б збільлило час обробки в 2 рази,
            // хоча треба протестувати на швидкість коли є і великі букви і коли буква переводиться в один із регістрів 
            #endregion
        }

    }
}
